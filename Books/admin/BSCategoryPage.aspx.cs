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
    public partial class BSCategoryPage : System.Web.UI.Page
    {
        BookCategoryBLL bbc = new BookCategoryBLL();
        BLLBSCategory bbs = new BLLBSCategory();
        ModelBSCategory info = new ModelBSCategory();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindBLList();
                BindBsGridView(1,int.Parse(ddlpagesize.Text));
                BindLalCount();
            }
        }
        #region 数据绑定
        public void BindBLList()
        {
            List<ModelBLCategory> bllist = bbc.GetBLCategory();
            bllist.Insert(0, new ModelBLCategory { BLID = -1, BLName = "全部" });
            dropBl.DataTextField = "BLName";
            dropBl.DataValueField = "BLID";
            dropBl.DataSource = bllist;
            dropBl.DataBind();
        }
        public void BindBsGridView(int index,int size)
        {
            info.BLID = int.Parse(dropBl.SelectedValue);
            info.BSName = txtBsname.Text.Trim();
            GridView1.DataSource = bbs.GetBSCategoryByPageIndex(info,index,size);
            GridView1.DataBind();
        }
        /// <summary>
        /// 绑定总页数
        /// </summary>
        public void BindLalCount()
        {
            info.BLID = int.Parse(dropBl.SelectedValue);
            info.BSName = txtBsname.Text.Trim();
            int pagenums = bbs.GetBsCategoryCount(info);
            int pagesize = int.Parse(ddlpagesize.Text);
            if(pagenums%pagesize==0)
            {
                labCount.Text = (pagenums / pagesize).ToString();
            }
            else
            {
                labCount.Text = (pagenums / pagesize +1).ToString();
            }

        }
        #endregion
        #region 分页控件
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnHead_Click(object sender, EventArgs e)
        {
            if (labCount.Text == "1")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ErroMsg", "layer.msg('当前已经是首页')", true);
                return;
            }
            else
            {
                labCurrent.Text = "1";
                BindBsGridView(1, int.Parse(ddlpagesize.Text));
            }
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUp_Click(object sender, EventArgs e)
        {
            if (labCurrent.Text == "1")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ErroMsg", "layer.msg('当前已经是第一页')", true);
                return;
            }
            else
            {
                labCurrent.Text = (int.Parse(labCurrent.Text)-1).ToString();
                BindBsGridView(int.Parse(labCurrent.Text),int.Parse(ddlpagesize.Text));
            }
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDown_Click(object sender, EventArgs e)
        {
            if (labCurrent.Text == labCount.Text)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ErroMsg", "layer.msg('当前已经是最后一页')", true);
                return;
            }
            else
            {
                labCurrent.Text = (int.Parse(labCurrent.Text) + 1).ToString();
                BindBsGridView(int.Parse(labCurrent.Text), int.Parse(ddlpagesize.Text));
            }
        }
        /// <summary>
        /// 尾页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEnd_Click(object sender, EventArgs e)
        {
            if (labCurrent.Text == labCount.Text)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ErroMsg", "layer.msg('当前已经是尾页')", true);
                return;
            }
            else
            {
                labCurrent.Text = (int.Parse(labCount.Text)).ToString();
                BindBsGridView(int.Parse(labCurrent.Text), int.Parse(ddlpagesize.Text));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btngo_Click(object sender, EventArgs e)
        {
            if(int.Parse(txtgo.Text) > int.Parse(labCount.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ErroMsg", "layer.msg('总页数一共"+labCount.Text+"页，跳转的页码大于总页数')", true);
                return;
            }
            else if (int.Parse(txtgo.Text) <= 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ErroMsg", "layer.msg('总页数一共" + labCount.Text + "页，跳转的页码不能为0')", true);
                return;
            }
            else if(int.Parse(txtgo.Text) <= int.Parse(labCount.Text))
            {
                labCurrent.Text = txtgo.Text;
                BindBsGridView(int.Parse(labCurrent.Text), int.Parse(ddlpagesize.Text));
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ErroMsg", "layer.msg('请输入数字,nt',{icon:2})", true);
                return;
            }
        }
        #endregion

        
        /// <summary>
        /// 页面更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlpagesize_SelectedIndexChanged(object sender, EventArgs e)
        {
            labCurrent.Text = "1";
            BindLalCount();
            BindBsGridView(int.Parse(labCurrent.Text), int.Parse(ddlpagesize.Text));
        }
        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            labCurrent.Text = "1";
            BindLalCount();
            BindBsGridView(int.Parse(labCurrent.Text), int.Parse(ddlpagesize.Text));
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            info.BSID = int.Parse(e.Keys["BSID"].ToString());
            if (bbs.delete(info) > 0)
            {

                labCurrent.Text = "1";
                BindLalCount();    
                BindBsGridView(int.Parse(labCurrent.Text), int.Parse(ddlpagesize.Text));
                ScriptManager.RegisterStartupScript(this, GetType(), "ErroMsg", "layer.msg('删除成功',{icon:1})", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ErroMsg", "layer.msg('删除失败',{icon:2})", true);
            }
            Response.Write("<script>document.location = document.location</script>");
        }
    }
}