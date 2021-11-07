<%@ Page Title="" Language="C#" MasterPageFile="~/Master/HeadAndFoot.Master" AutoEventWireup="true" CodeBehind="CustomerOrderPage.aspx.cs" Inherits="Books.Customer.CustomerOrderPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
        <p></p>
        <div style="background-color: #F6F6F6; color: Black; font-weight: bold; font-size: 14px; height: 30px; line-height: 30px; padding: 3px 10px">已购买书籍列表</div>
        <p></p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  class="dataTable" border="1" style="width:98%;border-collapse:collapse" PageIndex="4" PageSize="5">
            <Columns>
                <asp:TemplateField HeaderText="订单编号">
                    <ItemTemplate>
                       <a href="BalanceDone.aspx?ordernum=<%# Eval("OrderNum") %>"> <asp:Label ID="Label3" runat="server" Text='<%# Eval("OrderNum") %>'></asp:Label> </a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="客户名称" DataField="username" />
                <asp:BoundField HeaderText="订单时间" DataField="OrderDate" />
                <asp:BoundField HeaderText="订单金额" DataField="OrderMoney" />
                <asp:TemplateField HeaderText="订单状态">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("OrderState").ToString()=="1"?"待确认":Eval("OrderState").ToString()=="2"?"已确认":Eval("OrderState").ToString()=="3"?"已发货":"完成" %>'></asp:Label><br />
                        <a href="Appraise.aspx?orderid=<%#Eval("OrderID")%>">
                            <asp:Label ID="Label2" runat="server" Text="待评价" Visible='<%#Eval("OrderState").ToString()=="3"?true:false%>'></asp:Label></a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
        <p></p>

           <asp:Button ID="btnHead"  runat="server" Text="首页" CssClass="btn btn-info" OnClick="btnHead_Click"  />&nbsp;
            <asp:Button ID="btnUp" runat="server" Text="上一页" CssClass="btn btn-info" OnClick="btnUp_Click" />&nbsp;
            <asp:Button ID="btnDown" runat="server" Text="下一页" CssClass="btn btn-info" OnClick="btnDown_Click"  />&nbsp;
            <asp:Button ID="btnEnd" runat="server" Text="尾页" CssClass="btn btn-info" OnClick="btnEnd_Click"  />
          
            &nbsp;当前页/总页数： 
            <asp:Label ID="labCurrent" runat="server" Text="1"></asp:Label>/
            <asp:Label ID="labCount" runat="server" Text="0"></asp:Label>
    </div>
</asp:Content>
