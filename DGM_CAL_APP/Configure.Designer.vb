<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Configure
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.configconfirmbutton = New System.Windows.Forms.Button()
        Me.configlabel1 = New System.Windows.Forms.Label()
        Me.configlabel2 = New System.Windows.Forms.Label()
        Me.usrstdtemptxtbox = New System.Windows.Forms.TextBox()
        Me.celsiusradiobutton = New System.Windows.Forms.RadioButton()
        Me.fahrenheitradiobutton = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.restoredefaultsbutton = New System.Windows.Forms.Button()
        Me.defaultlabel = New System.Windows.Forms.Label()
        Me.tempoffsetlabel1 = New System.Windows.Forms.TextBox()
        Me.tempoffsetlabel0 = New System.Windows.Forms.Label()
        Me.configtimer = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'configconfirmbutton
        '
        Me.configconfirmbutton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.5!)
        Me.configconfirmbutton.Location = New System.Drawing.Point(654, 366)
        Me.configconfirmbutton.Name = "configconfirmbutton"
        Me.configconfirmbutton.Size = New System.Drawing.Size(118, 59)
        Me.configconfirmbutton.TabIndex = 0
        Me.configconfirmbutton.Text = "Confirm"
        Me.configconfirmbutton.UseVisualStyleBackColor = True
        '
        'configlabel1
        '
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
        Me.usrstdtemptxtbox.Location = New System.Drawing.Point(262, 34)
        Me.usrstdtemptxtbox.Name = "usrstdtemptxtbox"
        Me.usrstdtemptxtbox.Size = New System.Drawing.Size(157, 20)
        Me.usrstdtemptxtbox.TabIndex = 3
        Me.usrstdtemptxtbox.Text = "20"
        '
        'celsiusradiobutton
        '
        Me.celsiusradiobutton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.celsiusradiobutton.ForeColor = System.Drawing.SystemColors.Control
        Me.celsiusradiobutton.Location = New System.Drawing.Point(178, 170)
        Me.celsiusradiobutton.Name = "celsiusradiobutton"
        Me.celsiusradiobutton.Size = New System.Drawing.Size(70, 24)
        Me.celsiusradiobutton.TabIndex = 4
        Me.celsiusradiobutton.Text = "Metric"
        Me.celsiusradiobutton.UseVisualStyleBackColor = True
        '
        'fahrenheitradiobutton
        '
        Me.fahrenheitradiobutton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.fahrenheitradiobutton.ForeColor = System.Drawing.SystemColors.Control
        Me.fahrenheitradiobutton.Location = New System.Drawing.Point(262, 170)
        Me.fahrenheitradiobutton.Name = "fahrenheitradiobutton"
        Me.fahrenheitradiobutton.Size = New System.Drawing.Size(247, 24)
        Me.fahrenheitradiobutton.TabIndex = 5
        Me.fahrenheitradiobutton.Text = "Imperial (If you use Fahrenheit)"
        Me.fahrenheitradiobutton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.5!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(12, 170)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Enter Unit System: "
        '
        'restoredefaultsbutton
        '
        Me.restoredefaultsbutton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.5!)
        Me.restoredefaultsbutton.Location = New System.Drawing.Point(12, 366)
        Me.restoredefaultsbutton.Name = "restoredefaultsbutton"
        Me.restoredefaultsbutton.Size = New System.Drawing.Size(118, 59)
        Me.restoredefaultsbutton.TabIndex = 8
        Me.restoredefaultsbutton.Text = "Restore Defaults"
        Me.restoredefaultsbutton.UseVisualStyleBackColor = True
        '
        'defaultlabel
        '
        Me.defaultlabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.5!)
        Me.defaultlabel.ForeColor = System.Drawing.SystemColors.Control
        Me.defaultlabel.Location = New System.Drawing.Point(154, 366)
        Me.defaultlabel.Name = "defaultlabel"
        Me.defaultlabel.Size = New System.Drawing.Size(344, 20)
        Me.defaultlabel.TabIndex = 9
        Me.defaultlabel.Text = "Default Settings: 20 degrees celsius (metric)"
        '
        'tempoffsetlabel1
        '
        Me.tempoffsetlabel1.Location = New System.Drawing.Point(262, 104)
        Me.tempoffsetlabel1.Name = "tempoffsetlabel1"
        Me.tempoffsetlabel1.Size = New System.Drawing.Size(157, 20)
        Me.tempoffsetlabel1.TabIndex = 11
        '
        'tempoffsetlabel0
        '
        Me.tempoffsetlabel0.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.5!)
        Me.tempoffsetlabel0.ForeColor = System.Drawing.SystemColors.Control
        Me.tempoffsetlabel0.Location = New System.Drawing.Point(12, 104)
        Me.tempoffsetlabel0.Name = "tempoffsetlabel0"
        Me.tempoffsetlabel0.Size = New System.Drawing.Size(236, 20)
        Me.tempoffsetlabel0.TabIndex = 10
        Me.tempoffsetlabel0.Text = "Enter Ref Meter Temp Offset: "
        '
        'configtimer
        '
        Me.configtimer.Enabled = True
        '
        'Configure
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSlateGray
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.tempoffsetlabel1)
        Me.Controls.Add(Me.tempoffsetlabel0)
        Me.Controls.Add(Me.defaultlabel)
        Me.Controls.Add(Me.restoredefaultsbutton)
        Me.Controls.Add(Me.Label1)
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
    Friend WithEvents Label1 As Label
    Friend WithEvents restoredefaultsbutton As Button
    Friend WithEvents defaultlabel As Label
    Friend WithEvents tempoffsetlabel1 As TextBox
    Friend WithEvents tempoffsetlabel0 As Label
    Friend WithEvents configtimer As Timer
End Class
