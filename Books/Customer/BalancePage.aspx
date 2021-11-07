<%@ Page Title="" Language="C#" MasterPageFile="~/Master/HeadAndFoot.Master" AutoEventWireup="true" CodeBehind="BalancePage.aspx.cs" Inherits="Books.Customer.BalancePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <div>
            <p></p>
            <div style="background-color:#F6F6F6;color:Black;font-weight:bold;font-size:14px;height:30px;line-height:30px;padding:3px 10px">收货人信息</div>
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
                        <asp:TextBox ID="txtAddress" runat="server" style="width:471px;"  placeholder="请输入收货地址"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px">&nbsp;</td>
                    <td colspan="3" style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                        <asp:Button ID="btnDefault" runat="server" Text="使用默认地址" OnClick="btnDefault_Click"/>&nbsp;
                        <input type="button" onclick="addressmanage()" value="地址管理"/>
                    </td>
                </tr>
            </table>
            <p></p>
            <div style="background-color:#F6F6F6;color:Black;font-weight:bold;font-size:14px;height:30px;line-height:30px;padding:3px 10px">付款方式</div>
            <p></p>
            <div><input type="radio" name="money"  checked="checked" />支付宝&nbsp;&nbsp;<input type="radio" name="money" />网银&nbsp;&nbsp;<input type="radio" name="money" />微信</div>
            <p></p>
            <div style="background-color:#F6F6F6;color:Black;font-weight:bold;font-size:14px;height:30px;line-height:30px;padding:3px 10px">购物清单</div>
            <p></p>
            <asp:GridView ID="gdvGoodslist" runat="server" AutoGenerateColumns="False" style="width:98%;border-collapse:collapse" CssClass="dataTable" DataKeyNames="BookID" OnRowDataBound="gdvGoodslist_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="BookTitle" HeaderText="商品名称" />
                    <asp:BoundField DataField="BookPrice" HeaderText="原价" />
                    <asp:BoundField DataField="BookMoney" HeaderText="折扣价" />
                    <asp:BoundField HeaderText="购买数量" />
                    <asp:BoundField HeaderText="小计" />
                </Columns>
            </asp:GridView>
            <div style="text-align:right;padding-top:20px">
                <font color="#FF7126" style="font-weight:bold;font-size:20px"><asp:Label ID="labSum" runat="server" Text="0"></asp:Label>元</font>&nbsp;&nbsp;
                <asp:Button ID="btnEnter" runat="server" Text="提交订单" OnClick="btnEnter_Click"/>        
            </div>    
        </div>
</asp:Content>
