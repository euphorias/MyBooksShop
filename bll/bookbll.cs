using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal;
using models;

namespace bll
{
    public class bookbll
    {
        sbdal zz = new sbdal();
        public int login (string name, string pwd)
        {
            return zz.login(name, pwd);
        }
        public ModelAdmin Register(string username, string pwd)
        {
            return zz.register(username, pwd);
        }
    }
}
