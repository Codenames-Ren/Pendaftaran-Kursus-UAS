Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Public Class APIService

    Sub send(dataType As String, dataProperties As String)
        'Buat objek data
        Dim jsonData As New Dictionary(Of String, String)
        jsonData.Add("dataType", dataType)
        jsonData.Add("dataProperties", dataProperties)

        'ubah ke format json
        Dim jsonString As String = JsonConvert.SerializeObject(jsonData)

        'API endpoint
        Dim url As String = "http://103.82.242.90:10006/api/data/store" 'Bisa diubah dengan URL API asli

        'create request
        Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
        request.Method = "POST" 'Method CRUD ada GET, POST, PUT, DELETE, dan REQUEST
        request.ContentType = "application/json"

        'Tulis json ke body request
        Using StreamWriter As New StreamWriter(request.GetRequestStream())
            StreamWriter.Write(jsonString)
        End Using

        'Get response
        Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
        Using StreamReader As New StreamReader(response.GetResponseStream())
            Dim result As String = StreamReader.ReadToEnd()
            Console.WriteLine("API Response : " & result)
        End Using

        Console.ReadLine()
    End Sub

End Class

Public Class APIModel
        Public Property dataType As String
        Public Property dataProperties As String
        Public Property createdAt As List(Of Integer)
    Function retrieve(dataType As String, dt As DataTable) As DataTable
        Try
            Dim url As String = $"http://103.82.242.90:10006/api/data/retrieve/{dataType}"
            Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            request.Method = "GET"
            request.ContentType = "application/json"

            Using response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                Using reader As New StreamReader(response.GetResponseStream())
                    Dim json = reader.ReadToEnd()
                    Dim dataList = JsonConvert.DeserializeObject(Of List(Of APIModel))(json)

                    For Each objectJson In dataList
                        If Not String.IsNullOrEmpty(objectJson.dataProperties) Then
                            Dim parts = objectJson.dataProperties.Split("|"c)
                            ' Tambahkan kolom secara dinamis jika belum ada cukup kolom
                            While dt.Columns.Count < parts.Length
                                dt.Columns.Add("Column" & (dt.Columns.Count + 1))
                            End While

                            ' Tambahkan kolom CreatedAt jika belum ada
                            If dt.Columns.Contains("CreatedAt") = False Then
                                dt.Columns.Add("CreatedAt")
                            End If

                            ' Buat array isi baris
                            Dim rowValues As New List(Of String)
                            rowValues.AddRange(parts.Select(Function(p) p.Trim()))

                            ' Tambahkan createdAt ke akhir baris
                            Dim createdAt As String = If(objectJson.createdAt IsNot Nothing, String.Join("-", objectJson.createdAt), "")
                            rowValues.Add(createdAt)

                            ' Tambahkan ke DataTable
                            dt.Rows.Add(rowValues.ToArray())
                        End If
                    Next
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Gagal mengambil data: " & ex.Message)
        End Try

        Return dt
    End Function

End Class
