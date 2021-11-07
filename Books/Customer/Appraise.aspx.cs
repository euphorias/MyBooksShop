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
    public partial class Appraise : System.Web.UI.Page
    {
        BllCustomerOrder bod = new BllCustomerOrder();
        ModelBookAppraise mba = new ModelBookAppraise();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            string orderid = Request.QueryString["orderid"].ToString();
            string BAPoint = ddlPoint.SelectedValue;
            string BADesc = txtDesc.Text.Trim();
            mba.ODID = int.Parse(orderid);
            mba.BADesc = BADesc.ToString();
            mba.BAPoint = int.Parse(BAPoint);
            if (txtDesc.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ErroMsg", "layer.msg('评论不为空',{icon:2})", true);
                return;
            }
            else
            {
                int b = bod.UpdateBookAppraise(mba);
                int i = bod.InsertBookAppraise(mba);
                if (i > 0)
                {
                    Response.Redirect("CustomerOrderPage.aspx");
                }
            }


        }
    }
}