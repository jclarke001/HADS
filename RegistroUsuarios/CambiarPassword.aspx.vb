Imports System.Net.Mail
Imports RegistroUsuarios.accesodatosSQL

Public Class WebForm3
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim resultado As String
        resultado = conectar()
        LabelError.Text = resultado
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim email As String = TextBoxEmail.Text
        If email = "" Then
            LabelError.Text = "Email incorrecto."
            LabelError.Visible = True
        Else
            Dim reader = obtenerdatos(email)

            If reader.Read Then
                reader.Close()
                Dim codpass = obtenercodigo(email)
                enviarEmail(email, codpass)
            Else
                LabelError.Text = "Email incorrecto."
                LabelError.Visible = True
                reader.Close()
            End If

            cerrarconexion()
        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim password As String = TextBoxPassword.Text
        Dim newpass As String = TextBoxNewPass.Text
        If password = "" Or newpass = "" Then
            LabelError.Text = "Código o nueva contraseña incorrecta."
            LabelError.Visible = True
        Else
            Dim email = obteneremail(password)

            If email = "" Then
                LabelError.Text = "Código incorrecto."
                LabelError.Visible = True
            Else
                cambiarpassword(email, newpass)
            End If

        End If

        cerrarconexion()
    End Sub

    Public Function enviarEmail(ByVal strEmail As String, ByVal strCodPass As Integer) As Boolean
        Try
            'Direccion de origen
            Dim from_address As New MailAddress("jclarke001@ikasle.ehu.eus", "Cambio Contraseña HADS")
            'Direccion de destino
            Dim to_address As New MailAddress(strEmail)
            'Password de la cuenta
            Dim from_pass As String = "*30jGuTln3rj"
            'Objeto para el cliente smtp
            Dim smtp As New SmtpClient
            'Host en este caso el servidor de gmail
            smtp.Host = "smtp.ehu.eus"
            'Puerto
            smtp.Port = 587
            'SSL activado para que se manden correos de manera segura
            smtp.EnableSsl = True
            'No usar los credenciales por defecto ya que si no no funciona
            smtp.UseDefaultCredentials = False
            'Credenciales
            smtp.Credentials = New System.Net.NetworkCredential(from_address.Address, from_pass)
            'Creamos el mensaje con los parametros de origen y destino
            Dim message As New MailMessage(from_address, to_address)
            'Añadimos el asunto
            message.Subject = "Cambiar contraseña"
            'Concatenamos el cuerpo del mensaje a la plantilla
            message.Body = "<html><head></head><body>" & "Su código es el siguiente: " & strCodPass & "</body></html>"
            'Definimos el cuerpo como html para poder escojer mejor como lo mandamos
            message.IsBodyHtml = True
            'Se envia el correo
            smtp.Send(message)
        Catch e As Exception
            MsgBox(e.Message)
            Return e.Message
        End Try
        Return True
    End Function

End Class