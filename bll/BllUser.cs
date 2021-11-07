using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal;
using models;

namespace bll
{
    public class BllUser
    {
        DalUsers du = new DalUsers();
        public ModelUsers login(string name, string pwd)
        {
            return du.login(name,pwd);
        }
        public List<ModelUsers> getUser(ModelUsers info)
        {
            return du.getUser(info);
        }
    }
}
