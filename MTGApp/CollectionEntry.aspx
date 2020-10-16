<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CollectionEntry.aspx.cs" Inherits="MTGApp.CollectionEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Collection Entry</title>
    <style type="text/css">
        #TextArea1 {
            height: 500px;
            width: 600px;
        }
    </style>
</head>
<body>
    <h2>Collection Mass Entry</h2>
    Use this form to enter your collection
    <br /><br />

    <form id="MassEntryBox" runat="server">
        <asp:PlaceHolder ID="TextBox" runat="server" />
        <br />
        <asp:PlaceHolder ID="ControlContainer" runat="server"/>
    </form>
    <article id="validation output" style="float: left; width:20%">
        Test Data.
    </article>
</body>
</html>
