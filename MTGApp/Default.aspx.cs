﻿using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Xml.Linq;
using System;
using System.Web.UI.HtmlControls;
using System.Web.Services.Description;
using System.Configuration;
using System.Data;
using System.Configuration;
using System.Web.Security;


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

            HtmlButton SignIn = new HtmlButton();
            SignIn.ID = "SigninButton";
            SignIn.InnerHtml = "Login!";
            SignIn.ServerClick += new System.EventHandler(this.SignIn_Click);
            Signin.Controls.Add(SignIn);

            HtmlButton SignUp = new HtmlButton();
            SignUp.ID = "SignupButton";
            SignUp.InnerHtml = "Register!";
            SignUp.ServerClick += new System.EventHandler(this.SignUp_Click);
            Signin.Controls.Add(SignUp);
        }

        //Demo purposes only to get practice connecting to the database 
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
        }
        void SignIn_Click(object sender, EventArgs e)
        {
            int userid = 0;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "hrpsvr.database.windows.net";
            builder.UserID = "hrpzip";
            builder.Password = "DBMProject1!";
            builder.InitialCatalog = "MagicDB";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                string user = TextBoxUsername.Text;
                string pass = TextBoxPassword.Text;
                connection.Open();

                string qry = "SELECT * FROM UserInfo WHERE username='" + user + "' AND password='" + pass + "'";
                SqlCommand cmd = new SqlCommand(qry, connection);
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.Read())
                    {
                        Label4.Text = "Login Sucess......!!";
                    }
                    else
                    {
                        Label4.Text = "UserId& Password Is not correct Try again..!!";

                    }
                }

            }
        }
        void SignUp_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "hrpsvr.database.windows.net";
            builder.UserID = "hrpzip";
            builder.Password = "DBMProject1!";
            builder.InitialCatalog = "MagicDB";
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                
                string Username = TextBoxUsername.Text;
                string Password = TextBoxPassword.Text;
                
                string myQuery = "INSERT INTO UserInfo(username, password, collectionNumber) " +
                    "VALUES('" + Username + "', '" + Password + "', 0)";

                connection.Open();
                SqlCommand command = new SqlCommand(myQuery, connection);
                command.ExecuteNonQuery();
                //command.Parameters.Add(userParam);
                //command.Parameters.Add(passParam);
                
            }
        }

    }
}