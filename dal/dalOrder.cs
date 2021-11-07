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
    public class dalOrder
    {
        dbhelp db = new dbhelp();
        /// <summary>
        /// 获取新的订单号码
        /// </summary>
        /// <returns></returns>
        public string GetOrderNumber()
        {
            string sql = "select DBO.GetOrderNum()";
            return db.ExecuteScalar(sql).ToString();
        }
        /// <summary>
        /// 保存订单信息，返回生成的订单ID
        /// </summary>
        /// <param name="odinfo"></param>
        /// <param name="dics"></param>
        /// <returns></returns>
        public int InsertOrderInfo(ModelOrders odinfo)
        {
            string sql = @"insert into Orders values(@UserID,@AMID,@OrderNum,getdate(),1,@OrderMoney);select @@IDENTITY";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@UserID", odinfo.UserID));
            list.Add(new SqlParameter("@AMID", odinfo.AMID));
            list.Add(new SqlParameter("@OrderNum", odinfo.OrderNum));
            list.Add(new SqlParameter("@OrderMoney", odinfo.OrderMoney));
            object i = db.ExecuteScalar(sql, list);
            return int.Parse(i.ToString());
        }
        /// <summary>
        /// 保存订单详情
        /// </summary>
        /// <param name="oddinfo"></param>
        /// <returns></returns>
        public int InsertOrderDetail(ModelOrderDetail oddinfo)
        {
            string sql = " insert into OrderDetail values(@OrderID,@BookID,@Odprice,@odcount,@odmoney)";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@OrderID", oddinfo.OrderID));
            list.Add(new SqlParameter("@BookID", oddinfo.BookID));
            list.Add(new SqlParameter("@Odprice", oddinfo.ODPrice));
            list.Add(new SqlParameter("@odcount", oddinfo.ODCount));
            list.Add(new SqlParameter("@odmoney", oddinfo.ODMoney));
            return db.executeNonQuery(sql,list);
        }
    }
}
