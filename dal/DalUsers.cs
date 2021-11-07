using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using models;

namespace dal
{
    public class DalUsers
    {
        dbhelp db = new dbhelp();
        public ModelUsers login(string name, string pwd)
        {
            string sql = @"select * from Users where UserName= @UserName and UserPwd=@pwd";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@UserName", name));
            list.Add(new SqlParameter("@pwd", pwd));
            SqlDataReader dr = db.selectDataReader(sql, list);
            ModelUsers info = new ModelUsers();
            while (dr.Read())
            {
                info.UserID = (int)dr["UserID"];
                info.UserName = dr["UserName"].ToString();
                info.UserNick = dr["UserNick"].ToString();
            }
            return info;
        }
        public List<ModelUsers> getUser(ModelUsers info)
        {
            string sql = "select * from Users where UserID = @UserID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@UserID", info.UserID));
            DataTable dt = db.getData(sql, list);
            List<ModelUsers> mulist = new List<ModelUsers>();
            if (dt.Rows.Count > 0)
            {
                ModelUsers muinfo = new ModelUsers();
                muinfo.UserName = dt.Rows[0]["UserName"].ToString();
                muinfo.UserNick = dt.Rows[0]["UserNick"].ToString();
                mulist.Add(muinfo);
            }
            return mulist;

        }
    }
}
