<%@ Page AutoEventWireup="true" CodeBehind="CollectionEntry.aspx.cs" EnableEventValidation="false" Inherits="MTGApp.CollectionEntry" Language="C#" MasterPageFile="~/Site.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<html xmlns="http://www.w3.org/1999/xhtml">

<body>
    <span id="Span1"
            runat="server"/>
    <br />
    <br />
    <br />

    <h2>Collection Mass Entry</h2>
    Use this form to enter your collection
    <br /><br />
    

        Enter your cards here in this format:  <br /> 
    1xLlanowar Elves <br />
    2xLightning Bolt <br />

        <textarea id="entrybox" name="entrybox"  runat="server" style="float:left;" cols="50" rows="20">
1xLlanowar Elves 
2xLightning Bolt</textarea>
    


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
    </asp:Content>  

