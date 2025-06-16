Imports Npgsql

Public Class formKursus
    Public idEdit As Integer = 0

    Public Sub InitComboJadwal()
        If cmbJadwalHari.Items.Count = 0 Then
            cmbJadwalHari.Items.AddRange(New Object() {
            "1 - Senin", "2 - Selasa", "3 - Rabu", "4 - Kamis", "5 - Jumat", "6 - Sabtu", "7 - Minggu"
        })
        End If
    End Sub

    Private Sub formKursus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitComboJadwal()
    End Sub
    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If txtKodeKursus.Text.Trim() = "" Or
           txtNamaKursus.Text.Trim() = "" Or
           cmbJadwalHari.SelectedIndex = -1 Or
           txtDurasi.Text.Trim() = "" Or
           txtLamaKursus.Text.Trim() = "" Or
           txtMentorKursus.Text.Trim() = "" Then

            MessageBox.Show("Semua field wajib diisi!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not IsNumeric(txtDurasi.Text) Or Not IsNumeric(txtLamaKursus.Text) Then
            MessageBox.Show("Durasi dan Lama Kursus harus berupa angka tanpa huruf!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Dim conn = DBConnection.OpenConnection()
            Dim cmd As NpgsqlCommand

            Dim jadwalVal As Integer = Val(cmbJadwalHari.SelectedItem.ToString().Split(" "c)(0))

            If idEdit = 0 Then
                Dim query As String = "INSERT INTO public.kursus (kode_kursus, nama_kursus, jadwal_hari, durasi, lama_kursus, mentor, created_by, created_on)
                                       VALUES (@kode, @nama, @jadwal, @durasi, @lama,  @mentor, 1, NOW())"

                cmd = New NpgsqlCommand(query, conn)

            Else
                Dim query As String = "UPDATE public.kursus SET kode_kursus = @kode, nama_kursus = @nama, jadwal_hari = @jadwal,
                                       durasi = @durasi, lama_kursus = @lama, mentor = @mentor, modify_by = 1, modify_on = now()
                                       WHERE id = @id"

                cmd = New NpgsqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@id", idEdit)
            End If

            cmd.Parameters.AddWithValue("@kode", txtKodeKursus.Text)
            cmd.Parameters.AddWithValue("@nama", txtNamaKursus.Text)
            cmd.Parameters.AddWithValue("@jadwal", jadwalVal)
            cmd.Parameters.AddWithValue("@durasi", Convert.ToInt32(txtDurasi.Text))
            cmd.Parameters.AddWithValue("@lama", Convert.ToInt32(txtLamaKursus.Text))
            cmd.Parameters.AddWithValue("@mentor", txtMentorKursus.Text)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Data berhasil disimpan!")

            Try
                Dim api As New APIService()
                Dim dataProperties As String = txtKodeKursus.Text.Trim() & "|" &
                                   txtNamaKursus.Text.Trim() & "|" &
                                   cmbJadwalHari.SelectedItem.ToString() & "|" &
                                   txtDurasi.Text.Trim() & "|" &
                                   txtLamaKursus.Text.Trim() & "|" &
                                   txtMentorKursus.Text.Trim()

                api.send("kursus", dataProperties)
                MessageBox.Show("Pengiriman data ke API berhasil!")
            Catch exApi As Exception
                MessageBox.Show("Data tersimpan, tapi gagal mengirim ke API: " & exApi.Message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                MessageBox.Show("Gagal kirim ke API: " & exApi.Message)
                Console.WriteLine("Error kirim API: " & exApi.ToString())
            End Try
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan data: " & ex.Message)
        Finally
            DBConnection.closeConnection()
        End Try
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtKodeKursus.Clear()
        txtNamaKursus.Clear()
        cmbJadwalHari.SelectedIndex = -1
        txtDurasi.Clear()
        txtLamaKursus.Clear()
        txtMentorKursus.Clear()
        txtKodeKursus.Focus()
    End Sub
End Class