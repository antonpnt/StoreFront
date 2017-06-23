<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Week3Assignment._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/Site.css" rel="stylesheet" />
    <div class="jumbotron">
        <h1 class="text-center">Music Store front
        </h1>
        <br /><br />
        <p class="lead"></p>
        
        <table class="nav-justified">
            <tr>
                <td class="text-center" style="font-size: 16pt;">Click <a href="CustomersAdmin1.aspx">here</a> to go to users</td>
                <td class="text-center" style="font-size: 16pt;">Click <a href="ProductsAdmin.aspx">here</a> to go to products</td>
            </tr>
        </table>
    </div>

    <div class="row">
    </div>

</asp:Content>
