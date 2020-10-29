using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace MTGApp
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlButton SignIn = new HtmlButton();
            SignIn.ID = "SigninButton";
            SignIn.InnerHtml = "Login!";
            SignIn.ServerClick += new System.EventHandler(this.SignIn_Click);
            Signin.Controls.Add(SignIn);

            /*HtmlButton SignUp = new HtmlButton();
            SignUp.ID = "SignupButton";
            SignUp.InnerHtml = "Register!";
            SignUp.ServerClick += new System.EventHandler(this.SignUp_Click);
            Signin.Controls.Add(SignUp); */
        }
        void SignIn_Click(object sender, EventArgs e)
        {
            //int userid = 0;
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
                        Label4.Text = "Login Sucess......!!\n";
                        HttpCookie CookieName = new HttpCookie("username");
                        CookieName.Value = user;
                        Response.SetCookie(CookieName);
                        string User_name = Request.Cookies["username"].Value;
                        Label3.Text = "Signed in as " + User_name;
                    }
                    else
                    {
                        Label4.Text = "UserId& Password Is not correct Try again..!!";

                    }
                }

            }
        }
       

    }
}