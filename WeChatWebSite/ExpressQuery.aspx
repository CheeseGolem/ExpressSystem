<%@ Page Title="" Language="C#" MasterPageFile="~/WeChat.Master" AutoEventWireup="true" CodeBehind="ExpressQuery.aspx.cs" Inherits="WeChatWebSite.ExpressQuery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="weui-cells__title">表单</div>
    <div class="weui-cells weui-cells_form">
        <div class="weui-cell">
            <div class="weui-cell__hd">
                <label class="weui-label">快递单号</label>
            </div>
            <div class="weui-cell__bd">
                <input class="weui-input" type="number" pattern="[0-9]*" placeholder="请输入快递单号" />
            </div>
        </div>
        <%--<div class="weui-cell weui-cell_vcode">
            <div class="weui-cell__hd">
                <label class="weui-label">手机号</label>
            </div>
            <div class="weui-cell__bd">
                <input class="weui-input" type="tel" placeholder="请输入手机号" />
            </div>
            <div class="weui-cell__ft">
                <button class="weui-vcode-btn">获取验证码</button>
            </div>
        </div>
        <div class="weui-cell">
            <div class="weui-cell__hd">
                <label for="" class="weui-label">日期</label>
            </div>
            <div class="weui-cell__bd">
                <input class="weui-input" type="date" value="" />
            </div>
        </div>
        <div class="weui-cell">
            <div class="weui-cell__hd">
                <label for="" class="weui-label">时间</label>
            </div>
            <div class="weui-cell__bd">
                <input class="weui-input" type="datetime-local" value="" placeholder="" />
            </div>
        </div>
        <div class="weui-cell weui-cell_vcode">
            <div class="weui-cell__hd">
                <label class="weui-label">验证码</label>
            </div>
            <div class="weui-cell__bd">
                <input class="weui-input" type="number" placeholder="请输入验证码" />
            </div>
            <div class="weui-cell__ft">
                <img class="weui-vcode-img" src="./images/vcode.jpg" />
            </div>
        </div>--%>
    </div>
    <div class="weui-cells__tips">底部说明文字底部说明文字</div>
    <div class="weui-btn-area">
        <a class="weui-btn weui-btn_primary" href="javascript:" id="btnQuery">查询</a>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
    <script type="text/javascript">
        $('#btnQuery').on('click', function () {

        })
    </script>
</asp:Content>
