<%@ Page Title="" Language="C#" MasterPageFile="~/WeChat.Master" AutoEventWireup="true" CodeBehind="SendExpress.aspx.cs" Inherits="Express_SendExpress" %>

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
        <img src="../Content/Images/banner.jpg" style="height: 180px; width: 100%" />
    </div>
    <div class="weui-cells weui-cells_form">
        <div class="weui-cell">
            <div class="weui-cell__hd">
                <label class="weui-label">姓名</label>
            </div>
            <div class="weui-cell__bd">
                <input class="weui-input" type="text" id="txtName" placeholder="请输入收件人的姓名" value="">
            </div>
        </div>

        <div class="weui-cell">
            <div class="weui-cell__hd">
                <label class="weui-label">手机</label>
            </div>
            <div class="weui-cell__bd">
                <input class="weui-input" type="number" id="txtPhone" placeholder="请输入收件人的联系方式" value="">
            </div>
        </div>

        <div class="weui-cell">
            <div class="weui-cell__hd">
                <label class="weui-label">地址</label>
            </div>
            <div class="weui-cell__bd">
                <input class="weui-input" type="text" id="txtAddress" placeholder="请输入收件人的地址">
            </div>
        </div>
        <div class="weui-cell">
            <div class="weui-cell__hd">
                <label class="weui-label">是否保价</label>
            </div>
            <div class="weui-cell__bd">
                <select class="weui-select select" id="sltExpensive">
                    <option value="0" selected="selected">否</option>
                    <option value="1">是</option>
                </select>
            </div>
        </div>
    </div>
    <div class="center weixinpadding">
        <input id="btnConfirm" class="weui-btn weui-btn_primary" value="确认" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
    <script type="text/javascript">
        $(function () {
            sendExpress();
        })

        function sendExpress() {
            $('#btnConfirm').click(function () {
                var name = $('#txtName').val();
                var phone = $('#txtPhone').val();
                var address = $('#txtAddress').val();
                var isExp = $('#sltExpensive').val();

                if (name == "") {
                    weui.alert('请输入收件人姓名');
                    return false;
                }
                if (phone == "") {
                    weui.alert('请输入收件人手机号码');
                    return false;
                } 
                if (address == "") {
                    weui.alert('请输入收件人地址');
                    return false;
                } 

                var obj = Express_SendExpress.AddExpress(name, phone, address, isExp);
                if (obj) {
                    weui.alert('添加成功！');
                } else {
                    weui.alert("添加失败！");
                }
            })
        }
    </script>
</asp:Content>
