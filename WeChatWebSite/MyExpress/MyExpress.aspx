<%@ Page Title="" Language="C#" MasterPageFile="~/WeChat.Master" AutoEventWireup="true" CodeBehind="MyExpress.aspx.cs" Inherits="WeChatWebSite.MyExpress.MyExpress" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="weui-cells">
        <div class="weui-cell">
            <img src="../Content/Images/banner.jpg" style="height: 180px;width:100%" />            
        </div>

        <asp:Repeater ID="rptExpress" runat="server">
            <ItemTemplate>
                <div class="weui-cell">
                    <div class="weui-cell__hd" style="position: relative; margin-right: 10px;">
                        <img src="/Content/images/pic_160.png" style="width: 50px; display: block" />
                        <%--<span class="weui-badge" style="position: absolute; top: -.4em; right: -.4em;">8</span>--%>
                    </div>
                    <div class="weui-cell__bd">
                        <p>快递单号</p>
                        <p style="font-size: 13px; color: #888888;">摘要信息</p>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <%--<div class="weui-cell">
            <div class="weui-cell__hd" style="position: relative; margin-right: 10px;">
                <img src="images/pic_160.png" style="width: 50px; display: block" />
            </div>
            <div class="weui-cell__bd">
                <p>快递单号</p>
                <p style="font-size: 13px; color: #888888;">摘要信息</p>
            </div>
        </div>--%>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
