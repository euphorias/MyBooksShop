<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderDetailPage.aspx.cs" Inherits="Books.admin.OrderDetailPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>订单详情管理</title>
    <%=Styles.Render("~/bundles/UiCss") %>
     <%=Scripts.Render("~/bundles/UiJs") %>
</head>
<body>
    <form id="form1" runat="server">
        <div>
         <p></p>
            <div class="title_right"><span class="pull-right margin-bottom-5"></span><strong>订单详情管理</strong></div>
            <p></p>
             <div style="background-color:#F6F6F6;color:Black;font-weight:bold;font-size:14px;height:30px;line-height:30px;padding:3px 10px">订单信息</div>
           
            <table class="dataTable" style="width:98%">
                <tr>
                    <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px;width:200px">订单编号：</td>
                    <td style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                        <asp:Label ID="ordernum" runat="server" ></asp:Label>
                    </td>
                    <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px;width:200px">订单时间：</td>
                    <td style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                        <asp:Label ID="orderdate" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                     <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px;width:200px">订单总金额：</td>
                    <td style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                        <asp:Label ID="ordermoney" runat="server"></asp:Label>
                    </td>
                    <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px;width:200px">订单状态：</td>
                    <td style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                        <asp:Label ID="ordersate" runat="server" ></asp:Label>
                    </td>
                </tr>  
            </table>
            <p></p>
            <div style="background-color:#F6F6F6;color:Black;font-weight:bold;font-size:14px;height:30px;line-height:30px;padding:3px 10px">购买人信息</div>
           
            <table class="dataTable" style="width:98%">
                <tr>
                    <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px;width:200px">登录账户：</td>
                    <td style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                        <asp:Label ID="Label1" runat="server" ></asp:Label>
                    </td>
                    <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px;width:200px">收货人：</td>
                    <td style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                        <asp:Label ID="Label2" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                     <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px;width:200px">联系电话：</td>
                    <td style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                        <asp:Label ID="Label3" runat="server"></asp:Label>
                    </td>
                    <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px;width:200px">收货地址：</td>
                    <td style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                        <asp:Label ID="Label4" runat="server" ></asp:Label>
                    </td>
                </tr>  
            </table>
            <p></p>
           <div style="background-color:#F6F6F6;color:Black;font-weight:bold;font-size:14px;height:30px;line-height:30px;padding:3px 10px">订单详情信息</div>
            
             <asp:GridView ID="gdvGoodslist" runat="server" AutoGenerateColumns="False" style="width:98%;border-collapse:collapse" CssClass="table table-bordered table-striped table-hover">
                <Columns> 
                    <asp:BoundField DataField="BookTitle" HeaderText="书籍名" />
                    <asp:BoundField DataField="ODPrice" HeaderText="单价" />
                    <asp:BoundField DataField="ODCount" HeaderText ="数量" />     
                     <asp:BoundField DataField="ODMoney" HeaderText ="总金额" />     
                </Columns>
            </asp:GridView>
            
        </div>
        <asp:Button ID="back" runat="server" Text="返回" CssClass="btn btn-info" OnClick="back_Click" />
    </form>
</body>
</html>
