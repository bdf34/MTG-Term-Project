using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Diagnostics;
using System.Web.Services.Description;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Xml.Linq;

namespace MTGApp
{
    public partial class DeckViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = "hrpsvr.database.windows.net",
                    UserID = "hrpzip",
                    Password = "DBMProject1!",
                    InitialCatalog = "MagicDB"
                };

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    string queryBuild = "SELECT * FROM Decks WHERE userID = 22;";
                    SqlDataAdapter command = new SqlDataAdapter(queryBuild, connection);
                    connection.Open();

                    DataSet ds = new DataSet();
                    command.Fill(ds, "DeckList");

                    Select1.DataSource = ds;
                    Select1.DataTextField = "deckName";
                    Select1.DataValueField = "deckId";
                    Select1.DataBind();
                }


                HtmlButton DeckButton = new HtmlButton
                {
                    ID = "Submitter",
                    InnerHtml = "Submit"
                };
                DeckButton.Attributes.Add("style", "float: left;");
                DeckButton.ServerClick += new EventHandler(DeckButton_Click);
                ConfirmDeck.Controls.Add(DeckButton);





            }
            


            //create deck viewer
            //create deck entry

            //problem card display

            //problem card entry


            //create suggest button
            /*
            HtmlButton SuggestButton = new HtmlButton
            {
                ID = "Submitter",
                InnerHtml = "Submit"
            };
            SuggestButton.Attributes.Add("style", "float: left;");
            SuggestButton.ServerClick += new EventHandler(SuggestCardButton_Click);
            SuggestCardButton.Controls.Add(SuggestButton);

            */
        }

        public void SuggestCardButton_Click(object sender, EventArgs e)
        {

        }


        public void DeckButton_Click(object sender, EventArgs e)
        {

        }
    }
}