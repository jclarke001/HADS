Public Class errorobtenciondatos
    Inherits ApplicationException
    Public Sub New _
    (Optional ByVal Mensaje As String =
    "No se ha podido obtener el usuario.")
        MyBase.New(Mensaje)
    End Sub
End Class
