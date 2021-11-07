using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal;
using models;

namespace bll
{
    public class BLLBooks
    {
        DalBooks db = new DalBooks();
        public List<ModelView_book> GetBooks(ModelSelect info)
        {
            return db.GetBooks(info);
        }
        public int UpdateBookIsBuy(int bookid)
        {
            return db.UpdateBookIsBuy(bookid);
        }
        public int UpdateBookIsHot(int bookid)
        {
            return db.UpdateBookIsHot(bookid);
        }
        public int Insert(ModelBooks info)
        {
            return db.Insert(info);
        }
        public int GetBooksCount(ModelSelect info)
        {
            return db.GetBooksCount(info);
        }
        public int delete(ModelView_book info)
        {
            return db.delete(info);
        }
        public List<ModelView_book> GetBook(ModelView_book info)
        {
            return db.GetBook(info);
        }
        public int update(ModelBooks info)
        {
            return db.update(info);
        }
        public List<ModelView_book> GetBookIsBuyList()
        {
            return db.GetBookIsBuyList();
        }
        public List<ModelView_book> GetBookIsHotList()
        {
            return db.GetBookIsHotList();
        }
        public List<ModelView_book> GetCartList(Dictionary<int,int> dics)
        {
            //session对象为空时,返回集合
            if (dics == null)
            {
                return new List<ModelView_book>();
            }
            //session对象不为空，字典数据为空时，同样返回集合，不做更改
            if (dics.Count == 0)
            {
                return new List<ModelView_book>();
            }
            else
            {
                string ids = "";
                //遍历数据字典的key值进行拼接
                foreach(int id in dics.Keys)
                {
                    ids += id+",";
                }
                //去除字符串尾部的逗号
                ids = ids.TrimEnd(',');
                return db.GetCartList(ids);
            }

        }
    }
}
