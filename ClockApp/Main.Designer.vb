<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.antibugbutton = New System.Windows.Forms.Button()
        Me.FlowRatetxtbox1 = New System.Windows.Forms.TextBox()
        Me.FlowRatetxtbox2 = New System.Windows.Forms.TextBox()
        Me.FlowRatetxtbox3 = New System.Windows.Forms.TextBox()
        Me.FlowRatetxtbox4 = New System.Windows.Forms.TextBox()
        Me.FlowRatetxtbox5 = New System.Windows.Forms.TextBox()
        Me.FlowRatetxtbox6 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'antibugbutton
        '
        Me.antibugbutton.Location = New System.Drawing.Point(923, 660)
        Me.antibugbutton.Name = "antibugbutton"
        Me.antibugbutton.Size = New System.Drawing.Size(114, 35)
        Me.antibugbutton.TabIndex = 0
        Me.antibugbutton.Text = "Button1"
        Me.antibugbutton.UseVisualStyleBackColor = True
        '
        'FlowRatetxtbox1
        '
        Me.FlowRatetxtbox1.Location = New System.Drawing.Point(134, 163)
        Me.FlowRatetxtbox1.Name = "FlowRatetxtbox1"
        Me.FlowRatetxtbox1.Size = New System.Drawing.Size(123, 20)
        Me.FlowRatetxtbox1.TabIndex = 1
        '
        'FlowRatetxtbox2
        '
        Me.FlowRatetxtbox2.Location = New System.Drawing.Point(134, 189)
        Me.FlowRatetxtbox2.Name = "FlowRatetxtbox2"
        Me.FlowRatetxtbox2.Size = New System.Drawing.Size(123, 20)
        Me.FlowRatetxtbox2.TabIndex = 2
        '
        'FlowRatetxtbox3
        '
        Me.FlowRatetxtbox3.Location = New System.Drawing.Point(134, 215)
        Me.FlowRatetxtbox3.Name = "FlowRatetxtbox3"
        Me.FlowRatetxtbox3.Size = New System.Drawing.Size(123, 20)
        Me.FlowRatetxtbox3.TabIndex = 3
        '
        'FlowRatetxtbox4
        '
        Me.FlowRatetxtbox4.Location = New System.Drawing.Point(134, 241)
        Me.FlowRatetxtbox4.Name = "FlowRatetxtbox4"
        Me.FlowRatetxtbox4.Size = New System.Drawing.Size(123, 20)
        Me.FlowRatetxtbox4.TabIndex = 4
        '
        'FlowRatetxtbox5
        '
        Me.FlowRatetxtbox5.Location = New System.Drawing.Point(134, 267)
        Me.FlowRatetxtbox5.Name = "FlowRatetxtbox5"
        Me.FlowRatetxtbox5.Size = New System.Drawing.Size(123, 20)
        Me.FlowRatetxtbox5.TabIndex = 5
        '
        'FlowRatetxtbox6
        '
        Me.FlowRatetxtbox6.Location = New System.Drawing.Point(134, 293)
        Me.FlowRatetxtbox6.Name = "FlowRatetxtbox6"
        Me.FlowRatetxtbox6.Size = New System.Drawing.Size(123, 20)
        Me.FlowRatetxtbox6.TabIndex = 6
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSlateGray
        Me.ClientSize = New System.Drawing.Size(1049, 707)
        Me.Controls.Add(Me.FlowRatetxtbox6)
        Me.Controls.Add(Me.FlowRatetxtbox5)
        Me.Controls.Add(Me.FlowRatetxtbox4)
        Me.Controls.Add(Me.FlowRatetxtbox3)
        Me.Controls.Add(Me.FlowRatetxtbox2)
        Me.Controls.Add(Me.FlowRatetxtbox1)
        Me.Controls.Add(Me.antibugbutton)
        Me.Name = "Main"
        Me.Text = "Form2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents antibugbutton As Button
    Friend WithEvents FlowRatetxtbox1 As TextBox
    Friend WithEvents FlowRatetxtbox2 As TextBox
    Friend WithEvents FlowRatetxtbox3 As TextBox
    Friend WithEvents FlowRatetxtbox4 As TextBox
    Friend WithEvents FlowRatetxtbox5 As TextBox
    Friend WithEvents FlowRatetxtbox6 As TextBox
End Class
