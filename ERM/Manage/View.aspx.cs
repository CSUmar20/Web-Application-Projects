using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERM.ERM.Manage
{
    public partial class View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //load specific registration record
            GetDetails();
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
                        lblFirstName.Text = reader["FirstName"].ToString();
                        lblLastName.Text = reader["LastName"].ToString();
                        lblEmail.Text = reader["EmailAddress"].ToString();
                        lblRates.Text = reader["Rates"].ToString();
                        lblLunch.Text = reader["Lunch"].ToString();

                        lblAudioAid.Text = reader["AudioAid"].ToString();
                        lblVisualAid.Text = reader["VisualAid"].ToString();
                        lblMobileAid.Text = reader["MobileAid"].ToString();
                    }
                }
                //close objects
                reader.Close();
                connection.Close();

            }
        }

        protected void cmdEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Edit.aspx?id=" + Request.QueryString["id"]);
        }

        protected void cmdDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("Delete.aspx?id=" + Request.QueryString["id"]);
        }

        protected void cmdCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }
    }
}