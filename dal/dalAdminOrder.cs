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
    public class dalAdminOrder
    {
        dbhelp db = new dbhelp();
        //绑定订单数据
        public List<ModelOrders> GetOrder(ModelOrders info,int pageindex, int pagesize)
        {
            string sql = "select od.*,us.UserNick from Orders od,Users us where us.UserID=od.UserID and od.OrderNum like '%'+@OrderNum+'%'";
            if (info.UserNick != "")
            {
                sql += " AND us.UserNick = @UserNick ";
            }
            if (info.OrderState != -1)
            {
                sql += " AND od.OrderState = @OrderState ";
            }
            sql += " ORDER BY od.OrderID OFFSET (@pageindex-1)*@pagesize ROWS FETCH NEXT @pagesize ROWS ONLY";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@OrderNum", info.OrderNum));
            list.Add(new SqlParameter("@UserNick", info.UserNick));
            list.Add(new SqlParameter("@OrderState", info.OrderState));
            list.Add(new SqlParameter("@pagesize", pagesize));
            list.Add(new SqlParameter("@pageindex", pageindex));
            SqlDataReader dr = db.selectDataReader(sql, list);
            List<ModelOrders> molist = new List<ModelOrders>();
            while (dr.Read())
            {
                ModelOrders moinfo = new ModelOrders();
                moinfo.OrderID = int.Parse(dr["OrderID"].ToString());
                moinfo.UserID = (int)dr["UserID"];
                moinfo.AMID = (int)dr["AMID"];
                moinfo.OrderNum = dr["OrderNum"].ToString();
                moinfo.OrderDate = Convert.ToDateTime(dr["OrderDate"].ToString());
                moinfo.OrderState = (int)dr["OrderState"];
                moinfo.OrderMoney = (decimal)dr["OrderMoney"];
                moinfo.UserNick = dr["UserNick"].ToString();
                molist.Add(moinfo);
            }
            return molist;
        }
        //获取订单页数文本
        public int GetOrdersCount(ModelOrders info)
        {
            string sql = "select COUNT(1) AS PAGENUMS FROM  Orders od,Users us where us.UserID=od.UserID AND od.OrderNum LIKE '%'+@OrderNum+'%'";
            if (info.UserNick != "")
            {
                sql += " AND us.UserNick = @UserNick ";
            }
            if (info.OrderState != -1)
            {
                sql += " AND od.OrderState = @OrderState ";
            }
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@OrderNum", info.OrderNum));
            list.Add(new SqlParameter("@UserNick", info.UserNick));
            list.Add(new SqlParameter("@OrderState", info.OrderState));
            SqlDataReader dr = db.selectDataReader(sql, list);
            int pagenums = 0;
            while (dr.Read())
            {
                pagenums = int.Parse(dr["PAGENUMS"].ToString());
            }
            return pagenums;
        }
        //更新订单状态
        public int UpdateState(int orderId)
        {
            string sql = "update Orders set OrderState = OrderState + 1 where OrderID = @OrderID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@OrderID", orderId));
            return db.executeNonQuery(sql, list);
        }
        public List<ModelOrderDetail> GetDOrder(int orderID)
        {
            string sql = "select odd.*,bks.* from OrderDetail odd,Books bks where bks.BookID = odd.BookID and OrderID=@OrderID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@OrderID", orderID));
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
        public List<ModelOrders> GetOrderInfo(int OrderID)
        {
            string sql = "select * from Orders where OrderID = @OrderID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@OrderID", OrderID));
            SqlDataReader dr = db.selectDataReader(sql, list);
            //创建订单的数据集合
            List<ModelOrders> mdlist = new List<ModelOrders>();
            while (dr.Read())
            {
                ModelOrders mdinfo = new ModelOrders();
                mdinfo.OrderNum = dr["OrderNum"].ToString();
                mdinfo.OrderState = (int)dr["OrderState"];
                mdinfo.OrderDate = Convert.ToDateTime(dr["OrderDate"]);
                mdinfo.OrderMoney = (decimal)dr["OrderMoney"];
                mdlist.Add(mdinfo);

            }
            return mdlist;
        }
        public List<ModelAddressManager> GetUserInfo(int UserID)
        {
            string sql = "select am.*,us.UserName from Users us,AddressManager am where am.UserID=us.UserID and am.UserID=@UserID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@UserID", UserID));
            SqlDataReader dr = db.selectDataReader(sql, list);
            //创建地址的数据集合
            List<ModelAddressManager> malist = new List<ModelAddressManager>();
            while (dr.Read())
            {
                ModelAddressManager mainfo = new ModelAddressManager();
                mainfo.UserName = dr["UserName"].ToString();
                mainfo.AMUser = dr["AMUser"].ToString();
                mainfo.AMTel = dr["AMTel"].ToString();
                mainfo.AMAddress = dr["AMAddress"].ToString();
                malist.Add(mainfo);

            }
            return malist;
        }
    }
}
