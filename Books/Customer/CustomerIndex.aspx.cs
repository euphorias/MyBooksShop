using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bll;
using models;

namespace Books.Customer
{
    public partial class CustomerIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BLLBooks bb = new BLLBooks();
            if (!IsPostBack)
            {
                repBuy.DataSource = bb.GetBookIsBuyList();
                repBuy.DataBind();
                repHot.DataSource = bb.GetBookIsHotList();
                repHot.DataBind();
            }
        }

        protected void repBuy_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //新建数据字典
            Dictionary<int, int> dic = new Dictionary<int, int>();
            //判断是否已经存在购物数据
            if (Session["books"] != null)
            {
                dic = (Dictionary<int, int>)Session["books"];
            }
            //获取添加的书籍ID
            int bookid = int.Parse(e.CommandArgument.ToString());
            //判断以往的购物车里面是否已经存在同一本书籍的数据
            if (dic.ContainsKey(bookid))
            {
                //存在则寻找bookID对应的书籍数量+1
                dic[bookid] += 1;
            }
            else
            {
                //否则往字典数据中添加一条数据
                dic.Add(bookid,1);
            }
            Session["books"] = dic;
            ScriptManager.RegisterStartupScript(this, GetType(), "Success", "layer.msg('成功了，nt',{icon:6,time:1000})", true);
        }
        protected void repHot_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //新建数据字典
            Dictionary<int, int> dic = new Dictionary<int, int>();
            //判断是否已经存在购物数据
            if (Session["books"] != null)
            {
                dic = (Dictionary<int, int>)Session["books"];
            }
            //获取添加的书籍ID
            int bookid = int.Parse(e.CommandArgument.ToString());
            //判断以往的购物车里面是否已经存在同一本书籍的数据
            if (dic.ContainsKey(bookid))
            {
                //存在则寻找bookID对应的书籍数量+1
                dic[bookid] += 1;
            }
            else
            {
                //否则往字典数据中添加一条数据
                dic.Add(bookid, 1);
            }
            Session["books"] = dic;
            ScriptManager.RegisterStartupScript(this, GetType(), "Success", "layer.msg('成功了，nt',{icon:6,time:1000})", true);
        }
    }
}