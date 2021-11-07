using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace dal
{
    public class dbhelp
    {
        public static string conn = ConfigurationManager.ConnectionStrings["sb"].ConnectionString;
        public DataTable getData(string sql)
        {
            SqlConnection con = new SqlConnection(conn);
            SqlDataAdapter adp = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getData(string sql,List<SqlParameter> list)
        {
            SqlConnection con = new SqlConnection(conn);
            SqlDataAdapter adp = new SqlDataAdapter(sql, con);
            adp.SelectCommand.Parameters.AddRange(list.ToArray());
            DataTable dt = new DataTable();
            adp.Fill(dt);
            con.Close();
            return dt;
        }
        public int executeNonQuery(string sql)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i; 
        }
        public int executeNonQuery(string sql, List<SqlParameter> list)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(list.ToArray());
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        /// <summary>
        /// 执行多条SQL语句，返回最后一条查询的第一行第一列的值，其他数据将被忽略
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object ExecuteScalar(string sql)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            object i = cmd.ExecuteScalar();
            con.Close();
            return i;
        }
        public object ExecuteScalar(string sql, List<SqlParameter> list)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(list.ToArray());
            object i = cmd.ExecuteScalar();
            con.Close();
            return i;
        }
        //执行查询，返回读取器
        public SqlDataReader selectDataReader(string sql)
        {
            SqlConnection con = new SqlConnection(conn);
            //开始连接
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            //返回读取器，关闭链接
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        public SqlDataReader selectDataReader(string sql, List<SqlParameter> list)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            //将查询参数添加到数据库命令的参选列表，需要将list转换为数组
            cmd.Parameters.AddRange(list.ToArray());
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}

