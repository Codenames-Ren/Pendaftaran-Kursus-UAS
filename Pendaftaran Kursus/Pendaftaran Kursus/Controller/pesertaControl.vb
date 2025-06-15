Imports Npgsql

Public Class pesertaControl
    Private Sub btnGridTambah_Click(sender As Object, e As EventArgs) Handles btnGridTambah.Click
        Dim inputForm As New formPeserta()
        AddHandler inputForm.FormClosed, AddressOf refreshGrid
        inputForm.Show()
    End Sub

    Private Sub refreshGrid(sender As Object, e As FormClosedEventArgs)
        LoadDataPeserta()
    End Sub

    Public Sub LoadDataPeserta()
        Try
            Dim conn = DBConnection.OpenConnection()
            Dim query As String = "SELECT id, kode_peserta, nama_peserta, alamat, no_handphone, email FROM peserta WHERE is_deleted IS NULL OR is_deleted = 0 ORDER BY id ASC"
            Dim cmd As New NpgsqlCommand(query, conn)
            Dim adapter As New NpgsqlDataAdapter(cmd)
            Dim table As New DataTable()

            adapter.Fill(table)
            DataGridPeserta.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data peserta: " & ex.Message)

        Finally
            DBConnection.closeConnection()

        End Try
    End Sub

    Private Sub btnGridRefrsh_Click(sender As Object, e As EventArgs)

    End Sub
End Class
