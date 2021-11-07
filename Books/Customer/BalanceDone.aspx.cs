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
    public partial class BalanceDone : System.Web.UI.Page
    {
        BllCustomerOrder blo = new BllCustomerOrder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                labNum.Text = Request.QueryString["ordernum"].ToString();
                bindBook();
            }
        }
        public void bindBook()
        {
            ModelOrderDetail modinfo = new ModelOrderDetail();
            string OrderNum = Request.QueryString["ordernum"].ToString();
            gdvGoodslist.DataSource = blo.GetDOrder(OrderNum);
            gdvGoodslist.DataBind();
        }
    }
}