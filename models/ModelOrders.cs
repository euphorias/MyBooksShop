using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    public class ModelOrders : ModelUsers
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int AMID { get; set; }
        public string OrderNum { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderState { get; set; }
        public decimal OrderMoney { get; set; }
    }
}
