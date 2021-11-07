using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal;
using models;

namespace bll
{
    public class BLLBSCategory
    {
        DalBSCategory ds = new DalBSCategory();
        public List<ModelBSCategory> GetBSCategoryByPageIndex(ModelBSCategory info,int pageindex,int pagesize)
        {
            return ds.GetBSCategoryByPageIndex(info,pageindex,pagesize);
        }
        public int GetBsCategoryCount(ModelBSCategory info)
        {
            return ds.GetBsCategoryCount(info);
        }
        public int insert(ModelBSCategory info)
        {
            return ds.insert(info);
        }
        public int update(ModelBSCategory info)
        {
            return ds.update(info);
        }
        public int delete(ModelBSCategory info)
        {
            return ds.Delete(info);
        }
        public List<ModelBSCategory> GetBSlist()
        {
            return ds.GetBSlist();
        }
        public List<ModelBSCategory> GetBsListByBlid(int blid)
        {
            return ds.GetBsListByBlid(blid);
        }
    }
}
