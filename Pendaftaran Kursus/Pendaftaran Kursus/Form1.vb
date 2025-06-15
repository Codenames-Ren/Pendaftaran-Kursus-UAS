Public Class Form1

    Private Sub PesertaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PesertaToolStripMenuItem.Click
        LoadMenu(New pesertaControl)
    End Sub

    Private Sub LoadMenu(control As UserControl)
        PanelContent.Controls.Clear()
        control.Dock = DockStyle.Fill
        PanelContent.Controls.Add(control)
    End Sub

End Class
