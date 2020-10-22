<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MTGApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    </br>
    <asp:Label ID="Label1" runat="server" Text="login"></asp:Label>
    <asp:TextBox ID="TextBoxUsername" placeholder="username" runat="server"></asp:TextBox>
    <asp:TextBox ID="TextBoxPassword" placeholder="password" TextMode="Password" runat="server"></asp:TextBox>
    <asp:PlaceHolder ID="Signin"
           runat="server"/>
    <asp:PlaceHolder ID="Signup"
           runat="server"/>
    <td><asp:Label ID="Label4" runat="server"></asp:Label></td>
    <td><asp:Label ID="Label3" runat="server"></asp:Label></td>
    

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
               
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
          
            <asp:PlaceHolder ID="ControlContainer"
           runat="server"/>

            <br /><br />
 
      <span id="Message"
            runat="server"/>
        </div>
    </div>
    
   
 

</asp:Content>