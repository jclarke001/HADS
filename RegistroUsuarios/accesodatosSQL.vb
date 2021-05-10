Imports System.Data.SqlClient

Public Class accesodatosSQL

    Private Shared conexion As New SqlConnection
    Private Shared comando As New SqlCommand

    Public Shared Function conectar() As String
        Try
            conexion.ConnectionString = “Server=tcp:hadsjclarke001.database.windows.net,1433;Initial Catalog=hadsjclarke001;Persist Security Info=False;User ID=julen_clarke@hotmail.com@hadsjclarke001;Password=jA268526ft;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            conexion.Open()
        Catch ex As Exception
            Return "ERROR DE CONEXIÓN: " + ex.Message
        End Try
        Return "CONEXION OK"
    End Function

    Public Shared Sub cerrarconexion()
        conexion.Close()
    End Sub

    Public Shared Function insertar(ByVal strEmail As String, ByVal strNombre As String, ByVal strApellidos As String,
                                                 ByVal intNumConf As Integer, ByVal boolConfirmado As Boolean,
                                                 ByVal strTipo As String, ByVal strPass As String, ByVal strCodPass As Integer) As String
        Dim st As String = "insert into Usuarios (email,nombre,apellidos,numconfir,confirmado,tipo,pass,codpass) VALUES ('" & strEmail & "','" & strNombre & "','" & strApellidos & "'," & intNumConf & ",'" & boolConfirmado & "','" & strTipo & "','" & strPass & "'," & strCodPass & ")"
        comando = New SqlCommand(st, conexion)
        Try
            Return comando.ExecuteNonQuery()
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Shared Function obtenerdatos(ByVal strEmail As String) As SqlDataReader
        Try
            Dim st As String = "select * from Usuarios where email='" & strEmail & "'"
            comando = New SqlCommand(st, conexion)
            Dim reader = comando.ExecuteReader()
            Return (reader)
        Catch ex As Exception
            MsgBox(ex.Message)
            Throw New errorobtenciondatos()
        End Try

    End Function

    Public Shared Function confirmarusuario(ByVal strEmail As String) As Integer
        Dim strSQL As String
        Try
            strSQL = "update Usuarios set confirmado='true' where email='" & strEmail & "'"
            comando = New SqlCommand(strSQL, conexion)
            Dim reader = comando.ExecuteReader()
            reader.Close()

        Catch ex As Exception
            Return ex.Message
        End Try
        Try
            strSQL = "select Count(*) from Usuarios"
            comando = New SqlCommand(strSQL, conexion)
            Return (comando.ExecuteScalar)
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

    Public Shared Function obtenercodigo(ByVal strEmail As String) As Integer
        Try
            Dim st As String = "select codpass from Usuarios where email='" & strEmail & "'"
            comando = New SqlCommand(st, conexion)
            Dim reader = comando.ExecuteReader()
            Dim strResult As String = ""
            Dim result As Integer
            While reader.Read()
                strResult = Convert.ToString(reader.Read())
            End While
            reader.Close()
            MsgBox(strResult)
            If strResult = "False" Then
                result = 0
            Else
                result = Convert.ToInt32(strResult)
            End If
            Return (result)
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

    Public Shared Function obteneremail(ByVal strCodPass As String) As String
        Try
            Dim st As String = "select email from Usuarios where codpass='" & strCodPass & "'"
            comando = New SqlCommand(st, conexion)
            Dim reader = comando.ExecuteReader()
            Dim result = reader.ToString()
            reader.Close()
            Return (result)
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

    Public Shared Function cambiarpassword(ByVal strEmail As String, ByVal strPassword As String) As Integer
        Dim strSQL As String
        Try
            strSQL = "update Usuarios set password='" & strPassword & "' where email='" & strEmail & "'"
            comando = New SqlCommand(strSQL, conexion)
            Dim reader = comando.ExecuteReader()
            reader.Close()

        Catch ex As Exception
            Return ex.Message
        End Try
        Try
            strSQL = "select Count(*) from Usuarios"
            comando = New SqlCommand(strSQL, conexion)
            Return (comando.ExecuteScalar)
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function




End Class
