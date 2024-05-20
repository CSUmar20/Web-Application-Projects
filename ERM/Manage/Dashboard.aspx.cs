using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERM.ERM.Manage
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
            {
                DisplayGrid();
            }
            
        }

        protected void DisplayGrid()
        {
            //delcare the database variables
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ERMConnection"].ConnectionString;
            string SQL = "SELECT [RegistrationID], [FirstName] + ' ' + [LastName] AS [Name], CONVERT(varchar, [DateTimeCreated], 1) AS [DateTimeCreated] FROM [Registrations] WHERE [IsDeleted] = 0 ORDER BY [Name]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(SQL, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet data = new DataSet();

                adapter.Fill(data, "Registrations");

                //bind the grid view
                RegistrationGrid.DataSource = data;
                RegistrationGrid.DataBind();

                //check for no records
                if (data.Tables[0].Rows.Count == 0)
                {
                    lblNoRecords.Visible = true;
                }
                else
                {
                    lblNoRecords.Visible = false;
                }


            }
        }

        protected void RegistrationGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //handle the paging
            RegistrationGrid.PageIndex = e.NewPageIndex;
            DisplayGrid();
        }
    }
}