<%@ Page Title="" Language="C#" MasterPageFile="~/ERM/Site.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="ERM.ERM.Manage.View" %>

<asp:Content ID="MyContent" ContentPlaceHolderID="MyContentPlaceHolder" runat="server">

  <h2>Symposium Registration</h2>
  <br />

  <!-- ## NAME & EMAIL ## -->
  <div class="container">
      <div class="row">
          <div class="col-6">
              <table>
                  <tr>
                      <td><asp:Label ID="lblFirstName" runat="server"></asp:Label> <asp:Label ID="lblLastName" runat="server"></asp:Label></td>
                  </tr>
              </table>
          </div>
          <div class="col-6">
              <table>
                  <tr>
                      <td><asp:Label ID="lblEmail" runat="server"></asp:Label></td>
                  </tr>
              </table>
          </div>
      </div>
  </div>
  <br />

  <!-- ## RATES ##-->
  <h2>Symposium Rate</h2>
  <br />

  <div class="container">
      <div class="row">
          <div class="col">
                  <table>
                      <tr>
                          <td>
                              <asp:Label ID="lblRates" runat="server"></asp:Label>
                          </td>
                      </tr>
                  </table>
          </div>
      </div>
  </div>
  <br />

  <h2>Lunch Options</h2>
  <br />

  <!-- ## Lunch ## -->
  <div class="container">
      <div class="row">
          <div class="col">
              <p>The following lunch option has been selected:</p>
          </div>
      </div>
      <div class="row">
          <div class="col">
              <p>
                  <asp:Label ID="lblLunch" runat="server"></asp:Label>
              </p>
          </div>
      </div>
  </div>
  <br />

  <h2>Accessibility Options</h2>
  <br />

  <!-- ## DISABILITY ## -->
  <div class="container">
  <div class="row">
      <div class="col">
          <p>The following services are required:</p>
      </div>
  </div>
  <div class="row">
      <div class="col">
          <p>Audio Assistance Required: <asp:Label ID="lblAudioAid" runat="server" /></p>
          <p>Visual Assistance Required: <asp:Label ID="lblVisualAid" runat="server" /></p>
          <p>Mobile Assistance Required: <asp:Label ID="lblMobileAid" runat="server" /> </p>
      </div>
  </div>
</div>
<br />

  <p><asp:Button ID="cmdEdit" runat="server" Text="EDIT" OnClick="cmdEdit_Click" />&nbsp;&nbsp;<asp:Button ID="cmdDelete" runat="server" Text="DELETE" OnClick="cmdDelete_Click" />&nbsp;&nbsp;<asp:LinkButton ID="cmdCancel" runat="server" OnClick="cmdCancel_Click">CANCEL</asp:LinkButton></p>
</asp:Content>
