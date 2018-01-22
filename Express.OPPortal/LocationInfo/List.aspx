<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Express.OPPortal.LocationInfo.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="right" runat="server">
    <%-- 新增按钮 跳转页面 --%>
    <input type="button" class="btn btn-primary" value="新增货位" onclick="javascript: location.href = '/LocationInfo/Edit.aspx'" style="margin: 5px;" />

    <table class="table table-condensed table-striped table-hover">
        <tr>
            <th>货架编号</th>
            <th>货位编号</th>
            <th>货架类型</th>            
            <th>创建时间</th>
            <th>修改时间</th>
            <th>备注</th>
            <th>操作</th>
        </tr>
        <asp:Repeater ID="repShelfList" runat="server" OnItemDataBound="repShelfList_ItemDataBound" OnItemCommand="repShelfList_ItemCommand">
            <ItemTemplate>
                <tr>
                    <td><%#Eval("Shelf")%></td>
                    <td><%#Eval("Location")%></td>                    
                    <td>
                        <asp:Label ID="lblType" runat="server" Text='<%#Eval("Type") %>'></asp:Label>
                    </td>
                    <td><%#Eval("CreateTime")%></td>
                    <td><%#Eval("UpdateTime")%></td>
                    <td><%#Eval("Remark")%></td>
                    <td>
                        <a href="<%#"javascript:location.href='/LocationInfo/Edit.aspx?id="+ Eval("SID") +"'" %>">修改</a>
                        &nbsp;
                        <asp:LinkButton ID="lbtnDel" runat="server" CommandName="Del" CommandArgument='<%#Eval("SID")%>' OnClientClick="return confirm('确认删除吗？');">删除</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
