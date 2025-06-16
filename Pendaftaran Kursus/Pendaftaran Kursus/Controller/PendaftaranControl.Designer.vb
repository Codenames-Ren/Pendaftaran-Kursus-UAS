<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PendaftaranControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        btnGridSearch = New Button()
        txtGridSearch = New TextBox()
        btnGridHapus = New Button()
        btnGridKembali = New Button()
        btnGridTambah = New Button()
        DataGridPendaftaran = New DataGridView()
        CType(DataGridPendaftaran, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnGridSearch
        ' 
        btnGridSearch.BackColor = Color.White
        btnGridSearch.Location = New Point(79, 47)
        btnGridSearch.Name = "btnGridSearch"
        btnGridSearch.Size = New Size(36, 27)
        btnGridSearch.TabIndex = 16
        btnGridSearch.Text = "🔎"
        btnGridSearch.UseVisualStyleBackColor = False
        ' 
        ' txtGridSearch
        ' 
        txtGridSearch.Location = New Point(127, 47)
        txtGridSearch.Name = "txtGridSearch"
        txtGridSearch.Size = New Size(270, 27)
        txtGridSearch.TabIndex = 15
        ' 
        ' btnGridHapus
        ' 
        btnGridHapus.BackColor = Color.Red
        btnGridHapus.ForeColor = Color.White
        btnGridHapus.Location = New Point(642, 39)
        btnGridHapus.Name = "btnGridHapus"
        btnGridHapus.Size = New Size(104, 43)
        btnGridHapus.TabIndex = 14
        btnGridHapus.Text = "Hapus"
        btnGridHapus.UseVisualStyleBackColor = False
        ' 
        ' btnGridKembali
        ' 
        btnGridKembali.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        btnGridKembali.ForeColor = Color.White
        btnGridKembali.Location = New Point(770, 39)
        btnGridKembali.Name = "btnGridKembali"
        btnGridKembali.Size = New Size(104, 43)
        btnGridKembali.TabIndex = 13
        btnGridKembali.Text = "Kembali"
        btnGridKembali.UseVisualStyleBackColor = False
        ' 
        ' btnGridTambah
        ' 
        btnGridTambah.BackColor = Color.RoyalBlue
        btnGridTambah.ForeColor = Color.White
        btnGridTambah.Location = New Point(516, 39)
        btnGridTambah.Name = "btnGridTambah"
        btnGridTambah.Size = New Size(104, 43)
        btnGridTambah.TabIndex = 12
        btnGridTambah.Text = "Tambah"
        btnGridTambah.UseVisualStyleBackColor = False
        ' 
        ' DataGridPendaftaran
        ' 
        DataGridPendaftaran.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridPendaftaran.Location = New Point(76, 109)
        DataGridPendaftaran.Name = "DataGridPendaftaran"
        DataGridPendaftaran.RowHeadersWidth = 51
        DataGridPendaftaran.Size = New Size(800, 388)
        DataGridPendaftaran.TabIndex = 11
        ' 
        ' PendaftaranControl
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DarkBlue
        Controls.Add(btnGridSearch)
        Controls.Add(txtGridSearch)
        Controls.Add(btnGridHapus)
        Controls.Add(btnGridKembali)
        Controls.Add(btnGridTambah)
        Controls.Add(DataGridPendaftaran)
        Name = "PendaftaranControl"
        Size = New Size(953, 536)
        CType(DataGridPendaftaran, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnGridSearch As Button
    Friend WithEvents txtGridSearch As TextBox
    Friend WithEvents btnGridHapus As Button
    Friend WithEvents btnGridKembali As Button
    Friend WithEvents btnGridTambah As Button
    Friend WithEvents DataGridPendaftaran As DataGridView

End Class
