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
    public partial class OrderPage : System.Web.UI.Page
    {
        bllAdminOrder bao = new bllAdminOrder();
        ModelOrders moinfo = new ModelOrders();
        BllUser blu = new BllUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            //是否首次加载
            if (!IsPostBack)
            {
                //分页绑定数据，传页数，绑总页数文本
                bind(1,int.Parse(ddlpagesize.Text));
                BindLalCount();
            }
        }
        //分页查询
        public void bind(int pageindex,int pagesize)
        {
            moinfo.OrderNum = txtOrderNum.Text.Trim();
            moinfo.UserNick = txtUserName.Text.Trim();
            moinfo.OrderState = int.Parse(dropOrderState.SelectedValue.ToString());
            gdvGoodslist.DataSource = bao.GetOrder(moinfo, pageindex, pagesize);
            gdvGoodslist.DataBind();
        }
        //绑定总页数文本
        public void BindLalCount()
        {
            moinfo.OrderNum = txtOrderNum.Text.Trim();
            moinfo.UserName = txtUserName.Text.Trim();
            moinfo.OrderState = int.Parse(dropOrderState.SelectedValue.ToString());
            int pagenums = bao.GetOrdersCount(moinfo);
            int pagesize = int.Parse(ddlpagesize.Text);
            if (pagenums % pagesize == 0)
            {
                labCount.Text = (pagenums / pagesize).ToString();
            }
            else
            {
                labCount.Text = (pagenums / pagesize + 1).ToString();
            }

        }
        #region 分页
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
                bind(1, int.Parse(ddlpagesize.Text));
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
                ScriptManager.RegisterStartupScript(this, GetType(), "ErroMsg", "layer.msg('当前已经是首页')", true);
                return;
            }
            else
            {
                labCurrent.Text = (int.Parse(labCurrent.Text) - 1).ToString();
                bind(int.Parse(labCurrent.Text), int.Parse(ddlpagesize.Text));
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
                ScriptManager.RegisterStartupScript(this, GetType(), "ErroMsg", "layer.msg('当前已经是尾页')", true);
                return;
            }
            else
            {
                labCurrent.Text = (int.Parse(labCurrent.Text) + 1).ToString();
                bind(int.Parse(labCurrent.Text), int.Parse(ddlpagesize.Text));
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
                bind(int.Parse(labCurrent.Text), int.Parse(ddlpagesize.Text));
            }
        }

        protected void ddlpagesize_SelectedIndexChanged(object sender, EventArgs e)
        {
            labCurrent.Text = "1";
            BindLalCount();
            bind(int.Parse(labCurrent.Text), int.Parse(ddlpagesize.Text));
        }
        #endregion
        //更改订单状态
        protected void gdvGoodslist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "change")
            {
                int ordId = int.Parse(e.CommandArgument.ToString());
                if (bao.UpdateState(ordId) > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessMsg", "layer.msg('成功了',{icon:1})", true);
                    bind(1, int.Parse(ddlpagesize.Text));
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "FailMsg", "layer.msg('失败了',{icon:2})", true);
                    return;
                }
            }
        }

        protected void btnselect_Click(object sender, EventArgs e)
        {
            labCurrent.Text = "1";
            bind(int.Parse(labCurrent.Text), int.Parse(ddlpagesize.Text));
            BindLalCount();
            
        }
    }
}