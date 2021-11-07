<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BSCategoryOpenPage.aspx.cs" Inherits="Books.admin.BSCategoryOpenPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>小类别管理</title>
    <%=Styles.Render("~/bundles/UiCss") %>
    <%=Scripts.Render("~/bundles/UiJs") %>
    <script type="text/javascript">
        function CloseUi() {
            var index = parent.layer.getFrameIndex(window.name);
            parent.layer.close(index);
            window.location.reload();
            
        }
    </script>
</head>
<body style="margin:10px">
    <form id="form1" runat="server">
    <table class="table table-bordered" style="width:95%">
        <tr>
            <td>小类别名称：</td>
            <td>
               <asp:TextBox ID="txtBsname" runat="server" CssClass="span1" style="width:200px" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>大类别名称：</td>
            <td>
               <asp:DropDownList ID="dropBl" runat="server"></asp:DropDownList>
            </td>
        </tr>
    </table>
    <div style="text-align:center">
        <asp:Button ID="btnadd" runat="server" Text="确定" CssClass="btn btn-info" OnClick="btnadd_Click"  />
        <input type="button" value="取消" class="btn btn-info" onclick="CloseUi()" />
    </div>
        </form>
</body>
</html>
