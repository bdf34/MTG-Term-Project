<%@ Page AutoEventWireup="true" CodeBehind="CollectionEntry.aspx.cs" EnableEventValidation="false" Inherits="MTGApp.CollectionEntry" Language="C#" MasterPageFile="~/Site.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<html xmlns="http://www.w3.org/1999/xhtml">

<body>
    <h2>Collection Mass Entry</h2>
    Use this form to enter your collection
    <br /><br />
    
<div>
    <PlaceHolder id="MassEntryBox" runat="server">
        <textarea id="entrybox" runat="server" style="float:left;" cols="50" rows="20">
Enter your cards here in this format:   
1x Llanowar Elves 
2x Lightning Bolt
        </textarea>
    

    </PlaceHolder>
   
    
    
</div>

<span id="Message" runat="server"> 
              Message area
              </span>


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
          
    <asp:PlaceHolder ID="ControlContainer" runat="server" />
    
  
</asp:Content>  


