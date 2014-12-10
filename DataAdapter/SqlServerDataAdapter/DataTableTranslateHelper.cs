﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SqlServerDataAdapter
{
    public class DataTableTranslateHelper
    {
        /// <summary>
        /// 将DataRow转换为Insert语句
        /// </summary>
        /// <param name="tableName">数据库表名</param>
        /// <param name="dr">数据源</param>
        /// <param name="columns">列名</param>
        /// <param name="parameters">参数集合</param>
        /// <returns></returns>
        public static string DataRowToInsert(string tableName, DataRow dr, string[] columns, List<SqlParameter> parameters)
        {
            string baseString = "INSERT INTO ";
            StringBuilder insertStr = new StringBuilder();
            insertStr.Append(baseString).Append(tableName);

            StringBuilder columnStr = new StringBuilder("(");
            StringBuilder valueStr = new StringBuilder("(");
            foreach (string item in columns)
            {
                columnStr.Append(item).Append(",");
                valueStr.Append("@I").Append(item).Append(",");
                parameters.Add(new SqlParameter("@I" + item, dr[item]));
            }
            columnStr.Remove(columnStr.Length - 1, 1).Append(")");
            valueStr.Remove(valueStr.Length - 1, 1).Append(")");
            insertStr.Append(" ").Append(columnStr.ToString());
            insertStr.Append(" VALUES ").Append(valueStr.ToString());

            return insertStr.ToString();
        }
        /// <summary>
        /// 将DataRow转换为Update语句
        /// </summary>
        /// <param name="tableName">数据库表名</param>
        /// <param name="dr">数据源</param>
        /// <param name="columns">列名</param>
        /// <param name="keyColumnName">判断条件列名</param>
        /// <param name="parameters">参数集合</param>
        /// <returns></returns>
        public static string DataRowToUpdate(string tableName, DataRow dr, string[] columns,
            string[] keyColumnName, List<SqlParameter> parameters)
        {
            string baseString = "UPDATE ";
            StringBuilder updateStr = new StringBuilder();
            updateStr.Append(baseString).Append(tableName).Append(" SET ");
            foreach (string item in columns)
            {
                updateStr.Append(item).Append("=@u").Append(item).Append(",");
                parameters.Add(new SqlParameter("@u" + item, dr[item]));
            }
            updateStr.Remove(updateStr.Length - 1, 1);
            updateStr.Append(" WHERE ");
            foreach (string item in keyColumnName)
            {
                updateStr.Append(item).Append("=@w").Append(item).Append(" AND ");
                parameters.Add(new SqlParameter("@w" + item, dr[item]));
            }
            updateStr.Remove(updateStr.Length - 5, 5);
            return updateStr.ToString();
        }
    }
}
