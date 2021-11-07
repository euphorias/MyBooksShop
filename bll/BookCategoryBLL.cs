using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using models;
using dal;

namespace bll
{
    public class BookCategoryBLL
    {
        dalBLCategory sb = new dalBLCategory();
        public List<ModelBLCategory> GetBLCategory()
        {
            return sb.GetBLCategory();
        }
        public int insert(ModelBLCategory info)
        {
            return sb.insert(info);
        }
        public int delete(ModelBLCategory info)
        {
            return sb.Delete(info);
        }
        public int update(ModelBLCategory info)
        {
            return sb.update(info);
        }
    }
}
