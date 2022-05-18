<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dp
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
        Me.components = New System.ComponentModel.Container()
        Me.lblClock = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.lblsp = New System.Windows.Forms.Label()
        Me.openCom = New System.Windows.Forms.Button()
        Me.lblfirst = New System.Windows.Forms.Label()
        Me.lblsecond = New System.Windows.Forms.Label()
        Me.lblthird = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblClock
        '
        Me.lblClock.AutoSize = True
        Me.lblClock.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClock.ForeColor = System.Drawing.SystemColors.Control
        Me.lblClock.Location = New System.Drawing.Point(39, 47)
        Me.lblClock.Name = "lblClock"
        Me.lblClock.Size = New System.Drawing.Size(456, 118)
        Me.lblClock.TabIndex = 0
        Me.lblClock.Text = "12:00:00"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'SerialPort1
        '
        Me.SerialPort1.BaudRate = 460800
        Me.SerialPort1.PortName = "COM4"
        '
        'lblsp
        '
        Me.lblsp.AutoSize = True
        Me.lblsp.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsp.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblsp.Location = New System.Drawing.Point(67, 248)
        Me.lblsp.Name = "lblsp"
        Me.lblsp.Size = New System.Drawing.Size(364, 118)
        Me.lblsp.TabIndex = 1
        Me.lblsp.Text = "Label1"
        '
        'openCom
        '
        Me.openCom.Location = New System.Drawing.Point(730, 106)
        Me.openCom.Name = "openCom"
        Me.openCom.Size = New System.Drawing.Size(290, 107)
        Me.openCom.TabIndex = 2
        Me.openCom.Text = "Connect"
        Me.openCom.UseVisualStyleBackColor = True
        '
        'lblfirst
        '
        Me.lblfirst.AutoSize = True
        Me.lblfirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!)
        Me.lblfirst.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblfirst.Location = New System.Drawing.Point(67, 445)
        Me.lblfirst.Name = "lblfirst"
        Me.lblfirst.Size = New System.Drawing.Size(248, 118)
        Me.lblfirst.TabIndex = 4
        Me.lblfirst.Text = "first:"
        '
        'lblsecond
        '
        Me.lblsecond.AutoSize = True
        Me.lblsecond.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!)
        Me.lblsecond.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblsecond.Location = New System.Drawing.Point(64, 596)
        Me.lblsecond.Name = "lblsecond"
        Me.lblsecond.Size = New System.Drawing.Size(443, 118)
        Me.lblsecond.TabIndex = 5
        Me.lblsecond.Text = "second: "
        '
        'lblthird
        '
        Me.lblthird.AutoSize = True
        Me.lblthird.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!)
        Me.lblthird.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblthird.Location = New System.Drawing.Point(90, 771)
        Me.lblthird.Name = "lblthird"
        Me.lblthird.Size = New System.Drawing.Size(283, 118)
        Me.lblthird.TabIndex = 6
        Me.lblthird.Text = "third:"
        '
        'dp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(19.0!, 37.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.ClientSize = New System.Drawing.Size(2007, 1126)
        Me.Controls.Add(Me.lblthird)
        Me.Controls.Add(Me.lblsecond)
        Me.Controls.Add(Me.lblfirst)
        Me.Controls.Add(Me.openCom)
        Me.Controls.Add(Me.lblsp)
        Me.Controls.Add(Me.lblClock)
        Me.Name = "dp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "A Clock"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblClock As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents lblsp As Label
    Friend WithEvents openCom As Button
    Friend WithEvents lblfirst As Label
    Friend WithEvents lblsecond As Label
    Friend WithEvents lblthird As Label
End Class
