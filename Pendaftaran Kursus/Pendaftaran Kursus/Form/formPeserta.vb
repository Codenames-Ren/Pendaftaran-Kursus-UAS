Imports Npgsql

Public Class formPeserta
    Public idEdit As Integer = 0
    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If txtKodePeserta.Text.Trim() = "" Or
        txtNamaPeserta.Text.Trim() = "" Or
        txtAlamat.Text.Trim() = "" Or
        txtNoHP.Text.Trim() = "" Or
        txtEmail.Text.Trim() = "" Then

            MessageBox.Show("Semua field wajib diisi!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        Try
            Dim conn = DBConnection.OpenConnection()
            Dim cmd As New NpgsqlCommand()

            If idEdit = 0 Then
                'Nambah Data'
                Dim query As String = "INSERT INTO public.peserta (kode_peserta, nama_peserta, alamat, no_handphone, email, created_by, created_on) 
                               VALUES (@kode, @nama, @alamat, @hp, @email, 1, NOW())"

                cmd = New NpgsqlCommand(query, conn)

            Else
                'Update data'
                Dim query As String = "UPDATE public.peserta SET kode_peserta = @kode, nama_peserta = @nama, alamat = @alamat,
                                       no_handphone = @hp, email = @email, modify_by = 1 WHERE id = @id"

                cmd = New NpgsqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@id", idEdit)
            End If

            cmd.Parameters.AddWithValue("@kode", txtKodePeserta.Text)
            cmd.Parameters.AddWithValue("@nama", txtNamaPeserta.Text)
            cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text)
            cmd.Parameters.AddWithValue("@hp", txtNoHP.Text)
            cmd.Parameters.AddWithValue("@email", txtEmail.Text)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Data berhasil disimpan!")
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan data: " & ex.Message)

        Finally
            DBConnection.closeConnection()

        End Try
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtKodePeserta.Clear()
        txtNamaPeserta.Clear()
        txtAlamat.Clear()
        txtNoHP.Clear()
        txtEmail.Clear()
        txtKodePeserta.Focus()
    End Sub
End Class