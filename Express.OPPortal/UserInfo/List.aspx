<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Express.OPPortal.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="right" runat="server">
    <table class="table table-condensed table-striped table-hover">
        <tr>
            <th>用户姓名</th>
            <th>手机号</th>
            <th>地址</th>
            <th>微信昵称</th>
            <th>备注</th>                        
        </tr>
        <asp:Repeater ID="repUserList" runat="server" OnItemDataBound="repUserList_ItemDataBound" OnItemCommand="repUserList_ItemCommand">
            <ItemTemplate>
                <tr>
                    <td><%#Eval("Name")%></td>
                    <td><%#Eval("Phone")%></td>
                    <td><%#Eval("Address")%></td>
                    <td><%#Eval("NickName")%></td>
                    <td><%#Eval("Remark")%></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
