<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.Master" AutoEventWireup="true" CodeBehind="Contacts.aspx.cs" Inherits="Diary.Contacts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Dubai" Font-Size="22px" Text="Inserir novo contato"></asp:Label>
<br />
<asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="16px" Text="Nome"></asp:Label>
<br />
<asp:TextBox ID="txbName" runat="server" Width="250px"></asp:TextBox>
<br />
<br />
<asp:Label ID="Label4" runat="server" Font-Names="Calibri" Font-Size="16px" Text="Email"></asp:Label>
<br />
<asp:TextBox ID="txbEmail" runat="server" Width="250px"></asp:TextBox>
<asp:Button ID="btnInsert" runat="server" Font-Names="Calibri" Font-Size="16px" OnClick="BtnInsert_Click" style="margin-left: 28px" Text="Inserir" />
<br />
<br />
<asp:Label ID="Label5" runat="server" Font-Names="Calibri" Font-Size="16px" Text="Telefone"></asp:Label>
<br />
<asp:TextBox ID="txbPhone" runat="server" Width="250px"></asp:TextBox>
<br />
<br />
<br />
<br />
<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Dubai" Font-Size="22px" Text="Lista de Contatos"></asp:Label>
    <asp:GridView ID="gvContacts" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id" DataSourceID="SqlDataSourceContacts" ForeColor="#333333" GridLines="None" AllowPaging="True">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="Name" HeaderText="Nome" SortExpression="Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="Phone" HeaderText="Telefone" SortExpression="Phone" />
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
    <asp:SqlDataSource ID="SqlDataSourceContacts" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Contact] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Contact] ([Name], [Email], [Phone]) VALUES (@Name, @Email, @Phone)" SelectCommand="SELECT * FROM [Contact]" UpdateCommand="UPDATE [Contact] SET [Name] = @Name, [Email] = @Email, [Phone] = @Phone WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="Phone" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="Phone" Type="String" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
