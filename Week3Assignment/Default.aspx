<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Week3Assignment._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/Site.css" rel="stylesheet" />
    <div class="jumbotron">
        <h1 class="text-left">Store Front&nbsp;
            <asp:Image ID="Image1" runat="server" Height="106px" ImageUrl="~/Images/cashregister.jpg" Width="151px" />
        </h1>
        <p class="lead">This is a simple asp.net application that makes use of a store front with customers and products.</p>
        <h1>&nbsp;</h1>
        <table class="nav-justified">
            <tr>
                <td>Click <a href="CustomersAdmin1.aspx">here</a> to go to users</td>
                <td>Click <a href="ProductsAdmin.aspx">here</a> to go to products</td>
            </tr>
        </table>
    </div>

    <div class="row">
    </div>

</asp:Content>
