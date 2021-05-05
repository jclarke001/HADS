<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Asignaturas.aspx.vb" Inherits="RegistroUsuarios.WebForm13" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:SqlDataSource ID="SqlDataSourceAsignaturas" runat="server" ConnectionString="<%$ ConnectionStrings:hadsjclarke001ConnectionString %>" SelectCommand="SELECT [codigo] FROM [Asignaturas]"></asp:SqlDataSource>
            <br />
                    Seleccionar Asignatura:<br />
            <br />
                    <asp:DropDownList ID="DropDownListAsignaturas" runat="server" AutoPostBack="True" DataSourceID="SqlDataSourceAsignaturas" DataTextField="codigo" DataValueField="codigo">
                    </asp:DropDownList>
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Calcular Media Horas" />
            <br />
            <br />
            Media Horas:
            <asp:Label ID="LabelResultado" runat="server" Visible="False"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Menú" />
            <br />
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" Text="Cerrar Sesión" />
        </div>
    </form>
</body>
</html>
