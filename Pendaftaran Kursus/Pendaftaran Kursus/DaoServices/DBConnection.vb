Imports Npgsql

Public Class DBConnection
    Private Shared hostPort As String = "Host=localhost; Port=5432;"
    Private Shared credentials As String = "Username=postgres; Password=945313;"
    Private Shared dbName As String = "Database=case_2_1124160034"
    Private Shared endpoint As String = hostPort & credentials & dbName
    Private Shared connectionDb As NpgsqlConnection

    Public Shared Function OpenConnection() As NpgsqlConnection
        Try
            connectionDb = New NpgsqlConnection(endpoint)
            connectionDb.Open()
            Return connectionDb
        Catch ex As Exception
            MessageBox.Show("Koneksi Gagal: " & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Sub closeConnection()
        If connectionDb IsNot Nothing AndAlso connectionDb.State = ConnectionState.Open Then
            connectionDb.Close()
        End If
    End Sub
End Class
