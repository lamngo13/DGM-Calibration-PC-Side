﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.configlabel1 = New System.Windows.Forms.Label()
        Me.configlabel2 = New System.Windows.Forms.Label()
        Me.usrstdtemptxtbox = New System.Windows.Forms.TextBox()
        Me.celsiusradiobutton = New System.Windows.Forms.RadioButton()
        Me.fahrenheitradiobutton = New System.Windows.Forms.RadioButton()
        Me.kelvinradiobutton = New System.Windows.Forms.RadioButton()
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
        'configlabel1
        '
        Me.configlabel1.AutoSize = True
        Me.configlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.5!)
        Me.configlabel1.ForeColor = System.Drawing.SystemColors.Control
        Me.configlabel1.Location = New System.Drawing.Point(12, 32)
        Me.configlabel1.Name = "configlabel1"
        Me.configlabel1.Size = New System.Drawing.Size(226, 20)
        Me.configlabel1.TabIndex = 1
        Me.configlabel1.Text = "Enter Standard Temperature:"
        '
        'configlabel2
        '
        Me.configlabel2.AutoSize = True
        Me.configlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.5!)
        Me.configlabel2.ForeColor = System.Drawing.SystemColors.Control
        Me.configlabel2.Location = New System.Drawing.Point(290, 215)
        Me.configlabel2.Name = "configlabel2"
        Me.configlabel2.Size = New System.Drawing.Size(0, 20)
        Me.configlabel2.TabIndex = 2
        '
        'usrstdtemptxtbox
        '
        Me.usrstdtemptxtbox.Location = New System.Drawing.Point(239, 34)
        Me.usrstdtemptxtbox.Name = "usrstdtemptxtbox"
        Me.usrstdtemptxtbox.Size = New System.Drawing.Size(157, 20)
        Me.usrstdtemptxtbox.TabIndex = 3
        '
        'celsiusradiobutton
        '
        Me.celsiusradiobutton.AutoSize = True
        Me.celsiusradiobutton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.celsiusradiobutton.ForeColor = System.Drawing.SystemColors.Control
        Me.celsiusradiobutton.Location = New System.Drawing.Point(428, 34)
        Me.celsiusradiobutton.Name = "celsiusradiobutton"
        Me.celsiusradiobutton.Size = New System.Drawing.Size(78, 24)
        Me.celsiusradiobutton.TabIndex = 4
        Me.celsiusradiobutton.TabStop = True
        Me.celsiusradiobutton.Text = "Celsius"
        Me.celsiusradiobutton.UseVisualStyleBackColor = True
        '
        'fahrenheitradiobutton
        '
        Me.fahrenheitradiobutton.AutoSize = True
        Me.fahrenheitradiobutton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.fahrenheitradiobutton.ForeColor = System.Drawing.SystemColors.Control
        Me.fahrenheitradiobutton.Location = New System.Drawing.Point(512, 34)
        Me.fahrenheitradiobutton.Name = "fahrenheitradiobutton"
        Me.fahrenheitradiobutton.Size = New System.Drawing.Size(104, 24)
        Me.fahrenheitradiobutton.TabIndex = 5
        Me.fahrenheitradiobutton.TabStop = True
        Me.fahrenheitradiobutton.Text = "Fahrenheit"
        Me.fahrenheitradiobutton.UseVisualStyleBackColor = True
        '
        'kelvinradiobutton
        '
        Me.kelvinradiobutton.AutoSize = True
        Me.kelvinradiobutton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.kelvinradiobutton.ForeColor = System.Drawing.SystemColors.Control
        Me.kelvinradiobutton.Location = New System.Drawing.Point(622, 34)
        Me.kelvinradiobutton.Name = "kelvinradiobutton"
        Me.kelvinradiobutton.Size = New System.Drawing.Size(68, 24)
        Me.kelvinradiobutton.TabIndex = 6
        Me.kelvinradiobutton.TabStop = True
        Me.kelvinradiobutton.Text = "Kelvin"
        Me.kelvinradiobutton.UseVisualStyleBackColor = True
        '
        'Configure
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSlateGray
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.kelvinradiobutton)
        Me.Controls.Add(Me.fahrenheitradiobutton)
        Me.Controls.Add(Me.celsiusradiobutton)
        Me.Controls.Add(Me.usrstdtemptxtbox)
        Me.Controls.Add(Me.configlabel2)
        Me.Controls.Add(Me.configlabel1)
        Me.Controls.Add(Me.configconfirmbutton)
        Me.Name = "Configure"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents configconfirmbutton As Button
    Friend WithEvents configlabel1 As Label
    Friend WithEvents configlabel2 As Label
    Friend WithEvents usrstdtemptxtbox As TextBox
    Friend WithEvents celsiusradiobutton As RadioButton
    Friend WithEvents fahrenheitradiobutton As RadioButton
    Friend WithEvents kelvinradiobutton As RadioButton
End Class
