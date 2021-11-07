using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    public class ModelAddressManager:ModelUsers
    {
        public int AMID { get; set; }
        public int UserID { get; set; }
        public string AMUser { get; set; }
        public string AMTel { get; set; }
        public string AMAddress { get; set; }
        public bool AMMark { get; set; }

    }
}
