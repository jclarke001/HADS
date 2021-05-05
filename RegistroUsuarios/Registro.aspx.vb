Imports System.Net.Mail
Imports RegistroUsuarios.accesodatosSQL

Public Class WebForm2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim resultado As String
        resultado = conectar()
        LabelError.Text = resultado
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim email As String = TextBoxEmail.Text
        Dim nombre As String = TextBoxNombre.Text
        Dim apellidos As String = TextBoxApellidos.Text
        Dim password As String = TextBoxPass.Text
        Dim repetirpass As String = TextBoxRepPass.Text
        Dim tipo As String = RadioButtonTipo.Text
        Dim errorform As Boolean = False

        Dim hash As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim bytes As Byte() = hash.ComputeHash(Encoding.UTF8.GetBytes(password))
        Dim sBuilder As New StringBuilder()
        For n As Integer = 0 To bytes.Length - 1
            sBuilder.Append(bytes(n).ToString("x2"))
        Next n

        Dim cryptopassword = sBuilder.ToString()

        Dim matricula As New comprobarmatricula.Matriculas

        If matricula.comprobar(email) = "NO" Then
            LabelError.Text = "Email no matriculado."
            LabelError.Visible = True
            errorform = True
        End If

        If email = "" Then
            LabelError.Text = "Email incorrecto."
            LabelError.Visible = True
            errorform = True
        Else
            Dim reader = obtenerdatos(email)

            If reader.Read Then
                LabelError.Text = "Email ya en uso."
                LabelError.Visible = True
                errorform = True
            End If
            reader.Close()
        End If

        If nombre = "" Then
            LabelError.Text = "Nombre incorrecto."
            LabelError.Visible = True
            errorform = True
        End If
        If apellidos = "" Then
            LabelError.Text = "Apellidos incorrectos."
            LabelError.Visible = True
            errorform = True
        End If
        If cryptopassword = "" Then
            LabelError.Text = "Password incorrecto."
            LabelError.Visible = True
            errorform = True
        End If
        If repetirpass = "" Then
            LabelError.Text = "Password incorrecto/no coincide."
            LabelError.Visible = True
            errorform = True
        End If
        If Not errorform Then
            Randomize()
            Dim numconf As Long = CLng(Rnd() * 9000000) + 1000000
            Dim codpass As Long = CLng(Rnd() * 900000) + 100000
            insertar(email, nombre, apellidos, numconf, False, tipo, cryptopassword, codpass)
            cerrarconexion()
            enviarEmail(email, numconf)
        End If
    End Sub

    Public Function enviarEmail(ByVal strEmail As String, ByVal lonNumConf As Long) As Boolean
        Try
            'Direccion de origen
            Dim from_address As New MailAddress("jclarke001@ikasle.ehu.eus", "Registro Usuarios HADS")
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
            message.Subject = "Registro de usuario"
            'Concatenamos el cuerpo del mensaje a la plantilla
            message.Body = "<html><head></head><body>" & "Por favor confirme su cuenta: " & "http://localhost:44318/Confirmar.aspx?usu=" & strEmail & "&NumConf=" & lonNumConf & "</body></html>"
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