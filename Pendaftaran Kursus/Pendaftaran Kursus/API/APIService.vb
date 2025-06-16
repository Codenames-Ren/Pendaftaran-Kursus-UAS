Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Public Class APIService

    Sub send(dataType As String, dataProperties As String)
        Try
            'Buat objek data
            Dim jsonData As New Dictionary(Of String, String)
            jsonData.Add("dataType", dataType)
            jsonData.Add("dataProperties", dataProperties)

            'Ubah ke format json
            Dim jsonString As String = JsonConvert.SerializeObject(jsonData)

            'API endpoint
            Dim url As String = "http://103.82.242.90:10006/api/data/store"

            'Create request
            Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            request.Method = "POST"
            request.ContentType = "application/json"

            'Tulis json ke body request
            Using streamWriter As New StreamWriter(request.GetRequestStream())
                streamWriter.Write(jsonString)
            End Using

            'Dapatkan response
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
            Dim statusCode = response.StatusCode
            Dim responseText As String = ""

            Using streamReader As New StreamReader(response.GetResponseStream())
                responseText = streamReader.ReadToEnd()
            End Using

            'Tampilkan status
            If statusCode = HttpStatusCode.OK Then
                MessageBox.Show("✅ Data berhasil dikirim ke API!" & vbCrLf & responseText, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("⚠️ Status: " & statusCode.ToString() & vbCrLf & responseText, "API Tidak OK", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As WebException
            'Tangani error dari server (misal: 404, 500)
            Dim errMsg As String = ""
            If ex.Response IsNot Nothing Then
                Using reader As New StreamReader(ex.Response.GetResponseStream())
                    errMsg = reader.ReadToEnd()
                End Using
            End If
            MessageBox.Show("❌ Gagal mengirim ke API: " & ex.Message & vbCrLf & errMsg, "Error WebException", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception
            'Tangani error umum lainnya
            MessageBox.Show("❌ Error umum saat kirim API: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
