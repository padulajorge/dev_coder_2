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
        jugadorTexBox = New TextBox()
        ingresarBtn = New Button()
        TableLayoutPanel1 = New TableLayoutPanel()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' jugadorTexBox
        ' 
        jugadorTexBox.Anchor = AnchorStyles.None
        jugadorTexBox.Location = New Point(240, 156)
        jugadorTexBox.Name = "jugadorTexBox"
        jugadorTexBox.Size = New Size(319, 23)
        jugadorTexBox.TabIndex = 0
        ' 
        ' ingresarBtn
        ' 
        ingresarBtn.Anchor = AnchorStyles.None
        ingresarBtn.Location = New Point(362, 268)
        ingresarBtn.Name = "ingresarBtn"
        ingresarBtn.Size = New Size(75, 23)
        ingresarBtn.TabIndex = 1
        ingresarBtn.Text = "Ingresar"
        ingresarBtn.UseVisualStyleBackColor = True
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Controls.Add(ingresarBtn, 0, 2)
        TableLayoutPanel1.Controls.Add(jugadorTexBox, 0, 1)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 4
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        TableLayoutPanel1.Size = New Size(800, 450)
        TableLayoutPanel1.TabIndex = 2
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(TableLayoutPanel1)
        Name = "Form1"
        Text = "Form1"
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents jugadorTexBox As TextBox
    Friend WithEvents ingresarBtn As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel

End Class
