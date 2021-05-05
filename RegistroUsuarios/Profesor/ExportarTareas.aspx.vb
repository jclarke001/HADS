Imports System.Data.SqlClient
Imports System.Xml

Public Class WebForm12
    Inherits System.Web.UI.Page

    Dim conClsf As SqlConnection = New SqlConnection("Server=tcp:hadsjclarke001.database.windows.net,1433;Initial Catalog=hadsjclarke001;Persist Security Info=False;User ID=julen_clarke@hotmail.com@hadsjclarke001;Password=jA268526ft;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")

    Dim dapExportar As New SqlDataAdapter()
    Dim dstExportar As New DataSet("Tareas")
    Dim tblExportar As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            dstExportar = Session("exportar")
            dapExportar = Session("adapter")
        Else
            dapExportar = New SqlDataAdapter("select Codigo, Descripcion, CodAsig, HEstimadas, Explotacion, TipoTarea from TareasGenericas where CodAsig='" & DropDownList1.SelectedValue & "'", conClsf)
            Dim bldExportar As New SqlCommandBuilder(dapExportar)
            dapExportar.Fill(dstExportar, "Tarea")
            tblExportar = dstExportar.Tables("Tarea")
            GridView1.DataSource = tblExportar
            GridView1.DataBind()
            Session("exportar") = dstExportar
            Session("adapter") = dapExportar
        End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Meter contenido en Atributos
        Dim xd As New XmlDocument
        Dim xt As XmlText
        Dim tareas As XmlElement
        tareas = xd.CreateElement("tareas")
        Dim at As XmlAttribute = xd.CreateAttribute("xmlns:has")
        xt = xd.CreateTextNode("http://ji.ehu.es/has")
        at.AppendChild(xt)
        tareas.Attributes.Append(at)
        dstExportar.WriteXml(Server.MapPath("../App_Data/ISO.xml"))
        LabelExport.Text = "Archivo exportado en " + Server.MapPath("../App_Data/ISO.xml")
        LabelExport.Visible = True
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        System.Web.Security.FormsAuthentication.SignOut()
        Response.Redirect("Inicio.aspx")
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Response.Redirect("Profesor.aspx")
    End Sub

End Class