<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MTGApp.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="panel panel-default">
        <br />
    <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
    <asp:TextBox ID="TextBoxUsername" placeholder="username" style="text-align: center" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
    <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
    <asp:TextBox ID="TextBoxPassword" placeholder="password" TextMode="Password" style="text-align: center" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
     <asp:Label ID="Label5" runat="server" Text="Confirm Password:"></asp:Label>
    <asp:TextBox ID="TextBoxPasswordConfirm" placeholder="password" TextMode="Password" style="text-align: center" runat="server"></asp:TextBox>
    </div>
    <asp:PlaceHolder ID="Signin" runat="server"/>
    <td><asp:Label ID="Label4" style="color:red" runat="server"></asp:Label></td>
    <td><asp:Label ID="Label6" style="color:red" runat="server"></asp:Label></td>
    <td><asp:Label ID="Label3" runat="server"></asp:Label></td>
</asp:Content>