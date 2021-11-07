<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Books.admin.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>电子书城后台管理系统</title>
    <%=Styles.Render("~/bundles/UiCss") %>
    <%=Scripts.Render("~/bundles/UiJs") %>
    <style type="text/css">
        .active {
            background-color: #38A3D5;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            //菜单栏点击事件
            $("#my_menu a").click(function () {
                var url = $(this).attr("url");
                $("#page").attr("src", url);
            });
            //点击中部按钮，切换左侧菜单栏隐藏显示
            $(".Switch").click(function () {
                $(".left").toggle();
            })
            //切换子菜单栏隐藏显示
            $("span").click(function () {
                $(this).nextAll().toggle();
            })
        });
    </script>
</head>
<body>
    <div class="header">
        <div class="logo" style="color: white; font-size: 28px; font-weight: bold; font-family: 'Microsoft YaHei UI'; padding: 20px 20px">万树IT电子书城后台管理系统</div>
        <div class="header-right" style="padding:0px 0px">
            <i class="icon-question-sign icon-white"></i> <a href="#">帮助</a> <i class="icon-off icon-white"></i>
			 <a id="modal-973558" href="#" role="button" data-toggle="modal">注销</a>
			 <a id="modal-973559" href="#" role="button" data-toggle="modal">修改密码</a>
        </div>
    </div>
    <!-- 顶部 -->
    <div id="middle">
        <div class="left">
            <div id="my_menu" class="sdmenu">
                <div id="lt">
                    <span >基础数据管理</span>
                    <a href="#" url="BLCategoryPage.aspx">书籍大类别管理</a>
                    <a href="#" url="BSCategoryPage.aspx">书籍小类别管理</a>
                    <a href="#" url="BookPage.aspx">书籍管理</a>
                </div>
                <div id="lb">
                    <span >单据管理</span>
                    <a href="#" url="OrderPage.aspx">订单管理</a>
                </div>
            </div>
        </div>
        <div class="Switch"></div>
        <div class="right" id="mainFrame">
            <iframe id="page" name="page" src="Main.aspx" style="width:98%;height:99%"></iframe>
        </div>
    </div>
</body>
</html>
