using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bll;

namespace Books.admin
{
    public partial class register : System.Web.UI.Page
    {
        bookbll nt = new bookbll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            string yhm = txtUser.Text.ToString();
            string pwd = txtPwd.Text.ToString();
            string pwdMD5 = MD5Service.GetMD5CodeToString(pwd);
            if (nt.Register(yhm, pwdMD5)!=null)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "LoginSuccess", "layer.msg('你是撒比',{icon:1})", true);
                Response.Redirect("log_in.aspx");
            }
        }
    }
}