<%@ Page Title="" Language="C#" MasterPageFile="~/Master/HeadAndFoot.Master" AutoEventWireup="true" CodeBehind="BalanceDone.aspx.cs" Inherits="Books.Customer.BalanceDone" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
            <div style="background-color:#F6F6F6;color:Black;font-weight:bold;font-size:14px;height:30px;line-height:30px;padding:3px 10px">完成订单</div>
            <p></p>
            <div style="text-align:center"><font style="font-size:20px;font-weight:bold">订单号：<asp:Label ID="labNum" runat="server" Text=""></asp:Label></font></div>
            <asp:GridView ID="gdvGoodslist" runat="server" AutoGenerateColumns="False" style="width:98%;border-collapse:collapse" CssClass="table table-bordered table-striped table-hover">
                <Columns> 
                    <asp:BoundField DataField="BookTitle" HeaderText="书籍名" />
                    <asp:BoundField DataField="ODPrice" HeaderText="单价" />
                    <asp:BoundField DataField="ODCount" HeaderText ="数量" />     
                     <asp:BoundField DataField="ODMoney" HeaderText ="总金额" />     
                </Columns>
            </asp:GridView>
        </div>
</asp:Content>
