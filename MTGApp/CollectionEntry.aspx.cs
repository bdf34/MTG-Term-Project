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
            HtmlTextArea CollectionEntry = new HtmlTextArea();
            CollectionEntry.ID = "entrybox";
            CollectionEntry.InnerHtml = "Enter your cards here in this format:   \n1x Llanowar Elves \n2x Lightning Bolt ";
            CollectionEntry.Attributes.Add("style", "float: left;");
            CollectionEntry.Attributes.Add("cols", "50");
            CollectionEntry.Attributes.Add("rows", "20");
            TextBox.Controls.Add(CollectionEntry);

            HtmlElement Output = new HtmlElement();
            Output.ID = "Outputter";
            Output.InnerHtml = "Test";
            Output.Attributes.Add("style", "float: left;");
            OutputArea.Controls.Add(Output);

            HtmlButton SubmitButton = new HtmlButton();
            SubmitButton.ID = "Submitter";
            SubmitButton.InnerHtml = "Submit";
            SubmitButton.Attributes.Add("style", "float: left;");
            SubmitButton.ServerClick += new EventHandler(SubmitButton_Click);
            ControlContainer.Controls.Add(SubmitButton);
            
            
            

        }

        void SubmitButton_Click(object sender, EventArgs e)
        {

            string textFromForm = Request["entrybox"].ToString();



            Message.InnerHtml = textFromForm;



        }
    }
}