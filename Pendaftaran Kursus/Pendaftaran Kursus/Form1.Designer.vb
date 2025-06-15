<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        MenuStrip1 = New MenuStrip()
        PesertaToolStripMenuItem = New ToolStripMenuItem()
        KursusToolStripMenuItem = New ToolStripMenuItem()
        PendaftaranKursusToolStripMenuItem = New ToolStripMenuItem()
        PanelContent = New Panel()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.ImageScalingSize = New Size(20, 20)
        MenuStrip1.Items.AddRange(New ToolStripItem() {PesertaToolStripMenuItem, KursusToolStripMenuItem, PendaftaranKursusToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(1051, 28)
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' PesertaToolStripMenuItem
        ' 
        PesertaToolStripMenuItem.Name = "PesertaToolStripMenuItem"
        PesertaToolStripMenuItem.Size = New Size(106, 24)
        PesertaToolStripMenuItem.Text = "Data Peserta"
        ' 
        ' KursusToolStripMenuItem
        ' 
        KursusToolStripMenuItem.Name = "KursusToolStripMenuItem"
        KursusToolStripMenuItem.Size = New Size(101, 24)
        KursusToolStripMenuItem.Text = "Data Kursus"
        ' 
        ' PendaftaranKursusToolStripMenuItem
        ' 
        PendaftaranKursusToolStripMenuItem.Name = "PendaftaranKursusToolStripMenuItem"
        PendaftaranKursusToolStripMenuItem.Size = New Size(148, 24)
        PendaftaranKursusToolStripMenuItem.Text = "Pendaftaran Kursus"
        ' 
        ' PanelContent
        ' 
        PanelContent.Dock = DockStyle.Fill
        PanelContent.Location = New Point(0, 28)
        PanelContent.Name = "PanelContent"
        PanelContent.Size = New Size(1051, 569)
        PanelContent.TabIndex = 1
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1051, 597)
        Controls.Add(PanelContent)
        Controls.Add(MenuStrip1)
        MainMenuStrip = MenuStrip1
        Name = "Form1"
        Text = "Pendaftaran Kursus"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents PesertaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KursusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PendaftaranKursusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PanelContent As Panel

End Class
