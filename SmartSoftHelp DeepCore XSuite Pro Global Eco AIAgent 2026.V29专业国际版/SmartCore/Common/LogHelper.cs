using System;
using System.Collections;
using System.IO;
using System.Text;

namespace Common
{
    /// <summary>
    /// .NET Core 跨平台应用程序日志记录工具类
    /// </summary>
    public static class LogHelper
    {
        /// <summary>
        /// 用于多线程同步的锁对象
        /// </summary>
        private static readonly object logLock = new object();

        /// <summary>
        /// 日志是否启用堆栈跟踪日志(发布正式版建议禁用)
        /// </summary>
        private static bool logStackTrace = true;

        /// <summary>
        /// 获取跨平台的基础日志目录
        /// </summary>
        private static string BaseLogPath => Path.Combine(AppContext.BaseDirectory, "Logs");

        /// <summary>
        /// 记录异常详细日志 (用于 try catch)
        /// </summary>
        /// <param name="ex">
        /// 异常对象
        /// </param>
        public static void WriteError(Exception ex)
        {
            if (ex == null) return;
            string folder = Path.Combine(BaseLogPath, "ErrorLog", "Exception");
            string content = FormatExceptionContent(ex);

            // 异常日志按天归档
            string fileName = $"Exception_{DateTime.Now:yyyyMMdd}.log";
            WriteToFile(folder, fileName, content);
        }

        /// <summary>
        /// 记录常规操作日志
        /// </summary>
        /// <param name="title">
        /// 日志标题
        /// </param>
        /// <param name="message">
        /// 日志内容
        /// </param>
        public static void WriteInfo(string title, string message)
        {
            string folder = Path.Combine(BaseLogPath, "InfoLog");
            string content = FormatCommonContent(title, message);

            // 常规日志按天归档（原代码是精确到毫秒生成一个文件，极易导致文件数量爆炸，这里优化为按天）
            string fileName = $"Info_{DateTime.Now:yyyyMMdd}.log";
            WriteToFile(folder, fileName, content);
        }

        /// <summary>
        /// 记录全局系统错误日志（字符串类型）
        /// </summary>
        /// <param name="title">
        /// 错误标题
        /// </param>
        /// <param name="message">
        /// 错误内容
        /// </param>
        public static void WriteSysError(string title, string message)
        {
            string folder = Path.Combine(BaseLogPath, "ErrorLog", "SysException");
            string content = FormatCommonContent(title, message);

            string fileName = $"SysError_{DateTime.Now:yyyyMMdd}.log";
            WriteToFile(folder, fileName, content);
        }

        /// <summary>
        /// 格式化常规/字符串信息
        /// </summary>
        private static string FormatCommonContent(string title, string message)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("★SmartSoftHelp辅助开发工具★ (.NET Core版)");
            sb.AppendLine("==============================================================================");
            sb.AppendLine($"时间: {DateTime.Now:yyyy年MM月dd日 HH点mm分ss秒ffff毫秒}");
            sb.AppendLine($"【{title}】日志记录：");
            sb.AppendLine("\r\n△△日志开始：\r\n\n");
            sb.AppendLine(message ?? "无内容");
            sb.AppendLine("\r\n△△日志结束.\r\n");
            sb.AppendLine("==============================================================================\r\n");
            return sb.ToString();
        }

        /// <summary>
        /// 格式化异常信息
        /// </summary>
        private static string FormatExceptionContent(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("★SmartSoftHelp辅助开发工具★ (.NET Core版)");
            sb.AppendLine("==============================================================================");
            sb.AppendLine($"时间: {DateTime.Now:yyyy年MM月dd日 HH点mm分ss秒ffff毫秒}");
            sb.AppendLine("【异常日志详细信息】：");
            sb.AppendLine("\r\n★日志开始：\r\n");
            sb.AppendLine($"【异常类型】：{ex.GetType().Name}");
            sb.AppendLine($"【内部异常】：{ex.InnerException?.ToString() ?? "无"}");
            sb.AppendLine($"【异常数据】：{FormatExceptionData(ex.Data)}");
            sb.AppendLine($"【异常来源】：{ex.Source}");
            sb.AppendLine($"【异常信息】：{ex.Message}");

            if (logStackTrace)
            {
                sb.AppendLine($"【堆栈跟踪】：{ex.StackTrace}");
            }

            sb.AppendLine($"【目标方法】：{ex.TargetSite}");
            sb.AppendLine("\r\n★日志结束.\r\n");
            sb.AppendLine("==============================================================================\r\n");
            return sb.ToString();
        }

        /// <summary>
        /// 格式化异常数据字典
        /// </summary>
        private static string FormatExceptionData(IDictionary data)
        {
            if (data == null || data.Count == 0) return "无";

            StringBuilder result = new StringBuilder();
            foreach (DictionaryEntry entry in data)
            {
                result.AppendLine($"  {entry.Key}: {entry.Value}");
            }
            return result.ToString();
        }

        /// <summary>
        /// 核心写入方法：线程安全的“即开即写即关”模式
        /// </summary>
        private static void WriteToFile(string folderPath, string fileName, string content)
        {
            try
            {
                // 1. 确保目录存在（跨平台安全）
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string fullPath = Path.Combine(folderPath, fileName);

                // 2. 线程安全锁定
                lock (logLock)
                {
                    // 3. 使用 using 保证流绝对释放，避免内存泄漏和文件占用
                    using (StreamWriter sw = new StreamWriter(fullPath, true, Encoding.UTF8))
                    {
                        sw.WriteLine(content);
                        sw.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                // 日志系统自身崩溃时，输出到控制台（.NET Core 控制台或控制台窗口）
                Console.WriteLine($"【日志系统写入失败】: {ex.Message}");
            }
        }
    }
}