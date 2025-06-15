Imports Npgsql

Public Class formPeserta
    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If txtKodePeserta.Text.Trim() = "" Or
        txtNamaPeserta.Text.Trim() = "" Or
        txtAlamat.Text.Trim() = "" Or
        txtNoHP.Text.Trim() = "" Or
        txtEmail.Text.Trim() = "" Then

            MessageBox.Show("Semua field wajib diisi!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        Try
            Dim conn = DBConnection.OpenConnection()
            Dim query As String = "INSERT INTO public.peserta (kode_peserta, nama_peserta, alamat, no_handphone, email, created_by, created_on) 
                               VALUES (@kode, @nama, @alamat, @hp, @email, 1, NOW())"


            Dim cmd As New NpgsqlCommand(query, conn)
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
End Class