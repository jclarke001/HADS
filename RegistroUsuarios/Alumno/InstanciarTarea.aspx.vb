Imports System.Data.SqlClient

Public Class WebForm7
    Inherits System.Web.UI.Page

    Dim conClsf As SqlConnection = New SqlConnection("Server=tcp:hadsjclarke001.database.windows.net,1433;Initial Catalog=hadsjclarke001;Persist Security Info=False;User ID=julen_clarke@hotmail.com@hadsjclarke001;Password=jA268526ft;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")

    Dim dapInstancia As New SqlDataAdapter()
    Dim dstInstancia As New DataSet
    Dim tblInstancia As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            dstInstancia = Session("instancia")
            dapInstancia = Session("adaptador")
        Else
            dapInstancia = New SqlDataAdapter("select Email, Descripción, HEstimadas, HReales from TareasPersonales", conClsf)
            Dim bldTarea As New SqlCommandBuilder(dapInstancia)
            dapInstancia.Fill(dstInstancia, "Instancia")
            tblInstancia = dstInstancia.Tables("Instancia")
            GridView1.DataSource = tblInstancia
            GridView1.DataBind()
            Session("instancia") = dstInstancia
            Session("adaptador") = dapInstancia
            TareaText.Text = Request.QueryString("codigo")
            HEstText.Text = Request.QueryString("hestimadas")
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tblInstancia = dstInstancia.Tables("Instancia")
        Dim rowInstancia As DataRow = tblInstancia.NewRow()
        rowInstancia("Email") = UsuarioText.Text
        rowInstancia("Descripción") = TareaText.Text
        rowInstancia("HEstimadas") = HEstText.Text
        rowInstancia("HReales") = HRealText.Text
        tblInstancia.Rows.Add(rowInstancia)
        dapInstancia.Update(dstInstancia, "Instancia")
        dstInstancia.AcceptChanges()
        LabelInstancia.Visible = True
        LabelInstancia.Text = "Tarea Instanciada."
        conClsf.Close()
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("TareasAlumno.aspx")
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        System.Web.Security.FormsAuthentication.SignOut()
        Response.Redirect("Inicio.aspx")
    End Sub
End Class