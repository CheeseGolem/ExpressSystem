<%@ Page Title="" Language="C#" MasterPageFile="~/WeChat.Master" AutoEventWireup="true" CodeBehind="RemoveBind.aspx.cs" Inherits="Express_RemoveBind" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="weui-cell">
        <img src="../Content/Images/banner.jpg" style="height: 180px; width: 100%" />
    </div>
    <div class="weui-cells weui-cells_form">
        <div class="weui-cell">
            <div class="weui-cell__bd">
                <input type="button" onclick="RemoveBind()" class="weui-btn weui-btn_primary" value="解除绑定" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
    <script type="text/javascript">
        function RemoveBind() {
            var confirm = weui.confirm('您确定要解除绑定吗？',
                function () {
                    var obj = Express_RemoveBind.RemoveBindByOpenId().value;
                    if (obj.Result) {
                        confirm.hide(function () {
                            weui.alert('解绑成功');
                        });
                    }
                    else {
                        confirm.hide(function () {
                            weui.alert('解绑失败');
                        });
                    }
                }, function () {
                    return;
                }, {
                    title: '解除绑定'
                });
        }
    </script>
</asp:Content>
