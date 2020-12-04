<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InsertDeck.aspx.cs" Inherits="MTGApp.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
    <span id="Span1"
            runat="server"/>
    <br />
    <br />
    <br />

    <h2>Deck Entry</h2>
    Use this form to enter your Deck
    <br /><br />
    Deck Title:
        <asp:TextBox id="DeckTitle" style="text-align: center" runat="server"></asp:TextBox></>
    <br /> 
    <br /> 
    Enter your cards here in this format:  <br /> 
    1xLlanowar Elves <br />
    2xLightning Bolt <br />

        <textarea id="entrybox" name="entrybox"  runat="server" style="float:left;" cols="50" rows="20">
</textarea>
    
    <asp:PlaceHolder ID="ControlContainer" runat="server" />

<h4 id="Message" runat="server"></h4>



    <p>
        &nbsp;
    </p>
    <p>
        &nbsp;
    </p>
    <p>
        &nbsp;
    </p>
    <p>
        &nbsp;
    </p>
    <p>
        &nbsp;
    </p>
    <p>
        &nbsp;
    </p>
    <p>
        &nbsp;
    </p>
    <p>
        &nbsp;
    </p>
    <p>
        &nbsp;
    </p>
          
    
    
  

    </asp:Content>  
