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
        Me.SuspendLayout()
        '
        'lblClock
        '
        Me.lblClock.AutoSize = True
        Me.lblClock.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClock.ForeColor = System.Drawing.SystemColors.Control
        Me.lblClock.Location = New System.Drawing.Point(866, 243)
        Me.lblClock.Name = "lblClock"
        Me.lblClock.Size = New System.Drawing.Size(456, 118)
        Me.lblClock.TabIndex = 0
        Me.lblClock.Text = "12:00:00"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
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
        Me.lblsp.Location = New System.Drawing.Point(918, 509)
        Me.lblsp.Name = "lblsp"
        Me.lblsp.Size = New System.Drawing.Size(364, 118)
        Me.lblsp.TabIndex = 1
        Me.lblsp.Text = "Label1"
        '
        'openCom
        '
        Me.openCom.Location = New System.Drawing.Point(1557, 302)
        Me.openCom.Name = "openCom"
        Me.openCom.Size = New System.Drawing.Size(290, 107)
        Me.openCom.TabIndex = 2
        Me.openCom.Text = "Connect"
        Me.openCom.UseVisualStyleBackColor = True
        '
        'dp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(19.0!, 37.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.ClientSize = New System.Drawing.Size(2354, 1140)
        Me.Controls.Add(Me.openCom)
        Me.Controls.Add(Me.lblsp)
        Me.Controls.Add(Me.lblClock)
        Me.Name = "dp"
        Me.Text = "A Clock"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblClock As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents lblsp As Label
    Friend WithEvents openCom As Button
End Class
