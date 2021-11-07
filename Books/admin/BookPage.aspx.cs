using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using models;
using bll;

namespace Books.admin
{
    public partial class BookPage : System.Web.UI.Page
    {
        BLLBSCategory bsl = new BLLBSCategory();
        BookCategoryBLL bbl = new BookCategoryBLL();
        BLLBooks bkl = new BLLBooks();
        ModelSelect info = new ModelSelect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                BindBLlistBslist();
                BindIsHotIsBuy();
                bindGV();
                BindLalCount();
            }
        }
        #region 绑定数据相关
        #region 绑定大小类别下拉框数据
        public void BindBLlistBslist()
        {

            List<ModelBLCategory> bllist = bbl.GetBLCategory();
            bllist.Insert(0, new ModelBLCategory { BLID = -1, BLName = "全部" });
            List<ModelBSCategory> bslist = bsl.GetBSlist();
            bslist.Insert(0, new ModelBSCategory { BSID = -1, BSName = "全部" });
            dropBL.DataTextField = "BLName";
            dropBL.DataValueField = "BLID";
            dropBL.DataSource = bllist;
            dropBL.DataBind();
            dropBS.DataTextField = "BSName";
            dropBS.DataValueField = "BSID";
            dropBS.DataSource = bslist;
            dropBS.DataBind();

        }
        #endregion
        #region 绑定是否秒杀、热门
        public void BindIsHotIsBuy()
        {
            Dictionary<int, string> dics = new Dictionary<int, string>();
            dics.Add(-1, "全部");
            dics.Add(1, "是");
            dics.Add(0, "否");
            dropBuy.DataTextField = "value";
            dropBuy.DataValueField = "key";
            dropBuy.DataSource = dics;
            dropBuy.DataBind();
            dropHot.DataTextField = "value";
            dropHot.DataValueField = "key";
            dropHot.DataSource = dics;
            dropHot.DataBind();
        }
        #endregion
        #region 分页查询绑定数据
        public void bindGV()
        {
            ModelSelect msinfo = new ModelSelect();
            msinfo.BLID = int.Parse(dropBL.SelectedValue);
            msinfo.BSID = int.Parse(dropBS.SelectedValue);
            msinfo.BookIsBuy = int.Parse(dropBuy.SelectedValue);
            msinfo.BookIsHot = int.Parse(dropHot.SelectedValue);
            msinfo.BookTitle = txtTitle.Text.Trim();
            msinfo.BookPublish = txtPub.Text.Trim();
            msinfo.pageindex = int.Parse(labCurrent.Text.Trim());
            msinfo.pagesize = int.Parse(ddlpagesize.Text);
            GridView1.DataSource = bkl.GetBooks(msinfo);
            GridView1.DataBind();
        }
        #endregion
        #region 绑定总页面文本
        public void BindLalCount()
        {
            info.BLID = int.Parse(dropBL.SelectedValue);
            info.BSID = int.Parse(dropBS.SelectedValue);
            info.BookIsBuy = int.Parse(dropBuy.SelectedValue);
            info.BookIsHot = int.Parse(dropHot.SelectedValue);
            info.BookTitle = txtTitle.Text.Trim();
            info.BookPublish = txtPub.Text.Trim();
            int pagenums = bkl.GetBooksCount(info);
            info.pagesize = int.Parse(ddlpagesize.Text);
            if (pagenums % info.pagesize == 0)
            {
                labCount.Text = (info.pageindex / info.pagesize).ToString();
            }
            else
            {
                labCount.Text = (pagenums / info.pagesize + 1).ToString();
            }

        }
        #endregion
        #endregion
        #region 大类别小类别二级联动
        protected void dropBL_SelectedIndexChanged(object sender, EventArgs e)
        {
            int blid = int.Parse(dropBL.SelectedValue);
            if (blid != -1)
            {
                List<ModelBSCategory> bslist = bsl.GetBsListByBlid(blid);
                bslist.Insert(0, new ModelBSCategory { BSID = -1, BSName = "全部" });
                dropBS.DataTextField = "BSName";
                dropBS.DataValueField = "BSID";
                dropBS.DataSource = bslist;
                dropBS.DataBind();
            }
            else
            {
                List<ModelBSCategory> bslist = bsl.GetBSlist();
                bslist.Insert(0, new ModelBSCategory { BSID = -1, BSName = "全部" });
                dropBS.DataTextField = "BSName";
                dropBS.DataValueField = "BSID";
                dropBS.DataSource = bslist;
                dropBS.DataBind();
            }
        }
        #endregion
        #region 执行单行命令事件
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "upisbuy")
            {
                int bookid = int.Parse(e.CommandArgument.ToString());
                if (bkl.UpdateBookIsBuy(bookid) > 0)
                {
                    bindGV();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ErroMsg", "layer.msg('失败了',{icon:2})", true);
                    return;
                }
            }
            if(e.CommandName == "upishot")
            {
                int bookid = int.Parse(e.CommandArgument.ToString());
                if (bkl.UpdateBookIsHot(bookid) > 0)
                {
                    bindGV();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ErroMsg", "layer.msg('失败了',{icon:2})", true);
                    return;
                }
            }
            if (e.CommandName == "updat")
            {
                int bookid = int.Parse(e.CommandArgument.ToString());
                Response.Redirect("BookOpenPage.aspx?bookid=" + bookid);
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
            if (labCurrent.Text == "1")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ErroMsg", "layer.msg('当前已经是首页')", true);
                return;
            }
            else
            {
                labCurrent.Text = "1";
                bindGV();
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
                labCurrent.Text = (int.Parse(labCurrent.Text) - 1).ToString();
                bindGV();
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
                bindGV();
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
                bindGV();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btngo_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtgo.Text) > int.Parse(labCount.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ErroMsg", "layer.msg('总页数一共" + labCount.Text + "页，跳转的页码大于总页数')", true);
                return;
            }
            else if (int.Parse(txtgo.Text) <= 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ErroMsg", "layer.msg('总页数一共" + labCount.Text + "页，跳转的页码不能为0')", true);
                return;
            }
            else if (int.Parse(txtgo.Text) <= int.Parse(labCount.Text))
            {
                labCurrent.Text = txtgo.Text;
                bindGV();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ErroMsg", "layer.msg('请输入数字,nt',{icon:2})", true);
                return;
            }
        }
        /// <summary>
        /// 页数索引
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlpagesize_SelectedIndexChanged(object sender, EventArgs e)
        {
            labCurrent.Text = "1";
            BindLalCount();
            bindGV();
        }

        #endregion
        #region 查询和删除
        /// <summary>
        /// 分页模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            labCurrent.Text = "1";
            BindLalCount();
            bindGV();
        }
        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ModelView_book bsinfo = new ModelView_book();
            bsinfo.BookID = int.Parse(e.Keys["BookID"].ToString());
            if (bkl.delete(bsinfo) > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ErroMsg", "layer.msg('删除成功',{icon:1})", true);
                labCurrent.Text = "1";
                BindLalCount();
                bindGV();
                
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ErroMsg", "layer.msg('删除失败',{icon:2})", true);
                return;
            }
            Response.Write("<script>document.location = document.location</script>");
        }
        #endregion


    }
}