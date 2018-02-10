<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Express.OPPortal.Comment.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="right" runat="server">
    <table class="table table-condensed table-striped table-hover">
        <tr>
            <th>提问编号</th>
            <th>问题概览</th>
            <th>提问时间</th>
            <th>回复状态</th>
            <th>操作</th>
        </tr>
        <asp:Repeater ID="repQuestionList" runat="server" OnItemDataBound="repQuestionList_ItemDataBound" OnItemCommand="repQuestionList_ItemCommand">
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("QId") %>'></asp:Label>
                    </td>
                    <td><%#Eval("QContent")%></td>                                        
                    <td><%#Eval("QTime")%></td>
                    <td>
                        <asp:Label ID="lblStatus" runat="server" Text=''></asp:Label>
                    </td>
                    <td>
                        <a href="<%#"javascript:location.href='/Comment/Edit.aspx?id="+ Eval("QId") +"'" %>">回复</a>                                                
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
