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

            HtmlButton SubmitButton = new HtmlButton();
            SubmitButton.ID = "Submitter";
            SubmitButton.InnerHtml = "Submit";
            SubmitButton.Attributes.Add("style", "float: left;");
            SubmitButton.ServerClick += new EventHandler(SubmitButton_Click);
            ControlContainer.Controls.Add(SubmitButton);
        }

        void SubmitButton_Click(Object sender, EventArgs e)
        {

            string textFromForm = Request["entrybox"].ToString();



            Message.InnerHtml = textFromForm;



        }
    }
}