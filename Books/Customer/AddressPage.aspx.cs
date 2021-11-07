using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bll;
using models;

namespace Books.Customer
{
    public partial class AddressPage : System.Web.UI.Page
    {
        BllAddressManager bla = new BllAddressManager();
        public static ModelUsers userinfo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                userinfo = Session["user"] as models.ModelUsers;
                bind();
            }
            
        }
        public void bind()
        {
            int UserID = int.Parse(userinfo.UserID.ToString());
            RepAdd.DataSource = bla.getAddress(UserID);
            RepAdd.DataBind();
        }

        protected void RepAdd_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ModelAddressManager mainfo = new ModelAddressManager();
            int AMID = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "saveChange")
            {
                TextBox AMUser = (TextBox)e.Item.FindControl("txtUser");
                TextBox AMTel = (TextBox)e.Item.FindControl("txtNum");
                TextBox AMAddress = (TextBox)e.Item.FindControl("txtAdr");
                string a= AMUser.Text.Trim();
                mainfo.AMUser = a.ToString();
                mainfo.AMTel = AMTel.Text.Trim();
                mainfo.AMAddress = AMAddress.Text.Trim();
                if (bla.saveChanges(mainfo,AMID) > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "succesmsg", "layer.msg('保存成功！',{icon:1})", true);
                    bind();
                }
            }
            if(e.CommandName == "saveDef")
            {
                if (bla.saveDefault(AMID) > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "succesmsg", "layer.msg('变成默认地址了我丢！',{icon:1})", true);
                    bind();
                }
            }
            if(e.CommandName == "delete")
            {
                if (bla.delete(AMID) > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "succesmsg", "layer.msg('居然删除成功了！',{icon:1})", true);
                    bind();
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ModelAddressManager mainfo = new ModelAddressManager();
            mainfo.UserID = int.Parse(userinfo.UserID.ToString());
            mainfo.AMUser = txtName.Text.Trim();
            mainfo.AMTel = txtTel.Text.Trim();
            mainfo.AMAddress = txtAdd.Text.Trim();
            if (bla.insert(mainfo) > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "succesmsg", "layer.msg('新增成功了！芜湖！',{icon:1})", true);
                bind();
            }

        }
    }
}