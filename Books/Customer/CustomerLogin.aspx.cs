using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bll;
using models;

namespace Books
{
    public partial class CustomerLogin : System.Web.UI.Page
    {
        BllUser bu = new BllUser();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string user = txtName.Text.Trim() ;
            string pwd = txtPWD.Text.Trim();
            string pwdMD5 = MD5Service.GetMD5CodeToString(pwd);
            ModelUsers info = bu.login(user, pwdMD5);
            if (info.UserName!=null)
            {
                Session["user"] = info;
                Response.Redirect("CustomerIndex.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "LoginFail", "layer.msg('登录失败，nt',{icon:2})", true);
                return;
            }
        }
    }
}