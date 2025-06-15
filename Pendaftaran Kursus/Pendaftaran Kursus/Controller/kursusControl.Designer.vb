<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class kursusControl
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
        DataGridKursus = New DataGridView()
        btnGridSearch = New Button()
        txtGridSearch = New TextBox()
        btnGridHapus = New Button()
        btnGridKembali = New Button()
        btnGridTambah = New Button()
        CType(DataGridKursus, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridKursus
        ' 
        DataGridKursus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridKursus.Location = New Point(77, 101)
        DataGridKursus.Name = "DataGridKursus"
        DataGridKursus.RowHeadersWidth = 51
        DataGridKursus.Size = New Size(800, 388)
        DataGridKursus.TabIndex = 1
        ' 
        ' btnGridSearch
        ' 
        btnGridSearch.BackColor = Color.White
        btnGridSearch.Location = New Point(80, 39)
        btnGridSearch.Name = "btnGridSearch"
        btnGridSearch.Size = New Size(36, 27)
        btnGridSearch.TabIndex = 10
        btnGridSearch.Text = "🔎"
        btnGridSearch.UseVisualStyleBackColor = False
        ' 
        ' txtGridSearch
        ' 
        txtGridSearch.Location = New Point(128, 39)
        txtGridSearch.Name = "txtGridSearch"
        txtGridSearch.Size = New Size(270, 27)
        txtGridSearch.TabIndex = 9
        ' 
        ' btnGridHapus
        ' 
        btnGridHapus.BackColor = Color.Red
        btnGridHapus.ForeColor = Color.White
        btnGridHapus.Location = New Point(643, 31)
        btnGridHapus.Name = "btnGridHapus"
        btnGridHapus.Size = New Size(104, 43)
        btnGridHapus.TabIndex = 8
        btnGridHapus.Text = "Hapus"
        btnGridHapus.UseVisualStyleBackColor = False
        ' 
        ' btnGridKembali
        ' 
        btnGridKembali.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        btnGridKembali.ForeColor = Color.White
        btnGridKembali.Location = New Point(771, 31)
        btnGridKembali.Name = "btnGridKembali"
        btnGridKembali.Size = New Size(104, 43)
        btnGridKembali.TabIndex = 7
        btnGridKembali.Text = "Kembali"
        btnGridKembali.UseVisualStyleBackColor = False
        ' 
        ' btnGridTambah
        ' 
        btnGridTambah.BackColor = Color.RoyalBlue
        btnGridTambah.ForeColor = Color.White
        btnGridTambah.Location = New Point(517, 31)
        btnGridTambah.Name = "btnGridTambah"
        btnGridTambah.Size = New Size(104, 43)
        btnGridTambah.TabIndex = 6
        btnGridTambah.Text = "Tambah"
        btnGridTambah.UseVisualStyleBackColor = False
        ' 
        ' kursusControl
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DarkBlue
        Controls.Add(btnGridSearch)
        Controls.Add(txtGridSearch)
        Controls.Add(btnGridHapus)
        Controls.Add(btnGridKembali)
        Controls.Add(btnGridTambah)
        Controls.Add(DataGridKursus)
        Name = "kursusControl"
        Size = New Size(946, 531)
        CType(DataGridKursus, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DataGridKursus As DataGridView
    Friend WithEvents btnGridSearch As Button
    Friend WithEvents txtGridSearch As TextBox
    Friend WithEvents btnGridHapus As Button
    Friend WithEvents btnGridKembali As Button
    Friend WithEvents btnGridTambah As Button

End Class
