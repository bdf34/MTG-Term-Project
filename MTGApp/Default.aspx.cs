using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.Xml.Linq;
using System;
using System.Web.UI.HtmlControls;
using System.Web.Services.Description;

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
            Console.WriteLine(builder.ConnectionString);
            builder.UserID = "hrpzip";
            builder.Password = "DBMProject1!";
            builder.InitialCatalog = "MagicDB";
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString)) 
            try
            {
                    connection.Open();

                    string myQuery = "SELECT Top 1 * FROM Questions ORDER BY rnd(cardID)";

                    SqlCommand command = new SqlCommand(myQuery, connection);
       
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           Message.InnerHtml = myQuery;
                        }
                    }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
  
            Console.ReadLine();

        }
       

    }
}

