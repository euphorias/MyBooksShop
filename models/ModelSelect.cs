using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    public class ModelSelect
    {
        public int BookID { get; set; }
        public string BookTitle { get; set; }
        public string BookPublish{ get; set; }
        public int BLID { get; set; }

        public int BSID { get; set; }

        public int BookIsBuy { get; set; }
        public int BookIsHot { get; set; }

        public int pageindex { get; set; }
        public int pagesize { get; set; }
    }
}
