using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using models;
using System.Data;
using System.Data.SqlClient;

namespace dal
{
    public class DalBSCategory
    {
        dbhelp db = new dbhelp();
        public List<ModelBSCategory> GetBSlist()
        {
            string sql = "select * from BSCategory";
            SqlDataReader dr = db.selectDataReader(sql);
            List<ModelBSCategory> bslist = new List<ModelBSCategory>();
            while (dr.Read())
            {
                ModelBSCategory bsinfo = new ModelBSCategory();
                bsinfo.BLID = int.Parse(dr["BLID"].ToString());
                bsinfo.BSID = (int)dr["BSID"];
                bsinfo.BSName = dr["BSName"].ToString();
                bslist.Add(bsinfo);
            }
            return bslist;
        }
        public List<ModelBSCategory> GetBsListByBlid(int blid)
        {
            string sql = "select * from BSCategory BS where BLID = @BLID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@BLID", blid));
            SqlDataReader dr = db.selectDataReader(sql, list);
            List<ModelBSCategory> bslist = new List<ModelBSCategory>();
            while (dr.Read())
            {
                ModelBSCategory info = new ModelBSCategory();
                info.BSID = (int)dr["BSID"];
                info.BSName = dr["BSName"].ToString();
                bslist.Add(info);
            }
            return bslist;

        }
        public List<ModelBSCategory> GetBSCategoryByPageIndex(ModelBSCategory info,int pageindex,int pagesize)
        {
            string sql = "select BS.*,BL.BLName from BSCategory BS,BLCategory BL where BS.BLID=BL.BLID AND BSName LIKE '%'+@BSName+'%'";
            if (info.BLID != -1)
            {
                sql += " AND BS.BLID = @BLID ";
            }
            sql += "ORDER BY BS.BSID OFFSET (@pageindex-1)*@pagesize ROWS FETCH NEXT @pagesize ROWS ONLY";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@BSName", info.BSName));
            list.Add(new SqlParameter("@BLID", info.BLID));
            list.Add(new SqlParameter("@pageindex", pageindex));
            list.Add(new SqlParameter("@pagesize", pagesize));
            SqlDataReader dr = db.selectDataReader(sql, list);
            List<ModelBSCategory> bslist = new List<ModelBSCategory>();
            while (dr.Read())
            {
                ModelBSCategory bsinfo = new ModelBSCategory();
                bsinfo.BLID = int.Parse(dr["BLID"].ToString());
                bsinfo.BSID = (int)dr["BSID"];
                bsinfo.BSName = dr["BSName"].ToString();
                bsinfo.BLName = dr["BLName"].ToString();
                bslist.Add(bsinfo);
            }
            return bslist;
        }
        /// <summary>
        /// 获取查询到的记录条数
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int GetBsCategoryCount(ModelBSCategory info)
        {
            string sql = "select COUNT(1) AS PAGENUMS FROM BSCategory BS,BLCategory BL where BS.BLID=BL.BLID AND BSName LIKE '%'+@BSName+'%'";
            if (info.BLID != -1)
            {
                sql += " AND BS.BLID = @BLID";
            }
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@BSName", info.BSName));
            list.Add(new SqlParameter("@BLID", info.BLID));
            SqlDataReader dr = db.selectDataReader(sql, list);
            int pagenums = 0;
            while (dr.Read())
            {
                pagenums = int.Parse(dr["PAGENUMS"].ToString());
            }
            return pagenums;
        }
        public int insert(ModelBSCategory info)
        {
            string sql = "insert into BSCategory values(@BLID,@bsname)";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@bsname", info.BSName));
            list.Add(new SqlParameter("@BLID", info.BLID));
            return db.executeNonQuery(sql, list);
        }
        public int update(ModelBSCategory info)
        {
            string sql = "update BSCategory set BSName = @BSName , BLID = @BLID where BSID = @BSID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@BLID", info.BLID));
            list.Add(new SqlParameter("@BSID", info.BSID));
            list.Add(new SqlParameter("@BSName", info.BSName));
            return db.executeNonQuery(sql, list);
        }
        public int Delete(ModelBSCategory info)
        {
            string sql = "delete from BSCategory where BSID = (@BSID)";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@BSID", info.BSID));
            return db.executeNonQuery(sql, list);
        }
    }
}
