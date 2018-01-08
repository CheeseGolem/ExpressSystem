<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Express.OPPortal.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <!-- 新 Bootstrap 核心 CSS 文件 -->
    <link href="/Content/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/bootstrap/css/bootstrap-theme.min.css" rel="stylesheet" />

    <link href="Content/bootstrap/css/bootstrap-admin-theme.css" rel="stylesheet" />
    <link href="/Content/css/login.css" rel="stylesheet" />

</head>
<body class="bootstrap-admin-without-padding">
    <div class="container">
        <div class="row">
            <%--<div class="alert alert-info">
                <a class="close" data-dismiss="alert" href="#">&times;</a>
                请输入正确的用户名和密码！
            </div>--%>
            <form method="post" class="bootstrap-admin-login-form" id="formLogin" runat="server">
                <h1>登录</h1>
                <div class="form-group">
                    <input class="form-control" type="text" id="txtUid" name="email" placeholder="用户名" onkeydown="return submitLoginRequest()" />
                </div>
                <div class="form-group">
                    <input class="form-control" type="password" id="txtPwd" name="password" placeholder="密码" onkeydown="return submitLoginRequest()" />
                </div>
                <div class="form-group">
                    <input class="form-control" type="text" id="txtCaptcha" maxlength="4" value="" onkeydown="return submitLoginRequest()" />
                    <img id="imgCaptcha" src="/Login/CaptchaHandler.ashx" alt="" title="点击刷新" onclick="refreshCaptcha(this);" />
                </div>
                <div class="form-group">
                    <label>
                        <input type="checkbox" name="remember_me"  id="chkAutoLogin"/>
                        自动登录
                    </label>
                </div>
                <input type="button" class="btn btn-primary" value="登录" id="btnLogin" onclick="login()" />&nbsp;<span class="tip">用户名错误</span>
                <%--<button class="btn btn-lg btn-primary" type="submit">提交</button>--%>
            </form>
        </div>
    </div>
</body>
</html>

<!-- jQuery文件。务必在bootstrap.min.js 之前引入 -->
<script src="/Content/js/jquery-1.9.1.min.js"></script>
<!-- 最新的 Bootstrap 核心 JavaScript 文件 -->
<script src="/Content/bootstrap/js/bootstrap.min.js"></script>

<script src="/Content/js/md5.encrypt.js"></script>
<script src="/Content/js/login.js"></script>
