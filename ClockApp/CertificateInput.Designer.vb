<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Certification
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Certification))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.teststatuslabel1 = New System.Windows.Forms.Label()
        Me.teststatuslabel2 = New System.Windows.Forms.Label()
        Me.messagetxtbox = New System.Windows.Forms.TextBox()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.txtCertUUTModel = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCertUUTSerial = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCertDGMSerial = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCertDGMModel = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtInitialGamma = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCertAltitude = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCertHumidity = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCertAmbTemp = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCertBarPressure = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.TextBox2)
        Me.Panel1.Controls.Add(Me.teststatuslabel1)
        Me.Panel1.Controls.Add(Me.teststatuslabel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1064, 113)
        Me.Panel1.TabIndex = 143
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Black
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(22, 23)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(203, 86)
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox2.BackColor = System.Drawing.Color.Black
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Font = New System.Drawing.Font("Futura PT Book", 24.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.ForeColor = System.Drawing.Color.White
        Me.TextBox2.Location = New System.Drawing.Point(3, 38)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(1061, 43)
        Me.TextBox2.TabIndex = 1
        Me.TextBox2.Text = "Certificate of Calibration"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'teststatuslabel1
        '
        Me.teststatuslabel1.AutoSize = True
        Me.teststatuslabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.teststatuslabel1.ForeColor = System.Drawing.SystemColors.Control
        Me.teststatuslabel1.Location = New System.Drawing.Point(1182, 19)
        Me.teststatuslabel1.Name = "teststatuslabel1"
        Me.teststatuslabel1.Size = New System.Drawing.Size(95, 20)
        Me.teststatuslabel1.TabIndex = 87
        Me.teststatuslabel1.Text = "Test Status:"
        '
        'teststatuslabel2
        '
        Me.teststatuslabel2.AutoSize = True
        Me.teststatuslabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.teststatuslabel2.ForeColor = System.Drawing.SystemColors.Control
        Me.teststatuslabel2.Location = New System.Drawing.Point(1192, 50)
        Me.teststatuslabel2.Name = "teststatuslabel2"
        Me.teststatuslabel2.Size = New System.Drawing.Size(98, 20)
        Me.teststatuslabel2.TabIndex = 88
        Me.teststatuslabel2.Text = "Not Running"
        '
        'messagetxtbox
        '
        Me.messagetxtbox.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.messagetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.messagetxtbox.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.messagetxtbox.Font = New System.Drawing.Font("Futura PT Book", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.messagetxtbox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.messagetxtbox.Location = New System.Drawing.Point(0, 668)
        Me.messagetxtbox.Multiline = True
        Me.messagetxtbox.Name = "messagetxtbox"
        Me.messagetxtbox.Size = New System.Drawing.Size(1064, 61)
        Me.messagetxtbox.TabIndex = 144
        Me.messagetxtbox.Text = "Welcome to the Apex Instruments Dry Gas Meter Calibration/Validation Tool." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Click" &
    " the Green RUN button to start the process."
        Me.messagetxtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblModel
        '
        Me.lblModel.AutoSize = True
        Me.lblModel.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblModel.Font = New System.Drawing.Font("Futura PT Book", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModel.ForeColor = System.Drawing.SystemColors.Control
        Me.lblModel.Location = New System.Drawing.Point(48, 233)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(89, 19)
        Me.lblModel.TabIndex = 145
        Me.lblModel.Text = "UUT Model #"
        '
        'txtCertUUTModel
        '
        Me.txtCertUUTModel.BackColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.txtCertUUTModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCertUUTModel.ForeColor = System.Drawing.Color.White
        Me.txtCertUUTModel.Location = New System.Drawing.Point(151, 231)
        Me.txtCertUUTModel.Multiline = True
        Me.txtCertUUTModel.Name = "txtCertUUTModel"
        Me.txtCertUUTModel.Size = New System.Drawing.Size(58, 23)
        Me.txtCertUUTModel.TabIndex = 146
        Me.txtCertUUTModel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Futura PT Book", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(63, 164)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 19)
        Me.Label1.TabIndex = 147
        Me.Label1.Text = "UUT Meter Console"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Futura PT Book", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(346, 164)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 19)
        Me.Label2.TabIndex = 148
        Me.Label2.Text = "Calibration Conditions"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Futura PT Book", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(575, 164)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(129, 19)
        Me.Label3.TabIndex = 149
        Me.Label3.Text = "Factors/Conversions"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Futura PT Book", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(842, 164)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(130, 19)
        Me.Label4.TabIndex = 150
        Me.Label4.Text = "Reference Equipment"
        '
        'txtCertUUTSerial
        '
        Me.txtCertUUTSerial.BackColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.txtCertUUTSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCertUUTSerial.ForeColor = System.Drawing.Color.White
        Me.txtCertUUTSerial.Location = New System.Drawing.Point(151, 261)
        Me.txtCertUUTSerial.Multiline = True
        Me.txtCertUUTSerial.Name = "txtCertUUTSerial"
        Me.txtCertUUTSerial.Size = New System.Drawing.Size(58, 23)
        Me.txtCertUUTSerial.TabIndex = 152
        Me.txtCertUUTSerial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Futura PT Book", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(48, 263)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 19)
        Me.Label5.TabIndex = 151
        Me.Label5.Text = "UUT Serial #"
        '
        'txtCertDGMSerial
        '
        Me.txtCertDGMSerial.BackColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.txtCertDGMSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCertDGMSerial.ForeColor = System.Drawing.Color.White
        Me.txtCertDGMSerial.Location = New System.Drawing.Point(151, 321)
        Me.txtCertDGMSerial.Multiline = True
        Me.txtCertDGMSerial.Name = "txtCertDGMSerial"
        Me.txtCertDGMSerial.Size = New System.Drawing.Size(58, 23)
        Me.txtCertDGMSerial.TabIndex = 156
        Me.txtCertDGMSerial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Futura PT Book", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Control
        Me.Label6.Location = New System.Drawing.Point(48, 323)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 19)
        Me.Label6.TabIndex = 155
        Me.Label6.Text = "DGM Serial #"
        '
        'txtCertDGMModel
        '
        Me.txtCertDGMModel.BackColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.txtCertDGMModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCertDGMModel.ForeColor = System.Drawing.Color.White
        Me.txtCertDGMModel.Location = New System.Drawing.Point(151, 291)
        Me.txtCertDGMModel.Multiline = True
        Me.txtCertDGMModel.Name = "txtCertDGMModel"
        Me.txtCertDGMModel.Size = New System.Drawing.Size(58, 23)
        Me.txtCertDGMModel.TabIndex = 154
        Me.txtCertDGMModel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("Futura PT Book", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.Control
        Me.Label7.Location = New System.Drawing.Point(48, 293)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 19)
        Me.Label7.TabIndex = 153
        Me.Label7.Text = "DGM Model #"
        '
        'txtInitialGamma
        '
        Me.txtInitialGamma.BackColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.txtInitialGamma.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInitialGamma.ForeColor = System.Drawing.Color.White
        Me.txtInitialGamma.Location = New System.Drawing.Point(151, 351)
        Me.txtInitialGamma.Multiline = True
        Me.txtInitialGamma.Name = "txtInitialGamma"
        Me.txtInitialGamma.Size = New System.Drawing.Size(58, 23)
        Me.txtInitialGamma.TabIndex = 158
        Me.txtInitialGamma.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Futura PT Book", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.Control
        Me.Label8.Location = New System.Drawing.Point(48, 353)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 19)
        Me.Label8.TabIndex = 157
        Me.Label8.Text = "Initial Gamma"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.White
        Me.TextBox1.Location = New System.Drawing.Point(427, 351)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(58, 23)
        Me.TextBox1.TabIndex = 168
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Futura PT Book", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.Control
        Me.Label9.Location = New System.Drawing.Point(270, 353)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(135, 19)
        Me.Label9.TabIndex = 167
        Me.Label9.Text = "Correct Bar Press (Hg)"
        '
        'txtCertAltitude
        '
        Me.txtCertAltitude.BackColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.txtCertAltitude.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCertAltitude.ForeColor = System.Drawing.Color.White
        Me.txtCertAltitude.Location = New System.Drawing.Point(427, 321)
        Me.txtCertAltitude.Multiline = True
        Me.txtCertAltitude.Name = "txtCertAltitude"
        Me.txtCertAltitude.Size = New System.Drawing.Size(58, 23)
        Me.txtCertAltitude.TabIndex = 166
        Me.txtCertAltitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label10.Font = New System.Drawing.Font("Futura PT Book", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.Control
        Me.Label10.Location = New System.Drawing.Point(270, 323)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 19)
        Me.Label10.TabIndex = 165
        Me.Label10.Text = "Altitude (ft)"
        '
        'txtCertHumidity
        '
        Me.txtCertHumidity.BackColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.txtCertHumidity.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCertHumidity.ForeColor = System.Drawing.Color.White
        Me.txtCertHumidity.Location = New System.Drawing.Point(427, 291)
        Me.txtCertHumidity.Multiline = True
        Me.txtCertHumidity.Name = "txtCertHumidity"
        Me.txtCertHumidity.Size = New System.Drawing.Size(58, 23)
        Me.txtCertHumidity.TabIndex = 164
        Me.txtCertHumidity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label11.Font = New System.Drawing.Font("Futura PT Book", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.Control
        Me.Label11.Location = New System.Drawing.Point(270, 293)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(122, 19)
        Me.Label11.TabIndex = 163
        Me.Label11.Text = "Relative Humidity %"
        '
        'txtCertAmbTemp
        '
        Me.txtCertAmbTemp.BackColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.txtCertAmbTemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCertAmbTemp.ForeColor = System.Drawing.Color.White
        Me.txtCertAmbTemp.Location = New System.Drawing.Point(427, 261)
        Me.txtCertAmbTemp.Multiline = True
        Me.txtCertAmbTemp.Name = "txtCertAmbTemp"
        Me.txtCertAmbTemp.Size = New System.Drawing.Size(58, 23)
        Me.txtCertAmbTemp.TabIndex = 162
        Me.txtCertAmbTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label12.Font = New System.Drawing.Font("Futura PT Book", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.Control
        Me.Label12.Location = New System.Drawing.Point(270, 263)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(129, 19)
        Me.Label12.TabIndex = 161
        Me.Label12.Text = "Ambient Temperature"
        '
        'txtCertBarPressure
        '
        Me.txtCertBarPressure.BackColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.txtCertBarPressure.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCertBarPressure.ForeColor = System.Drawing.Color.White
        Me.txtCertBarPressure.Location = New System.Drawing.Point(427, 231)
        Me.txtCertBarPressure.Multiline = True
        Me.txtCertBarPressure.Name = "txtCertBarPressure"
        Me.txtCertBarPressure.Size = New System.Drawing.Size(58, 23)
        Me.txtCertBarPressure.TabIndex = 160
        Me.txtCertBarPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label13.Font = New System.Drawing.Font("Futura PT Book", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.Control
        Me.Label13.Location = New System.Drawing.Point(270, 233)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(149, 19)
        Me.Label13.TabIndex = 159
        Me.Label13.Text = "Barometric Pressure (Hg)"
        '
        'Certification
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1064, 729)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtCertAltitude)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtCertHumidity)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtCertAmbTemp)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtCertBarPressure)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtInitialGamma)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtCertDGMSerial)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtCertDGMModel)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtCertUUTSerial)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCertUUTModel)
        Me.Controls.Add(Me.lblModel)
        Me.Controls.Add(Me.messagetxtbox)
        Me.Controls.Add(Me.Panel1)
        Me.ForeColor = System.Drawing.Color.White
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1080, 768)
        Me.Name = "Certification"
        Me.Text = "Certification"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents teststatuslabel1 As Label
    Friend WithEvents teststatuslabel2 As Label
    Friend WithEvents messagetxtbox As TextBox
    Friend WithEvents lblModel As Label
    Friend WithEvents txtCertUUTModel As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCertUUTSerial As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtCertDGMSerial As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtCertDGMModel As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtInitialGamma As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtCertAltitude As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtCertHumidity As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtCertAmbTemp As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtCertBarPressure As TextBox
    Friend WithEvents Label13 As Label
End Class
