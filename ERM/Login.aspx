<%@ Page Title="" Language="C#" MasterPageFile="~/ERM/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ERM.ERM.Login" %>

<asp:Content ID="MyContent" ContentPlaceHolderID="MyContentPlaceHolder" runat="server">

    <table align="center">
        <tr>
            <td>Username:</td>
            <td width="10">&nbsp;</td>
            <td><asp:TextBox ID="txtUsername" MaxLength="8" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Password:</td>
            <td width="10">&nbsp;</td>
            <td><asp:TextBox ID="txtPassword" MaxLength="24" TextMode="Password" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td><asp:Button ID="cmdLogin" runat="server" Text="LOGIN" OnClick="cmdLogin_Click" /></td>
        </tr>
    </table>


</asp:Content>
