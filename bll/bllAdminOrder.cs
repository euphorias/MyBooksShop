using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using dal;
using models;

namespace bll
{
    public class bllAdminOrder
    {
        dalAdminOrder sb = new dalAdminOrder();
        public List<ModelOrders> GetOrder(ModelOrders moinfo, int pageindex, int pagesize)
        {
            return sb.GetOrder(moinfo,pageindex,pagesize);
        }
        public int GetOrdersCount(ModelOrders info)
        {
            return sb.GetOrdersCount(info);
        }
        public int UpdateState(int orderId)
        {
            return sb.UpdateState(orderId);
        }
        public List<ModelOrderDetail> GetDOrder(int orderID)
        {
            return sb.GetDOrder(orderID);
        }
        public List<ModelOrders> GetOrderInfo(int OrderID)
        {
            return sb.GetOrderInfo(OrderID);
        }
        public List<ModelAddressManager> GetUserInfo(int UserID)
        {
            return sb.GetUserInfo(UserID);
        }
    }
}
