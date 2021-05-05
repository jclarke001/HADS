<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Alumno.aspx.vb" Inherits="RegistroUsuarios.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Tareas Genéricas" />
            <br />
            <br />
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <strong>USUARIOS LOGUEADOS:
                    <asp:Label ID="nalumnos" runat="server"></asp:Label>
                    &nbsp;Alumno/s y
                    <asp:Label ID="nprofesores" runat="server"></asp:Label>
                    &nbsp;Profe/s</strong><br />
                    <asp:ListBox ID="ListBox1" runat="server" Height="67px" Width="146px"></asp:ListBox>
                    <asp:ListBox ID="ListBox2" runat="server" Height="67px" Width="146px"></asp:ListBox>
            <br />
            
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" Text="Cerrar Sesión" />
        </div>
    </form>
</body>
</html>
