using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERM.ERM
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        protected bool Authentication(string username, string password) 
        {

            //setup and create connection to database
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ERMConnection"].ConnectionString;
            string SQL = "SELECT UserID FROM Users WHERE Username = '" + username + "' AND Passowrd = '" + password + "';";
            bool result = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(SQL);
                command.Connection = connection;
                command.Connection.Open();

                //Create a data reader
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows == true)
                {
                    result = true;
                }
                //close objects
                reader.Close();
                connection.Close();

            }

            return result;
        }

        protected void cmdLogin_Click(object sender, EventArgs e)
        {
            if(Authentication(txtUsername.Text, txtPassword.Text) == true)
            {
                System.Web.Security.FormsAuthentication.SetAuthCookie(txtUsername.Text, true);
                Response.Redirect("Manage/Dashboard.aspx");
            }
            
        }
    }
}