Public Class errorinserciondatos
    Inherits ApplicationException
    Public Sub New _
    (Optional ByVal Mensaje As String =
    "No se ha podido completar la inserción.")
        MyBase.New(Mensaje)
    End Sub
End Class
