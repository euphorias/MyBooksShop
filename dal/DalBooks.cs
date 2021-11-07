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
    public class DalBooks
    {
        dbhelp db = new dbhelp();
        /// <summary>
        /// 分页查询+模糊查询
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public List<ModelView_book> GetBooks(ModelSelect info)
        {
            string sql = "select * from BSCategory BS,BLCategory BL,Books B where B.BSID=BS.BSID and BS.BLID = BL.BLID and B.BookTitle like '%'+@BookTitle+'%' and B.BookPublish like '%'+@BookPublish+'%' ";
            if (info.BLID != -1)
            {
                sql += " AND BL.BLID = @BLID ";
            }
            if (info.BSID != -1)
            {
                sql += " AND BS.BSID = @BSID ";
            }
            if (info.BookIsBuy != -1)
            {
                sql += " AND B.BookIsBuy = @BookIsBuy ";
            }
            if (info.BookIsHot != -1)
            {
                sql += " AND B.BookIsHot = @BookIsHot ";
            }
            sql += " ORDER BY B.BookID OFFSET (@pageindex-1)*@pagesize ROWS FETCH NEXT @pagesize ROWS ONLY";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@BLID", info.BLID));
            list.Add(new SqlParameter("@BSID", info.BSID));
            list.Add(new SqlParameter("@BookTitle", info.BookTitle));
            list.Add(new SqlParameter("@BookPublish", info.BookPublish));
            list.Add(new SqlParameter("@BookIsBuy", info.BookIsBuy));
            list.Add(new SqlParameter("@BookIsHot", info.BookIsHot));
            list.Add(new SqlParameter("@pagesize", info.pagesize));
            list.Add(new SqlParameter("@pageindex", info.pageindex));
            DataTable dt = db.getData(sql, list);
            List<ModelView_book> bslist = new List<ModelView_book>();
            if (dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    ModelView_book bsinfo = new ModelView_book();
                    bsinfo.BookID = (int)dt.Rows[i]["BookID"];
                    bsinfo.BookTitle = dt.Rows[i]["BookTitle"].ToString();
                    bsinfo.BookPublish = dt.Rows[i]["BookPublish"].ToString();
                    bsinfo.BLName = dt.Rows[i]["BLName"].ToString();
                    bsinfo.BSName = dt.Rows[i]["BSName"].ToString();
                    bsinfo.BookMoney = (decimal)dt.Rows[i]["BookMoney"];
                    bsinfo.BookPrice = (decimal)dt.Rows[i]["BookPrice"];
                    bsinfo.BookSale = (int)dt.Rows[i]["BookSale"];
                    bsinfo.BookDeport = (int)dt.Rows[i]["BookDeport"];
                    bsinfo.BookIsBuy = (bool)dt.Rows[i]["BookIsBuy"];
                    bsinfo.BookIsHot = (bool)dt.Rows[i]["BookIsHot"];
                    bslist.Add(bsinfo);

                }
            }
            return bslist;
        }
        //获取单行数据
        public List<ModelView_book> GetBook(ModelView_book info)
        {
            string sql = "select * from Books where BookID=@BookID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@BookID", info.BookID));
            DataTable dt = db.getData(sql, list);
            List<ModelView_book> bslist = new List<ModelView_book>();
            if (dt.Rows.Count > 0)
            {
                ModelView_book bsinfo = new ModelView_book();
                bsinfo.BookTitle = dt.Rows[0]["BookTitle"].ToString();
                bsinfo.BookPublish = dt.Rows[0]["BookPublish"].ToString();
                bsinfo.BSID = (int)dt.Rows[0]["BSID"];
                bsinfo.BookMoney = (decimal)dt.Rows[0]["BookMoney"];
                bsinfo.BookPrice = (decimal)dt.Rows[0]["BookPrice"];
                bsinfo.BookComm = dt.Rows[0]["BookComm"].ToString();
                bsinfo.BookDeport = (int)dt.Rows[0]["BookDeport"];
                bsinfo.BookAuthorDesc = dt.Rows[0]["BookAuthorDesc"].ToString();
                bsinfo.BookContent = dt.Rows[0]["BookContent"].ToString();
                bsinfo.BookDesc = dt.Rows[0]["BookDesc"].ToString();
                bsinfo.BookCount = (int)dt.Rows[0]["BookCount"];
                bsinfo.BookAuthor = dt.Rows[0]["BookAuthor"].ToString();
                bsinfo.ISBN = dt.Rows[0]["ISBN"].ToString();
                bslist.Add(bsinfo);

            }
                return bslist;
        }
        //获取单页页数
        public int GetBooksCount(ModelSelect info)
        {
            string sql = "select COUNT(1) AS PAGENUMS FROM BSCategory BS,BLCategory BL,Books B where B.BSID=BS.BSID and BS.BLID = BL.BLID and B.BookTitle like '%'+@BookTitle+'%' and B.BookPublish like '%'+@BookPublish+'%' ";
            if (info.BLID != -1)
            {
                sql += " AND BL.BLID = @BLID ";
            }
            if (info.BSID != -1)
            {
                sql += " AND BS.BSID = @BSID ";
            }
            if (info.BookIsBuy != -1)
            {
                sql += " AND B.BookIsBuy = @BookIsBuy ";
            }
            if (info.BookIsHot != -1)
            {
                sql += " AND B.BookIsHot = @BookIsHot ";
            }
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@BLID", info.BLID));
            list.Add(new SqlParameter("@BSID", info.BSID));
            list.Add(new SqlParameter("@BookTitle", info.BookTitle));
            list.Add(new SqlParameter("@BookPublish", info.BookPublish));
            list.Add(new SqlParameter("@BookIsBuy", info.BookIsBuy));
            list.Add(new SqlParameter("@BookIsHot", info.BookIsHot));
            list.Add(new SqlParameter("@pagesize", info.pagesize));
            SqlDataReader dr = db.selectDataReader(sql, list);
            int pagenums = 0;
            while (dr.Read())
            {
                pagenums = int.Parse(dr["PAGENUMS"].ToString());
            }
            return pagenums;
        }

        #region 更新数据
        /// <summary>
        /// 更新书籍是否被秒杀
        /// </summary>
        /// <param name="bookid"></param>
        /// <returns></returns>
        public int UpdateBookIsBuy(int bookid)
        {
            string sql = "update Books set BookIsBuy =(case when BookIsBuy = 1 then 0 else 1 end) where BookID = @BookID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@BookID", bookid));
            return db.executeNonQuery(sql, list);
        }
        public int UpdateBookIsHot(int bookid)
        {
            string sql = "update Books set BookIsHot =(case when BookIsHot = 1 then 0 else 1 end) where BookID = @BookID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@BookID", bookid));
            return db.executeNonQuery(sql, list);
        }
        #endregion
        /// <summary>
        /// 插入新数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Insert (ModelBooks info)
        {
            string sql = "insert Books values(@BSID,@BookTitle,@BookAuthor,@BookPublish,@ISBN,@BookCount,@BookMoney,@BookPrice,@BookDesc," +
                "@BookAuthorDesc,@BookComm,@BookContent,0,@BookDeport,0,0,0,null,null)";
            List<SqlParameter> palist = new List<SqlParameter>();
            palist.Add(new SqlParameter("@BSID", info.BSID)); palist.Add(new SqlParameter("@BookTitle", info.BookTitle));
            palist.Add(new SqlParameter("@BookPublish", info.BookPublish)); palist.Add(new SqlParameter("@ISBN", info.ISBN));
            palist.Add(new SqlParameter("@BookAuthor", info.BookAuthor)); palist.Add(new SqlParameter("@BookCount", info.BookCount));
            palist.Add(new SqlParameter("@BookMoney", info.BookMoney)); palist.Add(new SqlParameter("@BookPrice", info.BookPrice));
            palist.Add(new SqlParameter("@BookDesc", info.BookDesc)); palist.Add(new SqlParameter("@BookAuthorDesc", info.BookAuthorDesc));
            palist.Add(new SqlParameter("@BookComm", info.BookComm)); palist.Add(new SqlParameter("@BookContent", info.BookContent));
            palist.Add(new SqlParameter("@BookDeport", info.BookDeport));
            return db.executeNonQuery(sql, palist);
        }
        public int delete(ModelView_book info)
        {
            string sql = "delete from Books where BookID = (@BookID)";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@BookID", info.BookID));
            return db.executeNonQuery(sql, list);
        }
        public int update(ModelBooks info)
        {
            string sql = "update Books set BookTitle=@BookTitle,BookAuthor = @BookAuthor,BookPublish= @BookPublish,BookPrice=@BookPrice," +
                "BookMoney=@BookMoney,BookAuthorDesc= @BookAuthorDesc,BookDeport = @BookDeport,BookDesc=@BookDesc,BSID=@BSID,ISBN=@ISBN,BookComm=@BookComm," +
                "BookContent=@BookContent,BookCount=@BookCount where BookID = @BookID";

            List<SqlParameter> palist = new List<SqlParameter>();
            palist.Add(new SqlParameter("@BookID", info.BookID));
            palist.Add(new SqlParameter("@BSID", info.BSID)); palist.Add(new SqlParameter("@BookTitle", info.BookTitle));
            palist.Add(new SqlParameter("@BookPublish", info.BookPublish)); palist.Add(new SqlParameter("@ISBN", info.ISBN));
            palist.Add(new SqlParameter("@BookAuthor", info.BookAuthor)); palist.Add(new SqlParameter("@BookCount", info.BookCount));
            palist.Add(new SqlParameter("@BookMoney", info.BookMoney)); palist.Add(new SqlParameter("@BookPrice", info.BookPrice));
            palist.Add(new SqlParameter("@BookDesc", info.BookDesc)); palist.Add(new SqlParameter("@BookAuthorDesc", info.BookAuthorDesc));
            palist.Add(new SqlParameter("@BookComm", info.BookComm)); palist.Add(new SqlParameter("@BookContent", info.BookContent));
            palist.Add(new SqlParameter("@BookDeport", info.BookDeport));
            return db.executeNonQuery(sql, palist);
        }
        /// <summary>
        /// 绑定是否秒杀列表数据
        /// </summary>
        /// <returns></returns>
        public List<ModelView_book> GetBookIsBuyList()
        {
            string sql = @"select top 10 * from Books Where BookIsBuy =1  order by BookSale DESC";
            SqlDataReader dr = db.selectDataReader(sql);
            List<ModelView_book> mvlist = new List<ModelView_book>();
            while (dr.Read())
            {
                ModelView_book mv = new ModelView_book();
                mv.BookID = (int)dr["BookID"];
                mv.BookTitle = dr["BookTitle"].ToString();
                mv.ISBN = dr["ISBN"].ToString();
                mv.BookPrice = (decimal)dr["BookPrice"];
                mv.BookMoney = (decimal)dr["BookMoney"];
                mvlist.Add(mv);
            }
            return mvlist;
        }
        /// <summary>
        /// 绑定前10行列表数据
        /// </summary>
        /// <returns></returns>
        public List<ModelView_book> GetBookIsHotList()
        {
            string sql = @"select top 10 * from Books Where BookIsHot =1  order by BookSale DESC";
            SqlDataReader dr = db.selectDataReader(sql);
            List<ModelView_book> mvlist = new List<ModelView_book>();
            while (dr.Read())
            {
                ModelView_book mv = new ModelView_book();
                mv.BookID = (int)dr["BookID"];
                mv.BookTitle = dr["BookTitle"].ToString();
                mv.ISBN = dr["ISBN"].ToString();
                mv.BookPrice = (decimal)dr["BookPrice"];
                mv.BookMoney = (decimal)dr["BookMoney"];
                mvlist.Add(mv);
            }
            return mvlist;
        }
        public List<ModelView_book> GetCartList(string ids)
        {
            string sql = @"select * from Books where bookid in (" + ids + ")";
            SqlDataReader dr = db.selectDataReader(sql);
            List<ModelView_book> mvlist = new List<ModelView_book>();
            while (dr.Read())
            {
                ModelView_book mv = new ModelView_book();
                mv.BookID = (int)dr["BookID"];
                mv.BookTitle = dr["BookTitle"].ToString();
                mv.BookPrice = (decimal)dr["BookPrice"];
                mv.BookMoney = (decimal)dr["BookMoney"];
                mvlist.Add(mv);
            }
            return mvlist;

        }
    }
}
