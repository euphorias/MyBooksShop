using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//引用绘图库
using System.Drawing;

namespace Books.admin
{
    public partial class ValidateCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //打开一个图片对象；
            System.Drawing.Image im = System.Drawing.Image.FromFile(Server.MapPath("../Content/Images/vali.jpg"));
            //创建绘图的工具；
            Graphics gc = Graphics.FromImage(im);
            //生成绘制的内容，四位数的随机数
            Random rd = new Random();
            int code = rd.Next(1000, 10000);
            //将随机数保存到session
            Session["ValideCode"] = code;
            //绘制验证码；
            gc.DrawString(code.ToString(), new Font("楷体", 20), new SolidBrush(Color.Black), 0, 0);
            //保存验证码，输出为HTTP响应流
            im.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            //设置客户端响应类型
            Response.ContentType = "image/jpeg";
            //图片输出完毕时，结束页面输出；
            Response.End();
        }
    }
}