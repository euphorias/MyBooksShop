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
    public class dalCustomerOrder
    {
        dbhelp db = new dbhelp();
        public List<ModelOrders> GetOrderListindex(ModelUsers usinfo)
        {
            string sql = "select o.*,u.UserName from Orders o , Users u where o.UserID = u.UserID and u.UserID=@userid ";

            sql += " ORDER BY o.UserID  OFFSET (@pageindex-1)*@pagesize ROWS FETCH NEXT @pagesize ROWS ONLY";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@userid", usinfo.UserID));
            list.Add(new SqlParameter("@pageindex", usinfo.pageindex));
            list.Add(new SqlParameter("@pagesize", usinfo.pagesize));
            SqlDataReader dr = db.selectDataReader(sql, list);
            List<ModelOrders> odlist = new List<ModelOrders>();
            while (dr.Read())
            {
                ModelOrders moinfo = new ModelOrders();
                moinfo.OrderNum = dr["OrderNum"].ToString();
                moinfo.UserName = dr["UserName"].ToString();
                moinfo.OrderDate = (DateTime)dr["OrderDate"];
                moinfo.OrderMoney = (decimal)dr["OrderMoney"];
                moinfo.OrderState = (int)dr["OrderState"];
                moinfo.OrderID = (int)dr["OrderID"];
                odlist.Add(moinfo);
            }
            return odlist;

        }

        public int GetCount(ModelUsers info)
        {
            string sql = "select COUNT(1) PAGENAME from Orders o , Users u  where o.UserID = u.UserID and o.UserID=@userid ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@userid", info.UserID));
            SqlDataReader dr = db.selectDataReader(sql, list);
            int pagenums = 0;
            while (dr.Read())
            {
                pagenums = (int)dr["PAGENAME"];
            }
            return pagenums;
        }

        public int InsertBookAppraise(ModelBookAppraise info)
        {
            string sql = @"insert into BookAppraise values(@ODID,@BADesc,@BAPoint,getdate())";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@ODID", info.ODID));
            list.Add(new SqlParameter("@BADesc", info.BADesc));
            list.Add(new SqlParameter("@BAPoint", info.BAPoint));
            int i = db.executeNonQuery(sql, list);
            return i;
        }
        public int UpdateBookAppraise(ModelBookAppraise info)
        {
            string sql = @"update Orders set OrderState=4 where OrderID=@ODID";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@ODID", info.ODID));
            int i = db.executeNonQuery(sql, list);
            return i;
        }
        public List<ModelOrderDetail> GetDOrder(string ordernum)
        {
            string sql = "select odd.*,bks.* from OrderDetail odd,Books bks,Orders od where bks.BookID = odd.BookID and odd.OrderID=od.OrderID and od.OrderNum like '%'+@OrderNum+'%'";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@OrderNum", ordernum));
            SqlDataReader dr = db.selectDataReader(sql, list);
            List<ModelOrderDetail> modlist = new List<ModelOrderDetail>();
            while (dr.Read())
            {
                ModelOrderDetail modinfo = new ModelOrderDetail();
                modinfo.ODID = (int)dr["ODID"];
                modinfo.OrderID = (int)dr["OrderID"];
                modinfo.BookID = (int)dr["BookID"];
                modinfo.ODPrice = (decimal)dr["ODPrice"];
                modinfo.ODMoney = (decimal)dr["ODMoney"];
                modinfo.ODCount = (int)dr["ODCount"];
                modinfo.BookTitle = dr["BookTitle"].ToString();
                modlist.Add(modinfo);

            }
            return modlist;
        }

    }
}
