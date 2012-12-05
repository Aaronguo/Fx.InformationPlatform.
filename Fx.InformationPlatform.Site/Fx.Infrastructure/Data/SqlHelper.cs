using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Fx.Infrastructure.Data
{
    public class SqlHelper
    {
        private string connectString = null;
        /// <summary>
        /// 初始话连接字符串
        /// </summary>
        /// <param name="ConnString">连接字符串</param>
        public SqlHelper(string ConnString)
        {
            this.connectString = ConnString;
        }

        public DataTable GetDt(string strSql)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = connectString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = strSql;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        /// <summary>
        /// 更新 删除
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="isProc">是不是存储过程</param>
        /// <param name="pars">参数</param>
        /// <returns>影响了几行</returns>
        public int Execute(string strSql, bool isProc, SqlParameter[] pars)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = connectString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = strSql;
            cmd.CommandType = isProc ? CommandType.StoredProcedure : CommandType.Text;
            if (pars != null)
            {
                foreach (SqlParameter p in pars)
                {
                    cmd.Parameters.Add(p);
                }
            }
            cn.Open();
            int rt = cmd.ExecuteNonQuery();
            cn.Close();
            return rt;
        }

    }

    public static class Extend
    {
        /// <summary>
        /// 对like语句字符过滤
        /// </summary>
        /// <param name="Keyword"></param>
        /// <returns></returns>
        public static string EncodingKeyword(this string Keyword)
        {
            return Keyword.Replace("_", "[_]").Replace("%", "[%]");
        }

        /// <summary>
        /// 对sql语句过滤
        /// </summary>
        /// <param name="Content"></param>
        /// <returns></returns>
        public static string EncodingString(this string Content)
        {
            return Content.Replace("'", "''").Replace("--", "");
        }
    }
}
