<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Express.OPPortal.ExpressInfo.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        th {
            text-align: center;
        }

        .link:hover {
            text-decoration: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="right" runat="server">
    <div class="query">
        <div class="row">
            <div class="col-md-12">
                快递单号：
                <asp:TextBox ID="txtExpressId" runat="server" CssClass="form-control"></asp:TextBox>
                &nbsp;&nbsp;
                用户名：
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                &nbsp;&nbsp;
                快递状态：
                <asp:DropDownList ID="ddlEpStatus" runat="server" CssClass="form-control">
                    <asp:ListItem Selected="True" Value="-1">---全部---</asp:ListItem>
                    <asp:ListItem Value="0">未接收</asp:ListItem>
                    <asp:ListItem Value="1">已接收</asp:ListItem>
                    <asp:ListItem Value="2">已超时</asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                到站时间：
                <input id="txtBeginDate" type="text" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss' })" runat="server" class="form-control" />
                &nbsp;&nbsp;&nbsp;至&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input id="txtEndDate" type="text" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss' })" runat="server" class="form-control" />
                &nbsp;&nbsp;
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" CssClass="btn btn-default" />
            </div>
        </div>
    </div>

    <%-- 新增按钮 跳转页面 --%>
    <input type="button" class="btn btn-primary" value="新增快递" onclick="javascript: location.href = '/ExpressInfo/Edit.aspx'" style="margin: 5px;" />

    <table class="table table-condensed table-striped table-hover">
        <tr>
            <th>快递单号</th>
            <th>用户名</th>
            <th>手机</th>
            <th>状态</th>
            <th>到站时间</th>
            <th>领取时间</th>
            <th>取件码</th>
            <th>备注</th>
            <th>操作</th>
        </tr>
        <asp:Repeater ID="repExpressList" runat="server" OnItemDataBound="repExpressList_ItemDataBound" OnItemCommand="repExpressList_ItemCommand">
            <ItemTemplate>
                <tr>
                    <td><%#Eval("ExpressId")%></td>
                    <td>
                        <asp:Label ID="lblUserId" runat="server" Text='<%#Eval("UserId") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblPhone" runat="server" Text='<%#Eval("ReceivePhone")%>'></asp:Label>
                    </td>
                    <td>
                        <%--<asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status") %>'></asp:Label>--%>
                        <asp:LinkButton ID="lbtnStatus" runat="server" CssClass="link" CommandName="Change" CommandArgument='<%#Eval("ID")+","+Eval("Status")%>' Text='<%#Eval("Status") %>'><%#Eval("Status") %></asp:LinkButton>
                    </td>
                    <td><%#Eval("ArrivalTime")%></td>
                    <td><%#Eval("GetTime")%></td>
                    <td><%#Eval("GetCode") %></td>
                    <td><%#Eval("Remark")%></td>
                    <td>
                        <asp:LinkButton ID="lbtnSend" runat="server" CommandName="Send" CommandArgument='<%#Eval("ID")%>' OnClientClick="return confirm('确认发送消息吗？');">发送</asp:LinkButton>
                        &nbsp;
                        <a href="<%#"javascript:location.href='/ExpressInfo/Edit.aspx?id="+ Eval("ID") +"'" %>">修改</a>
                        &nbsp;
                        <asp:LinkButton ID="lbtnDel" runat="server" CommandName="Del" CommandArgument='<%#Eval("ID")%>' OnClientClick="return confirm('确认删除吗？');">删除</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
