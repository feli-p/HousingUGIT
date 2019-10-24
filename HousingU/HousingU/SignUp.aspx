<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="HousingU.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            Nombre:
            <asp:TextBox ID="tBNombre" runat="server"></asp:TextBox>
            <br />
            <br />
            Correo:
            <asp:TextBox ID="tBCorreo" runat="server"></asp:TextBox>
            <br />
            <br />
            Contraseña:
            <asp:TextBox ID="tBCon" runat="server"></asp:TextBox>
            <br />
            <br />
            Verifica tu contraseña:
            <asp:TextBox ID="tBVerif" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:CheckBox ID="CheckBox1" runat="server"/>
            &nbsp;Quiero ofrecer mi vivienda como alojamiento estudiantil<br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="¡Regístrame! " OnClick="Button1_Click" />
            &nbsp;<br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
