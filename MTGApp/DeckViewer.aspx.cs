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
                InnerHtml = "Select"
            };
            DeckButton.Attributes.Add("style", "float: left;");
            DeckButton.ServerClick += new EventHandler(Select_Deck);
            PlaceHolder1.Controls.Add(DeckButton);

            if (!IsPostBack)
            {

                HtmlButton PCValidate = new HtmlButton
                {
                    ID = "PCValidate",
                    InnerHtml = "Submit"
                };
                PCValidate.Attributes.Add("style", "float: right;");
                PCValidate.ServerClick += new EventHandler(Validate_PC);
                PlaceHolder2.Controls.Add(PCValidate);
                PlaceHolder2.Visible = false;

                HtmlButton SuggestButton = new HtmlButton
                {
                    ID = "DisplaySuggestions",
                    InnerHtml = "Click for Suggestions"
                };
                SuggestButton.Attributes.Add("style", "float: unset;");
                SuggestButton.ServerClick += new EventHandler(SuggestCardButton_Click);
                SuggestCardButton.Controls.Add(SuggestButton);
                SuggestCardButton.Visible = false;


                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = "hrpsvr.database.windows.net",
                    UserID = "hrpzip",
                    Password = "DBMProject1!",
                    InitialCatalog = "MagicDB"
                };

                string userID = " ";
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    string User_name = Request.Cookies["username"].Value;
                    connection.Open();
                    string myQuery = "SELECT userID FROM UserInfo WHERE username ="
                        + " '" + User_name + "' ";
                    SqlCommand command = new SqlCommand(myQuery, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        userID = reader["userID"].ToString();
                    }

                }


                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    string queryBuild = "SELECT * FROM Decks WHERE userID = " + userID + ";";
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
            else
            {
                HtmlButton PCValidate = new HtmlButton
                {
                    ID = "PCValidate",
                    InnerHtml = "Validate"
                };
                PCValidate.Attributes.Add("style", "float: right;");
                PCValidate.ServerClick += new EventHandler(Validate_PC);
                PlaceHolder2.Controls.Add(PCValidate);
                PlaceHolder2.Visible = true;

                HtmlButton SuggestButton = new HtmlButton
                {
                    ID = "DisplaySuggestions",
                    InnerHtml = "Click for Suggestions"
                };
                SuggestButton.Attributes.Add("style", "float: unset;");
                SuggestButton.ServerClick += new EventHandler(SuggestCardButton_Click);
                SuggestCardButton.Controls.Add(SuggestButton);
                SuggestCardButton.Visible = true;
            }

        }

        public void Validate_PC(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = "hrpsvr.database.windows.net",
                UserID = "hrpzip",
                Password = "DBMProject1!",
                InitialCatalog = "MagicDB"
            };

            string pcCard;
            pcCard = ProblemCardEntry.Text.ToString();
            string pcNum = " ";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                string queryBuild = "SELECT cardID from Card WHERE name = \'" + pcCard + "\';";
                SqlCommand command = new SqlCommand(queryBuild, connection);

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    pcNum = reader["cardID"].ToString();
                }
                connection.Close();
            }

            if (pcNum == " ")
            {
                messageOutput.InnerText = "Not found";
                picOutput.Src = " ";
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    string uri = " ";
                    connection.Open();
                    string queryBuild = "SELECT imageURI from Card WHERE cardID = " + pcNum + ";";
                    SqlCommand command = new SqlCommand(queryBuild, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    // Call Read before accessing data.
                    while (reader.Read())
                    {
                        uri = reader["imageURI"].ToString();
                    }

                    messageOutput.InnerText = " ";
                    picOutput.Width = 200;
                    picOutput.Src = uri;
                    connection.Close();

                }

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    string deckID = Select1.Value.ToString();
                    string queryBuild = "INSERT INTO ProblemCards VALUES ( " + deckID + ", " + pcNum + ");";
                    
                    SqlCommand command = new SqlCommand(queryBuild, connection);

                    command.ExecuteNonQuery();
                    connection.Close();

                }
            }

        }


        public void SuggestCardButton_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "hrpsvr.database.windows.net";
            builder.UserID = "hrpzip";
            builder.Password = "DBMProject1!";
            builder.InitialCatalog = "MagicDB";

            string selection = Select1.Value;

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


            string userID = " ";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                string User_name = Request.Cookies["username"].Value;
                connection.Open();
                string myQuery = "SELECT userID FROM UserInfo WHERE username ="
                    + " '" + User_name + "' ";
                SqlCommand command = new SqlCommand(myQuery, connection);
                int i = 0;
                object user_id = command.ExecuteScalar();
                if (user_id != null)
                {
                    i = (int)user_id;
                }
                userID = i.ToString();
            }


            string deckID = Select1.Value;

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                string queryBuild = "Delete Suggestions WHERE deckID = " + deckID + ";";
                SqlCommand command = new SqlCommand(queryBuild, connection);

                command.ExecuteNonQuery();
                connection.Close();
            }

            foreach (string item in ProblemIDs)
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    string queryBuild = "Execute FixProblems @CardID=" + item +
                        ", @Color= " + deckColors +
                        ", @DeckID=" + deckID +
                        ", @UserID=" + userID + ";";
                    SqlCommand command = new SqlCommand(queryBuild, connection);
                    
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            string firstCard = Get_Suggested_Card(deckID);
            string secondCard = Get_Suggested_Card(deckID);
            string thirdCard = Get_Suggested_Card(deckID);
            suggestion1.Width = 200;
            suggestion2.Width = 200;
            suggestion3.Width = 200;
            suggestion1.Src = firstCard;
            suggestion2.Src = secondCard;
            suggestion3.Src = thirdCard;

            


        }

        protected string Get_Suggested_Card(string deckID)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "hrpsvr.database.windows.net";
            builder.UserID = "hrpzip";
            builder.Password = "DBMProject1!";
            builder.InitialCatalog = "MagicDB";

            string holder = " ";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                string queryBuild = "SELECT TOP 1 cardID From Suggestions WHERE deckID = " 
                    + deckID + " ORDER BY NEWID();";

                SqlCommand command = new SqlCommand(queryBuild, connection);
                SqlDataReader reader2 = command.ExecuteReader();

                
                while (reader2.Read())
                {

                    holder = reader2["cardID"].ToString();
                }
                connection.Close();
            }

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                string queryBuild = "Delete Suggestions where cardID = " + holder + "AND deckID = " + deckID + ";";
                SqlCommand command = new SqlCommand(queryBuild, connection);

                command.ExecuteNonQuery();
                connection.Close();
            }

            string suggestedURI = " ";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                string queryBuild = "SELECT TOP 1 imageURI From Card WHERE cardID = " + holder + ";";

                SqlCommand command = new SqlCommand(queryBuild, connection);
                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {

                    suggestedURI = reader2["imageURI"].ToString();
                }
                connection.Close();
            }

            return suggestedURI;
        }

        protected void Select_Deck(object sender, EventArgs e)
        {
            PlaceHolder2.Visible = true;
            SuggestCardButton.Visible = true;

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = "hrpsvr.database.windows.net",
                UserID = "hrpzip",
                Password = "DBMProject1!",
                InitialCatalog = "MagicDB"
            };

            string Selection = Select1.Value.ToString();

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                
                string queryBuild = "SELECT  Decks.deckName as deckName, Card.name as cardName, DeckList.quantity as quantity FROM Decks, DeckList, Card WHERE ";
                queryBuild += "Card.cardID = DeckList.cardID and Decks.deckID = DeckList.deckID and DeckList.deckID = " + Selection + ";";
                SqlDataAdapter command = new SqlDataAdapter(queryBuild, connection);
                connection.Open();

                DataSet ds = new DataSet();
                command.Fill(ds, "DeckList");
                Repeater1.DataSource = ds;
                Repeater1.DataBind();
            }

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                string deckTitle = "";
                string queryBuild = "SELECT deckName FROM Decks WHERE deckID = " + Selection + ";";
                SqlCommand command = new SqlCommand(queryBuild, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    deckTitle += reader["deckName"].ToString();
                }
                titleText.InnerText = deckTitle;
                connection.Close();
            }
        }
    }
}