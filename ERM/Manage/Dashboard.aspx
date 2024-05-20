<%@ Page Title="" Language="C#" MasterPageFile="~/ERM/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="ERM.ERM.Manage.Dashboard" %>

<asp:Content ID="MyContent" ContentPlaceHolderID="MyContentPlaceHolder" runat="server">

    <table width="772" cellspacing="0" cellpadding="0" align="center">
        <tr>
            <th>Manage Registration Dashboard</th>
        </tr>
        <tr>
            <td align="center">
                <br />
                <asp:GridView ID="RegistrationGrid" AutoGenerateColumns="false" AllowPaging="true" PageSize="2" GirdLine="Both" Width="772px" CellSpacing="5" CellPadding="5" DataKeyName="RegistrationID" OnPageIndexChanging="RegistrationGrid_PageIndexChanging" runat="server">
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="RegistrationID"
                            DataNavigateUrlFormatString="View.aspx?id={0}" DataTextField="Name"
                            HeaderText="Registration Name" ItemStyle-Width="582px" />
                        <asp:BoundField DataField="DateTimeCreated" HeaderText="Registration Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HortizontalAlign="Center" ItemStyle-Width="190px" />
                    </Columns>
                </asp:GridView>

                <p align="left"><asp:Label ID="lblNoRecords" Text="There are no results to show in this view." Visible="false" runat="server"></asp:Label> </p>
            </td>
        </tr>
    </table>

</asp:Content>
