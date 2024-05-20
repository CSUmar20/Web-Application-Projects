using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERM.ERM
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected bool VerifyForm()
        {
           // Response.Write("<h1>" + lstRates.SelectedValue + "<h1>");

            if(txtFirstName.Text == "")
            {
                //txtFirstName.BorderColor= System.Drawing.Color.Red;
                //txtFirstName.BackColor= System.Drawing.Color.Pink;
                //errFirstName.Visible = true;
                ErrorPanel.Visible = true;

                txtFirstName.Focus();
                return false;
            }
            else if(txtLastName.Text == "")
            {
                ErrorPanel.Visible = true;

                txtLastName.Focus();
                return false;
            }
            else if(txtEmail.Text == "")
            {
                ErrorPanel.Visible = true;
                txtEmail.Focus();
                return false;
            }
            else if(txtConfirmEmail.Text == "")
            {
                ErrorPanel.Visible = true;
                
                txtConfirmEmail.Focus();
                return false;
            }
            else if(txtEmail.Text != txtConfirmEmail.Text)
            {
                ErrorPanel.Visible = true;
                ErrorMessage.Text = "Please confirm your email address.";
                txtConfirmEmail.Text = String.Empty;
                txtConfirmEmail.Focus();
                return false;
            }
            else if(lstRates.SelectedValue == "NULL")
            {
                ErrorPanel.Visible = true;
                ErrorMessage.Text = "Please select a rate.";
                lstRates.Focus();
                return false;
            }
            else if(optRegular.Checked == false && optKosher.Checked == false && optVegetarian.Checked == false && optVegan.Checked == false && optFruit.Checked == false && optGluten.Checked == false && optLactose.Checked == false )
            {
                ErrorPanel.Visible = true;
                ErrorMessage.Text = "Please choose a lunch option.";
                optRegular.Focus();
                return false;
            }
            else
            {
                return true;
            }
            
        }

        public void SendEmailNotification()
        { 
            SmtpClient client = new SmtpClient(/*sendgrid.com/*/);
            client.Port = 25;
            client.EnableSsl = false;
            client.Credentials = new NetworkCredential(/*key/*, keycode/*/);

            
            MailMessage message = new MailMessage();
            message.From = new MailAddress(/*email you want to sent out from/*/);
            message.To.Add(new MailAddress(/*email to sent to notfication/*/));
            message.Subject = "ERM 2024 Symposium Registration Notification";
            message.IsBodyHtml = true;
            message.Body = txtFirstName.Text + " " + txtLastName.Text + "has just registered for the symposium";


            try
           {
                client.Send(message);
            }
           catch(Exception ex)
           {
                Response.Redirect("Error.aspx");
            }
            finally
            {
                message.Dispose();
                client.Dispose();
            }
        }

        public void SendEmailConfirmation()
        {
            SmtpClient client = new SmtpClient(/*sendgrid.com/*/);
            client.Port = 25;
            client.EnableSsl = false;
            client.Credentials = new NetworkCredential(/*key/*, keycode/*/);


            MailMessage message = new MailMessage();
            message.From = new MailAddress(/*email you want to sent out from/*/);
            message.To.Add(new MailAddress(txtEmail.Text));
            message.Subject = "ERM 2024 Symposium Registration Confirmation";
            message.IsBodyHtml = true;
           
            message.Body = "Thank you for registering for the 2024 ERM Symposium";
            message.Body += "<br/><br/>";
            message.Body += "First Name: " + txtFirstName + "<br />";
            message.Body += "Last Name: " + txtLastName + "<br/><br/>";

            message.Body += "Rate: " + lstRates.SelectedValue.ToString() + "<br />";

            string lunchOption = String.Empty;

            if(optRegular.Checked == true)
            {
                lunchOption = "Regular Lunch";
            }
            else if(optKosher.Checked == true)
            {
                lunchOption = "Kosher Lunch";
            }
            else if(optVegetarian.Checked == true)
            {
                lunchOption = "Vegetarian";
            }
            else if (optVegan.Checked == true)
            {
                lunchOption = "Vegan";
            }
            else if(optFruit.Checked == true)
            {
                lunchOption = "Fruit Plate";

            }
            else if(optGluten.Checked == true)
            {
                lunchOption = "Gluten Free";

            }
            else if(optLactose.Checked == true)
            {
                lunchOption = "Lactose Free";
            }

            message.Body += "Lunch Option: " + lunchOption;

            try
            {
                client.Send(message);
            }
            catch (Exception ex) 
            {
                Response.Redirect("Error.aspx");
            }
            finally
            {
                message.Dispose();
                client.Dispose();
            }
        }

        protected bool AddRegistration()
        {
          //  try
           // {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ERMConnection"].ConnectionString;
                string SQL = "INSERT INTO Registrations (RegistrationID, FirstName, LastName, EmailAddress, Rate, Lunch, AudioAid, VisualAid, MobileAid, DateTimeCreated) VALUES (@RegistrationID, @FirstName, @LastName, @EmailAddress, @Rate, @Lunch, @AudioAid, @VisualAid, @MobileAid, @DateTimeCreated)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(SQL, connection);

                    command.Parameters.AddWithValue("@RegistrationID", Guid.NewGuid().ToString());
                    command.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    command.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    command.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
                    command.Parameters.AddWithValue("@Rate", lstRates.SelectedValue);
                    

                    if (optRegular.Checked == true)
                    {
                        command.Parameters.AddWithValue("@Lunch", "Regular");
                    }
                    else if (optKosher.Checked == true)
                    {
                        command.Parameters.AddWithValue("@Lunch", "Kosher");
                    }
                    else if (optVegetarian.Checked == true)
                    {
                        command.Parameters.AddWithValue("@Lunch", "Vegetarian");
                    }
                    else if (optVegan.Checked == true)
                    {
                        command.Parameters.AddWithValue("@Lunch", "Vegan");
                    }
                    else if (optFruit.Checked == true)
                    {
                        command.Parameters.AddWithValue("@Lunch", "Fruit Plate");

                    }
                    else if (optGluten.Checked == true)
                    {
                        command.Parameters.AddWithValue("@Lunch", "Gluten Free");

                    }
                    else if (optLactose.Checked == true)
                    {
                        command.Parameters.AddWithValue("@Lunch", "Lactose Free");
                    }

                    command.Parameters.AddWithValue("@AudioAid", chkAudio.Checked);
                    command.Parameters.AddWithValue("@VisualAid", chkVisual.Checked);
                    command.Parameters.AddWithValue("@MobileAid", chkMobile.Checked);

                    command.Parameters.AddWithValue("@DateTimeCreated", DateTime.Now);

                    connection.Open();
                    command.ExecuteNonQuery();
                    }

                return true;
          //  }
           // catch (Exception ex)
            //{
             //   return false;
            //}
        }

        protected void cmdSubmit_Click(object sender, EventArgs e)
        {
            if(VerifyForm() == true)
            {
                if(AddRegistration() == true)
                {
                    SendEmailNotification();
                    SendEmailConfirmation();
                    Response.Redirect("ThankYou.aspx");
                }
                else
                {
                    Response.Redirect("Error.aspx");
                }
            }
            
        }
    }
}