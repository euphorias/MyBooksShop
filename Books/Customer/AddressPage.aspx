<%@ Page Title="" Language="C#" MasterPageFile="~/Master/HeadAndFoot.Master" AutoEventWireup="true" CodeBehind="AddressPage.aspx.cs" Inherits="Books.Customer.AddressPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
            <p></p>
            <div style="background-color:#F6F6F6;color:Black;font-weight:bold;font-size:14px;height:30px;line-height:30px;padding:3px 10px">地址管理</div>
            <p></p>
            <table class="dataTable" style="width:98%">
                <tr>
                    <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px;width:150px">收货人姓名(必填)：</td>
                    <td style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                        <asp:TextBox ID="txtName" runat="server" placeholder="请输入收货人姓名"></asp:TextBox>
                    </td>
                    <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px;width:150px">联系电话(必填)：</td>
                    <td style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                        <asp:TextBox ID="txtTel" runat="server" TextMode="Number" placeholder="请输入联系电话"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px;width:150px">收货地址(必填)：</td>
                    <td colspan="3" style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                        <asp:TextBox ID="txtAdd" runat="server" style="width:471px;"  placeholder="请输入收货地址" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px">&nbsp;</td>
                    <td colspan="3" style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                        <asp:Button ID="btnAdd" runat="server" Text="新增地址" OnClick="btnAdd_Click" />&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
            <p></p>
            <strong>地址列表</strong>
            <hr />
            <asp:Repeater ID="RepAdd" runat="server" OnItemCommand="RepAdd_ItemCommand">
                <ItemTemplate>
                       <table class="dataTable" style="width:98%">
                <tr>
                    <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px;width:150px">收货人姓名(必填)：</td>
                    <td style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                        <asp:TextBox ID="txtUser" runat="server" Text='<%# Eval("AMUser") %>'></asp:TextBox>
                    </td>
                    <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px;width:150px">联系电话(必填)：</td>
                    <td style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                        <asp:TextBox ID="txtNum" runat="server" Text='<%# Eval("AMTel") %>'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px;width:150px">收货地址(必填)：</td>
                    <td colspan="3" style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                        <asp:TextBox ID="txtAdr" runat="server" style="width:471px;" Text='<%# Eval("AMAddress") %>'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px;width:150px">是否为默认地址：</td>
                    <td colspan="3" style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                         <asp:Label ID="TextBox4" runat="server" style="width:471px;" Text='<%# Eval("AMMark").ToString() == "True" ? "是":"否" %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px">&nbsp;</td>
                    <td colspan="3" style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                        <asp:Button ID="btnSave" runat="server" CommandArgument='<%# Eval("AMID")%>' CommandName="saveChange" Text="保存修改"/>&nbsp;&nbsp;
                        <asp:Button ID="btnDefault" runat="server" Enabled='<%#Eval("AMMark").ToString() == "True" ? false:true %>' CommandName="saveDef" CommandArgument ='<%# Eval("AMID") %>' Text="保存为默认地址" />&nbsp;&nbsp;
                        <asp:Button ID="btnDelete" runat="server" CommandName="delete" CommandArgument='<%# Eval("AMID")%>' Text="删除"/>
                    </td>
                </tr>
            </table>
            <p></p>
                </ItemTemplate>
            </asp:Repeater>
        </div>
</asp:Content>
