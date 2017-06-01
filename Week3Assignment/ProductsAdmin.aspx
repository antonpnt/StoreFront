<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductsAdmin.aspx.cs" Inherits="Week3Assignment.ProductsAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Products Admin</h2>
    <h3 style="text-decoration: underline"><em>List of Products</em></h3>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ProductID" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display." BorderStyle="Solid" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="ProductID" DataNavigateUrlFormatString="ProductAdminDetails.aspx?ProductID={0}" Text="Edit" />
            <asp:BoundField DataField="ProductID" HeaderText="Product ID" ReadOnly="True" SortExpression="ProductID" />
            <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" />
            <asp:CheckBoxField DataField="IsPublished" HeaderText="Is Published" SortExpression="IsPublished" />
            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ecommerceConnectionString %>" DeleteCommand="DELETE FROM [Product] WHERE [ProductID] = @ProductID" InsertCommand="INSERT INTO [Product] ([ProductName], [Description], [IsPublished], [Quantity], [Price], [ImageFile], [CreatedBy], [DateModified], [ModifiedBy]) VALUES (@ProductName, @Description, @IsPublished, @Quantity, @Price, @ImageFile, @CreatedBy, @DateModified, @ModifiedBy)" ProviderName="<%$ ConnectionStrings:ecommerceConnectionString.ProviderName %>" SelectCommand="SELECT [ProductID], [ProductName], [Description], [IsPublished], [Quantity], [Price], [ImageFile], [CreatedBy], [DateModified], [ModifiedBy] FROM [Product]" UpdateCommand="UPDATE [Product] SET [ProductName] = @ProductName, [Description] = @Description, [IsPublished] = @IsPublished, [Quantity] = @Quantity, [Price] = @Price, [ImageFile] = @ImageFile, [CreatedBy] = @CreatedBy, [DateModified] = @DateModified, [ModifiedBy] = @ModifiedBy WHERE [ProductID] = @ProductID">
        <DeleteParameters>
            <asp:Parameter Name="ProductID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="ProductName" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="IsPublished" Type="Boolean" />
            <asp:Parameter Name="Quantity" Type="Int32" />
            <asp:Parameter Name="Price" Type="Decimal" />
            <asp:Parameter Name="ImageFile" Type="String" />
            <asp:Parameter Name="CreatedBy" Type="String" />
            <asp:Parameter Name="DateModified" Type="DateTime" />
            <asp:Parameter Name="ModifiedBy" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="ProductName" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="IsPublished" Type="Boolean" />
            <asp:Parameter Name="Quantity" Type="Int32" />
            <asp:Parameter Name="Price" Type="Decimal" />
            <asp:Parameter Name="ImageFile" Type="String" />
            <asp:Parameter Name="CreatedBy" Type="String" />
            <asp:Parameter Name="DateModified" Type="DateTime" />
            <asp:Parameter Name="ModifiedBy" Type="String" />
            <asp:Parameter Name="ProductID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <h3 style="text-decoration: underline"><em>Add Product</em></h3>
    <p>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="ProductID" DataSourceID="SqlDataSource1" DefaultMode="Insert" Height="50px" Width="296px" BorderStyle="Solid" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
            <EditRowStyle BackColor="#999999" />
            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
            <Fields>
                <asp:BoundField DataField="ProductID" HeaderText="Product ID" InsertVisible="false" ReadOnly="false" SortExpression="ProductID" />
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:CheckBoxField DataField="IsPublished" HeaderText="Is Published" SortExpression="IsPublished" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                   
                <asp:CommandField ShowInsertButton="True" />
            </Fields>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        </asp:DetailsView>
    </p>
    </asp:Content>
