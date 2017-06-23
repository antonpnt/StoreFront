<%@ Page Title="Customer Admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomersAdmin1.aspx.cs" Inherits="Week3Assignment.CustomersAdmin1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Customers Admin</h2>
    <h3 style="text-decoration: underline"><em>List of customers</em></h3>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="UserID" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display." CellPadding="50" CellSpacing="5" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="UserID" DataNavigateUrlFormatString="CustomerAdminDetails.aspx?UserID={0}" Text="Edit &nbsp;" />
                        <asp:BoundField DataField="UserID" HeaderText="User ID&nbsp;" SortExpression="UserID" />
                        <asp:BoundField DataField="UserName" HeaderText="Username" SortExpression="UserName" />
                        <asp:BoundField DataField="EmailAddress" HeaderText="Email Address" SortExpression="EmailAddress" />
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
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ecommerceConnectionString %>" DeleteCommand="DELETE FROM [User] WHERE [UserID] = @UserID" InsertCommand="INSERT INTO [User] ([UserName], [EmailAddress], [IsAdmin], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy]) VALUES (@UserName, @EmailAddress, @IsAdmin, @DateCreated, @CreatedBy, @DateModified, @ModifiedBy)" ProviderName="<%$ ConnectionStrings:ecommerceConnectionString.ProviderName %>" SelectCommand="SELECT [UserID], [UserName], [Password], [EmailAddress], [IsAdmin], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy] FROM [User]" UpdateCommand="UPDATE [User] SET [UserName] = @UserName, [EmailAddress] = @EmailAddress, [IsAdmin] = @IsAdmin, [DateCreated] = @DateCreated, [CreatedBy] = @CreatedBy, [DateModified] = @DateModified, [ModifiedBy] = @ModifiedBy WHERE [UserID] = @UserID">
                    <DeleteParameters>
                        <asp:Parameter Name="UserID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="UserName" Type="String" />
                        <asp:Parameter Name="EmailAddress" Type="String" />
                        <asp:Parameter Name="IsAdmin" Type="Boolean" />
                        <asp:Parameter Name="DateCreated" Type="DateTime" />
                        <asp:Parameter Name="CreatedBy" Type="String" />
                        <asp:Parameter Name="DateModified" Type="DateTime" />
                        <asp:Parameter Name="ModifiedBy" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="UserName" Type="String" />
                        <asp:Parameter Name="EmailAddress" Type="String" />
                        <asp:Parameter Name="IsAdmin" Type="Boolean" />
                        <asp:Parameter Name="DateCreated" Type="DateTime" />
                        <asp:Parameter Name="CreatedBy" Type="String" />
                        <asp:Parameter Name="DateModified" Type="DateTime" />
                        <asp:Parameter Name="ModifiedBy" Type="String" />
                        <asp:Parameter Name="UserID" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
        <h3 style="text-decoration: underline"><em>Add a Customer</em></h3> 
        <div class="text-left">
            <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="UserID" DataSourceID="SqlDataSource1" DefaultMode="Insert" Height="50px" Width="325px" CellPadding="4" ForeColor="#333333" GridLines="None" BorderStyle="Solid">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                <EditRowStyle BackColor="#999999" />
                <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                <Fields>
                    <asp:BoundField DataField="UserID" HeaderText="User ID" InsertVisible="False" ReadOnly="True" SortExpression="UserID" />
                    <asp:BoundField DataField="UserName" HeaderText="User Name" SortExpression="UserName" />
                    <asp:BoundField DataField="EmailAddress" HeaderText="Email Address" SortExpression="EmailAddress" />
                    <asp:CommandField ShowInsertButton="True" />
                </Fields>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            </asp:DetailsView>

    </div>

</asp:Content>
