using System;
using System.Data;

namespace SmartCode
{
    /// <summary>
    /// 零时虚拟表
    /// </summary>
    public static class virtualdatatable
    {
        /// <summary>
        /// 初始化datatable
        /// </summary>
        /// <returns>
        /// </returns>
        public static DataTable createTD()
        {
            /// <summary>
            /// 数据库表字段临时表
            /// </summary>
            DataTable tb = new DataTable("Datamx");//表名称
            tb.Columns.Add("字段序号", Type.GetType("System.int"));//1
            tb.Columns.Add("字段名", Type.GetType("System.String"));//2
            tb.Columns.Add("标识", Type.GetType("System.String"));//3
            tb.Columns.Add("主键", Type.GetType("System.String"));//4
            tb.Columns.Add("类型", Type.GetType("System.String"));//5
            tb.Columns.Add("占用字节数", Type.GetType("System.String"));//6
            tb.Columns.Add("长度", Type.GetType("System.Int"));//7
            tb.Columns.Add("小数位数", Type.GetType("System.Int"));//8
            tb.Columns.Add("允许空", Type.GetType("System.String"));//9
            tb.Columns.Add("默认值", Type.GetType("System.String"));//10
            tb.Columns.Add("字段说明", Type.GetType("System.String"));//11

            return tb;
        }

        /// <summary>
        /// datatable 初始化一列数据
        /// </summary>
        public static DataTable datatable_tb()
        {
            DataTable tb = createTD();
            tb.Rows[0]["字段序号"] = 1;
            tb.Rows[1]["字段名"] = 1;
            tb.Rows[2]["标识"] = 1;
            tb.Rows[3]["主键"] = 1;
            tb.Rows[4]["类型"] = 1;
            tb.Rows[5]["占用字节数"] = 1;
            tb.Rows[6]["长度"] = 1;
            tb.Rows[7]["小数位数"] = 1;
            tb.Rows[8]["允许空"] = 1;
            tb.Rows[9]["默认值"] = 1;
            tb.Rows[10]["字段说明"] = 1;
            return tb;
        }
    }
}