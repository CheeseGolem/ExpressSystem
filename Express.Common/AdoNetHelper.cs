using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Express.Common
{
    using System.Data;
    using System.Data.SqlClient;
    public static class AdoNetHelper
    {
        /// <summary>
        /// 判断列是否存在
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="columnName">列名</param>
        /// <returns></returns>
        public static bool IsContainsColumn(this SqlDataReader reader, string columnName)
        {
            return reader.GetSchemaTable().Select("ColumnName='" + columnName + "'").Length > 0;
        }

        /// <summary>
        /// 判断列是否存在
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="columnName">列名</param>
        /// <returns></returns>
        public static bool IsContainsColumn(this DataRow row, string columnName)
        {
            return row.Table.Columns.Contains(columnName);
        }
    }
}
