<%@ Page Title="" Language="C#" MasterPageFile="~/WeChat.Master" AutoEventWireup="true" CodeBehind="ExpressQuery.aspx.cs" Inherits="WeChatWebSite.ExpressQuery.ExpressQuery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="weui-cells weui-cells_form">
        <div class="weui-cell">
            <div class="weui-cell__hd">
                <label class="weui-label">快递单号</label>
            </div>
            <div class="weui-cell__bd">
                <input class="weui-input" type="number" pattern="[0-9]*" id="txtECode" placeholder="请输入快递单号" />
            </div>
        </div>
    </div>
    <div class="weui-btn-area">
        <a class="weui-btn weui-btn_primary" href="javascript:" id="btnQuery">查询</a>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
    <script type="text/javascript">
        $('#btnQuery').on('click', function () {
            if ($('#txtECode').val() == "") {
                weui.alert('请输入快递单号');
                return;
            }
            window.location.href = 'ExpressInfo.aspx?ECode=' + $('#txtECode').val();
        })
    </script>
</asp:Content>
