<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductAdminDetails.aspx.cs" Inherits="Week3Assignment.ProductAdminDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Update Product</h2>
    <p>
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="ProductID" DataSourceID="SqlDataSource1" Height="50px" Width="271px" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
        <EditRowStyle BackColor="#999999" />
        <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
        <Fields>
            <asp:BoundField DataField="ProductID" HeaderText="Product ID" InsertVisible="False" ReadOnly="True" SortExpression="ProductID" />
            <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:CheckBoxField DataField="IsPublished" HeaderText="Is Published" SortExpression="IsPublished" />
            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                    &nbsp;<asp:LinkButton OnClientClick="return confirm('Are you sure you want to delete this product?');" ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Fields>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    </asp:DetailsView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ecommerceConnectionString %>" DeleteCommand="spDeleteProduct" InsertCommand="spAddProduct" SelectCommand="spGetProduct" UpdateCommand="spUpdateProduct" DeleteCommandType="StoredProcedure" InsertCommandType="StoredProcedure" SelectCommandType="StoredProcedure" UpdateCommandType="StoredProcedure">
        <DeleteParameters>
            <asp:Parameter Name="ProductID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="ProductName" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="IsPublished" Type="Boolean" />
            <asp:Parameter Name="Price" Type="Decimal" />
        </InsertParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="ProductID" QueryStringField="ProductID" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="ProductID" Type="Int32" />
            <asp:Parameter Name="ProductName" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="IsPublished" Type="Boolean" />
            <asp:Parameter Name="Price" Type="Decimal" />
        </UpdateParameters>
    </asp:SqlDataSource>
    </p>
    <p><a href="ProductsAdmin.aspx">Back to products</a></p>
</asp:Content>
