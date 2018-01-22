<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Express.OPPortal.LocationInfo.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="right" runat="server">
    <table class="table">
        <tr>
            <th>货架编号：</th>
            <td>
                <asp:DropDownList ID="ddlShelf" CssClass="form-control" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <th>货位编号：</th>
            <td>
                <asp:DropDownList ID="ddlLocation" CssClass="form-control" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <th>货架类型：</th>
            <td>
                <asp:DropDownList ID="ddlShelfType" CssClass="form-control" runat="server"></asp:DropDownList>
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
                <asp:Button ID="btnSave" class="btn btn-primary" runat="server" Text="保存" OnClick="btnSave_Click"/>
                &nbsp;
                <input type="button" class="btn btn-cancel" value="取消" onclick="javascript: history.go(-1);" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
