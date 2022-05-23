<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Configure
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
        Me.configconfirmbutton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'configconfirmbutton
        '
        Me.configconfirmbutton.Location = New System.Drawing.Point(577, 294)
        Me.configconfirmbutton.Name = "configconfirmbutton"
        Me.configconfirmbutton.Size = New System.Drawing.Size(195, 131)
        Me.configconfirmbutton.TabIndex = 0
        Me.configconfirmbutton.Text = "Confirm"
        Me.configconfirmbutton.UseVisualStyleBackColor = True
        '
        'Configure
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.configconfirmbutton)
        Me.Name = "Configure"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents configconfirmbutton As Button
End Class
