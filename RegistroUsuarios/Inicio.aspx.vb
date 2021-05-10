Imports System.Data.SqlClient
Imports RegistroUsuarios.accesodatosSQL


Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim resultado As String
        resultado = conectar()
        LabelError.Text = resultado
    End Sub

    Protected Sub Login_Click(sender As Object, e As EventArgs) Handles Login.Click
        Dim email As String = TextBoxEmail.Text
        Dim contraseña As String = TextBoxContraseña.Text
        Dim respuesta As SqlDataReader = obtenerdatos(email)

        Dim hash As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim bytes As Byte() = hash.ComputeHash(Encoding.UTF8.GetBytes(contraseña))
        Dim sBuilder As New StringBuilder()
        For n As Integer = 0 To bytes.Length - 1
            sBuilder.Append(bytes(n).ToString("x2"))
        Next n

        Dim criptocontraseña = sBuilder.ToString()

        If Not respuesta.Read Then
            LabelError.Visible = True
            LabelError.Text = "Email incorrecto."
        Else

            Session("contadorp") = 0
            Session("contadora") = 0

            If respuesta.Item("pass").Equals(criptocontraseña) Then
                If respuesta.Item("tipo").Equals("Profesor") Then
                    If email = "vadillo@ehu.es" Then
                        cerrarconexion()
                        System.Web.Security.FormsAuthentication.SetAuthCookie("Vadillo", True)
                        Session("Email") = email
                        Response.Redirect("~/Profesor/Profesor.aspx")
                    Else
                        cerrarconexion()
                        System.Web.Security.FormsAuthentication.SetAuthCookie("Profesor", True)
                        Session("Email") = email
                        Response.Redirect("~/Profesor/Profesor.aspx")
                    End If
                Else
                    cerrarconexion()
                    System.Web.Security.FormsAuthentication.SetAuthCookie("Alumno", True)
                    Session("Email") = email
                    Response.Redirect("~/Alumno/Alumno.aspx")
                End If

            Else
                LabelError.Visible = True
                LabelError.Text = "Contraseña incorrecta."
            End If

        End If
        respuesta.Close()
    End Sub

    Protected Sub LinkButtonRegistro_Click(sender As Object, e As EventArgs) Handles LinkButtonRegistro.Click
        Response.Redirect("Registro.aspx")
    End Sub

    Protected Sub LinkButtonModificarContraseña_Click(sender As Object, e As EventArgs) Handles LinkButtonModificarContraseña.Click
        Response.Redirect("CambiarPassword.aspx", True)
    End Sub
End Class