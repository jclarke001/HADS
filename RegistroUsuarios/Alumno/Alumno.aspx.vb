Public Class WebForm5
    Inherits System.Web.UI.Page

    Dim contadorprofe As Integer
    Dim contadoralumno As Integer
    Dim emaillogueado As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        contadorprofe = Convert.ToInt32(Session("contadorp"))
        contadoralumno = Convert.ToInt32(Session("contadora"))
        contadoralumno += 1
        nprofesores.Text = contadorprofe.ToString
        nalumnos.Text = contadoralumno.ToString
        emaillogueado = Session("Email").ToString
        ListBox1.Items.Add(emaillogueado)
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("TareasAlumno.aspx")
    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        contadoralumno -= 1
        Session("contadora") = contadoralumno
        ListBox1.Items.Remove(emaillogueado)
        System.Web.Security.FormsAuthentication.SignOut()
    End Sub
End Class