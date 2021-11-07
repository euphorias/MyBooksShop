using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using models;
using System.Data;

namespace dal
{
    public class DalAddressManage
    {
        dbhelp db = new dbhelp();
        /// <summary>
        /// 获取用户默认地址
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public ModelAddressManager GetUserDefaultAddr(int userid)
        {
            string sql = @"select * from AddressManager Where UserID =" + userid + " AND AMMark = 1";
            SqlDataReader dr = db.selectDataReader(sql);
            ModelAddressManager adinfo = new ModelAddressManager();
            while (dr.Read())
            {
                adinfo.AMID = (int)dr["AMID"];
                adinfo.AMAddress = dr["AMAddress"].ToString();
                adinfo.AMUser = dr["AMUser"].ToString();
                adinfo.AMTel = dr["AMTel"].ToString();
            }
            return adinfo;
        }
        /// <summary>
        /// 新增地址
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int InsertAddressInfo(ModelAddressManager info)
        {
            string sql = "insert AddressManager values(@UserID,@AMUser,@AMTel,@AMAddress,0);select @@IDENTITY";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@UserID", info.UserID));
            list.Add(new SqlParameter("@AMUser", info.AMUser));
            list.Add(new SqlParameter("@AMTel", info.AMTel));
            list.Add(new SqlParameter("@AMAddress", info.AMAddress));
            object amid = db.ExecuteScalar(sql,list);
            return int.Parse(amid.ToString());
        }
        /// <summary>
        /// 获取用户个人地址
        /// </summary>
        /// <returns></returns>
        public List<ModelAddressManager> getAddress(int UserID)
        {
            string sql = "select * from AddressManager where UserID =@UserID";            
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@UserID", UserID));
            SqlDataReader dr = db.selectDataReader(sql,list);
            List<ModelAddressManager> malist = new List<ModelAddressManager>();
            while (dr.Read())
            {
                ModelAddressManager mainfo = new ModelAddressManager();
                mainfo.AMID = int.Parse(dr["AMID"].ToString());
                mainfo.AMUser = dr["AMUser"].ToString();
                mainfo.AMAddress = dr["AMAddress"].ToString();
                mainfo.AMTel = dr["AMTel"].ToString();
                mainfo.AMMark = (bool)dr["AMMark"];
                malist.Add(mainfo);
            }
            return malist;
            
        }
        /// <summary>
        /// 保存修改
        /// </summary>
        public int saveChanges(ModelAddressManager mainfo,int AMID)
        {
            string sql = "update AddressManager set AMUser=@AMUser,AMTel=@AMTel,AMAddress=@AMAddress where AMID = @AMID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@AMUser", mainfo.AMUser));
            list.Add(new SqlParameter("@AMTel", mainfo.AMTel));
            list.Add(new SqlParameter("@AMAddress", mainfo.AMAddress));
            list.Add(new SqlParameter("@AMID", AMID));
            return db.executeNonQuery(sql, list);
        }
        /// <summary>
        /// 保存默认地址
        /// </summary>
        /// <param name="mainfo"></param>
        /// <returns></returns>
        public int saveDefault(int AMID)
        {
            string sql = "update AddressManager set AMMark = 1 where AMID=@AMID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@AMID", AMID));
            return db.executeNonQuery(sql, list);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="AMID"></param>
        /// <returns></returns>
        public int delete(int AMID)
        {
            string sql = "delete from AddressManager where AMID=@AMID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@AMID", AMID));
            return db.executeNonQuery(sql, list);
        }
        public int insert(ModelAddressManager mainfo)
        {
            string sql = "insert AddressManager values(@UserID,@AMUser,@AMTel,@AMAddress,0)";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@UserID", mainfo.UserID));
            list.Add(new SqlParameter("@AMUser", mainfo.AMUser));
            list.Add(new SqlParameter("@AMTel", mainfo.AMTel));
            list.Add(new SqlParameter("@AMAddress", mainfo.AMAddress));
            return db.executeNonQuery(sql, list);
        }
    }
}
