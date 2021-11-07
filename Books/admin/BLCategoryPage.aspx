<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BLCategoryPage.aspx.cs" Inherits="Books.admin.BLCategoryPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    

<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>书籍大类别管理</title>
    <%=Styles.Render("~/bundles/UiCss") %>
    <%=Scripts.Render("~/bundles/UiJs") %>
    <script type="text/javascript">
        function OpenWin(blid,blname) {
            layer.open({
                type: 2,
                title:"大类别管理",
                  content:['BLCategoryOpenPage.aspx?blid='+blid+"&blname="+blname,'no'],
                  skin:"layui-layer-molv",
                  area: ['600px', '300px'],
                  offset:'auto'
            })
        }

    </script>
</head>
<body style="margin:10px">
    <form id="form1" runat="server">
    <div class="title_right"><span class="pull-right margin-bottom-5"></span><strong>书籍大类别管理</strong></div>
    <input type="button" value="新增大类别" class="btn btn-info" onclick="OpenWin(0,0)"/>
    <p></p>
    <asp:GridView ID="gdvbl" runat="server" Width="400px" AutoGenerateColumns="False"  CssClass="table table-bordered table-striped table-hover" DataKeyNames="BLID" OnRowDeleting="gdvbl_RowDeleting">
        <Columns>
            <asp:BoundField DataField="BLName" HeaderText="大类别名称" />
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <a onclick="OpenWin('<%# Eval("BLID") %>','<%# Eval("BLName") %>')">编辑</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton1" runat="server" Text="删除类别" CommandName="delete" OnClientClick="return confirm('确认删除')"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView>
    </form>
</body>
</html>













