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
        Enter your cards here in this format: <br />
        1xLlanowar Elves <br />
        2xLightning Bolt
        <br /><br /><br />
        <textarea id="entrybox" runat="server" style="float:left;" cols="50" rows="20">
1xLlanowar Elves 
2xLightning Bolt</textarea>
    

    </form>
   
    
    
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
    
    
</body>
</html>
