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
    public partial class BSCategoryOpenPage : System.Web.UI.Page
    {
        BookCategoryBLL bbc = new BookCategoryBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DPBind();
                if (Request.QueryString["bsid"] != "0")
                {
                    string abc = Request.QueryString["blid"].ToString();
                    txtBsname.Text = Request.QueryString["bsname"].ToString();
                    dropBl.Items.FindByValue(abc).Selected = true;
                }
                
            }
        }
        public void DPBind()
        {
            List<ModelBLCategory> bllist = bbc.GetBLCategory();
            dropBl.DataTextField = "BLName";
            dropBl.DataValueField = "BLID";
            dropBl.DataSource = bllist;
            dropBl.DataBind();
        }
        //新增按钮
        protected void btnadd_Click(object sender, EventArgs e)
        {
            BLLBSCategory bl = new BLLBSCategory();
            ModelBSCategory info = new ModelBSCategory();
            if (string.IsNullOrEmpty(txtBsname.Text.Trim()))
            {
                //js脚本管理器可以注册任何js脚本
                ScriptManager.RegisterStartupScript(this, GetType(), "ErroMsg", "layer.msg('小类别名称不能为空',{icon:2})", true);
                return;
            }
            if (Request.QueryString["bsid"] != "0")
            {
                //修改

                info.BSID = int.Parse(Request.QueryString["bsid"].ToString());
                info.BSName = txtBsname.Text.Trim();
                info.BLID = int.Parse(dropBl.SelectedValue);
                if (bl.update(info) > 0)
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
                info.BLID = int.Parse(dropBl.SelectedValue);
                info.BSName = txtBsname.Text.Trim();
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