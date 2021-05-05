<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Confirmar.aspx.vb" Inherits="RegistroUsuarios.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        &nbsp;<asp:Label ID="Label1" runat="server" Text="El usuario se ha registrado correctamente." Visible="False"></asp:Label>
        </div>
        <p>
            <asp:Button ID="ButtonLogin" runat="server" Height="31px" Text="Login" Width="65px" />
        </p>
    </form>
</body>
</html>
