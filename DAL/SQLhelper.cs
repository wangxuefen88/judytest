using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;

namespace DLL
{
    public class SQLhelper
    {
        private SqlConnection conn = null;
        private SqlCommand cmd = null;
        private SqlDataReader sdr = null;

        public SQLhelper()
        {

            string connStr = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;

            conn = new SqlConnection(connStr);

        }
        private SqlConnection GetConn()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }
        public int ExecuteNonQuery(string sql, SqlParameter[] paras)
        {
            int res;
            using (cmd = new SqlCommand(sql, GetConn()))
            {
                cmd.Parameters.AddRange(paras);
                res = cmd.ExecuteNonQuery();
            }
            return res;

        }

        #region  不带参数的sql查询语句
        /// <summary>
        /// 不带参数的sql查询语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string sql)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand(sql, GetConn());
            using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                dt.Load(sdr);
            }
            return dt;
        }
        #endregion
    }
}
