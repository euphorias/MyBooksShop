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
    public partial class BalancePage : UserPage
    {
        BLLBooks bb = new BLLBooks();
        BllAddressManager bla = new BllAddressManager();
        bllOrder blo = new bllOrder();
        public static Dictionary<int, int> dics;
        public static ModelUsers userinfo;
        public static ModelAddressManager adinfo = new ModelAddressManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindCart();
            }
        }
        public void bindCart()
        {

            //读取Session
            dics = (Dictionary<int, int>)Session["books"];
            //绑定购物车数据
            List<ModelView_book> info = bb.GetCartList(dics);
            gdvGoodslist.DataSource = info;
            gdvGoodslist.DataBind();
            decimal moneycount = 0;
            //遍历集合的书籍，计算小计和折扣
            foreach (var item in info)
            {
                int count = dics[item.BookID];
                //累加折扣
                moneycount += (decimal)count * item.BookMoney;

            }
            labSum.Text = string.Format("{0:C}", moneycount);
        }

        protected void gdvGoodslist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //当前行为正常的数据行且不能处于编辑或插入状态
            if (e.Row.RowType == DataControlRowType.DataRow &&
                (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
            {
                //读取售价和折扣价单元格值
                decimal price = decimal.Parse(e.Row.Cells[1].Text);
                decimal money = decimal.Parse(e.Row.Cells[2].Text);
                //显示文本转换成货币格式
                //string.formar("文本格式",格式化的值) {0:C}=>人民币
                e.Row.Cells[1].Text = string.Format("{0:C}", price);
                e.Row.Cells[2].Text = string.Format("{0:C}", money);
                //读取购物车的数据
                dics = (Dictionary<int, int>)Session["books"];
                //获取每行的书籍ID
                int bookid = (int)gdvGoodslist.DataKeys[e.Row.RowIndex].Value;
                //通过书籍ID获取字典数据中同本书籍的数量
                int count = dics[bookid];
                e.Row.Cells[3].Text = count.ToString();
                e.Row.Cells[4].Text = string.Format("{0:C}", money * count);
                
            }
        }
        /// <summary>
        /// 获取用户的默认地址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDefault_Click(object sender, EventArgs e)
        {
            userinfo = Session["user"] as models.ModelUsers;
            ModelAddressManager adinfo = bla.GetUserDefaultAddr(userinfo.UserID);
            //当没有获取到默认地址时
            if(adinfo.AMID == 0)
            {
                //启用控件
                txtTel.Enabled = true;
                txtName.Enabled = true;
                txtAddress.Enabled = true;
            }
            //否则回写数据，禁用控件
            else
            {
                //获取默认地址
                txtAddress.Text = adinfo.AMAddress;
                txtName.Text = adinfo.AMUser;
                txtTel.Text = adinfo.AMTel;
                //并禁用控件
                txtTel.Enabled = false;
                txtName.Enabled = false;
                txtAddress.Enabled = false;
            }
        }
        /// <summary>
        /// 提交订单按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEnter_Click(object sender, EventArgs e)
        {
            dics = (Dictionary<int, int>)Session["books"];
            userinfo = Session["user"] as models.ModelUsers;
            //当用户不使用默认地址，或不写地址时
            if (txtAddress.Text.Trim()==""|| txtName.Text.Trim() == ""|| txtTel.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SubmitFail", "layer.msg('地址是空的，nt',{icon:2,time:1000})", true);
                return;
            }
            if(adinfo.AMID == 0) 
            {
                ModelAddressManager mainfo = new ModelAddressManager();
                mainfo.UserID = userinfo.UserID;
                mainfo.AMAddress = txtAddress.Text.Trim();
                mainfo.AMTel = txtTel.Text.Trim();
                mainfo.AMUser = txtName.Text.Trim();
                adinfo.AMID = bla.InsertAddressInfo(mainfo);
                
            }
            //将订单信息传递给实体类
            ModelOrders odinfo = new ModelOrders();
            odinfo.UserID = userinfo.UserID;
            odinfo.AMID = adinfo.AMID;
            //截取小计人民币符号后面的数字
            odinfo.OrderMoney = decimal.Parse( labSum.Text.Substring(1));
            //保存订单
            string ordernum = blo.InsertOrdersInfo(odinfo, dics);
            //清空购物车并移除session，清空数据字典
            Session.Remove("books");
            dics.Clear();
            //跳转页面
            Response.Redirect("BalanceDone.aspx?ordernum="+ordernum);
            Response.End();
            


        }
    }
}