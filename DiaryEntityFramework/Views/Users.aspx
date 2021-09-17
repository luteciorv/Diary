<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/MainMasterPage.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="DiaryEntityFramework.Views.Users" %>

<asp:Content ID="UserContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:Label ID="lUsers" runat="server" Font-Bold="True" Font-Names="Segoe UI" Font-Size="22px" ForeColor="#333333" Text="Usuários"></asp:Label>
    </p>
    <div>
        <asp:ListView ID="UsersList" runat="server" ItemType="DiaryEntityFramework.Models.User"
            SelectMethod="GetUsersAsync" DataKeyNames="Id" UpdateMethod="UpdateItem" DeleteMethod="DeleteItem">

            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: grey; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr runat="server" style="background-color: grey; color: #000000;">
                                    <th runat="server">Identificação</th>
                                    <th runat="server">Email</th>
                                    <th runat="server">Senha</th>
                                    <th runat="server">Nome</th>
                                    <th runat="server">Idade</th>
                                    <th runat="server">Lista de Contatos</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;"></td>
                    </tr>
                </table>
            </LayoutTemplate>

            <ItemTemplate>
                <tr style="background-color: #DCDCDC; color: black">
                    <td>
                        <asp:Label ID="IdLabel" runat="server" Text="<%#: Item.Id %>" />
                    </td>

                    <td>
                        <asp:Label ID="EmailLabel" runat="server" Text="<%#: Item.Email %>" />
                    </td>

                    <td>
                        <asp:Label ID="PasswordLabel" runat="server" Text="<%#: Item.Password %>" />
                    </td>

                    <td>
                        <asp:Label ID="NameLabel" runat="server" Text="<%#: Item.Name %>" />
                    </td>

                    <td>
                        <asp:Label ID="AgeLabel" runat="server" Text="<%#: Item.Age %>" />
                    </td>

                    <td>
                        <asp:Label ID="ContactsLabel" runat="server" Text="<%#:Item.GetAllContacts() %>" />
                    </td>

                    <td>
                        <asp:LinkButton ID="linkEdit" runat="server" Text="Editar" CommandName="Edit" />
                        <asp:LinkButton ID="linkDelete" runat="server" Text="Excluir" CommandName="Delete" />
                    </td>
                </tr>
            </ItemTemplate>

            <EditItemTemplate>
                <tr style="background-color: #008A8C; color: #FFFFFF;">
                    <td>
                        <asp:Label ID="IdLabelEdit" runat="server" Text='<%# Item.Id %>' />
                    </td>

                    <td>
                        <asp:TextBox ID="EmailLabelEdit" runat="server" Text='<%# Bind("Email") %>' />
                    </td>

                    <td>
                        <asp:TextBox ID="PasswordLabelEdit" runat="server" Text='<%# Bind("Password") %>' />
                    </td>

                    <td>
                        <asp:TextBox ID="NameLabelEdit" runat="server" Text='<%# Bind("Name") %>' />
                    </td>

                    <td>
                        <asp:TextBox ID="AgeLabelEdit" runat="server" Text='<%# Bind("Age") %>' />
                    </td>

                    <td>
                        <asp:Label ID="ContactsLabelEdit" runat="server" Text='<%# Item.GetAllContacts() %>' />
                    </td>

                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Salvar" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancelar" />
                    </td>
                </tr>
            </EditItemTemplate>
        </asp:ListView>

        <br />
        <br />

        <asp:GridView ID="UsersGrid" runat="server" BackColor="White"
            BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="2px"
            CellPadding="5" ForeColor="Black" GridLines="Both"
            ItemType="DiaryEntityFramework.Models.User" DataKeyNames="Id"
            SelectMethod="GetUsersAsync" UpdateMethod="UpdateItem" DeleteMethod="DeleteItem"
            AutoGenerateEditButton="true" AutoGenerateDeleteButton="true" AutoGenerateColumns="false">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />

            <Columns>
                <asp:DynamicField HeaderText="Identificação" DataField="Id" />
                <asp:DynamicField HeaderText="Email" DataField="Email" />
                <asp:DynamicField HeaderText="Senha" DataField="Password" />
                <asp:DynamicField HeaderText="Nome" DataField="Name" />
                <asp:DynamicField HeaderText="Idade" DataField="Age" />

                <asp:TemplateField HeaderText="Contatos">
                    <ItemTemplate>
                        <asp:Label runat="server" Text="<%#: Item.GetAllContacts() %>" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <br />
        <br />

        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Segoe UI" Font-Size="16px" Text="Adicionar novo usuário" CssClass="dynamic"></asp:Label>
        <br />
        <asp:Table ID="NewUserTable" runat="server" Width="300px" BackColor="#999966" Font-Bold="True" Font-Names="Segoe UI" ForeColor="#CCCCCC">
            <asp:TableRow runat="server" BorderStyle="Solid">
                <asp:TableCell runat="server" BorderStyle="Inset" HorizontalAlign="Left" VerticalAlign="Middle">
                    Identificação
                </asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
                    <asp:TextBox ID="txbId" runat="server" Width="50px" />
                </asp:TableCell></asp:TableRow><asp:TableRow runat="server" BorderStyle="Solid">
                <asp:TableCell runat="server" BorderStyle="Inset" HorizontalAlign="Left" VerticalAlign="Middle">
                    Email
                </asp:TableCell><asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
                    <asp:TextBox ID="txbEmail" runat="server" Width="180px" />
                </asp:TableCell></asp:TableRow><asp:TableRow runat="server" BorderStyle="Solid">
                <asp:TableCell runat="server" BorderStyle="Inset" HorizontalAlign="Left" VerticalAlign="Middle">
                    Senha 
                </asp:TableCell><asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
                    <asp:TextBox ID="txbPassword" runat="server" Width="180px" />
                </asp:TableCell></asp:TableRow><asp:TableRow runat="server" BorderStyle="Solid">
                <asp:TableCell runat="server" BorderStyle="Inset" HorizontalAlign="Left" VerticalAlign="Middle">
                    Nome
                </asp:TableCell><asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
                    <asp:TextBox ID="txbName" runat="server" Width="180px" />
                </asp:TableCell></asp:TableRow><asp:TableRow runat="server" BorderStyle="Solid">
                <asp:TableCell runat="server" BorderStyle="Inset" HorizontalAlign="Left" VerticalAlign="Middle">
                    Idade
                </asp:TableCell><asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
                    <asp:TextBox ID="txbAge" runat="server" Width="180px" />
                </asp:TableCell></asp:TableRow><asp:TableRow runat="server" BorderStyle="Solid">
                <asp:TableCell runat="server" BorderStyle="Inset" HorizontalAlign="Left" VerticalAlign="Middle">
                    Contato inicial
                </asp:TableCell><asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
                    <asp:DropDownList ID="ddlContact" runat="server" />
                </asp:TableCell></asp:TableRow></asp:Table><br /><asp:Label ID="lErrorAddUser" runat="server" BorderStyle="None" Font-Bold="True" Font-Italic="True" Font-Names="Segoe UI" Font-Underline="True" ForeColor="Red" style="margin-left: 0px"></asp:Label><br /><br />
        <asp:Button ID="btnAdd" runat="server" BackColor="#33CC33" BorderColor="Black" BorderStyle="Solid" CssClass="dynamic selected" Font-Bold="True" Font-Italic="False" Font-Names="Segoe UI" ForeColor="White" Height="35px" OnClick="BtnAdd_ClickAsync" Style="margin-left: 60px" Text="Adicionar" /><asp:Button ID="btnClean" runat="server" BackColor="#FFCC00" BorderColor="Black" BorderStyle="Solid" CssClass="dynamic" Font-Bold="True" Font-Italic="True" Font-Names="Segoe UI" ForeColor="White" Height="35px" OnClick="BtnClean_Click" Style="margin-left: 20px" Text="Limpar" />
        <br />
        <br />
    </div>
</asp:Content>
