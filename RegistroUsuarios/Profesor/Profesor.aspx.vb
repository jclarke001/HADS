Public Class WebForm8
    Inherits System.Web.UI.Page

    Dim contadorprofe As Integer
    Dim contadoralumno As Integer
    Dim emaillogueado As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        contadorprofe = Convert.ToInt32(Session("contadorp"))
        contadoralumno = Convert.ToInt32(Session("contadora"))
        contadorprofe += 1
        nprofesores.Text = contadorprofe.ToString
        nalumnos.Text = contadoralumno.ToString
        emaillogueado = Session("Email").ToString
        ListBox2.Items.Add(emaillogueado)
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("TareasProfesor.aspx")
    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Response.Redirect("ImportarTareas.aspx")
    End Sub

    Protected Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        contadorprofe -= 1
        Session("contadorp") = contadorprofe
        ListBox2.Items.Remove(emaillogueado)
        System.Web.Security.FormsAuthentication.SignOut()
        Response.Redirect("Inicio.aspx")
    End Sub

    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Response.Redirect("ExportarTareas.aspx")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("Asignaturas.aspx")
    End Sub
End Class