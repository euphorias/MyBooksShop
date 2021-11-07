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
    public partial class BLCategoryPage : System.Web.UI.Page
    {
        BookCategoryBLL bl = new BookCategoryBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gdvbl.DataSource = bl.GetBLCategory();
                gdvbl.DataBind();
            }
        }

        protected void gdvbl_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ModelBLCategory info = new ModelBLCategory();
            info.BLID = int.Parse(e.Keys["BLID"].ToString());
            if (bl.delete(info)>0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ErroMsg", "layer.msg('删除成功',{icon:1})", true);
                gdvbl.DataSource = bl.GetBLCategory();
                gdvbl.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ErroMsg", "layer.msg('删除失败',{icon:2})", true);
            }
            Response.Write("<script>document.location = document.location</script>");
        }
    }
}