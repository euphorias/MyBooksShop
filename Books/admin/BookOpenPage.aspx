<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookOpenPage.aspx.cs" ValidateRequest="false" Inherits="Books.admin.BookOpenPage" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <%= Styles.Render("~/bundles/UICss") %>    
    <%= Scripts.Render("~/bundles/UIJS") %>
    
    <script src="../Content/ckeditor/ckeditor.js"></script>
    <style type="text/css">
        .btn-info {
            height: 21px;
        }
    </style>
    <script type="text/javascript">
        function goback(){
            window.location.href = "BookOpenPage.aspx";
        }
    </script>
</head>
<body  style="margin:10px;overflow:auto">
    <form id="form1" runat="server">
        <div class="title_right"><span class="pull-right margin-bottom-5"></span>
            <% if (Request.QueryString["bookid"] != "0")
                { %>
            <strong>书籍修改</strong>
            <%}
                else
                {%>
            <strong>书籍添加</strong>
            <%} %>
        </div>
        <div style="height: 1000px; overflow: auto;">
        <table class="table table-bordered" style="width:98%">
            <tr style="height:40px">
                <td>书籍名称：</td>
                <td><asp:TextBox ID="txtTitle" runat="server" CssClass="span4" required="required"></asp:TextBox></td>
                <td>作者：</td>
                <td><asp:TextBox ID="txtAuthor" runat="server" CssClass="span4" required="required"></asp:TextBox></td>
            </tr>
            <tr style="height:40px">
                <td>出版社：</td>
                <td><asp:TextBox ID="txtPub" runat="server" CssClass="span4" required="required"></asp:TextBox></td>
                <td>ISBN：</td>
                <td>
                    <asp:TextBox ID="txtIsbn" runat="server" CssClass="span4" required="required"></asp:TextBox>
                    <asp:FileUpload ID="FileUpload1" runat="server"/>
               </td>
            </tr>
            <tr>
                <td>大类别：</td>
                <td>
                     <asp:DropDownList ID="dropBL" runat="server" CssClass="span2" style="height:25px"  required="required" AutoPostBack="True" OnSelectedIndexChanged="dropBL_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td>小类别:</td>
                <td>
                    <asp:DropDownList ID="dropBS" runat="server" CssClass="span2" style="height:25px"  required="required"></asp:DropDownList>
                </td>
            </tr>
            <tr style="height:40px">
                <td>标价：</td>
                <td><asp:TextBox ID="txtMoney" runat="server" CssClass="span4" required="required"></asp:TextBox></td>
                <td>售价：</td>
                <td><asp:TextBox ID="txtPrice" runat="server" CssClass="span4" required="required"></asp:TextBox></td>
            </tr>
            <tr style="height:40px">
                <td>字数：</td>
                <td><asp:TextBox ID="txtBookCount" runat="server" CssClass="span4"  required="required"></asp:TextBox></td>
                <td>初始库存：</td>
                <td><asp:TextBox ID="txtBookDeport" runat="server" CssClass="span4"  required="required"></asp:TextBox></td>
            </tr>
            <tr style="height:30px">
                <td>书籍介绍：</td>
                <td colspan="3" style="padding:5px"><textarea runat="server" id="txtBookDesc" style="width:95%;height:100px" required="required"></textarea></td>
            </tr>
            <tr style="height:30px">
                <td>作者介绍：</td>
                <td colspan="3" style="padding:5px"><textarea runat="server" id="txtAuthorDesc" style="width:95%;height:100px" required="required"></textarea></td>
            </tr>
            <tr style="height:30px">
                <td>推荐内容：</td>
                <td colspan="3" style="padding:5px"><textarea runat="server" id="txtBookComm" style="width:95%;height:100px" required="required"></textarea></td>
            </tr>
            <tr style="height:30px">
                <td>目录摘要：</td>
                <td colspan="3" style="padding:5px">
                    <asp:TextBox ID="txtContent" runat="server" required="required" TextMode="MultiLine"></asp:TextBox>
                    <script type="text/javascript">
                        CKEDITOR.replace(txtContent);
                    </script>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align:center;">
                    <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn btn-info" OnClick="btnSave_Click"/>
                    <input type="button" value="取消" class="btn btn-info" onclick="goback()"/>
                </td>
            </tr>
        </table>
    </div>  
    </form>
</body>
</html>

