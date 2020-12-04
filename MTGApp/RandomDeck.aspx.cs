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
    public partial class DeckEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlButton RandomDeckButton = new HtmlButton
            {
                InnerHtml = "Generate Random Deck"
            };
            RandomDeckButton.Attributes.Add("style", "float: right;");
            RandomDeckButton.ServerClick += new EventHandler(RandomDeck_Click);
            ConfirmDeck.Controls.Add(RandomDeckButton);

        }


        public void RandomDeck_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "hrpsvr.database.windows.net";
            builder.UserID = "hrpzip";
            builder.Password = "DBMProject1!";
            builder.InitialCatalog = "MagicDB";

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
                connection.Open();
                string newDeckName = RandomDeck.Text;
                if (!string.IsNullOrEmpty(newDeckName))
                {
                    string randomDeckQuery = "EXEC RandomDeck @UserID = ";
                    randomDeckQuery += userID;
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
                //Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }

            string Selection = " ";
            
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                string queryBuild = "SELECT TOP 1 deckID FROM Decks WHERE userID = " + userID + " order by deckID desc;";
                SqlCommand command = new SqlCommand(queryBuild, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    Selection += reader["deckID"].ToString();
                }
            }

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
        }
    }
}