<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CollectionEntry.aspx.cs" Inherits="MTGApp.CollectionEntry" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Collection Entry</title>
</head>
<body>
    <h2>Collection Mass Entry</h2>
    Use this form to enter your collection
    <br /><br />
    
<div>
    <form id="MassEntryBox" runat="server">
    <asp:PlaceHolder ID="TextBox" runat="server" />

    </form>
   
    
    
</div>
     <asp:PlaceHolder ID="ControlContainer" runat="server"/>

    <p>
        &nbsp;</p>

    <p>
        <asp:PlaceHolder ID="OutputArea" runat="server"/>
        
    </p>
          <span id="Message" runat="server"> 
              Message area
              </span>
    
    
    
</body>
</html>
