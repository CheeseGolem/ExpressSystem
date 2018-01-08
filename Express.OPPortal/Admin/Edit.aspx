<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Express.OPPortal.Admin.Edit" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="right" runat="server">

    <input type="hidden" id="txtUserId" runat="server" value="" />

    <table class="table">
        <tr>
            <th>用户名：</th>
            <td>
                <asp:TextBox ID="txtUsername" CssClass="form-control" runat="server"></asp:TextBox>
                <%--非空验证--%>
                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ErrorMessage="*用户名必填" ForeColor="Red" Display="Dynamic" ControlToValidate="txtUsername" ValidationGroup="name"></asp:RequiredFieldValidator>

                <%--范围验证--%>
                <%--<asp:RangeValidator ID="rvUsername" runat="server" ErrorMessage="必须在0~100范围内" MaximumValue="100" MinimumValue="1" ControlToValidate="txtUsername" Type="Integer"></asp:RangeValidator>--%>

                <%--只能包含字母、数字、下划线，只能以字母开头，长度8-16--%>
                <%--<asp:RegularExpressionValidator ID="revUsername" runat="server" ErrorMessage="只能包含字母、数字、下划线，只能以字母开头，长度8-16" ValidationExpression="^[a-zA-Z]\w{7,15}$" ControlToValidate="txtUsername" ></asp:RegularExpressionValidator>--%>
            </td>
        </tr>
        <tr>
            <th>密码：</th>
            <td>
                <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>                
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="*密码必填" ForeColor="Red" Display="Dynamic" ControlToValidate="txtPassword" ValidationGroup="pwd"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th>真实姓名：</th>
            <td>
                <asp:TextBox ID="txtRealName" CssClass="form-control" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>手机：</th>
            <td>
                <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>用户类型：</th>
            <td>
                <asp:DropDownList ID="ddlUserType" CssClass="form-control" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <th>用户状态：</th>
            <td>                
                <asp:RadioButtonList ID="rblStatus" runat="server"></asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <th></th>
            <td>
                <input type="button" class="btn btn-primary" value="保存" onclick="savaUser()" />
                &nbsp;
                <input type="button" class="btn btn-cancel" value="取消" onclick="javascript:history.go(-1);" />
                <%--<asp:Button ID="btnCancel" class="btn btn-cancel" runat="server" Text="取消" OnClientClick="javascript:history.go(-1);" />--%>
            </td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
    <script src="/Content/js/md5.encrypt.js" type="text/javascript"></script>
    <script type="text/javascript">

        function savaUser() {
            //输入项验证
            if (!Page_ClientValidate('name')) {
                return false;
            }
            if (!Page_ClientValidate('pwd')) {
                return false;
            }

            //1.0 获取编辑项的值

            //2.0 创建JS对象
            var postData = {
                UserId: $('#txtUserId').val(),
                Username: $('#txtUsername').val(),
                Password: '',
                RealName: $('#txtRealName').val(),
                Phone: $('#txtPhone').val(),
                UserType: $('#ddlUserType').val(),
                Status: $(':radio[name="ctl00$right$rblStatus"]:checked').val(),
            }

            //2.1 判断是否修改密码
            var pwd = $('#txtPassword').val();
            if (pwd != "" && pwd != "******") {
                postData.Password = hex_md5(pwd).toUpperCase();
            }


            //测试
            //console.log(postData);
            //return false;


            //3.0 发送AJAX请求
            $.ajax({
                url: '/Login/SaveUserHandler.ashx',
                type: 'post',
                dataType: 'json',
                data: postData,
                success: function (obj) {
                    if (obj.Status == 0) {
                        alert('保存成功');
                        window.location.href = '/Admin/List.aspx';
                    } else {
                        alert(obj.Msg);
                    }
                }
            });
        }   
    </script>
</asp:Content>
