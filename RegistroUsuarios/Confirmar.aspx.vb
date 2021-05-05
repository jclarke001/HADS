Imports System.Data.SqlClient
Imports RegistroUsuarios.accesodatosSQL

Public Class WebForm4
    Inherits System.Web.UI.Page

    Dim usuario As String
    Dim numconf As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        conectar()
        usuario = Request.QueryString("usu")
        numconf = Request.QueryString("numconf")
        Dim respuesta As SqlDataReader = obtenerdatos(usuario)
        If respuesta.Read Then
            If respuesta.Item("NumConf") Then
                respuesta.Close()
                confirmarusuario(usuario)
            End If
        Else
            Label1.Text = "No se ha podido confirmar el usuario."
        End If

    End Sub

    Protected Sub ButtonLogin_Click(sender As Object, e As EventArgs) Handles ButtonLogin.Click
        Response.Redirect("Inicio.aspx", True)
    End Sub
End Class