<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TareasAlumno.aspx.vb" Inherits="RegistroUsuarios.WebForm6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="font-weight: 700">
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <br />
            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Height="23px" Width="110px">
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:GridView ID="GridView1" runat="server" Width="488px">
                        <Columns>
                            <asp:CommandField ButtonType="Button" SelectText="Instanciar" ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Menú" />
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Cerrar Sesión" />
            <br />
        </div>
        <br />
    </form>
</body>
</html>
