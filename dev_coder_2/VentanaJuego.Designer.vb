<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VentanaJuego
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        TableLayoutPanel1 = New TableLayoutPanel()
        TableLayoutPanel2 = New TableLayoutPanel()
        compilarBtn = New Button()
        codigoRichTextBox = New RichTextBox()
        TableLayoutPanel3 = New TableLayoutPanel()
        consolaTextBox = New TextBox()
        codigoDataGridView = New DataGridView()
        TableLayoutPanel4 = New TableLayoutPanel()
        encapsulamientoBtn = New Button()
        clasesBtn = New Button()
        herenciaBtn = New Button()
        agregacionBtn = New Button()
        asociacionBtn = New Button()
        polimorfismoBtn = New Button()
        TreeView1 = New TreeView()
        TableLayoutPanel1.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        CType(codigoDataGridView, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel4.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 4
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        TableLayoutPanel1.Controls.Add(TableLayoutPanel2, 1, 0)
        TableLayoutPanel1.Controls.Add(TableLayoutPanel3, 2, 0)
        TableLayoutPanel1.Controls.Add(TableLayoutPanel4, 3, 0)
        TableLayoutPanel1.Controls.Add(TreeView1, 0, 0)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel1.Size = New Size(1070, 553)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 1
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Controls.Add(compilarBtn, 0, 1)
        TableLayoutPanel2.Controls.Add(codigoRichTextBox, 0, 0)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(270, 3)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 2
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 90F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
        TableLayoutPanel2.Size = New Size(261, 547)
        TableLayoutPanel2.TabIndex = 0
        ' 
        ' compilarBtn
        ' 
        compilarBtn.Dock = DockStyle.Fill
        compilarBtn.Location = New Point(3, 495)
        compilarBtn.Name = "compilarBtn"
        compilarBtn.Size = New Size(255, 49)
        compilarBtn.TabIndex = 1
        compilarBtn.Text = "Compilar"
        compilarBtn.UseVisualStyleBackColor = True
        ' 
        ' codigoRichTextBox
        ' 
        codigoRichTextBox.Dock = DockStyle.Fill
        codigoRichTextBox.Location = New Point(3, 3)
        codigoRichTextBox.Name = "codigoRichTextBox"
        codigoRichTextBox.Size = New Size(255, 486)
        codigoRichTextBox.TabIndex = 2
        codigoRichTextBox.Text = ""
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.ColumnCount = 1
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel3.Controls.Add(consolaTextBox, 0, 1)
        TableLayoutPanel3.Controls.Add(codigoDataGridView, 0, 0)
        TableLayoutPanel3.Dock = DockStyle.Fill
        TableLayoutPanel3.Location = New Point(537, 3)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 2
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 65F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 35F))
        TableLayoutPanel3.Size = New Size(261, 547)
        TableLayoutPanel3.TabIndex = 1
        ' 
        ' consolaTextBox
        ' 
        consolaTextBox.Dock = DockStyle.Fill
        consolaTextBox.Location = New Point(3, 358)
        consolaTextBox.Multiline = True
        consolaTextBox.Name = "consolaTextBox"
        consolaTextBox.ReadOnly = True
        consolaTextBox.Size = New Size(255, 186)
        consolaTextBox.TabIndex = 1
        ' 
        ' codigoDataGridView
        ' 
        codigoDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        codigoDataGridView.Dock = DockStyle.Fill
        codigoDataGridView.Location = New Point(3, 3)
        codigoDataGridView.Name = "codigoDataGridView"
        codigoDataGridView.Size = New Size(255, 349)
        codigoDataGridView.TabIndex = 2
        ' 
        ' TableLayoutPanel4
        ' 
        TableLayoutPanel4.ColumnCount = 1
        TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel4.Controls.Add(encapsulamientoBtn, 0, 0)
        TableLayoutPanel4.Controls.Add(clasesBtn, 0, 1)
        TableLayoutPanel4.Controls.Add(herenciaBtn, 0, 2)
        TableLayoutPanel4.Controls.Add(agregacionBtn, 0, 3)
        TableLayoutPanel4.Controls.Add(asociacionBtn, 0, 4)
        TableLayoutPanel4.Controls.Add(polimorfismoBtn, 0, 5)
        TableLayoutPanel4.Dock = DockStyle.Fill
        TableLayoutPanel4.Location = New Point(804, 3)
        TableLayoutPanel4.Name = "TableLayoutPanel4"
        TableLayoutPanel4.RowCount = 6
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel4.Size = New Size(263, 547)
        TableLayoutPanel4.TabIndex = 2
        ' 
        ' encapsulamientoBtn
        ' 
        encapsulamientoBtn.Dock = DockStyle.Fill
        encapsulamientoBtn.Location = New Point(3, 3)
        encapsulamientoBtn.Name = "encapsulamientoBtn"
        encapsulamientoBtn.Size = New Size(257, 85)
        encapsulamientoBtn.TabIndex = 0
        encapsulamientoBtn.Text = "Button1"
        encapsulamientoBtn.UseVisualStyleBackColor = True
        ' 
        ' clasesBtn
        ' 
        clasesBtn.Dock = DockStyle.Fill
        clasesBtn.Location = New Point(3, 94)
        clasesBtn.Name = "clasesBtn"
        clasesBtn.Size = New Size(257, 85)
        clasesBtn.TabIndex = 1
        clasesBtn.Text = "Button1"
        clasesBtn.UseVisualStyleBackColor = True
        ' 
        ' herenciaBtn
        ' 
        herenciaBtn.Dock = DockStyle.Fill
        herenciaBtn.Location = New Point(3, 185)
        herenciaBtn.Name = "herenciaBtn"
        herenciaBtn.Size = New Size(257, 85)
        herenciaBtn.TabIndex = 1
        herenciaBtn.Text = "Button1"
        herenciaBtn.UseVisualStyleBackColor = True
        ' 
        ' agregacionBtn
        ' 
        agregacionBtn.Dock = DockStyle.Fill
        agregacionBtn.Location = New Point(3, 276)
        agregacionBtn.Name = "agregacionBtn"
        agregacionBtn.Size = New Size(257, 85)
        agregacionBtn.TabIndex = 1
        agregacionBtn.Text = "Button1"
        agregacionBtn.UseVisualStyleBackColor = True
        ' 
        ' asociacionBtn
        ' 
        asociacionBtn.Dock = DockStyle.Fill
        asociacionBtn.Location = New Point(3, 367)
        asociacionBtn.Name = "asociacionBtn"
        asociacionBtn.Size = New Size(257, 85)
        asociacionBtn.TabIndex = 1
        asociacionBtn.Text = "Button1"
        asociacionBtn.UseVisualStyleBackColor = True
        ' 
        ' polimorfismoBtn
        ' 
        polimorfismoBtn.Dock = DockStyle.Fill
        polimorfismoBtn.Location = New Point(3, 458)
        polimorfismoBtn.Name = "polimorfismoBtn"
        polimorfismoBtn.Size = New Size(257, 86)
        polimorfismoBtn.TabIndex = 1
        polimorfismoBtn.Text = "Button1"
        polimorfismoBtn.UseVisualStyleBackColor = True
        ' 
        ' TreeView1
        ' 
        TreeView1.Dock = DockStyle.Fill
        TreeView1.Location = New Point(6, 6)
        TreeView1.Margin = New Padding(6)
        TreeView1.Name = "TreeView1"
        TreeView1.Size = New Size(255, 541)
        TreeView1.TabIndex = 3
        ' 
        ' VentanaJuego
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1070, 553)
        Controls.Add(TableLayoutPanel1)
        Name = "VentanaJuego"
        Text = "VentanaJuego"
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel3.ResumeLayout(False)
        TableLayoutPanel3.PerformLayout()
        CType(codigoDataGridView, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel4.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents compilarBtn As Button
    Friend WithEvents consolaTextBox As TextBox
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents codigoRichTextBox As RichTextBox
    Friend WithEvents codigoDataGridView As DataGridView
    Friend WithEvents encapsulamientoBtn As Button
    Friend WithEvents clasesBtn As Button
    Friend WithEvents herenciaBtn As Button
    Friend WithEvents agregacionBtn As Button
    Friend WithEvents asociacionBtn As Button
    Friend WithEvents polimorfismoBtn As Button
End Class
