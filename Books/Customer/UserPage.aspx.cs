using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Books.Customer
{
    public partial class UserPage : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (Session["user"] == null)
            {
                Response.Redirect("CustomerLogin.aspx");
                Response.End();
            }
        }
    }
}