<%@ Page Title="" Language="C#" MasterPageFile="~/ERM/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="ERM.ERM.Manage.Edit" %>

<asp:Content ID="MyContent" ContentPlaceHolderID="MyContentPlaceHolder" runat="server">

      <asp:Panel ID="ErrorPanel" Visible="false" runat="server">
      <div class="alert alert-danger" role="alert">
          <b>Error:</b> <asp:Label ID="ErrorMessage" runat="server" Text=""></asp:Label>
      </div>
  </asp:Panel>

  <h2>Symposium Registration</h2>
  <br />

  <!-- ## NAME ## -->
  <div class="container">
      <div class="row">
          <div class="col-6">
              <table>
                  <tr>
                      <td><asp:TextBox ID="txtFirstName" Width="425px" runat="server"></asp:TextBox></td>
                  </tr>
                  <tr>
                      <td><asp:Label ID="lblFirstName" CssClass="field-label" runat="server" Text="First Name"></asp:Label>&nbsp;<asp:Label ID="errFirstName" CssClass="red" Visible="false" runat="server" Text="*"></asp:Label></td>
                  </tr>
              </table>
          </div>
          <div class="col-6">
              <table>
                  <tr>
                      <td><asp:TextBox ID="txtLastName" Width="425px" runat="server"></asp:TextBox></td>
                  </tr>
                  <tr>
                      <td><asp:Label ID="lblLastName" CssClass="field-label" runat="server" Text="Last Name"></asp:Label></td>
                  </tr>
              </table>
          </div>
      </div>
  </div>
  <br />

  <!-- ## Email ## -->
      <div class="container">
          <div class="row">
              <div class="col-6">
                  <table>
                      <tr>
                          <td><asp:TextBox ID="txtEmail" Width="425px" runat="server"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td><asp:Label ID="lblEmail" CssClass="field-label" runat="server" Text="Email Address"></asp:Label></td>
                      </tr>
                  </table>
              </div>
              <div class="col-6">
                  <table>
                      <tr>
                          <td><asp:TextBox ID="txtConfirmEmail" Width="425px" runat="server"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td><asp:Label ID="lblConfirmEmail" CssClass="field-label" runat="server" Text="Confirm Email Address"></asp:Label></td>
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
                          <td><asp:DropDownList ID="lstRates" runat="server">
                                  <asp:ListItem Text=" [ Select a Rate ] " Value="NULL" Selected="True"></asp:ListItem>
                                  <asp:ListItem Text="CAS, CIA, SOA Member Fee" Value="Member"></asp:ListItem>
                                  <asp:ListItem Text="Non-member Fee" Value="Non-member"></asp:ListItem>
                                  <asp:ListItem Text="Dues Waiver" Value="Waiver"></asp:ListItem>
                              </asp:DropDownList></td>
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
              <p>I request the following lunch options:</p>
          </div>
      </div>
      <div class="row">
          <div class="col">
              <p>
                  <asp:RadioButton ID="optRegular" GroupName="Lunch" Text="&nbsp;Regular" runat="server" />&nbsp;&nbsp;
                  <asp:RadioButton ID="optKosher" GroupName="Lunch" Text="&nbsp;Kosher" runat="server" />&nbsp;&nbsp;
                  <asp:RadioButton ID="optVegetarian" GroupName="Lunch" Text="&nbsp;Vegetarian" runat="server" />&nbsp;&nbsp;
                  <asp:RadioButton ID="optVegan" GroupName="Lunch" Text="&nbsp;Vegan" runat="server" />&nbsp;&nbsp;
                  <asp:RadioButton ID="optFruit" GroupName="Lunch" Text="&nbsp;Fruit Plate" runat="server" />&nbsp;&nbsp;
                  <asp:RadioButton ID="optGluten" GroupName="Lunch" Text="&nbsp;Gluten Free" runat="server" />&nbsp;&nbsp;
                  <asp:RadioButton ID="optLactose" GroupName="Lunch" Text="&nbsp;Lactose Free" runat="server" />
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
          <p>I request the following services:</p>
      </div>
  </div>
  <div class="row">
      <div class="col">
          <p>
              <asp:CheckBox ID="chkAudio" Text="Audio Assistance" runat="server" />&nbsp;&nbsp;
              <asp:CheckBox ID="chkVisual" Text="Visual Assistance" runat="server" />&nbsp;&nbsp;
              <asp:CheckBox ID="chkMobile" Text="Mobile Assistance" runat="server" />
          </p>
      </div>
  </div>
</div>
<br />

  <p><asp:Button ID="cmdUpdate" runat="server" Text="UPDATE" OnClick="cmdUpdate_Click" />&nbsp;&nbsp;<asp:LinkButton ID="cmdCancel" runat="server" OnClick="cmdCancel_Click">CANCEL</asp:LinkButton></p>

</asp:Content>
