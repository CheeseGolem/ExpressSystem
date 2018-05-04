<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Express.OPPortal.SendExpress.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="right" runat="server">
    <div class="query">
        <div class="row">
            <div class="col-md-12">
                收件人姓名：
                <asp:TextBox ID="txtReceiveName" runat="server" CssClass="form-control"></asp:TextBox>
                &nbsp;&nbsp;
                收件人手机：
                <asp:TextBox ID="txtReceivePhone" runat="server" CssClass="form-control"></asp:TextBox>
                &nbsp;&nbsp;
                快递状态：
                <asp:DropDownList ID="ddlEpStatus" runat="server" CssClass="form-control">
                    <asp:ListItem Selected="True" Value="-1">---全部---</asp:ListItem>
                    <asp:ListItem Value="0">未接收</asp:ListItem>
                    <asp:ListItem Value="1">已接收</asp:ListItem>
                    <asp:ListItem Value="2">已发送</asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                到站时间：&nbsp;&nbsp;&nbsp;
                <input id="txtBeginDate" type="text" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss' })" runat="server" class="form-control" />
                &nbsp;&nbsp;&nbsp;至&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input id="txtEndDate" type="text" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss' })" runat="server" class="form-control" />
                &nbsp;&nbsp;
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" CssClass="btn btn-default" />
            </div>
        </div>
    </div>

    <table class="table table-condensed table-striped table-hover" style="margin-top:20px">
        <tr>
            <th>收件人姓名</th>
            <th>收件人手机</th>
            <th style="width:100px">收件人地址</th>
            <th>寄件人姓名</th>
            <th>寄件人手机</th>
            <th>状态</th>
            <th>填单时间时间</th>
            <th>是否保价</th>
            <th>操作</th>
        </tr>
        <asp:Repeater ID="repExpressList" runat="server" OnItemDataBound="repExpressList_ItemDataBound" OnItemCommand="repExpressList_ItemCommand">
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("ReceiveName") %>
                    </td>
                    <td>
                        <%#Eval("ReceivePhone")%>
                    </td>
                    <td>
                        <%#Eval("ReceiveAddress")%>
                    </td>
                    <td>
                        <asp:Label ID="lblSendId" runat="server" Text='<%#Eval("SendUserId") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblSendPhone" runat="server" Text='<%#Eval("SendUserId")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                    </td>
                    <td><%#Eval("CreateTime")%></td>
                    <td><%#Eval("IsExpensive").ToString()=="1"?"是":"否"%></td>
                    <td>                        
                        <asp:LinkButton ID="lbtnPrint" runat="server" CommandName="Print" CommandArgument='<%#Eval("ExpressId")%>' OnClientClick="return confirm('确认打印吗？');">打印单据</asp:LinkButton>
                        &nbsp;
                        <asp:LinkButton ID="lbtnSend" runat="server" CommandName="Send" CommandArgument='<%#Eval("ExpressId")%>' OnClientClick="return confirm('确认打印吗？');">发送</asp:LinkButton>
                        &nbsp;
                        <asp:LinkButton ID="lbtnDel" runat="server" CommandName="Del" CommandArgument='<%#Eval("ExpressId")%>' OnClientClick="return confirm('确认删除吗？');">删除</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
