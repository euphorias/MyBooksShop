using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bll;
using models;

namespace Books.admin
{
    public partial class OrderDetailPage : System.Web.UI.Page
    {
        BllUser blu = new BllUser();
        bllAdminOrder bla = new bllAdminOrder();
        protected void Page_Load(object sender, EventArgs e)
        {
            //首次加载页面
            if (!IsPostBack)
            {
                //获取querystring 的值并且初始化订单详情的文本
                int orderID = int.Parse(Request.QueryString["oddid"].ToString());
                int userID = int.Parse(Request.QueryString["userid"].ToString());
                bindBook();
                List<ModelOrders> mdlist = bla.GetOrderInfo(orderID);
                List<ModelAddressManager> malist = bla.GetUserInfo(userID);
                if (mdlist.Count > 0&&malist.Count>0)
                { 
                    foreach(var item in mdlist)
                    {
                        ordernum.Text = item.OrderNum;
                        ordersate.Text = item.OrderState.ToString();
                        orderdate.Text = item.OrderDate.ToString();
                        ordermoney.Text = item.OrderMoney.ToString();
                    }
                    foreach (var item in malist)
                    {
                        Label1.Text = item.UserName;
                        Label2.Text = item.AMUser;
                        Label3.Text = item.AMTel;
                        Label4.Text = item.AMAddress;
                    }
                }
                
            }

        }
        //绑数据
        public void bindBook()
        {
            ModelOrderDetail modinfo = new ModelOrderDetail();
            int odID = int.Parse(Request.QueryString["oddid"].ToString());
            gdvGoodslist.DataSource = bla.GetDOrder(odID);
            gdvGoodslist.DataBind();
        }
        //返回
        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderPage.aspx");
        }
    }
}