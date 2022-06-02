<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogUsr
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
        Me.dialoglbl = New System.Windows.Forms.Label()
        Me.dialogContinueButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'dialoglbl
        '
        Me.dialoglbl.AutoSize = True
        Me.dialoglbl.BackColor = System.Drawing.Color.White
        Me.dialoglbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.dialoglbl.Location = New System.Drawing.Point(58, 129)
        Me.dialoglbl.Name = "dialoglbl"
        Me.dialoglbl.Size = New System.Drawing.Size(64, 22)
        Me.dialoglbl.TabIndex = 0
        Me.dialoglbl.Text = "Label1"
        '
        'dialogContinueButton
        '
        Me.dialogContinueButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.dialogContinueButton.Location = New System.Drawing.Point(288, 257)
        Me.dialogContinueButton.Name = "dialogContinueButton"
        Me.dialogContinueButton.Size = New System.Drawing.Size(202, 83)
        Me.dialogContinueButton.TabIndex = 1
        Me.dialogContinueButton.Text = "Continue Test"
        Me.dialogContinueButton.UseVisualStyleBackColor = True
        '
        'DialogUsr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.dialogContinueButton)
        Me.Controls.Add(Me.dialoglbl)
        Me.Name = "DialogUsr"
        Me.Text = "DialogUsr"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dialoglbl As Label
    Friend WithEvents dialogContinueButton As Button
End Class
