<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ErrorForm
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
        Me.errormsglabel = New System.Windows.Forms.Label()
        Me.exiterrorformbutton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'errormsglabel
        '
        Me.errormsglabel.AutoSize = True
        Me.errormsglabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.errormsglabel.ForeColor = System.Drawing.Color.DarkRed
        Me.errormsglabel.Location = New System.Drawing.Point(104, 143)
        Me.errormsglabel.Name = "errormsglabel"
        Me.errormsglabel.Size = New System.Drawing.Size(64, 22)
        Me.errormsglabel.TabIndex = 0
        Me.errormsglabel.Text = "Label1"
        '
        'exiterrorformbutton
        '
        Me.exiterrorformbutton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.exiterrorformbutton.Location = New System.Drawing.Point(234, 267)
        Me.exiterrorformbutton.Name = "exiterrorformbutton"
        Me.exiterrorformbutton.Size = New System.Drawing.Size(130, 53)
        Me.exiterrorformbutton.TabIndex = 1
        Me.exiterrorformbutton.Text = "Ok"
        Me.exiterrorformbutton.UseVisualStyleBackColor = True
        '
        'ErrorForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Menu
        Me.ClientSize = New System.Drawing.Size(637, 373)
        Me.Controls.Add(Me.exiterrorformbutton)
        Me.Controls.Add(Me.errormsglabel)
        Me.Name = "ErrorForm"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents errormsglabel As Label
    Friend WithEvents exiterrorformbutton As Button
End Class
