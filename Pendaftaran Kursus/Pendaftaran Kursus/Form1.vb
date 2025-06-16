Public Class Form1

    Private Sub PesertaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PesertaToolStripMenuItem.Click
        LoadMenu(New pesertaControl)
    End Sub

    Private Sub LoadMenu(control As UserControl)
        PanelContent.Controls.Clear()
        control.Dock = DockStyle.Fill
        PanelContent.Controls.Add(control)
    End Sub

    Private Sub KursusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KursusToolStripMenuItem.Click
        LoadMenu(New kursusControl)
    End Sub

    Private Sub PendaftaranKursusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PendaftaranKursusToolStripMenuItem.Click
        LoadMenu(New PendaftaranControl)
    End Sub

    Private Sub LaporanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanToolStripMenuItem.Click
        formLaporan.Show()
    End Sub
End Class
