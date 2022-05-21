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
        Me.crcdifflabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblClock
        '
        Me.lblClock.AutoSize = True
        Me.lblClock.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClock.ForeColor = System.Drawing.SystemColors.Control
        Me.lblClock.Location = New System.Drawing.Point(12, 17)
        Me.lblClock.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblClock.Name = "lblClock"
        Me.lblClock.Size = New System.Drawing.Size(151, 39)
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
        Me.lblsp.Location = New System.Drawing.Point(21, 87)
        Me.lblsp.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblsp.Name = "lblsp"
        Me.lblsp.Size = New System.Drawing.Size(120, 39)
        Me.lblsp.TabIndex = 1
        Me.lblsp.Text = "Label1"
        '
        'openCom
        '
        Me.openCom.Location = New System.Drawing.Point(231, 37)
        Me.openCom.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.openCom.Name = "openCom"
        Me.openCom.Size = New System.Drawing.Size(92, 38)
        Me.openCom.TabIndex = 2
        Me.openCom.Text = "Connect"
        Me.openCom.UseVisualStyleBackColor = True
        '
        'lblfirst
        '
        Me.lblfirst.AutoSize = True
        Me.lblfirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!)
        Me.lblfirst.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblfirst.Location = New System.Drawing.Point(21, 156)
        Me.lblfirst.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblfirst.Name = "lblfirst"
        Me.lblfirst.Size = New System.Drawing.Size(85, 39)
        Me.lblfirst.TabIndex = 4
        Me.lblfirst.Text = "first:"
        '
        'lblsecond
        '
        Me.lblsecond.AutoSize = True
        Me.lblsecond.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!)
        Me.lblsecond.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblsecond.Location = New System.Drawing.Point(20, 209)
        Me.lblsecond.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblsecond.Name = "lblsecond"
        Me.lblsecond.Size = New System.Drawing.Size(148, 39)
        Me.lblsecond.TabIndex = 5
        Me.lblsecond.Text = "second: "
        '
        'lblthird
        '
        Me.lblthird.AutoSize = True
        Me.lblthird.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!)
        Me.lblthird.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblthird.Location = New System.Drawing.Point(28, 271)
        Me.lblthird.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblthird.Name = "lblthird"
        Me.lblthird.Size = New System.Drawing.Size(95, 39)
        Me.lblthird.TabIndex = 6
        Me.lblthird.Text = "third:"
        '
        'crcdifflabel
        '
        Me.crcdifflabel.AutoSize = True
        Me.crcdifflabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!)
        Me.crcdifflabel.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.crcdifflabel.Location = New System.Drawing.Point(32, 332)
        Me.crcdifflabel.Name = "crcdifflabel"
        Me.crcdifflabel.Size = New System.Drawing.Size(137, 39)
        Me.crcdifflabel.TabIndex = 7
        Me.crcdifflabel.Text = "Diffcrc: "
        '
        'dp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.DarkSlateGray
        Me.ClientSize = New System.Drawing.Size(852, 534)
        Me.Controls.Add(Me.crcdifflabel)
        Me.Controls.Add(Me.lblthird)
        Me.Controls.Add(Me.lblsecond)
        Me.Controls.Add(Me.lblfirst)
        Me.Controls.Add(Me.openCom)
        Me.Controls.Add(Me.lblsp)
        Me.Controls.Add(Me.lblClock)
        Me.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
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
    Friend WithEvents crcdifflabel As Label
End Class
