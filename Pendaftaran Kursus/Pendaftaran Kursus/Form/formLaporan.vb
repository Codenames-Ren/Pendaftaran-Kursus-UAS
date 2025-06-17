Imports Npgsql
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports ClosedXML.Excel
Public Class formLaporan

    Private Sub formLaporan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbJenisData.Items.AddRange(New String() {"Peserta", "Kursus", "Pendaftaran"})
        cmbJenisData.SelectedIndex = -1
        dtpDateFrom.Value = Date.Today.AddMonths(-1)
        dtpDateTo.Value = Date.Today
    End Sub
    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        If cmbJenisData.SelectedIndex = -1 Then
            MessageBox.Show("Silakan pilih data yang ingin ditampilkan terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim jenisData As String = cmbJenisData.SelectedItem.ToString()
        Dim tanggalAwal As DateTime = dtpDateFrom.Value.Date
        Dim tanggalAkhir As DateTime = dtpDateTo.Value.Date.AddDays(1)

        If tanggalAwal > tanggalAkhir.AddDays(-1) Then
            MessageBox.Show("Tanggal awal tidak boleh lebih dari tanggal akhir!", "Validasi Tanggal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        Dim query As String = ""
        Select Case jenisData
            Case "Peserta"
                query = "SELECT kode_peserta, nama_peserta, alamat, no_handphone, email, created_on
                 FROM peserta 
                 WHERE (is_deleted IS NULL OR is_deleted = 0)
                 AND created_on >= @awal AND created_on < @akhir"

            Case "Kursus"
                query = "SELECT kode_kursus, nama_kursus, 
                 CASE jadwal_hari
                     WHEN 1 THEN 'Senin' WHEN 2 THEN 'Selasa' WHEN 3 THEN 'Rabu'
                     WHEN 4 THEN 'Kamis' WHEN 5 THEN 'Jumat' WHEN 6 THEN 'Sabtu'
                     WHEN 7 THEN 'Minggu' ELSE 'Tidak Diketahui' 
                 END AS jadwal_hari,
                 durasi || ' Jam' AS durasi, lama_kursus || ' Minggu' AS lama_kursus,
                 mentor, created_on 
                 FROM kursus
                 WHERE (is_deleted IS NULL OR is_deleted = 0)
                 AND created_on >= @awal AND created_on < @akhir"

            Case "Pendaftaran"
                query = "SELECT kb.kode_aktif, p.nama_peserta, k.nama_kursus, 
                 kb.biaya_pendaftaran, kb.sub_total, kb.total_biaya, 
                 kb.tanggal_aktif, kb.created_on
                 FROM kursus_berlangsung kb 
                 JOIN peserta p ON p.id = kb.id_peserta
                 JOIN kursus k ON k.id = kb.id_kursus 
                 WHERE (kb.is_deleted IS NULL OR kb.is_deleted = 0)
                 AND kb.created_on >= @awal AND kb.created_on < @akhir"
        End Select

        Try
            Dim conn = DBConnection.OpenConnection()
            Dim cmd = New NpgsqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@awal", tanggalAwal)
            cmd.Parameters.AddWithValue("@akhir", tanggalAkhir)

            Dim adapter As New NpgsqlDataAdapter(cmd)
            Dim table As New DataTable()
            adapter.Fill(table)
            dataGridLaporan.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data laporan: " & ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DBConnection.closeConnection()
        End Try
    End Sub

    Private Sub btnExportToExcel_Click(sender As Object, e As EventArgs) Handles btnExportToExcel.Click
        If dataGridLaporan.Rows.Count = 0 Then
            MessageBox.Show("Tidak ada data untuk di export.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim saveDialog As New SaveFileDialog
        saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx"
        saveDialog.Title = "Simpan Laporan Excel"
        saveDialog.FileName = $"Laporan_{cmbJenisData.SelectedItem}_{Date.Now:yyyyMMdd}.xlsx"

        If saveDialog.ShowDialog = DialogResult.OK Then
            Try
                Dim wb As New XLWorkbook
                Dim ws = wb.Worksheets.Add("Laporan")

                ' Header
                For col = 0 To dataGridLaporan.ColumnCount - 1
                    ws.Cell(1, col + 1).Value = dataGridLaporan.Columns(col).HeaderText
                    ws.Cell(1, col + 1).Style.Font.Bold = True
                    ws.Cell(1, col + 1).Style.Fill.BackgroundColor = XLColor.LightGray
                Next

                ' Data
                For row = 0 To dataGridLaporan.Rows.Count - 1
                    For col = 0 To dataGridLaporan.Columns.Count - 1
                        Dim value = dataGridLaporan.Rows(row).Cells(col).Value
                        ws.Cell(row + 2, col + 1).Value = If(value IsNot Nothing, value.ToString, "")
                    Next
                Next
                ws.Columns.AdjustToContents()

                wb.SaveAs(saveDialog.FileName)
                MessageBox.Show("Data berhasil diexport ke Excel!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Gagal mengexport data ke Excel: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnExportToPDF_Click(sender As Object, e As EventArgs) Handles btnExportToPDF.Click
        If dataGridLaporan.Rows.Count = 0 Then
            MessageBox.Show("Tidak ada data untuk di export!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf"
        saveFileDialog.Title = "Simpan Laporan PDF"
        saveFileDialog.FileName = $"Laporan_{cmbJenisData.SelectedItem}_{DateTime.Now:yyyyMMdd}.pdf"

        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            Try
                Dim doc As New Document(PageSize.A4.Rotate(), 20, 20, 20, 20)
                PdfWriter.GetInstance(doc, New FileStream(saveFileDialog.FileName, FileMode.Create))
                doc.Open()

                ' Title
                Dim judulFont = FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD)
                Dim infoFont = FontFactory.GetFont("Arial", 10)

                doc.Add(New Paragraph($"Laporan {cmbJenisData.SelectedItem}", judulFont))
                doc.Add(New Paragraph($"Periode: {dtpDateFrom.Value:dd MMM yyyy} s/d {dtpDateTo.Value:dd MMM yyyy}", infoFont))
                doc.Add(New Paragraph(" "))

                ' Table
                Dim table As New PdfPTable(dataGridLaporan.ColumnCount)
                table.WidthPercentage = 100
                table.DefaultCell.Padding = 5
                table.DefaultCell.BorderWidth = 1
                table.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT

                ' Header
                For Each column As DataGridViewColumn In dataGridLaporan.Columns
                    Dim headerCell As New PdfPCell(New Phrase(column.HeaderText, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD)))
                    headerCell.BackgroundColor = BaseColor.LIGHT_GRAY
                    headerCell.Padding = 5
                    table.AddCell(headerCell)
                Next

                ' Data Rows
                For Each row As DataGridViewRow In dataGridLaporan.Rows
                    If Not row.IsNewRow Then
                        For Each cell As DataGridViewCell In row.Cells
                            Dim value = If(cell.Value IsNot Nothing, cell.Value.ToString(), "")
                            Dim dataCell As New PdfPCell(New Phrase(value, FontFactory.GetFont("Arial", 9)))
                            dataCell.Padding = 5
                            table.AddCell(dataCell)
                        Next
                    End If
                Next

                doc.Add(table)
                doc.Close()

                MessageBox.Show("Laporan berhasil disimpan dalam bentuk PDF!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Gagal mengexport data ke PDF: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnKembali_Click(sender As Object, e As EventArgs) Handles btnKembali.Click
        Me.Close()
    End Sub
End Class