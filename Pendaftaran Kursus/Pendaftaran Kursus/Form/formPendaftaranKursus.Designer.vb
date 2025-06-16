<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formPendaftaranKursus
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
        txtBiayaPendaftaran = New TextBox()
        txtSubTotal = New TextBox()
        Label4 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        btnReset = New Button()
        btnSimpan = New Button()
        txtTotalBiaya = New TextBox()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        cmbPeserta = New ComboBox()
        cmbKursus = New ComboBox()
        txtKodeAktif = New TextBox()
        dtpTanggalAktif = New DateTimePicker()
        Label7 = New Label()
        SuspendLayout()
        ' 
        ' txtBiayaPendaftaran
        ' 
        txtBiayaPendaftaran.Location = New Point(264, 190)
        txtBiayaPendaftaran.Name = "txtBiayaPendaftaran"
        txtBiayaPendaftaran.ReadOnly = True
        txtBiayaPendaftaran.Size = New Size(217, 27)
        txtBiayaPendaftaran.TabIndex = 47
        ' 
        ' txtSubTotal
        ' 
        txtSubTotal.Location = New Point(264, 233)
        txtSubTotal.Name = "txtSubTotal"
        txtSubTotal.ReadOnly = True
        txtSubTotal.Size = New Size(217, 27)
        txtSubTotal.TabIndex = 46
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.ForeColor = Color.White
        Label4.Location = New Point(85, 233)
        Label4.Name = "Label4"
        Label4.Size = New Size(71, 20)
        Label4.TabIndex = 45
        Label4.Text = "Sub Total"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.ForeColor = Color.White
        Label6.Location = New Point(85, 147)
        Label6.Name = "Label6"
        Label6.Size = New Size(125, 20)
        Label6.TabIndex = 44
        Label6.Text = "Kode Aktif Kursus"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.ForeColor = Color.White
        Label5.Location = New Point(85, 190)
        Label5.Name = "Label5"
        Label5.Size = New Size(128, 20)
        Label5.TabIndex = 42
        Label5.Text = "Biaya Pendaftaran"
        ' 
        ' btnReset
        ' 
        btnReset.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        btnReset.ForeColor = Color.White
        btnReset.Location = New Point(378, 391)
        btnReset.Name = "btnReset"
        btnReset.Size = New Size(99, 30)
        btnReset.TabIndex = 41
        btnReset.Text = "Reset"
        btnReset.UseVisualStyleBackColor = False
        ' 
        ' btnSimpan
        ' 
        btnSimpan.BackColor = Color.RoyalBlue
        btnSimpan.ForeColor = Color.White
        btnSimpan.Location = New Point(264, 391)
        btnSimpan.Name = "btnSimpan"
        btnSimpan.Size = New Size(99, 30)
        btnSimpan.TabIndex = 40
        btnSimpan.Text = "Simpan"
        btnSimpan.UseVisualStyleBackColor = False
        ' 
        ' txtTotalBiaya
        ' 
        txtTotalBiaya.Location = New Point(265, 275)
        txtTotalBiaya.Name = "txtTotalBiaya"
        txtTotalBiaya.Size = New Size(216, 27)
        txtTotalBiaya.TabIndex = 39
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.ForeColor = Color.White
        Label3.Location = New Point(85, 275)
        Label3.Name = "Label3"
        Label3.Size = New Size(82, 20)
        Label3.TabIndex = 36
        Label3.Text = "Total Biaya"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.ForeColor = Color.White
        Label2.Location = New Point(85, 101)
        Label2.Name = "Label2"
        Label2.Size = New Size(99, 20)
        Label2.TabIndex = 35
        Label2.Text = "Pilihan Kursus"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.ForeColor = Color.White
        Label1.Location = New Point(85, 61)
        Label1.Name = "Label1"
        Label1.Size = New Size(100, 20)
        Label1.TabIndex = 34
        Label1.Text = "Nama Peserta"
        ' 
        ' cmbPeserta
        ' 
        cmbPeserta.FormattingEnabled = True
        cmbPeserta.Location = New Point(264, 61)
        cmbPeserta.Name = "cmbPeserta"
        cmbPeserta.Size = New Size(217, 28)
        cmbPeserta.TabIndex = 48
        ' 
        ' cmbKursus
        ' 
        cmbKursus.FormattingEnabled = True
        cmbKursus.Location = New Point(264, 101)
        cmbKursus.Name = "cmbKursus"
        cmbKursus.Size = New Size(217, 28)
        cmbKursus.TabIndex = 49
        ' 
        ' txtKodeAktif
        ' 
        txtKodeAktif.Location = New Point(264, 147)
        txtKodeAktif.Name = "txtKodeAktif"
        txtKodeAktif.ReadOnly = True
        txtKodeAktif.Size = New Size(217, 27)
        txtKodeAktif.TabIndex = 50
        ' 
        ' dtpTanggalAktif
        ' 
        dtpTanggalAktif.Location = New Point(265, 320)
        dtpTanggalAktif.Name = "dtpTanggalAktif"
        dtpTanggalAktif.Size = New Size(218, 27)
        dtpTanggalAktif.TabIndex = 51
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.Transparent
        Label7.ForeColor = Color.White
        Label7.Location = New Point(85, 320)
        Label7.Name = "Label7"
        Label7.Size = New Size(148, 20)
        Label7.TabIndex = 52
        Label7.Text = "Tanggal Mulai Kursus"
        ' 
        ' formPendaftaranKursus
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DarkBlue
        ClientSize = New Size(567, 451)
        Controls.Add(Label7)
        Controls.Add(dtpTanggalAktif)
        Controls.Add(txtKodeAktif)
        Controls.Add(cmbKursus)
        Controls.Add(cmbPeserta)
        Controls.Add(txtBiayaPendaftaran)
        Controls.Add(txtSubTotal)
        Controls.Add(Label4)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(btnReset)
        Controls.Add(btnSimpan)
        Controls.Add(txtTotalBiaya)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "formPendaftaranKursus"
        Text = "formPendaftaranKursus"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtBiayaPendaftaran As TextBox
    Friend WithEvents txtSubTotal As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnReset As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents txtTotalBiaya As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbPeserta As ComboBox
    Friend WithEvents cmbKursus As ComboBox
    Friend WithEvents txtKodeAktif As TextBox
    Friend WithEvents dtpTanggalAktif As DateTimePicker
    Friend WithEvents Label7 As Label
End Class
