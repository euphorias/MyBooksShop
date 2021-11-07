using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using dal;
using System.Configuration;
using models;

namespace dal
{
    public class sbdal
    {
        
        dbhelp db = new dbhelp();
        public int login(string name,string pwd)
        {
            string sql = "select * from Admins where AdminUser= @User and AdminPwd=@pwd";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@User", name));
            list.Add(new SqlParameter("@pwd", pwd));
            DataTable dt = db.getData(sql,list);
            if (dt.Rows.Count > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public ModelAdmin register(string name, string pwd)
        {
            string sql = "insert Admins(AdminUser,AdminPwd) values(@User,@pwd)";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@User", name));
            list.Add(new SqlParameter("@pwd", pwd));
            DataTable dt = db.getData(sql, list);
            ModelAdmin ma = new ModelAdmin();
            ma.AdminUser = name;
            ma.AdminPwd = pwd;
            return ma;
        }
    }
}
