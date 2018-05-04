<%@ Page Title="" Language="C#" MasterPageFile="~/WeChat.Master" AutoEventWireup="true" CodeBehind="QuestionHistory.aspx.cs" Inherits="WeChatWebSite.Comment.QuestionHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="weui-cells">
        <div class="weui-cell">
            <img src="../Content/Images/banner.jpg" style="height: 180px; width: 100%" />
        </div>
        <asp:Repeater ID="rptQuestion" runat="server">
            <ItemTemplate>
                <a href="AnswerDetail.aspx?qid=<%#Eval("qid") %>">
                    <div class="weui-cell">
                        <div class="weui-cell__hd" style="position: relative; margin-right: 10px;">
                            <%--<span class="weui-badge" style="position: absolute; top: -.4em; right: -.4em;">8</span>--%>
                        </div>
                        <div class="weui-cell__bd">
                            <p><%#Eval("QContent") %></p>
                            <p style="font-size: 13px; color: #888888;"><%#Eval("QTime") %></p>
                        </div>
                    </div>
                </a>
            </ItemTemplate>
        </asp:Repeater>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
