using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERM.ERM.Manage
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //load specific registration record
                GetDetails();
            }
            
        }

        protected bool VerifyForm()
        {
            // Response.Write("<h1>" + lstRates.SelectedValue + "<h1>");

            if (txtFirstName.Text == "")
            {
                //txtFirstName.BorderColor= System.Drawing.Color.Red;
                //txtFirstName.BackColor= System.Drawing.Color.Pink;
                //errFirstName.Visible = true;
                ErrorPanel.Visible = true;

                txtFirstName.Focus();
                return false;
            }
            else if (txtLastName.Text == "")
            {
                ErrorPanel.Visible = true;

                txtLastName.Focus();
                return false;
            }
            else if (txtEmail.Text == "")
            {
                ErrorPanel.Visible = true;
                txtEmail.Focus();
                return false;
            }
            else if (txtConfirmEmail.Text == "")
            {
                ErrorPanel.Visible = true;

                txtConfirmEmail.Focus();
                return false;
            }
            else if (txtEmail.Text != txtConfirmEmail.Text)
            {
                ErrorPanel.Visible = true;
                ErrorMessage.Text = "Please confirm your email address.";
                txtConfirmEmail.Text = String.Empty;
                txtConfirmEmail.Focus();
                return false;
            }
            else if (lstRates.SelectedValue == "NULL")
            {
                ErrorPanel.Visible = true;
                ErrorMessage.Text = "Please select a rate.";
                lstRates.Focus();
                return false;
            }
            else if (optRegular.Checked == false && optKosher.Checked == false && optVegetarian.Checked == false && optVegan.Checked == false && optFruit.Checked == false && optGluten.Checked == false && optLactose.Checked == false)
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

        protected void GetDetails()
        {
            //setup and create connection to database
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ERMConnection"].ConnectionString;
            string SQL = "SELECT * FROM [Registrations] WHERE [RegistrationID] = '" + Request.QueryString["id"] + "';";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(SQL);
                command.Connection = connection;
                command.Connection.Open();

                //Create a data reader
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        txtFirstName.Text = reader["FirstName"].ToString();
                        txtLastName.Text = reader["LastName"].ToString();
                        txtEmail.Text = reader["EmailAddress"].ToString();
                        txtConfirmEmail.Text = reader["EmailAddress"].ToString();

                        lstRates.SelectedValue = reader["Rate"].ToString();

                        //lblLunch.Text = reader["Lunch"].ToString();
                        switch(reader["Lunch"].ToString())
                        {
                            case "Regular":
                                optRegular.Checked = true;
                                break;
                            case "Kosher":
                                optKosher.Checked = true; 
                                break;
                            case "Vegetarian":
                                optVegetarian.Checked = true;
                                break;
                            case "Vegan":
                                optVegan.Checked = true;
                                break;
                            case "Fruit Plate":
                                optFruit.Checked = true;
                                break;
                            case "Gluten Free":
                                optGluten.Checked = true;
                                break;
                            case "Lactose Free":
                                optLactose.Checked = true;
                                break;
                            default:
                                break;
                        }

                        chkAudio.Checked = (bool)reader["AudioAid"];
                        chkVisual.Checked = (bool)reader["VisualAid"];
                        chkMobile.Checked = (bool)reader["MobileAid"];
                    }
                }
                //close objects
                reader.Close();
                connection.Close();

            }
        }

        protected bool UpdateRegistration()
        {
            //  try
            // {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ERMConnection"].ConnectionString;
            string SQL = "UPDATE Registrations SET FirstName = @FirstName, LastName = @LastName, EmailAddress = @EmailAddress, Rate = @Rate, Lunch = @Lunch, AudioAid = @AudioAid, VisualAid = @VisualAid, MobileAid = @MobileAid, DateTimeModified = @DateTimeModified WHERE RegistrationID = @RegistrationID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(SQL, connection);

                command.Parameters.AddWithValue("@RegistrationID", Request.QueryString["id"]);
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

                command.Parameters.AddWithValue("@DateTimeModified", DateTime.Now);

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

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            if (VerifyForm() == true)
            {
                if (UpdateRegistration() == true)
                {
                    Response.Redirect("Dashboard.aspx");
                }
                else
                {
                    Response.Redirect("Error.aspx");
                }
            }
        }

        protected void cmdCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("View.aspx?id=" + Request.QueryString["id"]);
        }
    }
}