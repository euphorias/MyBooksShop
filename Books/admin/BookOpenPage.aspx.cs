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
    public partial class BookOpenPage : System.Web.UI.Page
    {
        BLLBSCategory bsl = new BLLBSCategory();
        BookCategoryBLL bbl = new BookCategoryBLL();
        BLLBooks bkl = new BLLBooks();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBLlistBslist();
                if (Request.QueryString["bookid"] != "0")
                {
                    ModelView_book msinfo = new ModelView_book();
                    msinfo.BookID = int.Parse(Request.QueryString["bookid"].ToString());
                    List<ModelView_book> bklist = bkl.GetBook(msinfo);
                    if (bklist.Count > 0)
                    {
                        txtIsbn.Enabled = false;
                        foreach(var item in bklist)
                        {
                            txtTitle.Text = item.BookTitle;
                            txtAuthor.Text = item.BookAuthor;
                            int abc = item.BSID;
                            dropBS.Items.FindByValue(abc.ToString()).Selected = true;
                            txtPub.Text = item.BookPublish;
                            txtIsbn.Text = item.ISBN;
                            txtPrice.Text = item.BookPrice.ToString();
                            txtMoney.Text = item.BookMoney.ToString();
                            txtBookCount.Text = item.BookCount.ToString();
                            txtBookDeport.Text = item.BookDeport.ToString();
                            txtBookDesc.InnerText = item.BookDesc;
                            txtAuthorDesc.InnerText = item.BookAuthorDesc;
                            txtBookComm.InnerText = item.BookComm;
                            txtContent.Text = item.BookContent;
                        }
                    }
                }
            }
        }
        #region 绑定大小类别下拉框数据
        public void BindBLlistBslist()
        {

            List<ModelBLCategory> bllist = bbl.GetBLCategory();
            List<ModelBSCategory> bslist = bsl.GetBSlist();
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
        #region 大类别小类别二级联动
        protected void dropBL_SelectedIndexChanged(object sender, EventArgs e)
        {
            int blid = int.Parse(dropBL.SelectedValue);
            List<ModelBSCategory> bslist = bsl.GetBsListByBlid(blid);
            dropBS.DataTextField = "BSName";
            dropBS.DataValueField = "BSID";
            dropBS.DataSource = bslist;
            dropBS.DataBind();
        }
        #endregion
        #region 保存新增新书
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ModelBooks mb = new ModelBooks();
            mb.BSID = int.Parse(dropBS.SelectedValue.Trim());
            mb.BookTitle = txtTitle.Text.Trim();
            mb.BookAuthor = txtAuthor.Text.Trim();
            mb.BookPublish = txtPub.Text.Trim();
            mb.ISBN = txtIsbn.Text.Trim();
            mb.BookPrice = decimal.Parse(txtPrice.Text.Trim());
            mb.BookMoney = decimal.Parse(txtMoney.Text.Trim());
            mb.BookCount = int.Parse(txtBookCount.Text.Trim());
            mb.BookDeport = int.Parse(txtBookDeport.Text.Trim());
            mb.BookDesc = txtBookDesc.InnerText;
            mb.BookAuthorDesc = txtAuthorDesc.InnerText;
            mb.BookComm = txtBookComm.InnerText;
            mb.BookContent = txtContent.Text.Trim();
            if (Request.QueryString["bookid"] != "0") 
            {
                int bookid = int.Parse(Request.QueryString["bookid"].ToString());
                mb.BookID = bookid;
                //获取文件类型
                string[] type = { ".jpg", ".jpeg", ".png", ".gif" };
                string filename = FileUpload1.FileName;
                string filetype = filename.Substring(filename.IndexOf('.'));
                //判断上传图片是否为指定类型
                if (!type.Contains(filetype))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ErrorMsg", "layer.msg('上传图片类型不对啊大哥',{icon:2})", true);
                    return;
                }
                if (bkl.update(mb) > 0)
                {
                    if (FileUpload1.FileContent != null)
                    {
                        //上传图片
                        FileUpload1.SaveAs(Server.MapPath("../Content/BookImages/" + txtIsbn.Text + filetype));
                    }
                    Response.Redirect("BookPage.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "errormsg", "layer.msg('修改失败！',{icon:2})", true);
                    return;
                }
            }
            else
            {   
                string[] type = { ".jpg", ".jpeg", ".png", ".gif" };
                string filename = FileUpload1.FileName;
                string filetype = filename.Substring(filename.IndexOf('.'));
                //判断上传图片是否为指定类型
                if (!type.Contains(filetype))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ErrorMsg", "layer.msg('上传图片类型不对啊大哥',{icon:2})", true);
                    return;
                }
                if (bkl.Insert(mb) > 0)
                {
                    //上传图片
                    FileUpload1.SaveAs(Server.MapPath("../Content/BookImages/" + txtIsbn.Text + filetype));
                    Response.Redirect("BookPage.aspx");
                }
                //判断图片大小是否超过指定值
                else if(FileUpload1.PostedFile.ContentLength>1024*1024*5)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "errormsg", "layer.msg('上传图片大小太大了！',{icon:2})", true);
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "errormsg", "layer.msg('失败了',{icon:2})", true);
                }
            }
        }
        #endregion
    }
}