using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERM.ERM.Manage
{
    public partial class Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected bool VerifyForm()
        {
            if(chkConfirm.Checked == false)
            {
                ErrorPanel.Visible = true;
                ErrorMessage.Text = "Please confirm your removal request.";

                return false;
            }
            else
            {
                return true;
            }
        }

        protected bool DeleteRegistration()
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ERMConnection"].ConnectionString;
                string SQL = "UDPATE [Registrations] SET [IsDeleted] = 1, [DateTimeDeleted] = @DateTimeDeleted WHERE [RegistrationID] = @RegistrationID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(SQL, connection);

                    command.Parameters.AddWithValue("@RegistrationID", Request.QueryString["id"]);
                    command.Parameters.AddWithValue("@DateTimeDeleted", DateTime.Now);

                    connection.Open();
                    command.ExecuteNonQuery();

                }
                return true; 
            }
            catch
            {
                
                return false;
            }
        }
        protected void cmdDelete_Click(object sender, EventArgs e)
        {
            if (VerifyForm() == true)
            {
                if (DeleteRegistration() == true)
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