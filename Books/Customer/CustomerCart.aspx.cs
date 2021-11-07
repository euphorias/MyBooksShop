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
    public partial class CustomerCart : System.Web.UI.Page
    {
        BLLBooks bb = new BLLBooks();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["books"] != null)
                {
                    bindCart();
                }
            }
        }
        public void bindCart()
        {

            //读取Session
            Dictionary<int, int> dics = (Dictionary<int, int>)Session["books"];
            //绑定购物车数据
            List<ModelView_book> info = bb.GetCartList(dics);
            gdvspcart.DataSource = info;
            gdvspcart.DataBind();
            decimal pricecount = 0;
            decimal moneycount = 0;
            //遍历集合的书籍，计算小计和折扣
            foreach (var item in info)
            {
                int count = dics[item.BookID];
                //累加售价
                pricecount += (decimal)count * item.BookPrice;
                //累加折扣
                moneycount += (decimal)count * item.BookMoney;

            }
            lblprice.Text = string.Format("{0:C}", moneycount);
            lblmoney.Text = string.Format("{0:C}", pricecount);
            lblpd.Text = string.Format("{0:C}", pricecount-moneycount);
        }

        protected void gdvspcart_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //当前行为正常的数据行且不能处于编辑或插入状态
            if(e.Row.RowType == DataControlRowType.DataRow&&
                (e.Row.RowState==DataControlRowState.Normal||e.Row.RowState==DataControlRowState.Alternate))
            {
                //读取售价和折扣价单元格值
                decimal price = decimal.Parse(e.Row.Cells[1].Text);
                decimal money = decimal.Parse(e.Row.Cells[2].Text);
                //显示文本转换成货币格式
                //string.formar("文本格式",格式化的值) {0:C}=>人民币
                e.Row.Cells[1].Text = string.Format("{0:C}", price);
                e.Row.Cells[2].Text = string.Format("{0:C}", money);
                //读取购物车的数据
                Dictionary<int, int> dics = (Dictionary<int, int>)Session["books"];
                //获取每行的书籍ID
                int bookid = (int)gdvspcart.DataKeys[e.Row.RowIndex].Value;
                //通过书籍ID获取字典数据中同本书籍的数量
                int count = dics[bookid];
                //读取显示购物数量的控件
                Label lbcount = (Label)e.Row.FindControl("labAmount");
                lbcount.Text = count.ToString();
                //读取显示小计的控件
                Label labcount = (Label)e.Row.FindControl("labCount");
                labcount.Text = string.Format("{0:C}", money*count);
            }
        }

        protected void gdvspcart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Dictionary<int, int> dics = (Dictionary<int, int>)Session["books"];
            //获取命令源
            Button btn = (Button)e.CommandSource;
            //获取当前命令源所在的行
            GridViewRow rows = btn.Parent.Parent as GridViewRow;
            //获取当前行ID
            int bookid = (int)gdvspcart.DataKeys[rows.RowIndex].Value;
            //加号
            if (e.CommandName == "add")
            {
                dics[bookid] += 1;
            }
            //减号
            if (e.CommandName == "redu")
            {
                if (dics[bookid] > 1)
                {
                    dics[bookid] -= 1;
                }
                //购买书籍数量只有1时，删除记录
                else
                {
                    dics.Remove(bookid);
                }
            }
            //删除
            if (e.CommandName == "remove")
            {
                dics.Remove(bookid);
            }
            //更新Session
            Session["books"] = dics;
            bindCart();

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Dictionary<int, int> dics = (Dictionary<int, int>)Session["books"];
            //清空数据字典里的所有数据
            dics.Clear();
            //更新Session
            Session["books"] = dics;
            bindCart();
        }
    }
}