using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bll;
using System.Drawing;

namespace Books.admin
{
    public partial class Log_in : System.Web.UI.Page
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
            //验证码判断
            string valicode = txtCode.Text.Trim();

            if (nt.login(yhm, pwdMD5) > 0 && valicode == Session["ValideCode"].ToString())
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "LoginSuccess", "layer.msg('你是撒比',{icon:1})", true);
                Session["user"] = yhm;
                Response.Redirect("index.aspx");
            }
            else if (valicode != Session["ValideCode"].ToString())
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "LoginFail", "layer.msg('验证码输错了，nt',{icon:2})", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "LoginFail", "layer.msg('用户名或密码输错了，nt',{icon:2})", true);
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("register.aspx");
        }
    }
}