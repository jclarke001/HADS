' NOTE: You can use the "Rename" command on the context menu to change the class name "Service1" in code, svc and config file together.
' NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.vb at the Solution Explorer and start debugging.
Imports System.Data.SqlClient

Public Class Service1
    Implements IService1

    Public Sub New()
    End Sub

    Public Function ObtenerMedia(Asignatura As String) As Single Implements IService1.ObtenerMedia
        Dim con As New SqlConnection("Server=tcp:hadsjclarke001.database.windows.net,1433;Initial Catalog=hadsjclarke001;Persist Security Info=False;User ID=julen_clarke@hotmail.com@hadsjclarke001;Password=jA268526ft;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
        Dim da As New SqlDataAdapter("select HEstimadas from TareasGenericas where CodAsig = '" + Asignatura + "'", con)
        Dim ds As New DataSet
        da.Fill(ds, "Media")
        Dim suma As Integer = 0
        Dim divisor As Integer = 0
        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            Dim horas As Integer = Integer.Parse(ds.Tables(0).Rows(i)(0).ToString())
            suma += horas
            divisor += 1
        Next
        Dim mediahoras As Single = suma / divisor
        Return mediahoras
    End Function

End Class
