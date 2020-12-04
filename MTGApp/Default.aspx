<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MTGApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    </br>
    
    

    <div class="row">

            <h2>Magic the Gathering Deck Builder</h2>
            <p> Welcome to the (very basic) webpage for demo purposes only. </p
            </p>
        </div>
        <div class="col-md-4">
            
        <div class="col-md-4">
           
          
            <asp:PlaceHolder ID="ControlContainer"
           runat="server"/>

            <br /><br />
 
      <span id="Message"
            runat="server"/>
            <a href="" Style="float:unset">
<img  ID ="randomCard" runat="server"/>
</a>
        </div>
    </div>
</asp:Content>