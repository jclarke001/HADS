<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Inicio.aspx.vb" Inherits="RegistroUsuarios.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Button1 {
            height: 42px;
            width: 76px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            E-mail:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBoxContraseña" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="LabelError" runat="server" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Login" runat="server" Height="47px" Text="Login" Width="73px" />
            <br />
            <br />
            <asp:LinkButton ID="LinkButtonRegistro" runat="server">Quiero Registrarme</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="LinkButtonModificarContraseña" runat="server">Modificar Contraseña</asp:LinkButton>
            <br />
        </div>
    </form>
</body>
</html>
