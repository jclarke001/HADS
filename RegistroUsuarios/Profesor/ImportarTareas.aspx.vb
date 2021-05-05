Imports System.Data.SqlClient
Imports System.Xml

Public Class WebForm11
    Inherits System.Web.UI.Page

    Dim conClsf As SqlConnection = New SqlConnection("Server=tcp:hadsjclarke001.database.windows.net,1433;Initial Catalog=hadsjclarke001;Persist Security Info=False;User ID=julen_clarke@hotmail.com@hadsjclarke001;Password=jA268526ft;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")

    Dim dapImportar As New SqlDataAdapter()
    Dim dstImportar As New DataSet
    Dim tblImportar As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            tblImportar = Session("datosxml")
            dapImportar = Session("adapter")
        Else
            dapImportar = New SqlDataAdapter("select Codigo, Descripcion, CodAsig, HEstimadas, Explotacion, TipoTarea from TareasGenericas", conClsf)
            Dim bldImportar As New SqlCommandBuilder(dapImportar)
            dapImportar.Fill(dstImportar, "Tareas")
            tblImportar = dstImportar.Tables("Tareas")
            Session("datosxml") = tblImportar
            Session("adapter") = dapImportar
        End If

        Xml1.DocumentSource = "~/App_Data/" + DropDownList1.SelectedValue + ".xml"

        If (DropDownList1.SelectedValue = "HAS") Then
            Xml1.DocumentSource = "~/App_Data/HAS.xml"
        Else
            Xml1.DocumentSource = "~/App_Data/SEG.xml"
        End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim xtr As XmlReader = XmlReader.Create(Server.MapPath("~/App_Data/" + DropDownList1.SelectedValue + ".xml"))
        While xtr.Read
            If xtr.NodeType = XmlNodeType.Element Then
                If xtr.Name = "tarea" Then
                    Dim codigo = xtr.GetAttribute(0)
                    Dim rowselect() As DataRow
                    rowselect = tblImportar.Select("Codigo='" + codigo + "'")
                    If rowselect.Length < 1 Then
                        Dim rowMbrs As DataRow = tblImportar.NewRow()
                        rowMbrs("codigo") = xtr.GetAttribute(0)
                        While xtr.Name <> "descripcion“
                            xtr.Read()
                        End While
                        xtr.Read()
                        rowMbrs("descripcion") = xtr.Value
                        rowMbrs("codasig") = DropDownList1.SelectedValue
                        While xtr.Name <> "hestimadas“
                            xtr.Read()
                        End While
                        xtr.Read()
                        rowMbrs("hestimadas") = xtr.Value
                        While xtr.Name <> "explotacion“
                            xtr.Read()
                        End While
                        xtr.Read()
                        rowMbrs("explotacion") = xtr.Value
                        While xtr.Name <> "tipotarea“
                            xtr.Read()
                        End While
                        xtr.Read()
                        rowMbrs("tipotarea") = xtr.Value
                        tblImportar.Rows.Add(rowMbrs)
                    End If
                End If
            End If
        End While
        Dim num As Integer
        num = dapImportar.Update(tblImportar)
        dstImportar.AcceptChanges()
        If num > 0 Then
            Label1.Visible = True
            Label1.Text = "Cambios guardados en la BD."
        Else : Label1.Text = "No hay cambios en la BD."
        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        System.Web.Security.FormsAuthentication.SignOut()
        Response.Redirect("Inicio.aspx")
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Response.Redirect("Profesor.aspx")
    End Sub

End Class