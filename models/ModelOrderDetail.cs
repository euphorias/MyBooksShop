using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    public class ModelOrderDetail:ModelBooks
    {
        public int ODID { get; set; }
        public int OrderID { get; set; }
        public int BookID { get; set; }
        public decimal ODPrice { get; set; }
        public int ODCount { get; set; }
        public decimal ODMoney { get; set; }
    }
}
