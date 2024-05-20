<%@ Page Title="" Language="C#" MasterPageFile="~/ERM/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="ERM.ERM.Manage.Delete" %>

<asp:Content ID="MyContent" ContentPlaceHolderID="MyContentPlaceHolder" runat="server">

        <asp:Panel ID="ErrorPanel" Visible="false" runat="server">
    <div class="alert alert-danger" role="alert">
        <b>Error:</b> <asp:Label ID="ErrorMessage" runat="server" Text=""></asp:Label>
    </div>
    </asp:Panel>
    
  <h2>Symposium Registration</h2>
  <br />

    <!-- ## DELETE MESSAGE ## -->
    <div class="container">
        <div class="row">
            <div class="col">
                <table width="100%">
                    <tr>
                        <td>If you are <b>ABSOLUTELY POSITIVE</b> that you want to <b>DELETE</b> this registration from the database, confirm your action and click the button below</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><asp:CheckBox ID="chkConfirm" runat="server" />&nbsp;Yes, I am sure I want to remove this registration.</td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <br />

    <p><asp:Button ID="cmdDelete" runat="server" Text="DELETE" OnClick="cmdDelete_Click" />&nbsp;&nbsp;<asp:LinkButton ID="cmdCancel" runat="server" OnClick="cmdCancel_Click">CANCEL</asp:LinkButton></p>
</asp:Content>
