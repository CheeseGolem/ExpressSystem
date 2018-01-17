<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Express.OPPortal.Admin.List" ClientIDMode="Static" %>

<%@ Import Namespace="Express.Common" %>
<%@ Import Namespace="Express.Model" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="right" runat="server">
    <div class="query">
        <div class="row">
            <div class="col-md-12">
                用户编号：
                <asp:TextBox ID="txtUserId" runat="server" CssClass="form-control"></asp:TextBox>
                &nbsp;&nbsp;
                用户名：
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                &nbsp;&nbsp;
                用户类型：
                <asp:DropDownList ID="ddlUserType" runat="server" CssClass="form-control">
                    <asp:ListItem Selected="True" Value="-1">---全部---</asp:ListItem>
                    <asp:ListItem Value="1">系统管理员</asp:ListItem>
                    <asp:ListItem Value="2">网站管理员</asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                创建时间：
                <input id="txtBeginDate" type="text" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss' })" runat="server" class="form-control" />
                &nbsp;&nbsp;&nbsp;至&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input id="txtEndDate" type="text" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss' })" runat="server" class="form-control" />
                &nbsp;&nbsp;
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
    <%-- 新增按钮 跳转页面 --%>
    <input type="button" class="btn btn-primary" value="新增用户" onclick="javascript: location.href = '/Admin/Edit.aspx'" style="margin: 5px;" />

    <table class="table table-condensed table-striped table-hover">
        <tr>
            <th>用户编号</th>
            <th>用户名</th>
            <th>真实姓名</th>
            <th>手机</th>
            <th>用户类型</th>
            <th>状态</th>
            <th>创建时间</th>
            <th>操作</th>
        </tr>
        <asp:Repeater ID="repAdminList" runat="server" OnItemDataBound="repAdminList_ItemDataBound" OnItemCommand="repAdminList_ItemCommand">
            <ItemTemplate>
                <tr>
                    <td><%#Eval("UserId")%></td>
                    <td><%#Eval("Username")%></td>
                    <td><%#Eval("RealName")%></td>
                    <td><%#Eval("Phone")%></td>
                    <td><%#EnumHelper.GetDescription<UserType>(Convert.ToInt32(Eval("UserType")))%></td>
                    <td>
                        <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                    </td>
                    <td><%#Eval("CreateDate")%></td>
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
    <script src="../Content/js/common.js"></script>
    <%--引用My97DatePicker--%>
    <script src="../Content/My97DatePicker/WdatePicker.js"></script>

    <script type="text/javascript">
        document.getElementById('txtUserId').onkeydown = function (e) {
            return isNumber(e);
        };

        document.getElementById('txtUserId').onpaste = function (e) {
            return isPasteNum(e);
        }
    </script>
</asp:Content>
