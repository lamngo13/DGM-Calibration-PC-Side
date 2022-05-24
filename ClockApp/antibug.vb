Public Class antibug
    Public checksum As Integer
    Public backit As Integer = 9999

    Public currstr As String
    Public stritt As Integer = 1
    Public isgood As Boolean = True
    Public calchecksum As Integer
    '//output: label, pressure, ambient temp, pretend ref meter temp, ambient humidity, pulse count, checksum
    Public inputlabel As String = ""

    Public inputpressure As String = ""
    Public intpressure As Integer
    Public doublepressure As Double

    Public inputambtemp As String = ""
    Public intambtemp As Integer
    Public doubleambtemp As Double

    Public inputreftemp As String = ""
    Public intreftemp As Integer
    Public doublereftemp As Double

    Public inputambhum As String = ""
    Public intambhum As Integer
    Public doubleambhum As Double

    Public inputpulsecount As String = ""
    Public intpulsecount As Integer

    Public inputchecksum As String = ""
    Public intchecksum As Integer
    Public trimmedcrc As String = ""
    Public inttrimmedcrc As Integer

    'Public inputtruechecksum As String = ""
    'Public inttruechecksum As Integer


    Public ourcs As Integer
    Public ourcsitr As Integer

    Public gooddata As Boolean = True
    Public refportgood As Boolean = False

    'dim numbers = New Integer()

    Dim crc_table = New UInteger() {&H0, &H1021, &H2042, &H3063, &H4084, &H50A5, &H60C6, &H70E7, &H8108, &H9129, &HA14A, &HB16B,
&HC18C, &HD1AD, &HE1CE, &HF1EF, &H1231, &H210, &H3273, &H2252, &H52B5, &H4294, &H72F7, &H62D6,
&H9339, &H8318, &HB37B, &HA35A, &HD3BD, &HC39C, &HF3FF, &HE3DE, &H2462, &H3443, &H420, &H1401,
&H64E6, &H74C7, &H44A4, &H5485, &HA56A, &HB54B, &H8528, &H9509, &HE5EE, &HF5CF, &HC5AC, &HD58D,
&H3653, &H2672, &H1611, &H630, &H76D7, &H66F6, &H5695, &H46B4, &HB75B, &HA77A, &H9719, &H8738,
&HF7DF, &HE7FE, &HD79D, &HC7BC, &H48C4, &H58E5, &H6886, &H78A7, &H840, &H1861, &H2802, &H3823,
&HC9CC, &HD9ED, &HE98E, &HF9AF, &H8948, &H9969, &HA90A, &HB92B, &H5AF5, &H4AD4, &H7AB7, &H6A96,
&H1A71, &HA50, &H3A33, &H2A12, &HDBFD, &HCBDC, &HFBBF, &HEB9E, &H9B79, &H8B58, &HBB3B, &HAB1A,
&H6CA6, &H7C87, &H4CE4, &H5CC5, &H2C22, &H3C03, &HC60, &H1C41, &HEDAE, &HFD8F, &HCDEC, &HDDCD,
&HAD2A, &HBD0B, &H8D68, &H9D49, &H7E97, &H6EB6, &H5ED5, &H4EF4, &H3E13, &H2E32, &H1E51, &HE70,
&HFF9F, &HEFBE, &HDFDD, &HCFFC, &HBF1B, &HAF3A, &H9F59, &H8F78, &H9188, &H81A9, &HB1CA, &HA1EB,
&HD10C, &HC12D, &HF14E, &HE16F, &H1080, &HA1, &H30C2, &H20E3, &H5004, &H4025, &H7046, &H6067,
&H83B9, &H9398, &HA3FB, &HB3DA, &HC33D, &HD31C, &HE37F, &HF35E, &H2B1, &H1290, &H22F3, &H32D2,
&H4235, &H5214, &H6277, &H7256, &HB5EA, &HA5CB, &H95A8, &H8589, &HF56E, &HE54F, &HD52C, &HC50D,
&H34E2, &H24C3, &H14A0, &H481, &H7466, &H6447, &H5424, &H4405, &HA7DB, &HB7FA, &H8799, &H97B8,
&HE75F, &HF77E, &HC71D, &HD73C, &H26D3, &H36F2, &H691, &H16B0, &H6657, &H7676, &H4615, &H5634,
&HD94C, &HC96D, &HF90E, &HE92F, &H99C8, &H89E9, &HB98A, &HA9AB, &H5844, &H4865, &H7806, &H6827,
&H18C0, &H8E1, &H3882, &H28A3, &HCB7D, &HDB5C, &HEB3F, &HFB1E, &H8BF9, &H9BD8, &HABBB, &HBB9A,
&H4A75, &H5A54, &H6A37, &H7A16, &HAF1, &H1AD0, &H2AB3, &H3A92, &HFD2E, &HED0F, &HDD6C, &HCD4D,
&HBDAA, &HAD8B, &H9DE8, &H8DC9, &H7C26, &H6C07, &H5C64, &H4C45, &H3CA2, &H2C83, &H1CE0, &HCC1,
&HEF1F, &HFF3E, &HCF5D, &HDF7C, &HAF9B, &HBFBA, &H8FD9, &H9FF8, &H6E17, &H7E36, &H4E55, &H5E74,
&H2E93, &H3EB2, &HED1, &H1EF0}


    Public Function scanone() As String
        'test check this way??
        Dim go = True
        Dim theString = ""

        While (go)

            'INDEX OUTTA BONDS ERROR HERE BELOW ! gotta fix
            'If (currstr.Chars(stritt) = ",") Then
            If (Mid(currstr, stritt, 1) = ",") Then
                go = False
            Else
                'append to string
                'theString += currstr.Chars(stritt).ToString()
                theString += Mid(currstr, stritt, 1)
                stritt += 1
            End If

        End While
        'maybe extra iteration to account for space??
        stritt += 1
        Return theString

    End Function
    Public Function firstParse() As String
        Dim Main As New Main
        Dim go = True
        Dim theString = ""
        'diff here is discard if first char is not >
        If (Mid(currstr, 1, 1) <> ">") Then
            isgood = False
            Return inputlabel
        End If
        While (go)

            'INDEX OUTTA BONDS ERROR HERE BELOW ! gotta fix
            'If (currstr.Chars(stritt) = ",") Then
            If (Mid(currstr, stritt, 1) = ",") Then
                go = False
            Else
                'append to string
                'theString += currstr.Chars(stritt).ToString()
                theString += Mid(currstr, stritt, 1)
                stritt += 1
            End If

        End While
        'maybe extra iteration to account for space??
        stritt += 1
        Return theString
    End Function

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles lblClock.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Static ioStr As String = ""

        lblClock.Text = TimeString ' 24 hour time
        If (SerialPort1.IsOpen) Then

            If (SerialPort1.ReadBufferSize > 0) Then
                'start parsing stuff
                ioStr += Trim(SerialPort1.ReadExisting())
                If InStr(ioStr, Chr(10)) Then
                    'Returns an integer specifying the start position of the first occurrence of one string within another. 
                    'The Integer Is a one-based index If a match Is found. If no match Is found, the function returns zero.
                    stritt = 1
                    currstr = ioStr
                    ioStr = ""
                Else
                    'currstr = ""
                End If


                'currstr = Trim(SerialPort1.ReadExisting())


                'first portion
                stritt = 1
                If Len(currstr) > 10 Then
                    'change this one off condition

                    'diff condition for the first bc must have > else discard
                    '//output: label, pressure, ambient temp, pretend ref meter temp, ambient humidity, pulse count, checksum
                    'btw ONLY CONNECT IF LABEL HAS Cal-DGM
                    inputlabel = scanone()

                    inputpressure = scanone()
                    intpressure = Val(inputpressure)
                    doublepressure = (intpressure / 100)

                    inputambtemp = scanone()
                    intambtemp = Val(inputpressure)
                    doubleambtemp = (intambtemp / 100)

                    inputreftemp = scanone()
                    intreftemp = Val(inputreftemp)
                    doublereftemp = (intreftemp / 10)

                    inputambhum = scanone()
                    intambhum = Val(inputambhum)
                    doubleambhum = (intambhum / 10)


                    inputpulsecount = scanone()
                    intpulsecount = Val(inputpulsecount)
                    'TEST ADD TO MAIN FORM
                    Main.refpulselabel1.Text = inputpulsecount

                    inputchecksum = scanone()
                    intchecksum = Val(inputchecksum)
                    trimmedcrc = inputchecksum.Replace("|", "")
                    inttrimmedcrc = Val(trimmedcrc)

                End If
                'verify checksum

                'CRC TIME
                Dim iAccum As UInt16 = &HFFFF
                'gooddata WILL EQUAL FALSE IF IACCUM DOESNT MATCH UP
                If (currstr.Length <> vbNullString) Then
                    For i As Integer = 0 To (InStr(currstr, inputchecksum) - 1)
                        iAccum = (((iAccum And &HFF) << 8) Xor (crc_table(((iAccum >> 8) Xor Asc(currstr(i))) And &HFF)))
                    Next ' end of for loop
                End If

                If (Not iAccum = Val(inputchecksum)) Then
                    gooddata = False
                End If


                'ONLY UPDATE VALS IF GOOD
                'If (gooddata) Then
                'do this stuff below
                'MAKE THIS CONDITIONAL TO GOODDATA
                lblsp.Text = currstr
                lblfirst.Text = InStr(currstr, inputchecksum).ToString()
                lblsecond.Text = inputchecksum 'inputchecksum
                lblthird.Text = iAccum   'iAccum.ToString()
                crcdifflabel.Text = "our crc vs input crc: " + (iAccum - Val(inttrimmedcrc)).ToString()
            End If

            'end of tick!
        End If
    End Sub

    Private Sub dp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'what does this do lol
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles openCom.Click
        Dim comgo As Boolean = True
        Dim tempcomport As Integer = 1
        Dim comstr As String = "COM"
        If (Not refportgood) Then
            While (comgo)
                'comstr += CStr(tempcomport)
                Try
                    SerialPort1.PortName = comstr + CStr(tempcomport)
                    SerialPort1.Open()
                    'AFTER U OPEN THE COMPORT SCAN FOR Cal-DGM
                    'maybe bad THIS ISNT WORKING MAN
                    Dim fooinputstr As String
                    Dim zgo As Boolean = True
                    Dim giveup As Integer = 0
                    While (zgo)
                        fooinputstr = SerialPort1.ReadExisting()
                        If (fooinputstr.Length > 1) Then
                            zgo = False
                        End If
                        'give up will end the while loop if the com port goes a long time without transmitting anything
                        giveup += 1
                        Threading.Thread.Sleep(500) ' LETS GO THIS WORKS!!!!! Just need to tweak it a bit
                        'LIERALLY 10 ms WORKS BUT 9 DOESNT
                        'so im going to use 15 just to be safe
                        If (giveup > 5) Then
                            zgo = False
                        End If
                    End While
                    'fooinputstr = SerialPort1.ReadExisting()
                    If (InStr(1, fooinputstr, "Cal-DGM", 1)) Then 'PROBLEM HERE (I think it's because the serial port sends junk before an actual thing?? Or idk)
                        'THIS WORKS IN DEBUGGING BUT I SUSPECT ITS A TIMING ISSUE
                        'ID SAY SLEEP FOR A BIT IFF A COM PORT CAN BE OPENED
                        refportgood = True
                        comgo = False
                    End If
                    'comgo = False
                    'serial port name??
                Catch ex As Exception
                    tempcomport += 1
                End Try
            End While
        End If

    End Sub

    Private Sub antibugexitbutton_Click(sender As Object, e As EventArgs) Handles antibugexitbutton.Click
        Me.Close()
    End Sub
End Class
