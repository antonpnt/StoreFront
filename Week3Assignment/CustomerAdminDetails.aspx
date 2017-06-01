<%@ Page Title="Customer Admin Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerAdminDetails.aspx.cs" Inherits="Week3Assignment.CustomerAdminDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="text-decoration: underline"><em>Update User</em></h2>
    <p>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="UserID" DataSourceID="SqlDataSource1" Height="131px" Width="225px" OnPageIndexChanging="DetailsView1_PageIndexChanging" BorderStyle="Solid" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
            <EditRowStyle BackColor="#999999" />
            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
            <Fields>
                <asp:BoundField DataField="UserID" HeaderText="User ID" InsertVisible="False" ReadOnly="True" SortExpression="UserID" />
                <asp:BoundField DataField="UserName" HeaderText="User Name" SortExpression="UserName" />
                <asp:BoundField DataField="EmailAddress" HeaderText="Email Address" SortExpression="EmailAddress" />
                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                        &nbsp;<asp:LinkButton OnClientClick="return confirm('Are you sure you want to delete this user?');" ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Fields>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        </asp:DetailsView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ecommerceConnectionString %>" DeleteCommand="spDeleteUser" DeleteCommandType="StoredProcedure" SelectCommand="spGetUser" SelectCommandType="StoredProcedure" UpdateCommand="spUpdateUser" UpdateCommandType="StoredProcedure" InsertCommand="spAddUser" InsertCommandType="StoredProcedure">
            <DeleteParameters>
                <asp:Parameter Name="UserID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="UserName" Type="String" />
                <asp:Parameter Name="EmailAddress" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:QueryStringParameter Name="UserID" QueryStringField="UserID" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="UserID" Type="Int32" />
                <asp:Parameter Name="UserName" Type="String" />
                <asp:Parameter Name="EmailAddress" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>
    <p><a href="CustomersAdmin1.aspx">Back to customers</a></p>
    <h2 style="text-decoration: underline"><em>User Addresses</em></h2>
    <p>
        <asp:DetailsView ID="DetailsView2" runat="server" AllowPaging="True" AutoGenerateRows="False" DataKeyNames="AddressID" DataSourceID="SqlDataSource2" Height="50px" Width="258px" BorderStyle="Solid" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
            <EditRowStyle BackColor="#999999" />
            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
            <Fields>
                <asp:BoundField DataField="AddressID" HeaderText="Address ID" InsertVisible="False" ReadOnly="True" SortExpression="AddressID" />
                <asp:BoundField DataField="Address1" HeaderText="Address 1" SortExpression="Address1" />
                <asp:BoundField DataField="Address2" HeaderText="Address 2" SortExpression="Address2" />
                <asp:BoundField DataField="Address3" HeaderText="Address 3" SortExpression="Address3" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                <asp:BoundField DataField="StateID" HeaderText="State ID" SortExpression="StateID" />
                <asp:BoundField DataField="ZipCode" HeaderText="Zip Code" SortExpression="ZipCode" />
            </Fields>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        </asp:DetailsView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ecommerceConnectionString %>" SelectCommand="spGetUserAddresses" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:QueryStringParameter Name="UserID" QueryStringField="UserID" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
</asp:Content>
