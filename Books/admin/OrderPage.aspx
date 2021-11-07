<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderPage.aspx.cs" Inherits="Books.admin.OrderPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>订单管理</title>
     <%=Styles.Render("~/bundles/UiCss") %>
     <%=Scripts.Render("~/bundles/UiJs") %>
</head>
<body style="margin:10px">
     <form id="form1" runat="server">
        <div>
         <p></p>
            <div class="title_right"><span class="pull-right margin-bottom-5"></span><strong>订单管理</strong></div>
            <p></p> 
           订单编号：<asp:TextBox ID="txtOrderNum" runat="server"></asp:TextBox>
           客户姓名：<asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
           订单状态：<asp:DropDownList ID="dropOrderState" runat="server">
                <asp:ListItem Value="-1">全部</asp:ListItem>
                <asp:ListItem Value="1">待确认</asp:ListItem>
                <asp:ListItem Value="2">已确认</asp:ListItem>
                <asp:ListItem Value="3">已发货</asp:ListItem>
                <asp:ListItem Value="4">已完成</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnselect" runat="server" Text="查询" CssClass="btn btn-info" OnClick="btnselect_Click"   />
         <asp:GridView ID="gdvGoodslist" runat="server" AutoGenerateColumns="False" style="width:98%;border-collapse:collapse" CssClass="table table-bordered table-striped table-hover" DataKeyNames="OrderID" OnRowCommand="gdvGoodslist_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="订单编号">
                            <ItemTemplate>
                                <a href="OrderDetailPage.aspx?oddid=<%# Eval("OrderID")%>&userid=<%# Eval("UserID")%>"><%# Eval("OrderNum")%></a>
                            </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="UserNick" HeaderText="客户名称" />
                    <asp:BoundField DataField="OrderDate" HeaderText="订单时间" />
                    <asp:BoundField DataField="OrderMoney" HeaderText ="总金额" />
                    <asp:TemplateField HeaderText="状态">
                            <ItemTemplate>
                                <asp:Label id="labCount"  runat="server" Text='<%#(int) Eval("OrderState")==1?"待确认":(int) Eval("OrderState")==2?"已确认":(int) Eval("OrderState")==3?"已发货":"完成" %>'></asp:Label>
                            </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                 <asp:LinkButton ID="LinkButton1" runat="server" CommandName="change" CommandArgument='<%#Eval("OrderID") %>' Visible='<%#(int) Eval("OrderState")==4?false:true %>' Text='<%#(int) Eval("OrderState")==1?"确认":(int) Eval("OrderState")==2?"发货":(int) Eval("OrderState")==3?"完成":"不显示" %>'></asp:LinkButton>
                            </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnHead"  runat="server" Text="首页" CssClass="btn btn-info" OnClick="btnHead_Click"  />&nbsp;
            <asp:Button ID="btnUp" runat="server" Text="上一页" CssClass="btn btn-info" OnClick="btnUp_Click" />&nbsp;
            <asp:Button ID="btnDown" runat="server" Text="下一页" CssClass="btn btn-info" OnClick="btnDown_Click"  />&nbsp;
            <asp:Button ID="btnEnd" runat="server" Text="尾页" CssClass="btn btn-info" OnClick="btnEnd_Click"  />
             &nbsp; 记录数:
            <asp:DropDownList ID="ddlpagesize" runat="server" CssClass="span2" style="width:50px" AutoPostBack="True" OnSelectedIndexChanged="ddlpagesize_SelectedIndexChanged"  >
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
            </asp:DropDownList>
            &nbsp;当前页/总页数： 
            <asp:Label ID="labCurrent" runat="server" Text="1"></asp:Label>/
            <asp:Label ID="labCount" runat="server" Text="0"></asp:Label>
    </div>
    </form>
</body>
</html>

