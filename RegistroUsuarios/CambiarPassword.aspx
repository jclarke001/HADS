<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CambiarPassword.aspx.vb" Inherits="RegistroUsuarios.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        Email:&nbsp; <asp:TextBox ID="TextBoxEmail" runat="server" Width="238px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Height="35px" Text="Solicitar cambiar contraseña" Width="283px" />
        <p>
            Insertar código:&nbsp; <asp:TextBox ID="TextBoxPassword" runat="server" Width="194px"></asp:TextBox>
        </p>
        <p>
        <br />
            Nueva Contraseña:&nbsp; <asp:TextBox ID="TextBoxNewPass" runat="server" Width="167px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button2" runat="server" Text="Modificar contraseña" Width="195px" />
        </p>
        <p>
            <asp:Label ID="LabelError" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
