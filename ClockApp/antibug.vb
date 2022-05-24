Public Class antibug

    Dim Main As New Main
    'Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    '    Static ioStr As String = ""

    '    lblClock.Text = TimeString ' 24 hour time
    '    If (SerialPort1.IsOpen) Then

    '        If (SerialPort1.ReadBufferSize > 0) Then
    '            'start parsing stuff
    '            ioStr += Trim(SerialPort1.ReadExisting())
    '            If InStr(ioStr, Chr(10)) Then
    '                'Returns an integer specifying the start position of the first occurrence of one string within another. 
    '                'The Integer Is a one-based index If a match Is found. If no match Is found, the function returns zero.
    '                Main.stritt = 1
    '                Main.currstr = ioStr
    '                ioStr = ""
    '            Else
    '                'currstr = ""
    '            End If


    '            'currstr = Trim(SerialPort1.ReadExisting())


    '            'first portion
    '            Main.stritt = 1
    '            If Len(Main.currstr) > 10 Then
    '                'change this one off condition

    '                'diff condition for the first bc must have > else discard
    '                '//output: label, pressure, ambient temp, pretend ref meter temp, ambient humidity, pulse count, checksum
    '                'btw ONLY CONNECT IF LABEL HAS Cal-DGM
    '                Main.inputlabel = Main.scanone()

    '                Main.inputpressure = Main.scanone()
    '                Main.intpressure = Val(Main.inputpressure)
    '                Main.doublepressure = (Main.intpressure / 100)

    '                Main.inputambtemp = Main.scanone()
    '                Main.intambtemp = Val(Main.inputpressure)
    '                Main.doubleambtemp = (Main.intambtemp / 100)

    '                Main.inputreftemp = Main.scanone()
    '                Main.intreftemp = Val(Main.inputreftemp)
    '                Main.doublereftemp = (Main.intreftemp / 10)

    '                Main.inputambhum = Main.scanone()
    '                Main.intambhum = Val(Main.inputambhum)
    '                Main.doubleambhum = (Main.intambhum / 10)


    '                Main.inputpulsecount = Main.scanone()
    '                Main.intpulsecount = Val(Main.inputpulsecount)
    '                'TEST ADD TO MAIN FORM
    '                Main.refpulselabel1.Text = Main.inputpulsecount

    '                Main.inputchecksum = Main.scanone()
    '                Main.intchecksum = Val(Main.inputchecksum)
    '                Main.trimmedcrc = Main.inputchecksum.Replace("|", "")
    '                Main.inttrimmedcrc = Val(Main.trimmedcrc)

    '            End If
    '            'verify checksum

    '            'CRC TIME
    '            Dim iAccum As UInt16 = &HFFFF
    '            'gooddata WILL EQUAL FALSE IF IACCUM DOESNT MATCH UP
    '            If (Main.currstr.Length <> vbNullString) Then
    '                For i As Integer = 0 To (InStr(Main.currstr, Main.inputchecksum) - 1)
    '                    iAccum = (((iAccum And &HFF) << 8) Xor (Main.crc_table(((iAccum >> 8) Xor Asc(Main.currstr(i))) And &HFF)))
    '                Next ' end of for loop
    '            End If

    '            If (Not iAccum = Val(Main.inputchecksum)) Then
    '                Main.gooddata = False
    '            End If


    '            'ONLY UPDATE VALS IF GOOD
    '            'If (gooddata) Then
    '            'do this stuff below
    '            'MAKE THIS CONDITIONAL TO GOODDATA
    '            lblsp.Text = Main.currstr
    '            lblfirst.Text = InStr(Main.currstr, Main.inputchecksum).ToString()
    '            lblsecond.Text = Main.inputchecksum 'inputchecksum
    '            lblthird.Text = iAccum   'iAccum.ToString()
    '            crcdifflabel.Text = "our crc vs input crc: " + (iAccum - Val(Main.inttrimmedcrc)).ToString()
    '        End If

    '        'end of tick!
    '    End If
    'End Sub

    Private Sub antibugexitbutton_Click(sender As Object, e As EventArgs) Handles antibugexitbutton.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblsp.Text = Gs_str
    End Sub

    Private Sub antibug_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
