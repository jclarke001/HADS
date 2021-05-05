Imports System.Data.SqlClient
Public Class WebForm10
    Inherits System.Web.UI.Page

    Dim conClsf As SqlConnection = New SqlConnection("Server=tcp:hadsjclarke001.database.windows.net,1433;Initial Catalog=hadsjclarke001;Persist Security Info=False;User ID=julen_clarke@hotmail.com@hadsjclarke001;Password=jA268526ft;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")

    Dim dapTarea As New SqlDataAdapter()
    Dim dstTarea As New DataSet
    Dim tblTarea As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            dstTarea = Session("datos")
        Else
            dapTarea = New SqlDataAdapter("select * from TareasGenericas", conClsf)
            Dim bldTarea As New SqlCommandBuilder(dapTarea)
            dapTarea.Fill(dstTarea, "Tarea")
            tblTarea = dstTarea.Tables("Tarea")
            Session("datos") = dstTarea
            Session("adaptador") = dapTarea
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tblTarea = dstTarea.Tables("Tarea")
        Dim rowTarea As DataRow = tblTarea.NewRow()
        rowTarea("Codigo") = Codigo.Text
        rowTarea("Descripcion") = Descripcion.Text
        rowTarea("CodAsig") = DropDownList1.SelectedValue
        rowTarea("HEstimadas") = HEstimadas.Text
        rowTarea("TipoTarea") = DropDownList2.SelectedValue
        tblTarea.Rows.Add(rowTarea)
        dapTarea.Update(dstTarea, "Tarea")
        dstTarea.AcceptChanges()
        LabelTarea.Visible = True
        LabelTarea.Text = "Tarea Añadida."
        conClsf.Close()
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("TareasProfesor.aspx")
    End Sub
End Class