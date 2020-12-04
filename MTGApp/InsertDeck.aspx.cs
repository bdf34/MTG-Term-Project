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
    public partial class WebForm2 : System.Web.UI.Page
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
            //get text from entrybox
            string textFromForm = entrybox.Value;

            //create two lists - one to look for a number of cards followed by an x
            // and the name of those cards right after, and one to hold bad input values
            List<string> cardInputs = textFromForm.Split('\n').ToList();
            List<string> badValues = new List<string>();

            List<Tuple<string, string>> cardList = new List<Tuple<string, string>>();

            if (getDataLists(textFromForm, cardInputs, badValues, cardList))
            {
                insertCollection(cardList);
            }
            else
            {
                outPutErrors(badValues);
            }


        }

        void outPutErrors(List<string> values)
        {
            string errorList = "Cards were not entered. These values are not valid card inputs: <br \\><br \\>";
            foreach (string error in values)
            {
                errorList += error;
                errorList += "<br \\>";
            }

            Debug.WriteLine("Errors: " + errorList);
            Message.InnerHtml = errorList;
        }

        Boolean getDataLists(string textFromForm, List<string> cardInputs, List<string> badValues, List<Tuple<string, string>> cardList)
        {

            foreach (string line in cardInputs)
            {
                bool breakFlag = false;
                string quantity = "";
                string cardName = "";

                for (int i = 0; i < line.Length; ++i)
                {
                    if (line[i] == 'x') //looking for the first x, after a number
                    {
                        breakFlag = true;
                    }
                    else
                    {
                        quantity += line[i];
                    }

                    if (breakFlag)
                    {

                        cardName = line.Substring(i + 1, line.Length - (i + 1));
                        i = line.Length;
                        while (!(Char.IsLetter(cardName[cardName.Length - 1]))) //if the last character is a carriage return or not a letter, get rid of it
                        {
                            cardName = cardName.Substring(0, (cardName.Length - 1));

                        }

                    }

                    if ((!breakFlag) && (i == line.Length - 1))
                    {
                        badValues.Add(line);
                    }
                }

                string formattedQuantity = new string((from c in quantity
                                                       where char.IsDigit(c)
                                                       select c).ToArray());
                cardName = cardName.Replace("'", "''");
                
                cardList.Add(Tuple.Create(formattedQuantity, cardName));
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
                string myQuery = "SELECT name FROM Card WHERE name =";

                connection.Open();
                int counter = cardList.Count;
                for (int i = 0; i < counter; i++)
                {
                    if ((cardList[i].Item2 != null) && (cardList[i].Item2.Length > 1))
                    {
                        myQuery += "\'";
                        myQuery += cardList[i].Item2;
                        myQuery += "\' ;" ;

                        SqlCommand cmd = new SqlCommand(myQuery, connection);

                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if (sdr.Read())
                            {
                                Debug.WriteLine(cardList[i].Item2 + " exists");

                            }
                            else
                            {
                                Debug.WriteLine(cardList[i].Item2 + "doesnt exist");
                                Debug.WriteLine(myQuery);
                                string errorBuild = cardList[i].Item1 + cardList[i].Item2;
                                badValues.Add(errorBuild); //add to error list
                                cardList.Remove(cardList[i]);   //Remove from list
                                counter = cardList.Count;
                            }
                        }

                        myQuery = "SELECT name FROM Card WHERE name =";
                    }
                    else
                    {
                        cardList.RemoveAt(i);
                        counter--;
                        i--;
                    }
                }

                connection.Close();

                if (badValues.Count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }


        }


        void insertCollection(List<Tuple<string, string>> cards)
        {

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
                string queryBuild = " ";
                string deckname = DeckTitle.Text;
                connection.Open();

                foreach (Tuple<string, string> record in cards)
                {
                    // DeckInsert @DeckName varchar(50), @Format varchar(60) 
                    queryBuild = "EXEC DeckInsert @UserId = ";
                    //set user id
                    queryBuild += userID;
                    queryBuild += ", @Quantity = ";
                    queryBuild += record.Item1;
                    queryBuild += ", @CardName = \'";
                    queryBuild += record.Item2;
                    queryBuild += "\' , @DeckName = \' ";
                    queryBuild += deckname;
                    queryBuild += " \' , @Format = \' Standard \' ;";




                    SqlCommand cmd = new SqlCommand(queryBuild, connection);

                    cmd.ExecuteNonQuery();
                }

                connection.Close();

            }

            Message.InnerHtml = "<br /> Message: <br />Deck added successfully";

        }

    }
}
