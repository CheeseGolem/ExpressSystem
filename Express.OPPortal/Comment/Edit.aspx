<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Express.OPPortal.Comment.Edit"  ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        textarea {
            resize: none;
            width: 80%;
        }

        th{
            width:10%
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="right" runat="server">
    <table class="table">
        <tr>
            <th>评价提问：</th>
            <td colspan="2">
                <asp:Label ID="lblQuestion" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <asp:Repeater ID="rptAnswer" runat="server" OnItemDataBound="rptAnswer_ItemDataBound" OnItemCommand="rptAnswer_ItemCommand">
            <ItemTemplate>
                <tr>
                    <th>回复：</th>
                    <td>
                        <asp:Label ID="lblAnswer" runat="server" Text='<%#Eval("AContent") %>'></asp:Label>
                    </td>
                    <td style="width:300px;">
                        <a href='<%#"javascript:editAns("+ Eval("AId") +")" %>'>编辑</a>
                        <asp:LinkButton ID="lbtnDel" runat="server" CommandName="Del" CommandArgument='<%#Eval("AId")%>' OnClientClick="return confirm('确认删除吗？');">删除</asp:LinkButton>
                        <asp:LinkButton ID="lbtnRemind" runat="server" CommandName="Send" CommandArgument='<%#Eval("AId")%>' OnClientClick="return confirm('确认发送提醒吗？');">发送提醒</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>            
            <td colspan="2">
                <textarea id="txtAnswer" runat="server" rows="4" maxlength="300"></textarea>     
                <asp:RequiredFieldValidator ID="rfvAnswer" runat="server" ErrorMessage="*请输入回复" ForeColor="Red" Display="Dynamic" ControlToValidate="txtAnswer"></asp:RequiredFieldValidator>
            </td>
            <td style="padding-top:30px;">
                <asp:Button ID="btnSave" class="btn btn-primary" runat="server" Text="保存" OnClick="btnSave_Click" />
                &nbsp;
                <button type="reset" class="btn btn-default" onclick="clear()">清空</button>                
                &nbsp;
                <input type="button" class="btn btn-cancel" value="取消" onclick="javascript: location.href='/Comment/List.aspx';" />
            </td>
        </tr>
    </table>
    <input type="hidden" id="hidAnsId" runat="server"/>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
    <script type="text/javascript">
        function editAns(aId) {
            $('#hidAnsId').val(aId);            
            $('#txtAnswer').val($('#lblAnswer').text()); 
        }
        //清空隐藏域
        function clear() {
            $('#hidAnsId').val("");
        }
    </script>
</asp:Content>
