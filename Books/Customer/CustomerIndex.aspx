<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Master.Master" AutoEventWireup="true" CodeBehind="CustomerIndex.aspx.cs" Inherits="Books.Customer.CustomerIndex" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="mainDiv">
            <div class="redAll" style="float: right; width: 100%">
                <div class="redTitle" style="float:right;width:725px">秒杀专区</div>
                 <asp:Repeater ID="repBuy" runat="server" OnItemCommand="repBuy_ItemCommand">
                    <ItemTemplate>
                        <div style="float: left;margin:5px 5px;overflow:hidden">
                            <div style="width:135px;text-align:center">
                                <a href="BooksPage.html">
                                    <img src='../Content/BookImages/<%# Eval("ISBN") %>.jpg' style="border:1px solid #CDCECE;width:80px;height:110px" />
                                </a>
                            </div>
                            <div style="height:25px;line-height:15px;text-align:center">
                                <a title='<%# Eval("BookTitle") %>' href="BooksPage.html">
                                    <p style="width: 120px;overflow: hidden;white-space: nowrap;text-overflow: ellipsis;"><%# Eval("BookTitle") %></p>
                                </a>
                            </div>
                            <div style="height: 15px; line-height: 15px; text-align: center">
                                <font style="text-decoration: line-through">￥<%# Eval("BookPrice") %></font></div>
                            <div style="height: 15px; line-height: 15px; text-align: center">
                                <font color="#FF7126" style="font-weight:bold">￥<%# Eval("BookMoney") %></font></div>
                            <div style="text-align: center">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Content/Images/goumaismall.jpg" CommandName="addCart" CommandArgument ='<%# Eval("BookID") %>'/>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div style="clear:both"></div>
            <p></p>
            <div class="redAll" style="float: right; width: 100%">
                <div class="redTitle" style="float:right;width:725px">热门推荐</div>
                <asp:Repeater ID="repHot" runat="server" OnItemCommand="repHot_ItemCommand" >
                    <ItemTemplate>
                        <div style="float: left;margin:5px 5px;overflow:hidden">
                            <div style="width:135px;text-align:center">
                                <a href="BooksPage.html">
                                    <img src='../Content/BookImages/<%# Eval("ISBN") %>.jpg' style="border:1px solid #CDCECE;width:80px;height:110px" />
                                </a>
                            </div>
                            <div style="height:25px;line-height:15px;text-align:center">
                                <a title='<%# Eval("BookTitle") %>' href="BooksPage.html">
                                    <p style="width: 120px;overflow: hidden;white-space: nowrap;text-overflow: ellipsis;"><%# Eval("BookTitle") %></p>
                                </a>
                            </div>
                            <div style="height: 15px; line-height: 15px; text-align: center">
                                <font style="text-decoration: line-through">￥<%# Eval("BookPrice") %></font></div>
                            <div style="height: 15px; line-height: 15px; text-align: center">
                                <font color="#FF7126" style="font-weight:bold">￥<%# Eval("BookMoney") %></font></div>
                            <div style="text-align: center">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Content/Images/goumaismall.jpg" CommandName="addCart" CommandArgument ='<%# Eval("BookID") %>' />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                </div>
            </div>
</asp:Content>
