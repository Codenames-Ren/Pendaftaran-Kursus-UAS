Imports Npgsql

Public Class formPendaftaranKursus

    Private selectedPesertaId As Integer = 0
    Private selectedKursusId As Integer = 0
    Private Sub formPendaftaranKursus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadComboPeserta()
        LoadComboKursus()
        dtpTanggalAktif.Value = Date.Today
    End Sub

    Public Sub LoadComboPeserta()
        Dim conn = DBConnection.OpenConnection()
        Dim cmd = New NpgsqlCommand("SELECT id, nama_peserta FROM peserta WHERE is_deleted IS NULL OR is_deleted = 0", conn)
        Dim adapter = New NpgsqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)

        cmbPeserta.DataSource = table
        cmbPeserta.DisplayMember = "nama_peserta"
        cmbPeserta.ValueMember = "id"
        cmbPeserta.SelectedIndex = -1

        DBConnection.closeConnection()
    End Sub

    Public Sub LoadComboKursus()
        Dim conn = DBConnection.OpenConnection()
        Dim cmd = New NpgsqlCommand("SELECT id, nama_kursus FROM kursus WHERE is_deleted IS NULL OR is_deleted = 0", conn)
        Dim adapter = New NpgsqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)

        cmbKursus.DataSource = table
        cmbKursus.DisplayMember = "nama_kursus"
        cmbKursus.ValueMember = "id"
        cmbKursus.SelectedIndex = -1

        DBConnection.closeConnection()
    End Sub


    Private Sub cmbPeserta_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbPeserta.SelectionChangeCommitted
        If TypeOf cmbPeserta.SelectedValue Is Integer Then
            selectedPesertaId = Convert.ToInt32(cmbPeserta.SelectedValue)
        End If
    End Sub

    Private Sub cmbKursus_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbKursus.SelectionChangeCommitted
        If TypeOf cmbKursus.SelectedValue Is Integer Then
            selectedKursusId = Convert.ToInt32(cmbKursus.SelectedValue)

            Dim conn = DBConnection.OpenConnection()
            Dim cmd = New NpgsqlCommand("SELECT durasi, lama_kursus FROM kursus WHERE id = @id", conn)
            cmd.Parameters.AddWithValue("@id", selectedKursusId)
            Dim reader = cmd.ExecuteReader()

            If reader.Read() Then
                Dim durasi As Integer = Convert.ToInt32(reader("durasi")) ' jam per pertemuan
                Dim lama As Integer = Convert.ToInt32(reader("lama_kursus")) ' jumlah pertemuan
                Dim biayaPerJam As Integer = 150000

                Dim subTotal As Integer = durasi * lama * biayaPerJam
                txtSubTotal.Text = subTotal.ToString()
                txtBiayaPendaftaran.Text = "75000"
                txtTotalBiaya.Text = (subTotal + Val(txtBiayaPendaftaran.Text)).ToString()
                txtKodeAktif.Text = GenerateKodeAktif()
            End If

            reader.Close()
            DBConnection.closeConnection()
        End If
    End Sub

    Private Function GenerateKodeAktif() As String
        Return "GLB-" & DateTime.Now.ToString("yyMMddHHmmss")
    End Function

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        cmbPeserta.SelectedIndex = -1
        cmbKursus.SelectedIndex = -1
        selectedPesertaId = 0
        selectedKursusId = 0
        txtKodeAktif.Clear()
        txtBiayaPendaftaran.Clear()
        txtSubTotal.Clear()
        txtTotalBiaya.Clear()
        dtpTanggalAktif.Value = Date.Today
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If selectedPesertaId = 0 Or selectedKursusId = 0 Or
           txtKodeAktif.Text.Trim() = "" Or txtBiayaPendaftaran.Text.Trim() = "" Or
           txtSubTotal.Text.Trim() = "" Or txtTotalBiaya.Text.Trim() = "" Then

            MessageBox.Show("Semua field wajib diisi!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Dim conn = DBConnection.OpenConnection()
            Dim query As String = "INSERT INTO public.kursus_berlangsung (id_peserta, id_kursus, kode_aktif, biaya_pendaftaran, sub_total, total_biaya,
                                   tanggal_aktif, created_by, created_on) VALUES (@id_peserta, @id_kursus, @kode_aktif, @biaya, @sub, @total, @tanggal, 1, Now())"

            Dim cmd = New NpgsqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@id_peserta", selectedPesertaId)
            cmd.Parameters.AddWithValue("@id_kursus", selectedKursusId)
            cmd.Parameters.AddWithValue("@kode_aktif", txtKodeAktif.Text)
            cmd.Parameters.AddWithValue("@biaya", Convert.ToInt32(txtBiayaPendaftaran.Text))
            cmd.Parameters.AddWithValue("@sub", Convert.ToInt32(txtSubTotal.Text))
            cmd.Parameters.AddWithValue("@total", Convert.ToInt32(txtTotalBiaya.Text))
            cmd.Parameters.AddWithValue("@tanggal", dtpTanggalAktif.Value)

            cmd.ExecuteNonQuery()
            MessageBox.Show("Pendaftaran berhasil!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Kirim ke API
            Try
                Dim api As New APIService()
                Dim dataProperties As String = selectedPesertaId.ToString() & "|" &
                                           selectedKursusId.ToString() & "|" &
                                           txtKodeAktif.Text.Trim() & "|" &
                                           txtBiayaPendaftaran.Text.Trim() & "|" &
                                           txtSubTotal.Text.Trim() & "|" &
                                           txtTotalBiaya.Text.Trim() & "|" &
                                           dtpTanggalAktif.Value.ToString("yyyy-MM-dd") &
                                           "Bayu"

                api.send("pendaftaran", dataProperties)
                MessageBox.Show("Pengiriman data ke API berhasil!")
            Catch exApi As Exception
                MessageBox.Show("Data tersimpan, tapi gagal mengirim ke API: " & exApi.Message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                MessageBox.Show("Gagal kirim ke API: " & exApi.Message)
                Console.WriteLine("Error kirim API: " & exApi.ToString())
            End Try


            btnReset.PerformClick()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            DBConnection.closeConnection()
        End Try
    End Sub

    'Public idEdit As Integer = 0

    'Public Sub SetSelectedValues(kodeAktif As String, namaPeserta As String, namaKursus As String, subTotal As String, biayaPendaftaran As String,
    '                             totalBiaya As String, tanggalAktif As Date)

    '    txtKodeAktif.Text = kodeAktif
    '    txtSubTotal.Text = subTotal
    '    txtBiayaPendaftaran.Text = biayaPendaftaran
    '    txtTotalBiaya.Text = totalBiaya
    '    dtpTanggalAktif.Value = tanggalAktif

    '    For i As Integer = 0 To cmbPeserta.Items.Count - 1
    '        Dim item = CType(cmbPeserta.Items(i), KeyValuePair(Of Integer, String))
    '        If item.Value = namaPeserta Then
    '            cmbPeserta.SelectedIndex = i
    '            selectedPesertaId = item.Key
    '            Exit For
    '        End If
    '    Next

    '    For i As Integer = 0 To cmbKursus.Items.Count - 1
    '        Dim item = CType(cmbKursus.Items(i), KeyValuePair(Of Integer, String))
    '        If item.Value = namaKursus Then
    '            cmbKursus.SelectedIndex = i
    '            selectedKursusId = item.Key
    '            Exit For
    '        End If
    '    Next

    'End Sub
End Class