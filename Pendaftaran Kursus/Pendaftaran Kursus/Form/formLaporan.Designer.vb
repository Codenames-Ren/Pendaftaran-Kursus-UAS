<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formLaporan
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
        lblJenisData = New Label()
        lblDateFrom = New Label()
        lblDateTo = New Label()
        cmbJenisData = New ComboBox()
        dtpDateFrom = New DateTimePicker()
        dtpDateTo = New DateTimePicker()
        btnPreview = New Button()
        btnExportToPDF = New Button()
        btnExportToExcel = New Button()
        dataGridLaporan = New DataGridView()
        CType(dataGridLaporan, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblJenisData
        ' 
        lblJenisData.AutoSize = True
        lblJenisData.BackColor = Color.Transparent
        lblJenisData.ForeColor = Color.White
        lblJenisData.Location = New Point(333, 52)
        lblJenisData.Name = "lblJenisData"
        lblJenisData.Size = New Size(76, 20)
        lblJenisData.TabIndex = 0
        lblJenisData.Text = "Jenis Data"
        ' 
        ' lblDateFrom
        ' 
        lblDateFrom.AutoSize = True
        lblDateFrom.BackColor = Color.Transparent
        lblDateFrom.ForeColor = Color.White
        lblDateFrom.Location = New Point(333, 100)
        lblDateFrom.Name = "lblDateFrom"
        lblDateFrom.Size = New Size(98, 20)
        lblDateFrom.TabIndex = 1
        lblDateFrom.Text = "Tanggal Awal"
        ' 
        ' lblDateTo
        ' 
        lblDateTo.AutoSize = True
        lblDateTo.BackColor = Color.Transparent
        lblDateTo.ForeColor = Color.White
        lblDateTo.Location = New Point(333, 152)
        lblDateTo.Name = "lblDateTo"
        lblDateTo.Size = New Size(99, 20)
        lblDateTo.TabIndex = 2
        lblDateTo.Text = "Tanggal Akhir"
        ' 
        ' cmbJenisData
        ' 
        cmbJenisData.FormattingEnabled = True
        cmbJenisData.Location = New Point(465, 49)
        cmbJenisData.Name = "cmbJenisData"
        cmbJenisData.Size = New Size(303, 28)
        cmbJenisData.TabIndex = 3
        ' 
        ' dtpDateFrom
        ' 
        dtpDateFrom.Location = New Point(465, 100)
        dtpDateFrom.Name = "dtpDateFrom"
        dtpDateFrom.Size = New Size(303, 27)
        dtpDateFrom.TabIndex = 4
        ' 
        ' dtpDateTo
        ' 
        dtpDateTo.Location = New Point(465, 152)
        dtpDateTo.Name = "dtpDateTo"
        dtpDateTo.Size = New Size(303, 27)
        dtpDateTo.TabIndex = 5
        ' 
        ' btnPreview
        ' 
        btnPreview.BackColor = Color.RoyalBlue
        btnPreview.ForeColor = Color.White
        btnPreview.Location = New Point(280, 208)
        btnPreview.Name = "btnPreview"
        btnPreview.Size = New Size(129, 41)
        btnPreview.TabIndex = 6
        btnPreview.Text = "Preview"
        btnPreview.UseVisualStyleBackColor = False
        ' 
        ' btnExportToPDF
        ' 
        btnExportToPDF.BackColor = Color.Red
        btnExportToPDF.ForeColor = Color.White
        btnExportToPDF.Location = New Point(488, 208)
        btnExportToPDF.Name = "btnExportToPDF"
        btnExportToPDF.Size = New Size(129, 41)
        btnExportToPDF.TabIndex = 7
        btnExportToPDF.Text = "Export to PDF"
        btnExportToPDF.UseVisualStyleBackColor = False
        ' 
        ' btnExportToExcel
        ' 
        btnExportToExcel.BackColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        btnExportToExcel.ForeColor = Color.White
        btnExportToExcel.Location = New Point(694, 208)
        btnExportToExcel.Name = "btnExportToExcel"
        btnExportToExcel.Size = New Size(129, 41)
        btnExportToExcel.TabIndex = 8
        btnExportToExcel.Text = "Export to Excel"
        btnExportToExcel.UseVisualStyleBackColor = False
        ' 
        ' dataGridLaporan
        ' 
        dataGridLaporan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dataGridLaporan.Location = New Point(33, 274)
        dataGridLaporan.Name = "dataGridLaporan"
        dataGridLaporan.RowHeadersWidth = 51
        dataGridLaporan.Size = New Size(1028, 342)
        dataGridLaporan.TabIndex = 9
        ' 
        ' formLaporan
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DarkBlue
        ClientSize = New Size(1093, 628)
        Controls.Add(dataGridLaporan)
        Controls.Add(btnExportToExcel)
        Controls.Add(btnExportToPDF)
        Controls.Add(btnPreview)
        Controls.Add(dtpDateTo)
        Controls.Add(dtpDateFrom)
        Controls.Add(cmbJenisData)
        Controls.Add(lblDateTo)
        Controls.Add(lblDateFrom)
        Controls.Add(lblJenisData)
        Name = "formLaporan"
        Text = "formLaporan"
        CType(dataGridLaporan, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblJenisData As Label
    Friend WithEvents lblDateFrom As Label
    Friend WithEvents lblDateTo As Label
    Friend WithEvents cmbJenisData As ComboBox
    Friend WithEvents dtpDateFrom As DateTimePicker
    Friend WithEvents dtpDateTo As DateTimePicker
    Friend WithEvents btnPreview As Button
    Friend WithEvents btnExportToPDF As Button
    Friend WithEvents btnExportToExcel As Button
    Friend WithEvents dataGridLaporan As DataGridView
End Class
