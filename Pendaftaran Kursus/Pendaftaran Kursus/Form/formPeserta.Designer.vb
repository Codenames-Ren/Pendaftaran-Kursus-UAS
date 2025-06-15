<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formPeserta
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
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        txtKodePeserta = New TextBox()
        txtNamaPeserta = New TextBox()
        txtAlamat = New TextBox()
        txtNoHP = New TextBox()
        txtEmail = New TextBox()
        btnSimpan = New Button()
        btnReset = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.ForeColor = Color.White
        Label1.Location = New Point(64, 64)
        Label1.Name = "Label1"
        Label1.Size = New Size(95, 20)
        Label1.TabIndex = 0
        Label1.Text = "Kode Peserta"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.ForeColor = Color.White
        Label2.Location = New Point(64, 119)
        Label2.Name = "Label2"
        Label2.Size = New Size(100, 20)
        Label2.TabIndex = 1
        Label2.Text = "Nama Peserta"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.ForeColor = Color.White
        Label3.Location = New Point(64, 173)
        Label3.Name = "Label3"
        Label3.Size = New Size(57, 20)
        Label3.TabIndex = 2
        Label3.Text = "Alamat"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.ForeColor = Color.White
        Label4.Location = New Point(64, 230)
        Label4.Name = "Label4"
        Label4.Size = New Size(52, 20)
        Label4.TabIndex = 3
        Label4.Text = "No HP"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.ForeColor = Color.White
        Label5.Location = New Point(64, 285)
        Label5.Name = "Label5"
        Label5.Size = New Size(46, 20)
        Label5.TabIndex = 4
        Label5.Text = "Email"
        ' 
        ' txtKodePeserta
        ' 
        txtKodePeserta.Location = New Point(210, 57)
        txtKodePeserta.Name = "txtKodePeserta"
        txtKodePeserta.Size = New Size(213, 27)
        txtKodePeserta.TabIndex = 5
        ' 
        ' txtNamaPeserta
        ' 
        txtNamaPeserta.Location = New Point(210, 119)
        txtNamaPeserta.Name = "txtNamaPeserta"
        txtNamaPeserta.Size = New Size(213, 27)
        txtNamaPeserta.TabIndex = 6
        ' 
        ' txtAlamat
        ' 
        txtAlamat.Location = New Point(210, 173)
        txtAlamat.Name = "txtAlamat"
        txtAlamat.Size = New Size(213, 27)
        txtAlamat.TabIndex = 7
        ' 
        ' txtNoHP
        ' 
        txtNoHP.Location = New Point(210, 230)
        txtNoHP.Name = "txtNoHP"
        txtNoHP.Size = New Size(213, 27)
        txtNoHP.TabIndex = 8
        ' 
        ' txtEmail
        ' 
        txtEmail.Location = New Point(210, 285)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(213, 27)
        txtEmail.TabIndex = 9
        ' 
        ' btnSimpan
        ' 
        btnSimpan.BackColor = Color.RoyalBlue
        btnSimpan.ForeColor = Color.White
        btnSimpan.Location = New Point(210, 354)
        btnSimpan.Name = "btnSimpan"
        btnSimpan.Size = New Size(99, 30)
        btnSimpan.TabIndex = 10
        btnSimpan.Text = "Simpan"
        btnSimpan.UseVisualStyleBackColor = False
        ' 
        ' btnReset
        ' 
        btnReset.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        btnReset.ForeColor = Color.White
        btnReset.Location = New Point(324, 354)
        btnReset.Name = "btnReset"
        btnReset.Size = New Size(99, 30)
        btnReset.TabIndex = 13
        btnReset.Text = "Reset"
        btnReset.UseVisualStyleBackColor = False
        ' 
        ' formPeserta
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DarkBlue
        ClientSize = New Size(534, 421)
        Controls.Add(btnReset)
        Controls.Add(btnSimpan)
        Controls.Add(txtEmail)
        Controls.Add(txtNoHP)
        Controls.Add(txtAlamat)
        Controls.Add(txtNamaPeserta)
        Controls.Add(txtKodePeserta)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "formPeserta"
        Text = "formPeserta"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtKodePeserta As TextBox
    Friend WithEvents txtNamaPeserta As TextBox
    Friend WithEvents txtAlamat As TextBox
    Friend WithEvents txtNoHP As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents btnSimpan As Button
    Friend WithEvents btnReset As Button
End Class
