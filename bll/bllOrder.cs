using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using models;
using dal;
using System.Transactions;

namespace bll
{
    public class bllOrder
    {
        dalOrder dlo = new dalOrder();
        BLLBooks blb = new BLLBooks();
        /// <summary>
        /// 保存订单主表信息和订单详情信息
        /// </summary>
        /// <returns></returns>
        public string InsertOrdersInfo(ModelOrders odinfo,Dictionary<int,int> dic)
        {
            //获取生成的订单号码
            odinfo.OrderNum = dlo.GetOrderNumber();
            //设置需要保存的订单详细信息列表
            List<ModelOrderDetail> oddlist = new List<ModelOrderDetail>();
            //获取数据字典中购物车内的书籍信息
            List<ModelView_book> mblist = blb.GetCartList(dic);
            //保存详细信息到订单详细信息的集合中
            //遍历集合中的每一个数据
            //并将其保存到订单详细信息中去
            foreach(ModelView_book mbinfo in mblist)
            {
                ModelOrderDetail oddinfo = new ModelOrderDetail();
                oddinfo.BookID = mbinfo.BookID;
                oddinfo.ODCount = dic[mbinfo.BookID];
                oddinfo.ODPrice = mbinfo.BookPrice;
                oddinfo.ODMoney = mbinfo.BookMoney;
                oddlist.Add(oddinfo);
            }
            //开启事务，将保存订单信息事件和保存订单详情事件一起纳入
            //using 使里头的代码变成代码块，再用transactionscope将代码块事务化
            //代码块被执行后将被释放
            using (TransactionScope ts = new TransactionScope())
            {
                //保存订单并获取生成的订单ID
                int order = dlo.InsertOrderInfo(odinfo);
                //遍历订单详情的集合，逐条保存到集合
                foreach(ModelOrderDetail oddinfo in oddlist)
                {
                    oddinfo.OrderID = order;
                    dlo.InsertOrderDetail(oddinfo);
                }
                //提交事务，如果报错则跳出
                ts.Complete();
            }
            return odinfo.OrderNum;
        }
    }
}
