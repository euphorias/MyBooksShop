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
    public class dalBLCategory
    {
        dbhelp db = new dbhelp();
        public List<ModelBLCategory> GetBLCategory()
        {
            string sql = "select * from BLCategory";
            DataTable dt = db.getData(sql);
            List<ModelBLCategory> bllist = new List<ModelBLCategory>();
            if (dt.Rows.Count > 0)
            {
                for(int i = 0; i<dt.Rows.Count; i++)
                {
                    ModelBLCategory blinfo = new ModelBLCategory();
                    blinfo.BLID = int.Parse(dt.Rows[i]["BLID"].ToString());
                    blinfo.BLName = dt.Rows[i]["BLName"].ToString();
                    bllist.Add(blinfo);
                }
                
            }
            return bllist;
        }
        public int insert(ModelBLCategory info)
        {
            string sql = "insert into BLCategory values(@blname)";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@blname", info.BLName));
            return db.executeNonQuery(sql,list);
            

        }

        public int Delete(ModelBLCategory info)
        {
            string sql = "delete from BLCategory where BLID = (@BLID)";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@BLID", info.BLID));
            return db.executeNonQuery(sql, list);
        }
        public int update(ModelBLCategory info)
        {
            string sql = "update BLCategory set BLName = @BLName where BLID = @BLID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@BLID", info.BLID));
            list.Add(new SqlParameter("@BLName", info.BLName));
            return db.executeNonQuery(sql, list);
        }
    }
}
