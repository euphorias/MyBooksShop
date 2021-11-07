using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using models;
using bll;

namespace Books.Customer
{
    public partial class CustomerOrderPage : UserPage
    {
        public static ModelUsers userinfo = new ModelUsers();
        BllCustomerOrder blo = new BllCustomerOrder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                userinfo = Session["user"] as ModelUsers;
                BindOrder();
                binglabsda();
            }


        }

        public void binglabsda()
        {
            ModelUsers userinfo = Session["user"] as ModelUsers;
            int pagenums = blo.GetCount(userinfo);
            if (pagenums % 10 == 0)
            {
                labCount.Text = (pagenums / 10).ToString();
            }
            else
            {
                labCount.Text = (pagenums / 10 + 1).ToString();
            }
        }
        public void BindOrder()
        {
            ModelUsers userinfo = Session["user"] as ModelUsers;
            userinfo.pageindex = int.Parse(labCurrent.Text.Trim());
            userinfo.pagesize = 10;
            List<ModelOrders> info = blo.GetOrderListindex(userinfo);
            GridView1.DataSource = info;
            GridView1.DataBind();

        }
        //首页
        protected void btnHead_Click(object sender, EventArgs e)
        {
            if (labCurrent.Text == "1")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('当前首页')", true);
                return;
            }
            else
            {
                labCurrent.Text = "1";
                BindOrder();
            }

        }
        //上一页
        protected void btnUp_Click(object sender, EventArgs e)
        {
            if (labCurrent.Text == "1")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('当前首页')", true);
                return;
            }
            else
            {
                labCurrent.Text = (int.Parse(labCurrent.Text) - 1).ToString();
                BindOrder();
            }
        }
        //下一页
        protected void btnDown_Click(object sender, EventArgs e)
        {
            if (labCurrent.Text == labCount.Text)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('当前尾页')", true);
                return;
            }
            else
            {
                labCurrent.Text = (int.Parse(labCurrent.Text) + 1).ToString();
                BindOrder();
            }
        }
        //尾页
        protected void btnEnd_Click(object sender, EventArgs e)
        {
            if (labCurrent.Text == labCount.Text)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('当前尾页')", true);
                return;
            }
            else
            {
                labCurrent.Text = labCount.Text;
                BindOrder();
            }
        }
    }
}