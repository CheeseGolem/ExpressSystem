<%@ Page Title="" Language="C#" MasterPageFile="~/WeChat.Master" AutoEventWireup="true" CodeBehind="ExpressInfo.aspx.cs" Inherits="WeChatWebSite.ExpressQuery.ExpressInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        label{
            font-weight:normal;
            font-size:16px;
        }
        p{
            margin:1px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="weui-cells">
        <div class="weui-cell">
            <img src="../Content/Images/banner.jpg" style="height: 180px; width: 100%" />
        </div>
        <div class="weui-cells">
            <div class="weui-cell">
                <div class="weui-cell__hd" style="position: relative; margin-right: 10px;">
                    <p style="font-size:18px;font-weight:bold;">寄</p>
                </div>
                <div class="weui-cell__bd">
                    <p>
                        <label id="lblSendName" runat="server"></label>                        
                    </p>
                    <p>
                        <label id="lblSendPhone" runat="server"></label>
                    </p>
                </div>
                <div class="weui-cell__hd" style="position: relative; margin-right: 10px;">
                    <p style="font-size:18px;font-weight:bold;">收</p>
                </div>
                <div class="weui-cell__bd">
                    <p>
                        <label id="lblReceiveName" runat="server"></label>                        
                    </p>
                    <p>
                        <label id="lblReceivePhone" runat="server"></label>
                    </p>
                </div>
            </div>
        </div>

        <asp:Repeater ID="rptAnswer" runat="server">
            <ItemTemplate>
                <div class="wei-cells">
                    <div class="weui-cell">
                        <div class="weui-cell__hd" style="position: relative; margin-right: 10px;">
                            <p><%#Eval("Time") %></p>
                        </div>
                        <div class="weui-cell__bd">
                            <p><%#Eval("Info") %></p>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
