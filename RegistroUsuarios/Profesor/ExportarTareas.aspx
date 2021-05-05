<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm12.aspx.vb" Inherits="RegistroUsuarios.WebForm12" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            Seleccionar Asignatura a Exportar:<br />
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>ISO</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Height="62px" Text="EXPORTAR XML" Width="204px" />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />
            <br />
            <asp:Label ID="LabelExport" runat="server" Visible="False"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" Text="Menú" />
            <br />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Cerrar Sesión" />
        </div>
    </form>
</body>
</html>
