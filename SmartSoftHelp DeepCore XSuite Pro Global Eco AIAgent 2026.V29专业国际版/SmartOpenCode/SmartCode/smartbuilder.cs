using System;
using System.Data;
using System.Text;

/// <summary>
/// OpenSource开放代码生成辅助类
/// </summary>
namespace SmartCode
{
    /// <summary>
    /// 生成返回统一接口
    /// </summary>
    public static class smartbuilder
    {
        /// <summary>
        /// 返回功能按钮 4.API
        /// </summary>
        /// <param name="tablename">
        /// 表名称
        /// </param>
        /// <param name="table_description">
        /// 表描述
        /// </param>
        /// <param name="dt">
        /// 表结构
        /// </param>
        /// <returns>
        /// </returns>
        public static string getAPI(string tablename, string table_description, DataTable dt)
        {
            string return_str = "";
            if (tablename.ToString().Trim().Length <= 0)
            {
                tablename = "测试表名称";
            }
            if (tablename.ToString().Trim().Length <= 0)
            {
                tablename = "测试表描述";
            }
            if (dt == null)
            {
                dt = virtualdatatable.datatable_tb();
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\n\t#region API成员方法" + Environment.NewLine);
            try
            {
                ///代码生成开始
                sb.AppendLine("\t///API 代码生成\n");
                sb.AppendLine("\t///表名称 " + tablename + "\n");
                sb.AppendLine("\t///表描述 " + tablename + "\n");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.AppendLine("\t///表字段 " + dt.Rows[i][1] + "\n");
                }

                ///代码生成结束
            }
            catch (Exception ex)
            {
                return_str = "生成异常:" + ex.Message;
            }
            sb.AppendLine("\n\t#endregion API成员方法" + Environment.NewLine);
            return_str += sb.ToString();
            return return_str;
        }

        /// <summary>
        /// 返回功能按钮 3.DbHelperEF
        /// </summary>
        /// <param name="tablename">
        /// 表名称
        /// </param>
        /// <param name="table_description">
        /// 表描述
        /// </param>
        /// <param name="dt">
        /// 表结构
        /// </param>
        /// <returns>
        /// </returns>
        public static string getDbHelperEF(string tablename, string table_description, DataTable dt)
        {
            string return_str = "";
            if (tablename.ToString().Trim().Length <= 0)
            {
                tablename = "测试表名称";
            }
            if (tablename.ToString().Trim().Length <= 0)
            {
                tablename = "测试表描述";
            }
            if (dt == null)
            {
                dt = virtualdatatable.datatable_tb();
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\n\t#region EF成员方法" + Environment.NewLine);
            try
            {
                ///代码生成开始
                sb.AppendLine("\t///EF 代码生成\n");
                sb.AppendLine("\t///表名称 " + tablename + "\n");
                sb.AppendLine("\t///表描述 " + tablename + "\n");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.AppendLine("\t///表字段 " + dt.Rows[i][1] + "\n");
                }
                ///代码生成结束
            }
            catch (Exception ex)
            {
                return_str = "生成异常:" + ex.Message;
            }
            sb.AppendLine("\n\t#endregion EF成员方法" + Environment.NewLine);
            return_str += sb.ToString();
            return return_str;
        }

        /// <summary>
        /// 返回功能按钮 1.getDbHelperSQL
        /// </summary>
        /// <param name="tablename">
        /// 表名称
        /// </param>
        /// <param name="table_description">
        /// 表描述
        /// </param>
        /// <param name="dt">
        /// 表结构
        /// </param>
        /// <returns>
        /// </returns>
        public static string getDbHelperSQL(string tablename, string table_description, DataTable dt)
        {
            string return_str = "";
            if (tablename.ToString().Trim().Length <= 0)
            {
                tablename = "测试表名称";
            }
            if (tablename.ToString().Trim().Length <= 0)
            {
                tablename = "测试表描述";
            }
            if (dt == null)
            {
                dt = virtualdatatable.datatable_tb();
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\n\t#region SQL成员方法" + Environment.NewLine);
            try
            {
                ///代码生成开始
                sb.AppendLine("\t///SQL 代码生成\n");
                sb.AppendLine("\t///表名称 " + tablename + "\n");
                sb.AppendLine("\t///表描述 " + tablename + "\n");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.AppendLine("\t///表字段 " + dt.Rows[i][1] + "\n");
                }
                ///代码生成结束
            }
            catch (Exception ex)
            {
                return_str = "生成异常:" + ex.Message;
            }
            sb.AppendLine("\n\t#endregion SQL成员方法" + Environment.NewLine);
            return_str += sb.ToString();
            return return_str;
        }

        /// <summary>
        /// 返回功能按钮 2.getModel
        /// </summary>
        /// <param name="tablename">
        /// 表名称
        /// </param>
        /// <param name="table_description">
        /// 表描述
        /// </param>
        /// <param name="dt">
        /// 表结构
        /// </param>
        /// <returns>
        /// </returns>
        public static string getModel(string tablename, string table_description, DataTable dt)
        {
            string return_str = "";
            if (tablename.ToString().Trim().Length <= 0)
            {
                tablename = "测试表名称";
            }
            if (tablename.ToString().Trim().Length <= 0)
            {
                tablename = "测试表描述";
            }
            if (dt == null)
            {
                dt = virtualdatatable.datatable_tb();
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\n\t#region Model成员方法" + Environment.NewLine);
            try
            {
                ///代码生成开始
                sb.AppendLine("\t///Model 代码生成\n");
                sb.AppendLine("\t///表名称 " + tablename + "\n");
                sb.AppendLine("\t///表描述 " + tablename + "\n");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.AppendLine("\t///表字段 " + dt.Rows[i][1] + "\n");
                }
                ///代码生成结束
            }
            catch (Exception ex)
            {
                return_str = "生成异常:" + ex.Message;
            }
            sb.AppendLine("\n\t#endregion Model成员方法" + Environment.NewLine);
            return_str += sb.ToString();
            return return_str;
        }

        /// <summary>
        /// 返回功能按钮 7.SQL脚本
        /// </summary>
        /// <param name="tablename">
        /// 表名称
        /// </param>
        /// <param name="table_description">
        /// 表描述
        /// </param>
        /// <param name="dt">
        /// 表结构
        /// </param>
        /// <returns>
        /// </returns>
        public static string getSQLTXT(string tablename, string table_description, DataTable dt)
        {
            string return_str = "";
            if (tablename.ToString().Trim().Length <= 0)
            {
                tablename = "测试表名称";
            }
            if (tablename.ToString().Trim().Length <= 0)
            {
                tablename = "测试表描述";
            }
            if (dt == null)
            {
                dt = virtualdatatable.datatable_tb();
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\n\t--SQLTXT成员方法" + Environment.NewLine);
            try
            {
                ///代码生成开始
                sb.AppendLine("\t///SQLTXT 代码生成\n");
                sb.AppendLine("\t///表名称 " + tablename + "\n");
                sb.AppendLine("\t///表描述 " + tablename + "\n");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.AppendLine("\t///表字段 " + dt.Rows[i][1] + "\n");
                }
                ///代码生成结束
            }
            catch (Exception ex)
            {
                return_str = "生成异常:" + ex.Message;
            }
            sb.AppendLine("\n\t--SQLTXT成员方法" + Environment.NewLine);
            return_str += sb.ToString();
            return return_str;
        }

        /// <summary>
        /// 返回功能按钮 5.UI①
        /// </summary>
        /// <param name="tablename">
        /// 表名称
        /// </param>
        /// <param name="table_description">
        /// 表描述
        /// </param>
        /// <param name="dt">
        /// 表结构
        /// </param>
        /// <returns>
        /// </returns>
        public static string getUI1(string tablename, string table_description, DataTable dt)
        {
            string return_str = "";
            if (tablename.ToString().Trim().Length <= 0)
            {
                tablename = "测试表名称";
            }
            if (tablename.ToString().Trim().Length <= 0)
            {
                tablename = "测试表描述";
            }
            if (dt == null)
            {
                dt = virtualdatatable.datatable_tb();
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\n" + Environment.NewLine);
            try
            {
                ///代码生成开始
                sb.AppendLine("\t///getUI1 代码生成\n");
                sb.AppendLine("\t///表名称 " + tablename + "\n");
                sb.AppendLine("\t///表描述 " + tablename + "\n");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.AppendLine("\t///表字段 " + dt.Rows[i][1] + "\n");
                }
                ///代码生成结束
            }
            catch (Exception ex)
            {
                return_str = "生成异常:" + ex.Message;
            }
            sb.AppendLine("\n" + Environment.NewLine);
            return_str += sb.ToString();
            return return_str;
        }

        /// <summary>
        /// 返回功能按钮 6.UI①
        /// </summary>
        /// <param name="tablename">
        /// 表名称
        /// </param>
        /// <param name="table_description">
        /// 表描述
        /// </param>
        /// <param name="dt">
        /// 表结构
        /// </param>
        /// <returns>
        /// </returns>
        public static string getUI2(string tablename, string table_description, DataTable dt)
        {
            string return_str = "";
            if (tablename.ToString().Trim().Length <= 0)
            {
                tablename = "测试表名称";
            }
            if (tablename.ToString().Trim().Length <= 0)
            {
                tablename = "测试表描述";
            }
            if (dt == null)
            {
                dt = virtualdatatable.datatable_tb();
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\n" + Environment.NewLine);
            try
            {
                ///代码生成开始
                sb.AppendLine("\t///getUI2 代码生成\n");
                sb.AppendLine("\t///表名称 " + tablename + "\n");
                sb.AppendLine("\t///表描述 " + tablename + "\n");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.AppendLine("\t///表字段 " + dt.Rows[i][1] + "\n");
                }
                ///代码生成结束
            }
            catch (Exception ex)
            {
                return_str = "生成异常:" + ex.Message;
            }
            sb.AppendLine("\n" + Environment.NewLine);
            return_str += sb.ToString();
            return return_str;
        }
    }
}