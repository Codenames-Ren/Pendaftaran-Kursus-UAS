<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pesertaControl
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
        DataGridPeserta = New DataGridView()
        btnGridTambah = New Button()
        btnGridKembali = New Button()
        btnGridHapus = New Button()
        txtGridSearch = New TextBox()
        btnGridSearch = New Button()
        CType(DataGridPeserta, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridPeserta
        ' 
        DataGridPeserta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridPeserta.Location = New Point(68, 114)
        DataGridPeserta.Name = "DataGridPeserta"
        DataGridPeserta.RowHeadersWidth = 51
        DataGridPeserta.Size = New Size(800, 388)
        DataGridPeserta.TabIndex = 0
        ' 
        ' btnGridTambah
        ' 
        btnGridTambah.BackColor = Color.RoyalBlue
        btnGridTambah.ForeColor = Color.White
        btnGridTambah.Location = New Point(510, 35)
        btnGridTambah.Name = "btnGridTambah"
        btnGridTambah.Size = New Size(104, 43)
        btnGridTambah.TabIndex = 1
        btnGridTambah.Text = "Tambah"
        btnGridTambah.UseVisualStyleBackColor = False
        ' 
        ' btnGridKembali
        ' 
        btnGridKembali.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        btnGridKembali.ForeColor = Color.White
        btnGridKembali.Location = New Point(764, 35)
        btnGridKembali.Name = "btnGridKembali"
        btnGridKembali.Size = New Size(104, 43)
        btnGridKembali.TabIndex = 2
        btnGridKembali.Text = "Kembali"
        btnGridKembali.UseVisualStyleBackColor = False
        ' 
        ' btnGridHapus
        ' 
        btnGridHapus.BackColor = Color.Red
        btnGridHapus.ForeColor = Color.White
        btnGridHapus.Location = New Point(636, 35)
        btnGridHapus.Name = "btnGridHapus"
        btnGridHapus.Size = New Size(104, 43)
        btnGridHapus.TabIndex = 3
        btnGridHapus.Text = "Hapus"
        btnGridHapus.UseVisualStyleBackColor = False
        ' 
        ' txtGridSearch
        ' 
        txtGridSearch.Location = New Point(121, 43)
        txtGridSearch.Name = "txtGridSearch"
        txtGridSearch.Size = New Size(270, 27)
        txtGridSearch.TabIndex = 4
        ' 
        ' btnGridSearch
        ' 
        btnGridSearch.BackColor = Color.White
        btnGridSearch.Location = New Point(73, 43)
        btnGridSearch.Name = "btnGridSearch"
        btnGridSearch.Size = New Size(36, 27)
        btnGridSearch.TabIndex = 5
        btnGridSearch.Text = "🔎"
        btnGridSearch.UseVisualStyleBackColor = False
        ' 
        ' pesertaControl
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DarkBlue
        BackgroundImageLayout = ImageLayout.Zoom
        Controls.Add(btnGridSearch)
        Controls.Add(txtGridSearch)
        Controls.Add(btnGridHapus)
        Controls.Add(btnGridKembali)
        Controls.Add(btnGridTambah)
        Controls.Add(DataGridPeserta)
        Name = "pesertaControl"
        Size = New Size(942, 536)
        CType(DataGridPeserta, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DataGridPeserta As DataGridView
    Friend WithEvents btnGridTambah As Button
    Friend WithEvents btnGridKembali As Button
    Friend WithEvents btnGridHapus As Button
    Friend WithEvents txtGridSearch As TextBox
    Friend WithEvents btnGridSearch As Button

End Class
