<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Express.OPPortal.ExpressInfo.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="right" runat="server">
    <%-- 新增按钮 跳转页面 --%>
    <input type="button" class="btn btn-primary" value="新增用户" onclick="javascript: location.href = '/Admin/Edit.aspx'" style="margin: 5px;" />

    <table class="table table-condensed table-striped table-hover">
        <tr>
            <th>快递单号</th>
            <th>用户名</th>            
            <th>手机</th>
            <th>状态</th>
            <th>到站时间</th>
            <th>领取时间</th>
            <th>备注</th>            
            <th>操作</th>
        </tr>
        <asp:Repeater ID="repExpressList" runat="server" OnItemDataBound="repExpressList_ItemDataBound" OnItemCommand="repExpressList_ItemCommand">
            <ItemTemplate>
                <tr>
                    <td><%#Eval("ExpressId")%></td>
                    <td><%#Eval("UserId")%></td>                    
                    <td><%#Eval("SendPhone")%></td>                    
                    <td>
                        <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                    </td>
                    <td><%#Eval("ArrivalTime")%></td>
                    <td><%#Eval("GetTime")%></td>
                    <td><%#Eval("Remark")%></td>
                    <td>
                        <a href="<%#"javascript:location.href='/Admin/Edit.aspx?id="+ Eval("UserId") +"'" %>">修改</a>
                        &nbsp;
                        <asp:LinkButton ID="lbtnDel" runat="server" CommandName="Del" CommandArgument='<%#Eval("UserId")%>' OnClientClick="return confirm('确认删除吗？');">删除</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
