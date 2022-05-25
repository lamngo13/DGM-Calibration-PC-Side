﻿Public Class Main
    Const NUM_OF_ROWS As Integer = 5
    'Const REF_MEMBERS_MAX As Integer = 25

    Const REF_INPUT_LABEL As Integer = 1
    Const REF_INPUT_PRESSURE As Integer = 2
    Const REF_AMB_TEMP As Integer = 3
    Const REF_METER_TEMP As Integer = 4
    Const REF_AMB_HUM As Integer = 5
    Const REF_PULSECOUNT As Integer = 6
    Const REF_CHECKSUM As Integer = 7
    Const REF_MAX_MEMBERS = 8

    Dim Gs_str As String = "foo"
    Dim intpulsecount As Integer
    '''''''''''''' Dim testpulses = New Integer() {1, 2, 3, 4, 5, 6, 7}
    Dim checksum As Integer
    Dim backit As Integer = 9999


    'Dim Gs_currstr As String
    Dim debugstr As String
    Dim stritt As Integer = 1
    Dim isgood As Boolean = True
    Dim calchecksum As Integer
    '//output: label, pressure, ambient temp, pretend ref meter temp, ambient humidity, pulse count, checksum
    Dim inputlabel As String = ""

    Dim inputpressure As String = ""
    Dim intpressure As Integer
    Dim doublepressure As Double

    Dim inputambtemp As String = ""
    Dim intambtemp As Integer
    Dim doubleambtemp As Double

    Dim inputreftemp As String = ""
    Dim intreftemp As Integer
    Dim doublereftemp As Double

    Dim inputambhum As String = ""
    Dim intambhum As Integer
    Dim doubleambhum As Double

    Dim inputpulsecount As String = ""
    'Dim intpulsecount As Integer

    'Dim inputchecksum As String = ""
    Dim intchecksum As Integer
    Dim trimmedcrc As String = ""
    'Dim inttrimmedcrc As Integer

    'Dim inputtruechecksum As String = ""
    'Dim inttruechecksum As Integer

    'Dim testpulses = New Integer() {0, 0, 0, 0, 0, 0}
    Dim testendvolume = New Integer() {0, 0, 0, 0, 0, 0, 0}
    Dim testtimers = New Double() {0, 0, 0, 0, 0, 0, 0}  ' DOUBLE
    Dim testwarmups = New Integer() {0, 0, 0, 0, 0, 0, 0}
    Dim warmuptimes = New Integer() {0, 0, 0, 0, 0, 0, 0}
    Dim testusrflowrate = New Integer() {0, 0, 0, 0, 0, 0, 0}
    Dim warmuppulses = New Integer() {0, 0, 0, 0, 0, 0, 0}
    Dim testreftemp = New Double() {0, 0, 0, 0, 0, 0, 0}  'DOUBLE
    Dim currenttest As Integer = 1
    Dim duringwarmup As Boolean = False
    Dim endtestnum As Integer = 6

    Dim bigtimer As Double = 0.0

    Dim testover As Boolean = False
    Dim testongoing As Boolean = False
    Dim warmuptimer As Double



    Dim ourcs As Integer
    Dim ourcsitr As Integer
    Dim refcrcstr As String
    Dim refcrcint As Integer




    'inputlabel, inputpressure, doublepressure, inputambtemp, inputreftemp, inputambhum, 
    Dim s_ref_in(REF_MAX_MEMBERS) As String
    Dim zrefinputlabel As String
    Dim zrefinputpressure As String
    Dim zrefinputambtemp As String
    Dim zrefinputreftemp As String
    Dim zrefinputambhum As String

    Dim gooddata As Boolean = True
    Dim refportgood As Boolean = False

    Public Function scanone() As String
        'test check this way??
        Dim go = True
        Dim theString = ""

        While (go)

            'INDEX OUTTA BONDS ERROR HERE BELOW ! gotta fix
            'If (Gs_currstr.Chars(stritt) = ",") Then
            If (Mid(Gs_currstr, stritt, 1) = ",") Then
                go = False
            Else
                'append to string
                'theString += Gs_currstr.Chars(stritt).ToString()
                theString += Mid(Gs_currstr, stritt, 1)
                stritt += 1
            End If

        End While
        'maybe extra iteration to account for space??
        stritt += 1
        Return theString

    End Function

    Public Sub goodParse()
        Dim zindex As Integer = 1
        Dim tempStr As String = ""
        Dim i As Integer
        For i = 1 To Len(Gs_currstr)
            If (Mid(Gs_currstr, i, 1) <> ",") Then
                tempStr &= Mid(Gs_currstr, i, 1)
            Else
                s_ref_in(zindex) = tempStr
                zindex += 1
                tempStr = ""
                If (zindex = REF_MAX_MEMBERS) Then
                    Exit For
                End If
            End If
        Next
    End Sub

    Public Sub refUpdateVals()
        inputlabel = s_ref_in(REF_INPUT_LABEL)
        intpressure = CInt(s_ref_in(REF_INPUT_PRESSURE))
        inputambtemp = CInt(s_ref_in(REF_AMB_TEMP))
        inputreftemp = CInt(s_ref_in(REF_METER_TEMP))
        inputambhum = CInt(s_ref_in(REF_AMB_HUM))
        intpulsecount = CInt(s_ref_in(REF_PULSECOUNT))
        Gs_inputchecksum = s_ref_in(REF_CHECKSUM)
    End Sub

    Public Function firstParse() As String
        Dim Main As New Main
        Dim go = True
        Dim theString = ""
        'diff here is discard if first char is not >
        If (Mid(Gs_currstr, 1, 1) <> ">") Then
            isgood = False
            Return inputlabel
        End If
        While (go)

            'INDEX OUTTA BONDS ERROR HERE BELOW ! gotta fix
            'If (Gs_currstr.Chars(stritt) = ",") Then
            If (Mid(Gs_currstr, stritt, 1) = ",") Then
                go = False
            Else
                'append to string
                'theString += Gs_currstr.Chars(stritt).ToString()
                theString += Mid(Gs_currstr, stritt, 1)
                stritt += 1
            End If

        End While
        'maybe extra iteration to account for space??
        stritt += 1
        Return theString
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Main_Timer.Tick
        Static ioStr As String = ""


        Timer_Old()
        ioStr = ""
        Gs_currstr = ""
        mainclocklbl.Text = TimeString ' 24 hour time
        If (mainserialport1.IsOpen) Then

            If (mainserialport1.ReadBufferSize > 0) Then
                antibug8.Text = "CONNECTED YAY"
                'start parsing stuff
                ioStr += Trim(mainserialport1.ReadExisting())
                Dim bruh2 = ioStr
                If (InStr(ioStr, Chr(10)) And ioStr <> "" And ioStr.Length > 15) Then

                    Gs_currstr = ioStr
                    goodParse()  'NEWLY ADDED
                    'ioStr = ""
                    Gs_str = Gs_currstr  ' this is for debugging
                    Dim tempinstr = Gs_str
                    Dim startrefcrc As Integer = InStr(tempinstr, "|")
                    Dim endrefcrc As Integer = InStr(startrefcrc, tempinstr, ",")
                    Dim tcrc As String = Mid(tempinstr, startrefcrc + 1, endrefcrc - startrefcrc)
                    refcrcstr = tcrc
                    refcrcint = CInt(refcrcstr)
                    'Dim aa As String = scanone()
                    'Dim ab As String = scanone()
                    'Dim ac As String = scanone()
                    'Dim ad As String = scanone()
                    'Dim ae As String = scanone()
                    'Dim af As String = scanone()
                    'Dim Gs_inputchecksum As String = scanone()

                    ''looking for the 7th one

                    iAccum = &HFFFF
                    'gooddata WILL EQUAL FALSE IF IACCUM DOESNT MATCH UP (Gs_currstr, Gs_inputchecksum) - 1)
                    Dim ii As Integer
                    If (tempinstr <> vbNullString) Then
                        For i As Integer = 0 To (startrefcrc - 2) '(InStr(tempinstr, Gs_inputchecksum) - 1)
                            ii = i
                            iAccum = (((iAccum And &HFF) << 8) Xor (crc_table(((iAccum >> 8) Xor Asc(tempinstr(i))) And &HFF)))
                        Next ' end of for loop
                    End If

                    If (iAccum = refcrcint) Then
                        refUpdateVals()
                    End If
                End If
                'Returns an integer specifying the start position of the first occurrence of one string within another. 
                'The Integer Is a one-based index If a match Is found. If no match Is found, the function returns zero.
                ' 7 members
                'stritt = 1
                '''''PASTE AFTER THIS LINE HEREEEEEEEEEEEEEE

                'first portion
                'stritt = 1
                'If Len(Gs_currstr) > 10 Then
                '    'change this one off condition

                '    'diff condition for the first bc must have > else discard
                '    '//output: label, pressure, ambient temp, pretend ref meter temp, ambient humidity, pulse count, checksum
                '    'btw ONLY CONNECT IF LABEL HAS Cal-DGM
                '    inputlabel = scanone()

                '    inputpressure = scanone()
                '    intpressure = Val(inputpressure)
                '    doublepressure = (intpressure / 100)

                '    inputambtemp = scanone()
                '    intambtemp = Val(inputpressure)
                '    doubleambtemp = (intambtemp / 100)

                '    inputreftemp = scanone()
                '    intreftemp = Val(inputreftemp)
                '    doublereftemp = (intreftemp / 10)

                '    inputambhum = scanone()
                '    intambhum = Val(inputambhum)
                '    doubleambhum = (intambhum / 10)


                '    inputpulsecount = scanone()
                '    intpulsecount = CInt(inputpulsecount)


                '    Gi_BL_Debug = CInt(inputpulsecount)




                '    Gs_inputchecksum = scanone()
                '    intchecksum = Val(Gs_inputchecksum)
                '    trimmedcrc = Gs_inputchecksum.Replace("|", "")
                '    Gi_inttrimmedcrc = Val(trimmedcrc)


                'End If
                'verify checksum

                'CRC TIME
                'iAccum = &HFFFF
                ''gooddata WILL EQUAL FALSE IF IACCUM DOESNT MATCH UP
                'If (Gs_currstr.Length <> vbNullString) Then
                '    For i As Integer = 0 To (InStr(Gs_currstr, Gs_inputchecksum) - 1)
                '        iAccum = (((iAccum And &HFF) << 8) Xor (crc_table(((iAccum >> 8) Xor Asc(Gs_currstr(i))) And &HFF)))
                '    Next ' end of for loop
                'End If

                'If (Not iAccum = Val(Gs_inputchecksum)) Then
                '    gooddata = False
                'End If

                'If (gooddata) Then
                '    'ONLY UPDATE VALS IF DATA IS GOOD
                'End If

            End If

        End If
        'NEW STUFF bruh

        '''''''''''''''''''''''''''''''''''''''''''''''''''refpulselabel(currenttest).Text = CStr(testpulses(currenttest))

        'rrefpulselabel(currenttest).Text = intpulsecount


        antibug5.Text = "curr test pulses: " + testpulses(currenttest).ToString() ' THIS DOES NOT FLASH
        antibug7.Text = "current warmup pulses: " + warmuppulses(currenttest).ToString()

    End Sub

    Private Sub dp_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        flowratetxtbox = ControlArrayUtils.getControlArray(Me, "flowratetxtbox", NUM_OF_ROWS)
        endvoltxtbox = ControlArrayUtils.getControlArray(Me, "endvoltxtbox", NUM_OF_ROWS)
        warmuptxtbox = ControlArrayUtils.getControlArray(Me, "warmuptxtbox", NUM_OF_ROWS)
        refpulselabel = ControlArrayUtils.getControlArray(Me, "refpulselabel", NUM_OF_ROWS)
        testpulselabel = ControlArrayUtils.getControlArray(Me, "testpulselabel", NUM_OF_ROWS)
        reftemplabel = ControlArrayUtils.getControlArray(Me, "reftemplabel", NUM_OF_ROWS)
        testtimerlabel = ControlArrayUtils.getControlArray(Me, "testtimerlabel", NUM_OF_ROWS)

        'flowratetxtbox(1).Text = "999"
        'flowratetxtbox(2).Text = "111"
        'endvoltxtbox(1).Text = "goodski"
        'warmuptxtbox(1).Text = "goodski"
        'refpulselabel(1).Text = "bruh"
        'testpulselabel(1).Text = "bruh"
        'reftemplabel(1).Text = "bruh amchine"

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles connectbutton.Click
        Dim comgo As Boolean = True
        Dim tempcomport As Integer = 1
        Dim comstr As String = "COM"
        If (Not refportgood) Then
            While (comgo)
                'comstr += CStr(tempcomport)
                Try
                    mainserialport1.PortName = comstr + CStr(tempcomport)
                    mainserialport1.Open()
                    'AFTER U OPEN THE COMPORT SCAN FOR Cal-DGM
                    'maybe bad THIS ISNT WORKING MAN
                    Dim fooinputstr As String
                    Dim zgo As Boolean = True
                    Dim giveup As Integer = 0
                    While (zgo)
                        fooinputstr = mainserialport1.ReadExisting()
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
    Public Function send_error()
        Dim ErrorForm As New ErrorForm
        ErrorForm.StartPosition = FormStartPosition.CenterScreen
        ErrorForm.ShowDialog()
    End Function
    Private Sub antibugbutton_Click(sender As Object, e As EventArgs) Handles antibugbutton.Click
        Dim antibug As New antibug
        antibug.StartPosition = FormStartPosition.CenterScreen
        antibug.ShowDialog()

    End Sub

    Private Sub ConfigureButton_Click(sender As Object, e As EventArgs) Handles configurebutton.Click
        Dim configure As New Configure
        configure.StartPosition = FormStartPosition.CenterScreen
        configure.ShowDialog()
    End Sub

    Private Sub Timer_Old()
        'this happens super fast
        'handle real timer stuff after start is pressed
        'start ticking the warmuptimer
        Dim debug1 As Integer = testpulses(currenttest)
        Dim debug2 As Integer = testendvolume(currenttest)
        Dim debug3 As Integer = currenttest

        'debugg
        antibug1.Text = "big timer: " & CStr(bigtimer)
        antibug2.Text = "curr test timer: " + testtimers(currenttest).ToString()
        antibug3.Text = "total pulse count: " + intpulsecount.ToString()
        antibug4.Text = "current test: " + currenttest.ToString()
        'antibug5.Text = "testonging: " + testongoing.ToString()
        antibug6.Text = "during warmup: " + duringwarmup.ToString()
        'antibug7.Text = "current warmup pulses: " + warmuptimes(currenttest).ToString()

        refpulselabel(currenttest).Text = CStr(testpulses(currenttest))  ' this works
        testtimerlabel(currenttest).Text = CStr(testtimers(currenttest))
        reftemplabel(currenttest).Text = CStr(testreftemp(currenttest))


        If (testongoing) Then
            'ensure correct string:
            teststatuslabel2.Text = "Running Test: " + CStr(currenttest)
            'END TEST IF NO MORE TEST SPECIFIED
            If (currenttest = endtestnum) Then
                testongoing = False
                testover = True
                teststatuslabel2.Text = "Test Over"
            End If
        End If

        If (testongoing) Then

            bigtimer += 0.1

            'check for end of warmup
            If (warmuptimer > Val(warmuptxtbox(currenttest).Text)) Then
                duringwarmup = False
            End If

            'increment warmup timer(s)
            If (duringwarmup) Then
                warmuptimer += 0.1
                warmuptimes(currenttest) += 0.1
                warmuppulses(currenttest) = intpulsecount
            End If

            'USE VALS FROM INPUT
            If (Not duringwarmup) Then
                testtimers(currenttest) += 0.1
                'testpulses(currenttest) = intpulsecount - warmuptimes(currenttest) ' THIS SHOULD BE warmuppulses(currenttest)
                testpulses(currenttest) = intpulsecount - warmuppulses(currenttest)
                testreftemp(currenttest) = conversions.cIntToDouble(inputreftemp)
            End If

            'check for end condition off of pulses/volume
            'go to next test
            debug1 = testpulses(currenttest)
            debug2 = CInt(endvoltxtbox(currenttest).Text)
            If (testpulses(currenttest) > Val(endvoltxtbox(currenttest).Text)) Then
                duringwarmup = True
                currenttest += 1
                warmuptimer = 0  'reset warmup timer
            End If

            'end test ongoing
        End If


        'to process after test
        If (testover) Then
            'process the vals lmao
        End If
    End Sub


    Private Sub flowratetxtbox1_TextChanged(sender As Object, e As EventArgs) Handles flowratetxtbox1.TextChanged
        'testusrflowrate(1) = flowratetxtbox1.Text
    End Sub

    Private Sub endvoltxtbox1_TextChanged(sender As Object, e As EventArgs) Handles endvoltxtbox1.TextChanged
        'testusrendvol(1) = Val(endvoltxtbox1.Text)
    End Sub

    Private Sub warmuptxtbox1_TextChanged(sender As Object, e As EventArgs) Handles warmuptxtbox1.TextChanged
        'testusrwarmup(1) = Val(warmuptxtbox1.Text)
    End Sub

    Private Sub startbutton_Click(sender As Object, e As EventArgs) Handles startbutton.Click
        testongoing = True
        duringwarmup = True
        currenttest = 1
        'assign vals based on user input
        For startiterator = 1 To 6
            If (flowratetxtbox(startiterator).Text = "") Then
                endtestnum = startiterator
                startiterator = 7
            End If
            'find something that disables start button!!!
        Next
    End Sub

    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
        'If testongoing Then bigtimer += 0.1
    End Sub
End Class