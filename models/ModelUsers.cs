using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    public class ModelUsers
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public string UsrEmail { get; set; }
        public string UserSex { get; set; }
        public string UserNick { get; set; }
        public int pageindex { get; set; }
        public int pagesize { get; set; }
    }
}
