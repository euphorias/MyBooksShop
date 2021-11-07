using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using models;
using dal;

namespace bll
{
    public class BllCustomerOrder
    {
        dalCustomerOrder da = new dalCustomerOrder();
        public List<ModelOrders> GetOrderListindex(ModelUsers usinfo)
        {
            return da.GetOrderListindex(usinfo);
        }
        public int GetCount(ModelUsers info)
        {
            return da.GetCount(info);
        }
        public int InsertBookAppraise(ModelBookAppraise info)
        {
            return da.InsertBookAppraise(info);
        }
        public int UpdateBookAppraise(ModelBookAppraise info)
        {
            return da.UpdateBookAppraise(info);
        }
        public List<ModelOrderDetail> GetDOrder(string ordernum)
        {
            return da.GetDOrder(ordernum);
        }
    }
}
