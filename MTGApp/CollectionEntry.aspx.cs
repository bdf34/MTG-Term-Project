using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Services.Description;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Xml.Linq;


namespace MTGApp
{

    public partial class CollectionEntry : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            HtmlButton SubmitButton = new HtmlButton
            {
                ID = "Submitter",
                InnerHtml = "Submit"
            };
            SubmitButton.Attributes.Add("style", "float: left;");
            SubmitButton.ServerClick += new EventHandler(SubmitButton_Click);
            ControlContainer.Controls.Add(SubmitButton);
        }

        void SubmitButton_Click(Object sender, EventArgs e)
        {

            string textFromForm = Request["entrybox"].ToString();

            Message.InnerHtml = textFromForm;


            List<string> cardInputs = textFromForm.Split('\n').ToList();
            List<string> badValues = new List<string>();

            foreach (string line in cardInputs)
                {
                    bool breakFlag = false;
                    string quantity ="";
                    string cardName = "";

                    for(int i = 0; i < line.Length; ++i)
                    { 
                        if (line[i] == 'x')
                        {
                            breakFlag = true; 
                        }
                        else
                        {
                            quantity += line[i];
                        }

                        if (breakFlag)
                        {
                            cardName = line.Substring(i + 1);
                            i = line.Length;
                            cardName.TrimStart(' ');
                            cardName.TrimEnd(' ');
                        }

                        if ((!breakFlag) && (i == line.Length-1))
                        {
                            badValues.Add(line);
                        }
                    }

                string formatedQuantity = new string((from c in quantity
                                                      where char.IsDigit(c)
                                                      select c ).ToArray());
                
                }

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = "hrpsvr.database.windows.net",
                UserID = "hrpzip",
                Password = "DBMProject1!",
                InitialCatalog = "MagicDB"
            };


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
        }
    }
}