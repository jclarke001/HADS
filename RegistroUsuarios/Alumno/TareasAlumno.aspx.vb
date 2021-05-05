Imports System.Data.SqlClient

Public Class WebForm6
    Inherits System.Web.UI.Page

    Dim conClsf As SqlConnection = New SqlConnection("Server=tcp:hadsjclarke001.database.windows.net,1433;Initial Catalog=hadsjclarke001;Persist Security Info=False;User ID=julen_clarke@hotmail.com@hadsjclarke001;Password=jA268526ft;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dapAlumno As New SqlDataAdapter()
        Dim dstAlumno As New DataSet
        Dim tblAlumno As New DataTable
        Dim dapAsig As New SqlDataAdapter()
        Dim dstAsig As New DataSet
        Dim tblAsig As New DataTable
        Dim strAsig As String
        If Page.IsPostBack Then
            dstAlumno = Session("datosalumno")
        Else
            dapAsig = New SqlDataAdapter("select distinct codigo from Asignaturas", conClsf)
            Dim bldAsig As New SqlCommandBuilder(dapAsig)
            dapAsig.Fill(dstAsig, "Asig")
            tblAsig = dstAsig.Tables("Asig")
            DropDownList1.DataSource = tblAsig
            DropDownList1.DataTextField = "codigo"
            DropDownList1.DataBind()
            DropDownList1.SelectedIndex = 1
            strAsig = "select * from TareasGenericas where CodAsig='" & DropDownList1.SelectedValue & "'"
            dapAlumno = New SqlDataAdapter(strAsig, conClsf)
            Dim bldAlumno As New SqlCommandBuilder(dapAlumno)
            dapAlumno.Fill(dstAlumno, "Tarea")
            tblAlumno = dstAlumno.Tables("Tarea")
            GridView1.DataSource = tblAlumno
            GridView1.DataBind()
            Session("datosalumno") = dstAlumno
            Session("adaptadoralumno") = dapAlumno
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Response.Redirect("InstanciarTarea.aspx?codigo=" & GridView1.SelectedRow.Cells(1).Text & "&hestimadas=" & GridView1.SelectedRow.Cells(4).Text)
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Dim dapAlumno As New SqlDataAdapter()
        Dim dstAlumno As New DataSet
        Dim tblAlumno As New DataTable
        Dim strAsig As String
        strAsig = "select * from TareasGenericas where CodAsig='" & DropDownList1.SelectedValue & "'"
        dapAlumno = New SqlDataAdapter(strAsig, conClsf)
        Dim bldAlumno As New SqlCommandBuilder(dapAlumno)
        dapAlumno.Fill(dstAlumno, "Tarea")
        tblAlumno = dstAlumno.Tables("Tarea")
        GridView1.DataSource = tblAlumno
        GridView1.DataBind()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        System.Web.Security.FormsAuthentication.SignOut()
        Response.Redirect("Inicio.aspx")
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("Alumno.aspx")
    End Sub
End Class