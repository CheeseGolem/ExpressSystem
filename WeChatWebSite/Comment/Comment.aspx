<%@ Page Title="" Language="C#" MasterPageFile="~/WeChat.Master" AutoEventWireup="true" CodeBehind="Comment.aspx.cs" Inherits="WeChatWebSite.Comment.Comment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .weui-textarea {
            border-radius: 6px;
            font-size: 14px;
            border: 1px solid #999999;
        }

        .weui-font {
            font-size: 14px;
        }

        .weui-btn_u {
            background-color: #61B2DF;
            padding: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="weui-cells">
        <div class="baby_overlay_arrow">
            <img alt="" src="../Content/Images/banner.jpg" height="180" style="width: 100%" />
        </div>
        <div class="weixin-panel">
            <div class="weui-cell weui-cell__bd">
                评价我们
            </div>
        </div>
        <div class="weui-form-preview">
            <div class="weui-cells weui-cells_form">
                <div class="col-md-10 weui-cell">
                    <div class="weui-cell__bd">
                        <textarea class="weui-textarea" id="txt_area" placeholder="请留下您的意见与看法，便于我们更好地提供服务"
                            rows="10" onkeyup="keypress();" onblur="keypress();"></textarea>
                        <div class="weui-textarea-counter"><span class="weui-font">可输入剩余字数：<span id="tcount">0</span>/300</span></div>
                    </div>
                </div>
            </div>
        </div>

        <div class="weui-cells">
            <div class="weui-cell">
                <div class="weui-cell__bd" style="margin-right: 30px;">
                    <a class="weui-btn weui-btn_primary" id="showTooltips" href="javascript:" onclick="sumbit();">提交</a>
                </div>
                <div class="weui-cell__bd">
                    <a class="weui-btn weui-btn_u" id="showTooltips" href="#">查看历史提问</a>
                </div>
            </div>

            <div class="weui-btn-area">
                <a class="weui-btn weui-btn_u" id="showTooltips" href="tel:@phone">电话咨询:@phone</a>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
    <script type="text/javascript">
        function keypress() //textarea输入长度处理
        {
            var text1 = document.getElementById("txt_area").value;
            //汉字的个数
            var str = (text1.replace(/\w/g, "")).length;
            //非汉字的个数
            var abcnum = text1.length - str;
            var total = str * 2 + abcnum;
            var len; //记录剩余字符串的长度
            if (total >= 600) //textarea控件不能用maxlength属性，就通过这样显示输入字符数了
            {
                document.getElementById("txt_area").value = text1.substr(0, 300);
                len = 0;
            } else {
                len = 300 - text1.length;
            }

            document.getElementById("tcount").innerText = len;
        }
    </script>
</asp:Content>
