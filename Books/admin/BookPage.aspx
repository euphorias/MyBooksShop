<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookPage.aspx.cs" Inherits="Books.admin.BookPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <%=Styles.Render("~/bundles/UiCss") %>
    <%=Scripts.Render("~/bundles/UiJs") %>
    <style type="text/css">
        .auto-style1 {
            width: 77px;
        }
    </style>
    <script type="text/javascript">
        function openWin() {
            window.location.href = "BookOpenPage.aspx?bookid=0";
        }
    </script>
</head>
<body style="overflow:auto">
    <form id="form1" runat="server">
        <div class="title_right"><span class="pull-right margin-bottom-5"></span><strong>书籍管理</strong></div>
        <table style="width:700px;margin:10px 0px;padding:5px 2px">
        <tr>
            <td>书籍名称：</td>
            <td><asp:TextBox ID="txtTitle" runat="server" CssClass="span2"></asp:TextBox></td>
            <td >大类别：</td>
            <td class="auto-style1">
                <asp:DropDownList ID="dropBL" runat="server" CssClass="span2" style="height:25px" AutoPostBack="True" OnSelectedIndexChanged="dropBL_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td >小类别：</td>
            <td>
                <asp:DropDownList ID="dropBS" runat="server" CssClass="span2" style="height:25px"></asp:DropDownList>
            </td>
            <td></td>
        </tr>
        <tr>
            <td >出版社：</td>
            <td><asp:TextBox ID="txtPub" runat="server" CssClass="span2"></asp:TextBox></td>
            <td >是否秒杀：</td>
            <td class="auto-style1">
                <asp:DropDownList ID="dropBuy" runat="server" CssClass="span2" style="height:25px"></asp:DropDownList>
            </td>
            <td >是否热门：</td>
            <td>
                <asp:DropDownList ID="dropHot" runat="server" CssClass="span2" style="height:25px"></asp:DropDownList>
            </td>
        </tr>
    </table>
    <asp:Button ID="btnSelect" runat="server" Text="查询" CssClass="btn btn-info" OnClick="btnSelect_Click"/>
    <input type="button" value="新增书籍" class="btn btn-info" onclick="openWin()"/>
    <p />
        &nbsp;&nbsp;&nbsp;
        <asp:GridView ID="GridView1" runat="server" style="width:90%" CssClass="table table-bordered table-striped table-hover" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" DataKeyNames="BookID" OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:BoundField DataField="BookTitle" HeaderText="书籍名" />
                <asp:BoundField DataField="BLName" HeaderText="大类别" />
                <asp:BoundField DataField="BSName" HeaderText="小类别" />
                <asp:BoundField DataField="BookPublish" HeaderText="出版社" />
                <asp:BoundField DataField="BookMoney" HeaderText="标价" />
                <asp:BoundField DataField="BookPrice" HeaderText="售价" />
                <asp:BoundField DataField="BookSale" HeaderText="销售数量" />
                <asp:BoundField DataField="BookDeport" HeaderText="库存数量" />
                <asp:TemplateField HeaderText="是否秒杀">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton3" runat="server" Text='<%# Eval("BookIsBuy").ToString()=="False"?"否":"是" %>' CommandArgument='<%# Eval("BookId") %>' CommandName="upisbuy"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="是否热门">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton4" runat="server" Text='<%# Eval("BookIsHot").ToString()=="False"?"否":"是" %>' CommandArgument='<%# Eval("BookId") %>' CommandName="upishot"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1"  runat="server" CommandName="updat" CommandArgument='<%# Eval("BookID") %>'>编辑</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="delete" OnClientClick="return confirm('确认删除')">删除</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
         <div style="text-align:left;width:90%">
            <asp:Button ID="btnHead" runat="server" Text="首页" CssClass="btn btn-info" OnClick="btnHead_Click" />
            <asp:Button ID="btnUp" runat="server" Text="上一页" CssClass="btn btn-info" OnClick="btnUp_Click"/>
            <asp:Button ID="btnDown" runat="server" Text="下一页" CssClass="btn btn-info" OnClick="btnDown_Click"/>
            <asp:Button ID="btnEnd" runat="server" Text="尾页" CssClass="btn btn-info" OnClick="btnEnd_Click"/>
		    &nbsp; 
            <asp:Button ID="btngo" runat="server" Text="跳转到:" CssClass="btn btn-info" OnClick="btngo_Click"/>
            <asp:TextBox ID="txtgo" runat="server" Text="1" Width="29px"></asp:TextBox>
            &nbsp; 记录数:
            <asp:DropDownList ID="ddlpagesize" runat="server" CssClass="span2" style="width:50px" AutoPostBack="True" OnSelectedIndexChanged="ddlpagesize_SelectedIndexChanged">
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>30</asp:ListItem>
                <asp:ListItem>40</asp:ListItem>
                <asp:ListItem>50</asp:ListItem>
            </asp:DropDownList>
            &nbsp;当前页/总页数： 
            <asp:Label ID="labCurrent" runat="server" Text="1"></asp:Label>/
            <asp:Label ID="labCount" runat="server" Text="0"></asp:Label>
        </div>
    </form>
</body>
</html>