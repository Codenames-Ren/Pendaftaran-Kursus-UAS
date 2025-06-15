<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formKursus
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        btnReset = New Button()
        btnSimpan = New Button()
        txtMentorKursus = New TextBox()
        txtNamaKursus = New TextBox()
        txtKodeKursus = New TextBox()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        Label5 = New Label()
        cmbJadwalHari = New ComboBox()
        Label6 = New Label()
        txtLamaKursus = New TextBox()
        Label4 = New Label()
        txtDurasi = New TextBox()
        SuspendLayout()
        ' 
        ' btnReset
        ' 
        btnReset.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        btnReset.ForeColor = Color.White
        btnReset.Location = New Point(354, 347)
        btnReset.Name = "btnReset"
        btnReset.Size = New Size(99, 30)
        btnReset.TabIndex = 25
        btnReset.Text = "Reset"
        btnReset.UseVisualStyleBackColor = False
        ' 
        ' btnSimpan
        ' 
        btnSimpan.BackColor = Color.RoyalBlue
        btnSimpan.ForeColor = Color.White
        btnSimpan.Location = New Point(240, 347)
        btnSimpan.Name = "btnSimpan"
        btnSimpan.Size = New Size(99, 30)
        btnSimpan.TabIndex = 24
        btnSimpan.Text = "Simpan"
        btnSimpan.UseVisualStyleBackColor = False
        ' 
        ' txtMentorKursus
        ' 
        txtMentorKursus.Location = New Point(240, 292)
        txtMentorKursus.Name = "txtMentorKursus"
        txtMentorKursus.Size = New Size(216, 27)
        txtMentorKursus.TabIndex = 21
        ' 
        ' txtNamaKursus
        ' 
        txtNamaKursus.Location = New Point(240, 97)
        txtNamaKursus.Name = "txtNamaKursus"
        txtNamaKursus.Size = New Size(217, 27)
        txtNamaKursus.TabIndex = 20
        ' 
        ' txtKodeKursus
        ' 
        txtKodeKursus.Location = New Point(240, 50)
        txtKodeKursus.Name = "txtKodeKursus"
        txtKodeKursus.Size = New Size(217, 27)
        txtKodeKursus.TabIndex = 19
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.ForeColor = Color.White
        Label3.Location = New Point(61, 295)
        Label3.Name = "Label3"
        Label3.Size = New Size(57, 20)
        Label3.TabIndex = 16
        Label3.Text = "Mentor"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.ForeColor = Color.White
        Label2.Location = New Point(61, 97)
        Label2.Name = "Label2"
        Label2.Size = New Size(95, 20)
        Label2.TabIndex = 15
        Label2.Text = "Nama Kursus"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.ForeColor = Color.White
        Label1.Location = New Point(61, 57)
        Label1.Name = "Label1"
        Label1.Size = New Size(90, 20)
        Label1.TabIndex = 14
        Label1.Text = "Kode Kursus"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.ForeColor = Color.White
        Label5.Location = New Point(61, 195)
        Label5.Name = "Label5"
        Label5.Size = New Size(91, 20)
        Label5.TabIndex = 26
        Label5.Text = "Durasi (Jam)"
        ' 
        ' cmbJadwalHari
        ' 
        cmbJadwalHari.FormattingEnabled = True
        cmbJadwalHari.Location = New Point(240, 143)
        cmbJadwalHari.Name = "cmbJadwalHari"
        cmbJadwalHari.Size = New Size(217, 28)
        cmbJadwalHari.TabIndex = 29
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.ForeColor = Color.White
        Label6.Location = New Point(61, 143)
        Label6.Name = "Label6"
        Label6.Size = New Size(86, 20)
        Label6.TabIndex = 30
        Label6.Text = "Jadwal Hari"
        ' 
        ' txtLamaKursus
        ' 
        txtLamaKursus.Location = New Point(240, 244)
        txtLamaKursus.Name = "txtLamaKursus"
        txtLamaKursus.Size = New Size(217, 27)
        txtLamaKursus.TabIndex = 32
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.ForeColor = Color.White
        Label4.Location = New Point(61, 244)
        Label4.Name = "Label4"
        Label4.Size = New Size(156, 20)
        Label4.TabIndex = 31
        Label4.Text = "Lama Kursus (Minggu)"
        ' 
        ' txtDurasi
        ' 
        txtDurasi.Location = New Point(240, 195)
        txtDurasi.Name = "txtDurasi"
        txtDurasi.Size = New Size(217, 27)
        txtDurasi.TabIndex = 33
        ' 
        ' formKursus
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DarkBlue
        ClientSize = New Size(552, 433)
        Controls.Add(txtDurasi)
        Controls.Add(txtLamaKursus)
        Controls.Add(Label4)
        Controls.Add(Label6)
        Controls.Add(cmbJadwalHari)
        Controls.Add(Label5)
        Controls.Add(btnReset)
        Controls.Add(btnSimpan)
        Controls.Add(txtMentorKursus)
        Controls.Add(txtNamaKursus)
        Controls.Add(txtKodeKursus)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "formKursus"
        Text = "formKursus"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnReset As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents txtHargaKursus As TextBox
    Friend WithEvents txtMentorKursus As TextBox
    Friend WithEvents txtNamaKursus As TextBox
    Friend WithEvents txtKodeKursus As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents cmbJadwalHari As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtLamaKursus As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDurasi As TextBox
End Class
