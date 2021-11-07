using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bll;
using models;

namespace Books.Master
{
    public partial class Master : System.Web.UI.MasterPage
    {
        BookCategoryBLL bbl =new BookCategoryBLL();
        BLLBSCategory bsl = new BLLBSCategory();
        List<ModelBSCategory> bslist = new List<ModelBSCategory>();

        protected void Page_Load(object sender, EventArgs e)
        {
            bslist = bsl.GetBSlist();
            repHead.DataSource = bbl.GetBLCategory();
            repHead.DataBind();
            repLeft.DataSource = bbl.GetBLCategory();
            repLeft.DataBind();
        }

        protected void repLeft_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //判断当前行是否为数据行
            if(e.Item.ItemType==ListItemType.Item|| e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //读取repLeft每行绑定的数据
                ModelBLCategory blinfo = e.Item.DataItem as ModelBLCategory;
                //获取blid
                int blid = blinfo.BLID;
                //通过id查找repLeft对应的内嵌控件
                Repeater repeat = e.Item.FindControl("repInter") as Repeater;
                //访问集合绑定数据(不用访问数据库)
                repeat.DataSource = bslist.Where(sb => sb.BLID == blid);
                repeat.DataBind();

            }
        }
    }
}