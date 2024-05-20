<%@ Page Title="" Language="C#" MasterPageFile="~/Alz/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Alz.Alz.Registration" %>

<asp:Content ID="MyContent" ContentPlaceHolderID="MyContentPlaceHolder2" runat="server">
    <table>
        <tr>
            <td>Walk Location:</td>
            <td width="15">&nbsp;</td>
            <td><asp:TextBox ID="txtWalk" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Team Name:</td>
            <td></td>
            <td><asp:TextBox ID="txtTeams" runat="server"></asp:TextBox></td>
        </tr>
    </table>
</asp:Content>
