<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BSCategoryPage.aspx.cs" Inherits="Books.admin.BSCategoryPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <%= Styles.Render("~/bundles/UICss") %>
    <%= Scripts.Render("~/bundles/UIJS") %>
    <script type="text/javascript">
        function URLencode(sStr) {
            return escape(sStr).replace(/\+/g, '%2B').replace(/\"/g, '%22').replace(/\'/g, '%27').replace(/\//g, '%2F');
        }
        
        function OpenWin(bsid, bsname, blid) {
            var str = URLencode(bsname);
            layer.open({
                type: 2,
                title:"大类别管理",
                content: ['BSCategoryOpenPage.aspx?bsid=' + bsid + "&bsname=" + str + "&blid=" + blid,'no'],
                  skin:"layui-layer-molv",
                  area: ['600px', '300px'],
                  offset:'auto'
            })
        }
        

    </script>
</head>
<body style="margin:10px">
    <form id="form1" runat="server">
    <div class="title_right"><span class="pull-right margin-bottom-5"></span><strong>书籍小类别管理</strong></div>
    <table style="margin:10px 0px;padding:5px 2px">
        <tr>
            <td>所属大类别：</td>
            <td>
                <asp:DropDownList ID="dropBl" runat="server"></asp:DropDownList>
            </td>
            <td>小类别名称：</td>
            <td>
                <asp:TextBox ID="txtBsname" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" Text="查询" CssClass="btn btn-info" OnClick="btnSearch_Click" /></td>
        </tr>
    </table>
    <input type="button" value="新增小类别" class="btn btn-info" onclick="OpenWin(0,0,0)"/>
    <p />
        <div>
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-striped table-hover" Width="352px" AutoGenerateColumns="False" DataKeyNames="BSID" OnRowDeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="BSName" HeaderText="小类别名称" />
                    <asp:BoundField DataField="BLName" HeaderText="所属大类别" />
                    <asp:TemplateField HeaderText="操作" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <a onclick="OpenWin('<%# Eval("BSID") %>','<%# Eval("BSName")%>','<%# Eval("BLID") %>')">编辑</a>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="delete" OnClientClick="return confirm('确认删除')">删除</asp:LinkButton>
                        </ItemTemplate><ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div style="text-align:left;width:90%">
            <asp:Button ID="btnHead" runat="server" Text="首页" CssClass="btn btn-info" OnClick="btnHead_Click" />
            <asp:Button ID="btnUp" runat="server" Text="上一页" CssClass="btn btn-info" OnClick="btnUp_Click" />
            <asp:Button ID="btnDown" runat="server" Text="下一页" CssClass="btn btn-info" OnClick="btnDown_Click" />
            <asp:Button ID="btnEnd" runat="server" Text="尾页" CssClass="btn btn-info" OnClick="btnEnd_Click" />
		    &nbsp; 
            <asp:Button ID="btngo" runat="server" Text="跳转到:" CssClass="btn btn-info" OnClick="btngo_Click" />
            <asp:TextBox ID="txtgo" runat="server" Text="1" Width="29px"></asp:TextBox>
            &nbsp; 记录数:
            <asp:DropDownList ID="ddlpagesize" runat="server" CssClass="span2" style="width:50px" AutoPostBack="True" OnSelectedIndexChanged="ddlpagesize_SelectedIndexChanged" >
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

