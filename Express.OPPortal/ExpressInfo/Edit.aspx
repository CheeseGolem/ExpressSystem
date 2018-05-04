<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Express.OPPortal.ExpressInfo.Edit" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="right" runat="server">
    <table class="table">
        <tr>
            <th>快递单号：</th>
            <td>
                <asp:TextBox ID="txtExpressId" CssClass="form-control" runat="server" onblur="GetPhone()"></asp:TextBox>
                <%--非空验证--%>
                <asp:RequiredFieldValidator ID="rfvExpressId" runat="server" ErrorMessage="*快递单号必填" ForeColor="Red" Display="Dynamic" ControlToValidate="txtExpressId"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th>手机：</th>
            <td>
                <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server" onblur="GetUser()"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ErrorMessage="*手机号必填" ForeColor="Red" Display="Dynamic" ControlToValidate="txtPhone"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th>用户名：</th>
            <td>
                <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>快递状态：</th>
            <td>
                <asp:DropDownList ID="ddlStatus" CssClass="form-control" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <th>备注：</th>
            <td>
                <asp:TextBox ID="txtRemark" CssClass="form-control" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th></th>
            <td>
                <asp:Button ID="btnSave" class="btn btn-primary" runat="server" Text="保存" OnClick="btnSave_Click" />
                &nbsp;
                <input type="button" class="btn btn-cancel" value="取消" onclick="javascript: history.go(-1);" />
            </td>
        </tr>
    </table>

    <input type="hidden" id="hidId" runat="server" value="" />
    <input type="hidden" id="hidPhone" runat="server" value="" />
    <input type="hidden" id="hidUserId" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
    <script type="text/javascript">      
        function GetPhone() {
            $.ajax({
                url: 'ExpressInfo.ashx',
                type: 'post',
                dataType: 'json',
                data: {
                    getmethod: "GetPhone",
                    ecode: $('#txtExpressId').val()
                },
                success: function (obj) {
                    $('#txtPhone').val(obj.ReceivedPhone);                    
                }
            })
        }

        function GetUser() {
            //发送AJAX请求
            $.ajax({
                url: 'ExpressInfo.ashx',
                type: 'post',
                dataType: 'json',
                data: {
                    getmethod: "GetUser",
                    phone: $('#txtPhone').val()
                },
                success: function (obj) {
                    $('#txtUserName').val(obj[0].Name);
                    $('#hidPhone').val(obj[0].Phone);
                    $('#hidUserId').val(obj[0].UserId);
                }
            })
        }
    </script>
</asp:Content>
