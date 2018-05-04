<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Express.OPPortal.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="right" runat="server">
    <div class="query">
        <div class="row">
            <div class="col-md-12">                
                用户名：&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                &nbsp;&nbsp;
                微信昵称：
                <asp:TextBox ID="txtNickName" runat="server" CssClass="form-control"></asp:TextBox>
                &nbsp;&nbsp;
                手机号：
                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                &nbsp;&nbsp;
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                创建时间：
                <input id="txtBeginDate" type="text" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss' })" runat="server" class="form-control" />
                &nbsp;&nbsp;&nbsp;至&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input id="txtEndDate" type="text" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss' })" runat="server" class="form-control" />
                &nbsp;&nbsp;
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
    <table class="table table-condensed table-striped table-hover">
        <tr>
            <th>用户姓名</th>
            <th>手机号</th>
            <th>地址</th>
            <th>微信昵称</th>
            <th>绑定时间</th>
            <th>备注</th>                        
        </tr>
        <asp:Repeater ID="repUserList" runat="server" OnItemDataBound="repUserList_ItemDataBound" OnItemCommand="repUserList_ItemCommand">
            <ItemTemplate>
                <tr>
                    <td><%#Eval("Name")%></td>
                    <td><%#Eval("Phone")%></td>
                    <td><%#Eval("Address")%></td>
                    <td><%#Eval("NickName")%></td>
                    <td><%#Eval("CreateTime")%></td>
                    <td><%#Eval("Remark")%></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
