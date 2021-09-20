<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DiaryEntityFramework.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <h2>Entre com seu login</h2>
        <main>
            <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
            <br />
            <asp:TextBox ID="txbEmail" runat="server"></asp:TextBox>
            <asp:Button ID="btnLogin" runat="server" Font-Bold="True" Font-Names="Segoe UI" Font-Overline="False" OnClick="BtnLogin_ClickAsync" style="margin-left: 30px; margin-top: 5px" Text="Entrar" BackColor="#00CC00" BorderColor="Black" BorderStyle="Solid" Font-Size="12px" ForeColor="White" Width="60px" />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Senha"></asp:Label>
            <br />
            <asp:TextBox ID="txbPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lMessage" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="16px" ForeColor="Red"></asp:Label>
        </main>        
        </div>
    </form>
</body>
</html>
