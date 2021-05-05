<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TareasProfesor.aspx.vb" Inherits="RegistroUsuarios.WebForm9" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>
            <br />
            <asp:SqlDataSource ID="Tareas" runat="server" ConnectionString="<%$ ConnectionStrings:hadsjclarke001ConnectionString %>" SelectCommand="SELECT * FROM [TareasGenericas] WHERE ([CodAsig] = @CodAsig)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" Name="CodAsig" PropertyName="SelectedValue" Type="String" DefaultValue="EDA1" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="Asignaturas" runat="server" ConnectionString="<%$ ConnectionStrings:hadsjclarke001ConnectionString %>" SelectCommand="SELECT [codigo] FROM [Asignaturas]" DeleteCommand="DELETE FROM [Asignaturas] WHERE [codigo] = @codigo" InsertCommand="INSERT INTO [Asignaturas] ([codigo]) VALUES (@codigo)">
                <DeleteParameters>
                    <asp:Parameter Name="codigo" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="codigo" Type="String" />
                </InsertParameters>
            </asp:SqlDataSource>
            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    Seleccionar Asignatura:<br />
            <br />
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="Asignaturas" DataTextField="codigo" DataValueField="codigo">
                    </asp:DropDownList>
            <br />
            <br />
                    <asp:Button ID="Button1" runat="server" Height="70px" Text="INSERTAR NUEVA TAREA" Width="226px" />
            <br />
            <br />
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Codigo" DataSourceID="Tareas">
                        <Columns>
                            <asp:CommandField EditText="Editar" ShowEditButton="True" />
                            <asp:BoundField DataField="Codigo" HeaderText="Codigo" ReadOnly="True" SortExpression="Codigo" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                            <asp:BoundField DataField="CodAsig" HeaderText="CodAsig" SortExpression="CodAsig" />
                            <asp:BoundField DataField="HEstimadas" HeaderText="HEstimadas" SortExpression="HEstimadas" />
                            <asp:CheckBoxField DataField="Explotacion" HeaderText="Explotacion" SortExpression="Explotacion" />
                            <asp:BoundField DataField="TipoTarea" HeaderText="TipoTarea" SortExpression="TipoTarea" />
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <asp:Button ID="Button2" runat="server" Text="Menú" />
            <br />
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" Text="Cerrar Sesión" />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
