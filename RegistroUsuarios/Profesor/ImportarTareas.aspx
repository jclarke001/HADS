<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm11.aspx.vb" Inherits="RegistroUsuarios.WebForm11" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 615px">
            <br />
            Seleccionar Asignatura a Importar:<br />
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>HAS</asp:ListItem>
                <asp:ListItem>SEG</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Height="63px" Text="IMPORTAR (XMLD)" Width="221px" />
            <br />
            <br />
            <br />
            <asp:Xml ID="Xml1" runat="server" TransformSource="~/App_Data/VerTablaTareas.xsl"></asp:Xml>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" Text="Menú" />
            <br />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Cerrar Sesión" />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
