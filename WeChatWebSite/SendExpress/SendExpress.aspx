<%@ Page Title="" Language="C#" MasterPageFile="~/WeChat.Master" AutoEventWireup="true" CodeBehind="SendExpress.aspx.cs" Inherits="WeChatWebSite.SendExpress.SendExpress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .weui-cell {
        padding: 5px 10px;
        position: relative;
        display: -webkit-box;
        display: flex;
        -webkit-box-align: center;
        align-items: center;
    }

    .weui-cells {
        margin-top: 10px !important;
        background-color: #FFFFFF;
        line-height: 1.47058824;
        font-size: 17px;
        overflow: hidden;
        position: relative;
    }

    .weui-label {
        display: block;
        width: 80px;
        word-wrap: break-word;
        word-break: break-all;
        margin: 0 !important;
        padding: 3px 5px !important;
    }

    .weui-input {
        width: 100%;
        border: 0;
        border-bottom: 1px solid #ffffff;
        outline: 0;
        -webkit-appearance: none;
        background-color: transparent;
        font-size: inherit;
        color: inherit;
        height: 1.47058824em;
        line-height: 1.47058824;
        padding: 3px 5px !important;
    }

    .select {
        padding-left: 5px;
        height: auto;
        line-height: normal;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="weui-cell">
            <img src="../Content/Images/banner.jpg" style="height: 180px;width:100%" />            
        </div>
    <div class="weui-cells weui-cells_form">
        <div class="weui-cell">
            <div class="weui-cell__hd"><label class="weui-label">姓名</label></div>
            <div class="weui-cell__bd">
                <input class="weui-input" type="text" id="txtName" placeholder="请输入收件人的姓名" value="">
            </div>
        </div>
        
        <div class="weui-cell">
            <div class="weui-cell__hd"><label class="weui-label">地址</label></div>
            <div class="weui-cell__bd">
                <input class="weui-input" type="text" id="txtAddress" placeholder="请输入收件人的地址">
            </div>
        </div>        
        <div class="weui-cell">
            <div class="weui-cell__hd"><label class="weui-label">是否保价</label></div>
            <div class="weui-cell__bd">
                <select class="weui-select select" id="sltExpensive">
                    <option value="0">是</option>
                    <option value="1" selected="selected">否</option>
                </select>
            </div>
        </div>
        <%--<div class="weui-cell ">
            <div class="weui-cell__hd">
                <div class="weui-cell__hd"><label class="weui-label">手机号码</label></div>
            </div>
            <div class="weui-cell__bd">
                <input class="weui-input" type="number" pattern="[0-9]*" placeholder="请输入您就诊预留的手机号码" title="正确格式的号码" id="phone" name="Tel">
            </div>
        </div>
        <div class="weui-cell weui-cell_vcode">
            <div class="weui-cell__hd"><label class="weui-label">验证码</label></div>
            <div class="weui-cell__bd">
                <input class="weui-input" type="number" placeholder="请输入验证码" id="vcode">
            </div>
            <div class="weui-cell__ft">
                @*<img class="weui-vcode-img" src="./images/vcode.jpg">*@
                <button type="button" class="weui-vcode-btn" onclick="getCode(this)">获取验证码</button>
            </div>
        </div>--%>
    </div>
    <div class="center weixinpadding">
        <button onclick="Binding()" class="weui-btn weui-btn_primary">确认</button>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
