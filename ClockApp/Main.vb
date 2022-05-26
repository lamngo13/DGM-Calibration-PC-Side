Public Class Main
    Const NUM_OF_ROWS As Integer = 5

    Const REF_INPUT_LABEL As Integer = 1
    Const REF_INPUT_PRESSURE As Integer = 2
    Const REF_AMB_TEMP As Integer = 3
    Const REF_METER_TEMP As Integer = 4
    Const REF_AMB_HUM As Integer = 5
    Const REF_PULSECOUNT As Integer = 6
    Const REF_CHECKSUM As Integer = 7
    Const REF_MAX_MEMBERS = 8

    Dim zDGM As String = "notyet"
    Dim Gs_str As String = "foo"
    Dim intpulsecount As Integer
    '''''''''''''' Dim testpulses = New Integer() {1, 2, 3, 4, 5, 6, 7}
    Dim checksum As Integer
    Dim backit As Integer = 9999

    Dim xdCurrStr As String = ""
    Dim xdIoStr As String = ""
    Dim xdParsedCheckStr As String = ""
    Dim xdParsedCheckInt As Integer
    Dim xdStartCheck As Integer
    Dim xdEndCheck As Integer
    Dim xdGoodData As Boolean
    Dim xdCalculatedCS As Integer

    Dim debugstr As String
    Dim stritt As Integer = 1
    Dim isgood As Boolean = True
    Dim calchecksum As Integer
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

    Dim testxdtemp = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
    Dim testxdvol = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
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

    Const XD_IN_VOL = 20
    Const XD_IN_TEMP = 10
    Const XD_IN_DATE = 1

    Dim xdInputVol As Double
    Dim xdInputTemp As Double
    Dim xdDate As String




    'inputlabel, inputpressure, doublepressure, inputambtemp, inputreftemp, inputambhum, 
    Dim s_ref_in(REF_MAX_MEMBERS) As String
    Dim zrefinputlabel As String
    Dim zrefinputpressure As String
    Dim zrefinputambtemp As String
    Dim zrefinputreftemp As String
    Dim zrefinputambhum As String

    Const XD_MAX_MEMBERS = 500
    Dim s_xd_in(XD_MAX_MEMBERS) As String
    Dim gooddata As Boolean = True
    Dim refportgood As Boolean = False
    Dim xdportgood As Boolean = False
    Dim bruh7 As Integer



    Public Sub goodParseRef()
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

    Public Sub goodParseXD()
        Dim zzindex As Integer = 1
        Dim xdTempInStr As String = ""
        Dim j As Integer
        For j = 1 To Len(xdCurrStr)
            If (Mid(xdCurrStr, j, 1) <> ",") Then
                xdTempInStr &= Mid(xdCurrStr, j, 1)
            Else
                s_xd_in(zzindex) = xdTempInStr   's_xd_in(zzindex) = xdTempInStr
                zzindex += 1
                xdTempInStr = ""
                If (zzindex = XD_MAX_MEMBERS) Then
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

    Public Sub xdUpdateVals()   'somewhere it's one off!!!!!
        Dim aaa = xdCurrStr  ' debugging
        xdInputVol = CDbl(s_xd_in(XD_IN_VOL + 1)) ' TODO PARSING IS OFFFFFFFF
        xdInputTemp = CDbl(s_xd_in(XD_IN_TEMP))  ' TODO CHANGE THSI
        xdDate = s_xd_in(XD_IN_DATE)
    End Sub



    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Main_Timer.Tick
        'PARSE REF METER
        Static ioStr As String = ""
        ioStr = ""
        Gs_currstr = ""
        mainclocklbl.Text = TimeString ' 24 hour time
        If (refport.IsOpen) Then

            If (refport.ReadBufferSize > 0) Then
                ioStr += Trim(refport.ReadExisting())

                If (InStr(ioStr, Chr(10)) And ioStr <> "" And ioStr.Length > 15) Then

                    Gs_currstr = ioStr
                    goodParseRef()
                    Gs_str = Gs_currstr  ' this is for debugging
                    Dim tempinstr = Gs_str

                    'read input crc
                    Dim startrefcrc As Integer = InStr(tempinstr, "|")
                    Dim endrefcrc As Integer = InStr(startrefcrc, tempinstr, ",")
                    Dim tcrc As String = Mid(tempinstr, startrefcrc + 1, endrefcrc - startrefcrc)
                    refcrcstr = tcrc
                    refcrcint = CInt(refcrcstr)

                    'check ur own local crc calculation
                    iAccum = &HFFFF
                    If (tempinstr <> vbNullString) Then
                        For i As Integer = 0 To (startrefcrc - 2) '(InStr(tempinstr, Gs_inputchecksum) - 1)
                            iAccum = (((iAccum And &HFF) << 8) Xor (crc_table(((iAccum >> 8) Xor Asc(tempinstr(i))) And &HFF)))
                        Next ' end of for loop
                    End If

                    'only update vals if crc is good
                    If (iAccum = refcrcint) Then
                        refUpdateVals()
                    End If

                End If
            End If
        End If

        ''START PARSING FROM DGM

        'start doing things with the read data ' ----------------------------------------
        Dim debug1 As Integer = testpulses(currenttest)
        Dim debug2 As Integer = testendvolume(currenttest)
        Dim debug3 As Integer = currenttest

        'debugg
        antibug1.Text = "big timer: " & CStr(bigtimer)
        antibug2.Text = "curr test timer: " + testtimers(currenttest).ToString()
        antibug3.Text = "total pulse count: " + intpulsecount.ToString()
        antibug4.Text = "current test: " + currenttest.ToString()
        antibug6.Text = "during warmup: " + duringwarmup.ToString()
        antibug5.Text = "curr test pulses: " + testpulses(currenttest).ToString()
        antibug7.Text = "current warmup pulses: " + warmuppulses(currenttest).ToString()

        ''START PARSING FROM DGM---------------------------------------------
        xdIoStr = ""
        xdCurrStr = ""
        If (xd502port.IsOpen) Then
            If (xd502port.ReadBufferSize > 0) Then
                'read data
                xdIoStr = xd502port.ReadExisting()

                If (InStr(xdIoStr, Chr(10)) And xdIoStr <> "" And xdIoStr.Length > 15) Then

                    xdCurrStr = xdIoStr
                    goodParseXD()
                    Dim xdTempInStr = xdCurrStr

                    'read checksum input
                    Dim lengthBetweenCSandNum As Integer = 6
                    xdStartCheck = (InStr(xdTempInStr, "!CS:, ")) + lengthBetweenCSandNum
                    xdEndCheck = InStr(xdStartCheck, xdTempInStr, ",")
                    xdParsedCheckStr = Mid(xdTempInStr, xdStartCheck, xdEndCheck - xdStartCheck)
                    xdParsedCheckInt = CInt(xdParsedCheckStr)

                    xdCalculatedCS = 0 ' reset just to be sure
                    'For j As Integer = 1 To (xdStartCheck - lengthBetweenCSandNum - 2) ' one before "!"

                    For j As Integer = 2 To InStr(xdTempInStr, "!")

                        xdCalculatedCS += Asc(Mid(xdTempInStr, j, 1))
                        If (xdCalculatedCS > 9999) Then
                            xdCalculatedCS -= 10000
                        End If
                    Next

                    xdCalculatedCS = 10000 - xdCalculatedCS

                    'update values if good
                    'what values do I need: volume, temp
                    If (xdCalculatedCS = xdParsedCheckInt) Then
                        xdUpdateVals()
                    End If

                End If
            End If

        End If


        'update labels with good values
        'ref
        refpulselabel(currenttest).Text = CStr(testpulses(currenttest))
        testtimerlabel(currenttest).Text = CStr(testtimers(currenttest))
        reftemplabel(currenttest).Text = CStr(testreftemp(currenttest))
        testpulselabel(currenttest).Text = CStr(testxdvol(currenttest))
        'UNCOMMENT AFTER U FIX PARSING
        'dgm
        testtemplabel(currenttest).Text = CStr(testxdtemp(currenttest))

        'dgm

        'If overall test is currently going
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

        'If overall test is currently going and end condition not met
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
                testpulses(currenttest) = intpulsecount - warmuppulses(currenttest)
                testreftemp(currenttest) = conversions.cIntToDouble(inputreftemp)
                'xd stuff
                'weird double stuff testxdtemp(currenttest) = conversions.cIntToDouble(xdInputTemp)
                testxdtemp(currenttest) = xdInputTemp
                testxdvol(currenttest) = xdInputVol
            End If

            'check for end condition off of pulses/volume
            'go to next test
            If (testpulses(currenttest) > Val(endvoltxtbox(currenttest).Text)) Then
                duringwarmup = True
                currenttest += 1 'goto next test
                warmuptimer = 0  'reset warmup timer
            End If
        End If


        'to process after test
        If (testover) Then
            'process the vals lmao like average them and move them to a spreadsheet
        End If

    End Sub

    Private Sub dp_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        flowratetxtbox = ControlArrayUtils.getControlArray(Me, "flowratetxtbox", NUM_OF_ROWS)
        endvoltxtbox = ControlArrayUtils.getControlArray(Me, "endvoltxtbox", NUM_OF_ROWS)
        warmuptxtbox = ControlArrayUtils.getControlArray(Me, "warmuptxtbox", NUM_OF_ROWS)
        refpulselabel = ControlArrayUtils.getControlArray(Me, "refpulselabel", NUM_OF_ROWS)
        testpulselabel = ControlArrayUtils.getControlArray(Me, "testpulselabel", NUM_OF_ROWS)
        reftemplabel = ControlArrayUtils.getControlArray(Me, "reftemplabel", NUM_OF_ROWS)
        testtimerlabel = ControlArrayUtils.getControlArray(Me, "testtimerlabel", NUM_OF_ROWS)
        testtemplabel = ControlArrayUtils.getControlArray(Me, "testtemplabel", NUM_OF_ROWS)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles connectbutton.Click
        Dim comgo As Boolean = True
        Dim xdcomgo As Boolean = True
        Dim tempcomport As Integer = 1
        Dim comstr As String = "COM"
        Dim refportsodontmesswith As Integer

        If (refport.IsOpen) Then
            refportgood = True
            comgo = False
        End If

        If (Not refportgood) Then
            'ref connection
            While (comgo)
                'comstr += CStr(tempcomport)
                Try
                    If (tempcomport > 300) Then
                        comgo = False
                    End If
                    refport.PortName = comstr + CStr(tempcomport)
                    refport.Open()
                    'AFTER U OPEN THE COMPORT SCAN FOR Cal-DGM
                    'maybe bad THIS ISNT WORKING MAN
                    Dim fooinputstr As String
                    Dim zgo As Boolean = True
                    Dim giveup As Integer = 0
                    While (zgo)
                        fooinputstr = refport.ReadExisting()
                        If (fooinputstr.Length > 1) Then
                            zgo = False
                        End If
                        'give up will end the while loop if the com port goes a long time without transmitting anything
                        giveup += 1
                        Threading.Thread.Sleep(200) ' LETS GO THIS WORKS!!!!! Just need to tweak it a bit
                        'LIERALLY 10 ms WORKS BUT 9 DOESNT
                        'so im going to use 15 just to be safe
                        If (giveup > 5) Then
                            zgo = False
                        End If
                    End While
                    'fooinputstr = SerialPort1.ReadExisting()
                    If (InStr(1, fooinputstr, "Cal-DGM", 1)) Then 'found it!
                        refportgood = True
                        comgo = False
                        refportsodontmesswith = tempcomport
                    End If
                    'comgo = False
                    'serial port name??
                Catch ex As Exception
                    tempcomport += 1
                End Try
            End While
            'end ref
        End If

        'XD502 Connection
        If (xd502port.IsOpen) Then
            xdportgood = True
            xdcomgo = False
        End If
        comstr = "COM"
        tempcomport = 1
        If (Not xdportgood) Then

            'don't overlap com ports
            If (tempcomport = refportsodontmesswith) Then
                tempcomport += 1
            End If

            'ref connection
            While (xdcomgo)
                'comstr += CStr(tempcomport)
                'DEBUG TAKE OUT
                If tempcomport = 5 Then
                    Dim bruh As String = "bruh"

                End If
                Try
                    If (tempcomport > 300) Then
                        xdcomgo = False
                    End If
                    xd502port.PortName = comstr + CStr(tempcomport)
                    xd502port.Open()
                    Dim fooinputstr As String
                    Dim zgo As Boolean = True
                    Dim giveup As Integer = 0
                    While (zgo)
                        fooinputstr = xd502port.ReadExisting()
                        If (fooinputstr.Length > 1) Then
                            zgo = False
                        End If
                        'give up will end the while loop if the com port goes a long time without transmitting anything
                        giveup += 1
                        Threading.Thread.Sleep(200) ' LETS GO THIS WORKS!!!!! Just need to tweak it a bit
                        'LIERALLY 10 ms WORKS BUT 9 DOESNT
                        'so im going to use 15 just to be safe
                        If (giveup > 5) Then
                            zgo = False
                        End If
                    End While
                    'fooinputstr = SerialPort1.ReadExisting()
                    If (InStr(1, fooinputstr, "-502", 1)) Then
                        xdportgood = True
                        xdcomgo = False
                    End If
                    'comgo = False
                    'serial port name??
                Catch ex As Exception
                    tempcomport += 1
                End Try
            End While
            'end ref
        End If
        If ((Not refportgood) And (Not xdportgood)) Then
            messagetxtbox.Text = "Message: Error! NEITHER port connected!"
        End If
        If ((Not refportgood) And (xdportgood)) Then
            messagetxtbox.Text = "Message: Error! Reference meter not connected!"
        End If
        If ((refportgood) And (Not xdportgood)) Then
            messagetxtbox.Text = "Message: Error! Test meter not connected!"
        End If
        If (refportgood And xdportgood) Then
            messagetxtbox.Text = "Message: Both ports connected!"
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
        antibug5.Text = "curr test pulses: " + testpulses(currenttest).ToString() ' THIS DOES NOT FLASH
        antibug7.Text = "current warmup pulses: " + warmuppulses(currenttest).ToString()
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
        If (refportgood And xdportgood) Then
            testongoing = True
            duringwarmup = True
            currenttest = 1
            'assign vals based on user input
            For startiterator = 1 To 6
                If (flowratetxtbox(startiterator).Text = "") Then ' find out how many rows are filled, this needs more!!
                    endtestnum = startiterator
                    startiterator = 7
                End If
                'find something that disables start button!!!
            Next
        End If


    End Sub

    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
        'If testongoing Then bigtimer += 0.1
    End Sub
End Class