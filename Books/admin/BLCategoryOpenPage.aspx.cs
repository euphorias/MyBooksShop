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
    public partial class BLCategoryOpenPage : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["blid"] != "0")
                {
                    txtBlname.Text = Request.QueryString["blname"].ToString();
                }
            }
            
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            BookCategoryBLL bl = new BookCategoryBLL();
            ModelBLCategory mb = new ModelBLCategory();
            if (string.IsNullOrEmpty(txtBlname.Text.Trim()))
            {
                //js脚本管理器可以注册任何js脚本
                ScriptManager.RegisterStartupScript(this, GetType(), "ErroMsg", "layer.msg('大类别名称不能为空',{icon:2})", true);
                return;
            }
            if (Request.QueryString["blid"] != "0")
            {
                //修改

                mb.BLID = int.Parse(Request.QueryString["blid"].ToString());
                mb.BLName = txtBlname.Text.Trim();
                if (bl.update(mb) > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ErroMsg", "layer.msg('编辑成功',{icon:1})", true);
                    Response.Write("<script>var index = parent.layer.getFrameIndex(window.name);parent.layer.close(index);window.parent.location.reload();</script>");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ErroMsg", "layer.msg('编辑失败',{icon:2})", true);
                }
            }
            else
            {
                //新增
                ModelBLCategory info = new ModelBLCategory();
                info.BLName = txtBlname.Text.Trim();
                if (bl.insert(info) > 0)
                {
                    Response.Write("<script> var index = parent.layer.getFrameIndex(window.name);parent.layer.close(index); window.parent.location.reload();</script>");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ErroMsg", "layer.msg('失败',{icon:2})", true);
                }
            }

        }
    }
}