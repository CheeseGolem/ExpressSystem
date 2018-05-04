<%@ Page Title="" Language="C#" MasterPageFile="~/WeChat.Master" AutoEventWireup="true" CodeBehind="UserBind.aspx.cs" Inherits="WeChatWebSite.UserBind.UserBind" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .weui-cell {
            padding: 5px 10px;
            position: relative;
            display: -webkit-box;
            display: flex;
            -webkit-box-align: center;
            align-items: center;
        }

        .weui-cells {
            margin-top: 50px !important;
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
    <div class="">
        <div class="weui-cell">
            <img src="../Content/Images/banner.jpg" style="height: 180px; width: 100%" />
        </div>
        <div class="weui-cells weui-cells_form">
            <div class="weui-cell">
                <div class="weui-cell__hd">
                    <label class="weui-label">姓名</label>
                </div>
                <div class="weui-cell__bd">
                    <input class="weui-input" type="text" id="tb_name" placeholder="请输入您的真实姓名" value="" runat="server">
                </div>
            </div>
            <div class="weui-cell ">
                <div class="weui-cell__hd">
                    <div class="weui-cell__hd">
                        <label class="weui-label">手机号码</label>
                    </div>
                </div>
                <div class="weui-cell__bd">
                    <input class="weui-input" type="number" pattern="[0-9]*" placeholder="请输入您的手机号码" title="正确格式的号码" id="phone" name="Tel" runat="server">
                </div>
            </div>
            <div class="weui-cell weui-cell_vcode">
                <div class="weui-cell__hd">
                    <label class="weui-label">验证码</label>
                </div>
                <div class="weui-cell__bd">
                    <input class="weui-input" type="number" placeholder="请输入验证码" id="vcode" runat="server">
                </div>
                <div class="weui-cell__ft">
                    <%--<img class="weui-vcode-img" src="./images/vcode.jpg">--%>
                    <button type="button" class="weui-vcode-btn" onclick="getCode(this)">获取验证码</button>
                </div>
            </div>
        </div>
        <div class="center weixinpadding">
            <input type="button" onclick="Binding()" class="weui-btn weui-btn_primary" value="确认" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
    <script type="text/javascript">                
        $xingming = $('#tb_name'),//姓名
            $phone = $('#phone'),//手机号
            $vcode = $('#vcode');//验证码        

        //手机号码格式
        function checkPhone(obj) {
            //var pattern = /^(13[0-9]|15[012356789]|17[678]|18[0-9]|14[57])[0-9]{8}$/;
            //if (!pattern.test(obj.val())) {
            //    //alert('请输入正确的手机号码');
            //    weui.alert("手机号格式错误");
            //    return false;
            //}
            return true;
        }

        //检查输入框
        var checkInput = function () {
            if ($xingming.val() == "") {
                weui.alert('请输入姓名');
                return false;
            }
            if ($phone.val() == "") {
                weui.alert('请输入手机号码');
                return false;
            } else {
                if (!checkPhone($phone)) {
                    return false;
                }
            }

            return true;
        }

        //绑定事件
        var Binding = function () {
            if (checkInput()) {
                var vcode = $('#vcode').val();
                if (vcode != "") {
                    var ajaxoption = {
                        url: 'UserBinding.ashx',
                        type: 'Post',
                        data: {
                            getmethod: 'GetUser',
                            bindname: $xingming.val(),
                            vcode: vcode,
                            phone: $phone.val()
                        },
                        error: function (result) {
                            weui.alert("绑定失败！" + result.statusText)
                        },
                        success: function (data) {
                            data = $.parseJSON(data);
                            if (data.Result) {
                                weui.alert("绑定成功");
                                setTimeout(function () {
                                    window.location.href = '/MyExpress/MyExpress.aspx';
                                }, 1500);
                            }
                            else {
                                weui.alert(data.MsgObjectContent);
                            }

                            //if (typeof (data.Result) == "undefined") {
                            //    window.location.href = data;
                            //} else {
                            //    //debugger;
                            //    weui.alert(data.MsgObjectContent)
                            //    if (data.Result) {
                            //        weui.alert("绑定成功");
                            //    }
                            //}
                        }
                    };
                    $.ajax(ajaxoption);
                } else {
                    weui.alert("请输入验证码");
                }

            }

        }

        //验证码发送倒计时器
        var countdown = 60;//60秒
        function settime(obj) {
            if (countdown == 0) {
                $(obj).removeAttr("disabled");
                $(obj).text("获取验证码");
                countdown = 60;
                return;
            } else {
                $(obj).attr("disabled", true);
                $(obj).text(countdown + 's' + '后重发');
                countdown--;
            }
            setTimeout(function () {
                settime(obj)
            }, 1000)
        }

        //发送手机验证码
        var getCode = function (obj) {
            if (checkInput()) {
                var ajaxoption = {
                    url: 'UserBinding.ashx',
                    type: 'Post',
                    data: {
                        getmethod: 'SendPhoneMsg'
                    },
                    error: function (result) {
                        weui.alert("发送失败，SeverError");
                    },
                    success: function (data) {
                        settime(obj);
                        weui.alert("发送成功！");
                        //if (!data.Result) {
                        //    weui.alert(data.MsgObjectContent);
                        //} else {
                        //    //发送成功
                        //    //定时器开始
                        //    settime(obj);
                        //    weui.alert("发送成功！");
                        //}
                    }
                };

                $.ajax(ajaxoption);
            }
        }
    </script>
</asp:Content>
