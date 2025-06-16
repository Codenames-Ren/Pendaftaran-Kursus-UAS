Imports System.Data.Common
Imports Npgsql

Public Class kursusControl
    Private Sub kursusControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataKursus()
    End Sub

    Public Sub LoadDataKursus()
        Try
            Dim conn = DBConnection.OpenConnection()
            Dim query As String = "SELECT id, kode_kursus, nama_kursus, jadwal_hari, durasi, lama_kursus, mentor
                                   FROM public.kursus WHERE is_deleted IS NULL OR is_deleted = 0
                                   ORDER BY id ASC"

            Dim cmd = New NpgsqlCommand(query, conn)
            Dim adapter = New NpgsqlDataAdapter(cmd)
            Dim table = New DataTable()
            adapter.Fill(table)
            DataGridKursus.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data kursus: " & ex.Message)

        Finally
            DBConnection.closeConnection()
        End Try
    End Sub

    Private Sub btnGridTambah_Click(sender As Object, e As EventArgs) Handles btnGridTambah.Click
        Dim inputForm As New formKursus()
        AddHandler inputForm.FormClosed, AddressOf refreshGrid
        inputForm.Show()
    End Sub

    Private Sub refreshGrid(sender As Object, e As FormClosedEventArgs)
        LoadDataKursus()
    End Sub

    Private Sub DataGridKursus_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridKursus.CellDoubleClick
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub

        Dim row = DataGridKursus.Rows(e.RowIndex)

        If IsDBNull(row.Cells("id").Value) Then Exit Sub

        Try
            Dim editForm As New formKursus
            editForm.InitComboJadwal()

            editForm.idEdit = row.Cells("id").Value
            editForm.txtKodeKursus.Text = row.Cells("kode_kursus").Value.ToString()
            editForm.txtNamaKursus.Text = row.Cells("nama_kursus").Value.ToString()
            editForm.cmbJadwalHari.SelectedIndex = Convert.ToInt32(row.Cells("jadwal_hari").Value) - 1
            editForm.txtDurasi.Text = row.Cells("durasi").Value.ToString()
            editForm.txtLamaKursus.Text = row.Cells("lama_kursus").Value.ToString()
            editForm.txtMentorKursus.Text = row.Cells("mentor").Value.ToString()

            AddHandler editForm.FormClosed, AddressOf refreshGrid
            editForm.Show()

        Catch ex As Exception
            MessageBox.Show("Gagal membuka data untuk diedit: " & ex.Message)
        End Try
    End Sub

    Private Sub btnGridHapus_Click(sender As Object, e As EventArgs) Handles btnGridHapus.Click
        If DataGridKursus.SelectedRows.Count > 0 Then
            Dim selectedRow = DataGridKursus.SelectedRows(0)

            If selectedRow.Cells("id").Value Is Nothing OrElse IsDBNull(selectedRow.Cells("id").Value) Then
                MessageBox.Show("Tidak ada data valid yang dipilih untuk dihapus!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim idKursus = selectedRow.Cells("id").Value
            Dim result = MessageBox.Show("Yakin ingin menghapus kursus ini?", "Konfirmasi", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Try
                    Dim conn = DBConnection.OpenConnection()
                    Dim cmd = New NpgsqlCommand("UPDATE public.kursus SET is_deleted = 1 WHERE id = @id", conn)
                    cmd.Parameters.AddWithValue("@id", idKursus)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Data berhasil dihapus.")
                    LoadDataKursus()
                Catch ex As Exception
                    MessageBox.Show("Gagal menghapus data: " & ex.Message)

                Finally
                    DBConnection.closeConnection()
                End Try
            End If

        Else
            MessageBox.Show("Pilih data kursus yang ingin dihapus!")
        End If
    End Sub

    Private Sub btnGridSearch_Click(sender As Object, e As EventArgs) Handles btnGridSearch.Click
        Dim keyword As String = txtGridSearch.Text.Trim()
        Try
            Dim conn = DBConnection.OpenConnection()
            Dim query As String = "SELECT id, kode_kursus, nama_kursus, jadwal_hari, durasi, lama_kursus, mentor
                                   FROM public.kursus WHERE (is_deleted IS NULL OR is_deleted = 0)
                                   AND (kode_kursus ILIKE @kw OR nama_kursus ILIKE @kw OR mentor ILIKE @kw)
                                   ORDER BY id ASC"

            Dim cmd = New NpgsqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@kw", "%" & keyword & "%")
            Dim adapter = New NpgsqlDataAdapter(cmd)
            Dim table = New DataTable()
            adapter.Fill(table)
            DataGridKursus.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Gagal mencari data: " & ex.Message)

        Finally
            DBConnection.closeConnection()
        End Try
    End Sub

    Private Sub txtGridSearch_TextChanged(sender As Object, e As EventArgs) Handles txtGridSearch.TextChanged
        btnGridSearch.PerformClick()
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


End Class
