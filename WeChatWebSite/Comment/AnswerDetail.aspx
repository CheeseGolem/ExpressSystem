<%@ Page Title="" Language="C#" MasterPageFile="~/WeChat.Master" AutoEventWireup="true" CodeBehind="AnswerDetail.aspx.cs" Inherits="WeChatWebSite.Comment.AnswerDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .weui-textarea {
            border-radius: 6px;
            font-size: 14px;
            border: 0px solid #999999;
        }

        .weui-cell {
            padding: 5px 15px;
            font-size: 14px;
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
                <div class="weui-cell__bd">
                    <p>您的询问</p>
                </div>
                <div class="weui-cell__ft">
                    <label id="lblATime" runat="server"></label>
                </div>
            </div>
        </div>
        <div class="weui-cells">
            <div class="weui-cell">
                <div class="weui-cell__bd">
                    <label id="lblQContent" runat="server"></label>                    
                </div>
            </div>
        </div>
        <asp:Repeater ID="rptAnswer" runat="server">
            <ItemTemplate>
                <div class="weui-cells">
                    <div class="weui-cell">
                        <div class="weui-cell__bd">
                            <p>回复 </p>
                        </div>
                        <div class="weui-cell__ft"><%#Eval("ATime") %></div>
                    </div>
                </div>
                <div class="wei-cells">
                    <div class="weui-cell">
                        <div class="weui-cell__bd">
                            <textarea class="weui-textarea"><%#Eval("AContent") %></textarea>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
