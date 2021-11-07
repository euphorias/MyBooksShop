using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using models;
using dal;

namespace bll
{
    public class BllAddressManager
    {
        DalAddressManage dla = new DalAddressManage();
        public ModelAddressManager GetUserDefaultAddr(int userid)
        {
            return dla.GetUserDefaultAddr(userid);
        }
        public int InsertAddressInfo(ModelAddressManager info)
        {
            return dla.InsertAddressInfo(info);
        }
        public List<ModelAddressManager> getAddress(int UserID)
        {
            return dla.getAddress(UserID);
        }
        public int saveChanges(ModelAddressManager mainfo,int AMID)
        {
            return dla.saveChanges(mainfo,AMID);
        }
        public int saveDefault(int AMID)
        {
            return dla.saveDefault(AMID);
        }
        public int delete(int AMID)
        {
            return dla.delete(AMID);
        }
        public int insert(ModelAddressManager mainfo)
        {
            return dla.insert(mainfo);
        }
    }
}
