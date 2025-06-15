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

    Private Sub DataGridPeserta_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridPeserta.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim selectedRow = DataGridPeserta.Rows(e.RowIndex)
            Dim editForm As New formPeserta()
            editForm.idEdit = selectedRow.Cells("id").Value
            editForm.txtKodePeserta.Text = selectedRow.Cells("kode_peserta").Value.ToString()
            editForm.txtNamaPeserta.Text = selectedRow.Cells("nama_peserta").Value.ToString()
            editForm.txtAlamat.Text = selectedRow.Cells("alamat").Value.ToString()
            editForm.txtNoHP.Text = selectedRow.Cells("no_handphone").Value.ToString()
            editForm.txtEmail.Text = selectedRow.Cells("email").Value.ToString()

            AddHandler editForm.FormClosed, AddressOf refreshGrid
            editForm.Show()
        End If
    End Sub

    Private Sub btnGridHapus_Click(sender As Object, e As EventArgs) Handles btnGridHapus.Click
        If DataGridPeserta.SelectedRows.Count > 0 Then
            Dim idPeserta = DataGridPeserta.SelectedRows(0).Cells("id").Value
            Dim result = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Try
                    Dim conn = DBConnection.OpenConnection()
                    Dim cmd = New NpgsqlCommand("UPDATE public.peserta SET is_deleted = 1 WHERE id = @id", conn)
                    cmd.Parameters.AddWithValue("@id", idPeserta)

                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Data berhasil dihapus!")
                    LoadDataPeserta()
                Catch ex As Exception
                    MessageBox.Show("Gagal Menghapus Data: " & ex.Message)

                Finally
                    DBConnection.closeConnection()
                End Try
            End If

        Else
            MessageBox.Show("Pilih data yang ingin dihapus!")
        End If
    End Sub

    Private Sub pesertaControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataPeserta()
    End Sub

    Private Sub btnGridKembali_Click(sender As Object, e As EventArgs) Handles btnGridKembali.Click
        Dim mainForm = Me.FindForm()
        If ParentForm IsNot Nothing Then
            Dim panel = mainForm.Controls.Find("PanelContent", True).FirstOrDefault()
            If panel IsNot Nothing AndAlso TypeOf panel Is Panel Then
                CType(panel, Panel).Controls.Clear()
            End If
        End If
    End Sub

    Private Sub btnGridSearch_Click(sender As Object, e As EventArgs) Handles btnGridSearch.Click
        Dim keyword As String = txtGridSearch.Text.Trim()

        Try
            Dim conn = DBConnection.OpenConnection()
            Dim query As String = "SELECT id, kode_peserta, nama_peserta, alamat, no_handphone, email
                                   FROM public.peserta WHERE (is_deleted is NULL OR is_deleted = 0)
                                   AND (kode_peserta ILIKE @kw OR nama_peserta ILIKE @kw OR alamat ILIKE @kw OR no_handphone ILIKE @kw OR email ILIKE @kw)
                                   ORDER BY id ASC"

            Dim cmd As New NpgsqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@kw", "%" & keyword & "%")

            Dim adapter As New NpgsqlDataAdapter(cmd)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridPeserta.DataSource = table

        Catch ex As Exception
            MessageBox.Show("Gagal mencari data: " & ex.Message)

        Finally
            DBConnection.closeConnection()
        End Try
    End Sub

    Private Sub txtGridSearch_TextChanged(sender As Object, e As EventArgs) Handles txtGridSearch.TextChanged
        btnGridSearch.PerformClick()
    End Sub
End Class
