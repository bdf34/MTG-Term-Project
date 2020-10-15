using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Xml.Linq;
using System;
using System.Web.UI.HtmlControls;
using System.Web.Services.Description;
using System.Configuration;
namespace MTGApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlButton RandomButton = new HtmlButton();
            RandomButton.ID = "RandomButton";
            RandomButton.InnerHtml = "Random Card!";
            RandomButton.ServerClick += new System.EventHandler(this.RandomButton_Click);
            ControlContainer.Controls.Add(RandomButton);
        }

        void RandomButton_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            
            builder.DataSource = "hrpsvr.database.windows.net";
            builder.UserID = "hrpzip";
            builder.Password = "DBMProject1!";
            builder.InitialCatalog = "MagicDB";
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                
                string myQuery = "SELECT Top 1 * FROM Cards ORDER BY NEWID()";

                SqlCommand command = new SqlCommand(myQuery, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Message.InnerHtml = (String.Format("{0}, {1}", reader[0], reader[1]));
                        
                    }
                }
            }
            
           // Console.ReadLine();

        }
       

    }
}

