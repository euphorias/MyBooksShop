<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Log_in.aspx.cs" Inherits="Books.admin.Log_in" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>电子书城后台管理系统</title>
    <%=Styles.Render("~/bundles/UiCss") %>
    <%=Scripts.Render("~/bundles/UiJs") %>
    <style type="text/css">
        body {
            background: #0066A8 url(../images/login_bg.png) no-repeat center 0px;
        }

        .tit {
            margin: auto;
            margin-top: 170px;
            text-align: center;
            width: 350px;
            padding-bottom: 20px;
        }

        .login-wrap {
            width: 220px;
            padding: 30px 50px 0 330px;
            height: 220px;
            background: #fff url(../Content/Images/20150212154319.jpg) no-repeat 30px 42px;
            margin: auto;
            overflow: hidden;
        }

        .login_input {
            display: block;
            width: 210px;
        }

        .login_user {
            background: url(../images/input_icon_1.png) no-repeat 200px center;
            font-family: "Lucida Sans Unicode", "Lucida Grande", sans-serif;
        }

        .login_password {
            background: url(../images/input_icon_2.png) no-repeat 200px center;
            font-family: "Courier New", Courier, monospace;
        }

        .btn-login {
            background: #40454B;
            box-shadow: none;
            text-shadow: none;
            color: #fff;
            border: none;
            height: 35px;
            line-height: 26px;
            font-size: 14px;
            font-family: "microsoft yahei";
        }
            .btn-login:hover {
                background: #333;
                color: #fff;
            }

        .copyright {
            margin: auto;
            margin-top: 10px;
            text-align: center;
            width: 370px;
            color: #CCC;
        }

        @media (max-height: 700px) {
            .tit {
                margin: auto;
                margin-top: 100px;
            }
        }

        @media (max-height: 500px) {
            .tit {
                margin: auto;
                margin-top: 50px;
            }
        }
        
    </style>
    <script>
        function Refresh(mi) {
            mi.src = "ValidateCode.aspx?data=" + Math.random();
        }
    </script>
</head>

<body>
    <form runat="server" id="form1">
    <div class="tit" style="color:white;font-size:28px;font-weight:bold;font-family:'Microsoft YaHei UI'">万树IT电子书城管理系统</div>
    <div class="login-wrap">
        <table >
            <tr>
                <td >用户名：</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtUser" runat="server"  CssClass="login_input login_user" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td >密  码：</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"  CssClass="login_input login_password" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td >验证码：</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtCode" runat="server" CssClass="input-small"></asp:TextBox>&nbsp;&nbsp;
                    <img src="ValidateCode.aspx" style="cursor:pointer;" onclick="Refresh(this)" />
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Button ID="btnlogin" runat="server" Text="登录" CssClass="btn btn-block btn-login" OnClick="btnlogin_Click"/>
                    <asp:Button ID="btnRegister" runat="server" Text="注册" CssClass="btn btn-block btn-login" OnClick="btnRegister_Click"/>
                </td>
            </tr>

        </table>
    </div>
    <div class="copyright">建议使用IE8以上版本或谷歌浏览器</div>
    </form>
</body>
</html>

