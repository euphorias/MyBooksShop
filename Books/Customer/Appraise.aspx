<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Appraise.aspx.cs" Inherits="Books.Customer.Appraise" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
            <div style="background-color: #F6F6F6; color: Black; font-weight: bold; font-size: 14px; height: 30px; line-height: 30px; padding: 3px 10px">书籍评价</div>
            <p></p>
            <table class="dataTable" style="width: 98%">
                <tr>
                    <td style="text-align: right; height: 30px; line-height: 30px; padding: 0px 8px">评分</td>
                    <td style="text-align: left; height: 30px; line-height: 30px; padding: 0px 8px">
                        <asp:DropDownList ID="ddlPoint" runat="server">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; height: 30px; line-height: 30px; padding: 0px 8px">评价</td>
                    <td colspan="3" style="text-align: left; height: 30px; line-height: 30px; padding: 0px 8px">
                        <asp:TextBox ID="txtDesc" style="width: 90%" runat="server" Rows="10" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; height: 30px; line-height: 30px; padding: 0px 8px">&nbsp;</td>
                    <td colspan="3" style="text-align: left; height: 30px; line-height: 30px; padding: 0px 8px">
                        <asp:Button ID="btnEnter" runat="server" Text="确定" OnClick="btnEnter_Click"/>&nbsp;
                        <input type="button" value="取消"   />
                    </td>
                </tr>
            </table>
        </div>
        </div>
    </form>
</body>
</html>
