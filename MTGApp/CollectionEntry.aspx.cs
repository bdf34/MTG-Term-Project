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
    public partial class CollectionEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlTextArea CollectionEntry = new HtmlTextArea();
            CollectionEntry.ID = "entry-box";
            CollectionEntry.InnerHtml = "Enter your cards here...";
            CollectionEntry.Attributes.Add("style", "float: left;  height: 80%; width: 50%;");
            TextBox.Controls.Add(CollectionEntry);


            HtmlButton SubmitButton = new HtmlButton();
            SubmitButton.ID = "btn-submit";
            SubmitButton.InnerHtml = "Submit";
            SubmitButton.ServerClick += new System.EventHandler(this.SubmitButton_Click);
            ControlContainer.Controls.Add(SubmitButton);
            
        }

        void SubmitButton_Click(object sender, EventArgs e)
        {

        }
    }
}