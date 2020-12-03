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

            HtmlButton DeckButton = new HtmlButton
            {
                ID = "Submitter",
                InnerHtml = "Submit"
            };
            DeckButton.Attributes.Add("style", "float: left;");
            DeckButton.ServerClick += new EventHandler(DeckButton_Click);
            PlaceHolder1.Controls.Add(DeckButton);

            HtmlButton RandomDeckButton = new HtmlButton
            {
                InnerHtml = "Generate Random Deck"
            };
            RandomDeckButton.Attributes.Add("style", "float: right;");
            RandomDeckButton.ServerClick += new EventHandler(RandomDeck_Click);
            ConfirmDeck.Controls.Add(RandomDeckButton);

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

            }

           



            //create deck viewer
            //create deck entry

            //problem card display

            //problem card entry


        }

        public void SuggestCardButton_Click(object sender, EventArgs e)
        {

        }


        public void DeckButton_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "hrpsvr.database.windows.net";
            builder.UserID = "hrpzip";
            builder.Password = "DBMProject1!";
            builder.InitialCatalog = "MagicDB";

            string selection = Select1.Value;
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                string deckTitle = "";
                string queryBuild = "SELECT deckName FROM Decks WHERE deckID = " + selection + ";";
                SqlCommand command = new SqlCommand(queryBuild, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    deckTitle += reader["deckName"].ToString();
                }
                fuckingHell.InnerText = deckTitle;
                connection.Close();
            }


            List<string> ProblemIDs = new List<string>();
            string deckColors = "G";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                string queryBuild = "SELECT Card.cardID from Card, ProblemCards where Card.cardID = ProblemCards.cardID and ProblemCards.deckID ="
                    + selection + ";";

                SqlCommand command = new SqlCommand(queryBuild, connection);
                
                SqlDataReader reader = command.ExecuteReader();

                string temp = "";

                // Call Read before accessing data.
                while (reader.Read())
                {
                    temp = reader["cardID"].ToString();
                    ProblemIDs.Add(temp);
                }
                connection.Close();
            }

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                string colorQuery = "SELECT color FROM Decks WHERE deckID = " + selection + ";";
                SqlCommand colorCommand = new SqlCommand(colorQuery, connection);
                SqlDataReader reader2 = colorCommand.ExecuteReader();
                
                while (reader2.Read())
                {
                   
                    deckColors = reader2["color"].ToString();
                }
                connection.Close();
            }


            int userID = 22;

            foreach (string item in ProblemIDs)
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    string deckID = Select1.Value;
                    string queryBuild = "Execute FixProblems @CardID=" + item +
                        ", @Color= " + deckColors +
                        ", @DeckID=" + deckID +
                        ", @UserID=" + userID + ";";
                    SqlCommand command = new SqlCommand(queryBuild, connection);
                    
                    command.ExecuteNonQuery();
                    connection.Close();
                }

            }
        }

        public void RandomDeck_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "hrpsvr.database.windows.net";
            builder.UserID = "hrpzip";
            builder.Password = "DBMProject1!";
            builder.InitialCatalog = "MagicDB";
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                string newDeckName = RandomDeck.Text;
                if(!string.IsNullOrEmpty(newDeckName))
                {
                    string randomDeckQuery = "EXEC RandomDeck @UserID = ";
                    randomDeckQuery += 22;
                    randomDeckQuery += ", @DeckName = \'";
                    randomDeckQuery += newDeckName;
                    randomDeckQuery += "\';";

                    SqlCommand cmd = new SqlCommand(randomDeckQuery, connection);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    ErrorMsg.Text = "This is not a valid deck name!";
                    
                }
                connection.Close();
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }

        protected void RandomDeck_TextChanged(object sender, EventArgs e)
        {

        }
    }
}