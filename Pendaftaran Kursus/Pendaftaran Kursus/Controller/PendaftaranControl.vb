Imports Npgsql

Public Class PendaftaranControl
    Private Sub PendaftaranControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataPendaftaran()
    End Sub

    Public Sub LoadDataPendaftaran()
        Try
            Dim conn = DBConnection.OpenConnection()
            Dim query As String = "SELECT kb.id, kb.kode_aktif, p.nama_peserta, k.nama_kursus, kb.biaya_pendaftaran, kb.sub_total, kb.total_biaya,
                                   kb.tanggal_aktif FROM kursus_berlangsung kb 
                                   JOIN peserta p ON p.id = kb.id_peserta JOIN kursus k ON k.id = kb.id_kursus
                                   WHERE kb.is_deleted IS NULL or kb.is_deleted = 0 
                                   ORDER BY kb.id ASC"

            Dim cmd = New NpgsqlCommand(query, conn)
            Dim adapter = New NpgsqlDataAdapter(cmd)
            Dim table As New DataTable()

            adapter.Fill(table)
            DataGridPendaftaran.DataSource = table

            If DataGridPendaftaran.Columns.Contains("total_biaya") Then
                DataGridPendaftaran.Columns("total_biaya").DefaultCellStyle.Format = "N0"
            End If

            If DataGridPendaftaran.Columns.Contains("tanggal_aktif") Then
                DataGridPendaftaran.Columns("tanggal_aktif").DefaultCellStyle.Format = "dd MMM yyyy"
            End If

        Catch ex As Exception
            MessageBox.Show("Gagal memuat data pendaftaran: " & ex.Message)

        Finally
            DBConnection.closeConnection()
        End Try
    End Sub

    Private Sub btnGridSearch_Click(sender As Object, e As EventArgs) Handles btnGridSearch.Click
        Dim keyword = txtGridSearch.Text.Trim()

        Try
            Dim conn = DBConnection.OpenConnection()
            Dim query = "SELECT kb.id, kb.kode_aktif, p.nama_peserta, k.nama_kursus, kb.biaya_pendaftaran, kb.sub_total, kb.total_biaya, kb.tanggal_aktif
                         FROM kursus_berlangsung kb JOIN peserta p ON p.id = kb.id_peserta
                         JOIN kursus k ON k.id = kb.id_kursus WHERE (kb.is_deleted IS NULL OR kb.is_deleted = 0)
                         AND (kb.kode_aktif ILIKE @kw OR p.nama_peserta ILIKE @kw OR k.nama_kursus ILIKE @kw)
                         ORDER BY kb.id ASC"

            Dim cmd = New NpgsqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@kw", "%" & keyword & "%")
            Dim adapter = New NpgsqlDataAdapter(cmd)
            Dim table As New DataTable()

            adapter.Fill(table)
            DataGridPendaftaran.DataSource = table

        Catch ex As Exception
            MessageBox.Show("Gagal mencari data: " & ex.Message)

        Finally
            DBConnection.closeConnection()
        End Try
    End Sub

    Private Sub txtGridSearch_TextChanged(sender As Object, e As EventArgs) Handles txtGridSearch.TextChanged
        btnGridSearch.PerformClick()
    End Sub

    Private Sub btnGridHapus_Click(sender As Object, e As EventArgs) Handles btnGridHapus.Click
        If DataGridPendaftaran.SelectedRows.Count = 0 Then
            MessageBox.Show("Pilih data pendaftaran yang ingin dihapus!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim selectedRow = DataGridPendaftaran.SelectedRows(0)

        If Not DataGridPendaftaran.Columns.Contains("id") Then
            MessageBox.Show("Kolom 'id' tidak ditemukan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If selectedRow.Cells("id").Value Is Nothing OrElse IsDBNull(selectedRow.Cells("id").Value) Then
            MessageBox.Show("Data yang dipilih tidak valid!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim id = selectedRow.Cells("id").Value

        If MessageBox.Show("Yakin ingin menghapus data pendaftaran ini?", "Konfirmasi", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Try
                Dim conn = DBConnection.OpenConnection()
                Dim cmd = New NpgsqlCommand("UPDATE public.kursus_berlangsung SET is_deleted = 1 WHERE id = @id", conn)
                cmd.Parameters.AddWithValue("@id", id)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Data berhasil dihapus.")
                LoadDataPendaftaran()
            Catch ex As Exception
                MessageBox.Show("Gagal menghapus data: " & ex.Message)
            Finally
                DBConnection.closeConnection()
            End Try
        End If
    End Sub

    Private Sub btnGridKembali_Click(sender As Object, e As EventArgs) Handles btnGridKembali.Click
        Dim mainForm = Me.FindForm()
        If mainForm IsNot Nothing Then
            Dim panel = mainForm.Controls.Find("PanelContent", True).FirstOrDefault()
            If panel IsNot Nothing AndAlso TypeOf panel Is Panel Then
                CType(panel, Panel).Controls.Clear()
            End If
        End If
    End Sub

    Private Sub btnGridTambah_Click(sender As Object, e As EventArgs) Handles btnGridTambah.Click
        Dim inputForm As New formPendaftaranKursus()
        AddHandler inputForm.FormClosed, AddressOf refreshGrid
        inputForm.Show()
    End Sub

    Private Sub refreshGrid(sender As Object, e As FormClosedEventArgs)
        LoadDataPendaftaran()
    End Sub

End Class
