Public Class Main

    Dim rs As New Resizer 'TODO MORE OF THIS ALSO WRITE TO REGISTRY

    Const NUM_OF_ROWS As Integer = 6

    Const REF_INPUT_LABEL As Integer = 1
    Const REF_INPUT_PRESSURE As Integer = 2
    Const REF_AMB_TEMP As Integer = 3
    Const REF_METER_TEMP As Integer = 4
    Const REF_AMB_HUM As Integer = 5
    Const DBG_AMB_HUM As Integer = 5 - 1
    Const REF_PULSECOUNT As Integer = 6
    Const REF_CHECKSUM As Integer = 7
    Const REF_MAX_MEMBERS = 8
    Const BAD_INPUT_LIMIT = 20
    Const BAD_CONNECTION_LIMIT = 5
    Const FLOWRATE_MIN_INPUT_METRIC As Double = 1
    Const FLOWRATE_MAX_INPUT_METRIC As Double = 1
    Const ENDVOL_MAX_INPUT_METRIC As Double = 1
    Const WARMUP_MIN_INPUT As Double = 1
    Const WARMUP_MAX_INPUT As Double = 800
    Const XD_STRING_TYPE As Integer = 4
    Const INBOUND_STRING_TYPE_ACTUAL As String = "A"
    Const INBOUND_STRING_TYPE_CALIBRATION As String = "C"
    Const sBLOCK_START As String = ChrW(1)
    Const BLOCK_MARKER_CS As String = Chr(31)
    Const FIND_SF As Integer = 19
    Const CAL_PULSE_COUNT As Integer = 16 + 1
    Const XD_FLOW_RATE_INPUT As Integer = 30
    Const XL_START_INDEX_ONE = 16
    Const XL_START_INDEX_TWO = 27

    '        sTemp = sBLOCK_START & sTemp & BLOCK_MARKER_CS & sCS & vbCrLf


    Dim xdGivenScaling As Double = 0.0
    Dim kelvinusrstdtemp As Double = 0.0

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
    Dim intinputambtemp As Integer = 0
    Dim intambtemp As Integer
    Dim doubleambtemp As Double

    Dim inputreftemp As String = ""
    Dim intreftemp As Integer
    Dim doublereftemp As Double

    Dim inputambhum As String = ""
    Dim intambhum As Integer
    Dim doubleambhum As Double

    Dim inputpulsecount As String = ""

    Dim intchecksum As Integer
    Dim trimmedcrc As String = ""

    Dim usrrefscalingfactor As Double
    Dim numtests As Integer

    Dim finaldiabox As Boolean = False

    Dim thisDate As Date


    'Dim testpulses = New Integer() {0, 0, 0, 0, 0, 0}
    Dim testendvolume = New Integer() {0, 0, 0, 0, 0, 0, 0}
    Dim warmuptimes = New Integer() {0, 0, 0, 0, 0, 0, 0}
    Dim testusrflowrate = New Integer() {0, 0, 0, 0, 0, 0, 0}

    Dim testtimers = New Double() {0, 0, 0, 0, 0, 0, 0}  ' DOUBLE
    Dim testwarmups = New Integer() {0, 0, 0, 0, 0, 0, 0}
    Dim warmuppulses = New Integer() {0, 0, 0, 0, 0, 0, 0}
    Dim xdWarmupVols = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
    Dim testreftemp = New Double() {0, 0, 0, 0, 0, 0, 0}  'DOUBLE
    Dim refvols = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
    Dim pressureArr = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
    Dim stdrefvols = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
    Dim endstdrefvols = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLEE

    Dim rowused = New Boolean() {False, False, False, False, False, False, False} ' BOOLEANS

    Dim testxdtemp = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
    Dim testxdvol = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
    Dim testxdstdvol = New Double() {0, 0, 0, 0, 0, 0, 0} 'DOUBLE
    Dim hypotheticaltestxdstdvol = New Double() {0, 0, 0, 0, 0, 0, 0} 'DOUBLE
    Dim avghypotheticalxd As Double = 0.0


    'FILE STUFF
    Dim newY = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
    Dim experimentY = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
    Dim filTestTime = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
    Dim filOrrifice = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
    Dim filuutPulseFinal = New Integer() {0, 0, 0, 0, 0, 0, 0}
    Dim filuutPulseTotal = New Integer() {0, 0, 0, 0, 0, 0, 0}
    Dim filuutInitTemp = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
    Dim filuutFinalTemp = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
    Dim filrefStdInitVol = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
    Dim filrefStdFinalVol = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
    Dim filrefStdTotalVol = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
    'meter pressure?
    Dim filrefInitVol = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
    Dim filrefFinalVol = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
    Dim filrefTotalVol = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
    Dim filOutletInitTemp = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
    Dim filOutlsetFinalTemp = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
    Dim filrefflowrate = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
    Dim xdflowrate As Double = 0.0
    Dim filuutFlowRate = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
    Dim thisTestSavedInits = New Boolean() {False, False, False, False, False, False, False}
    Dim thisTestSavedFinals = New Boolean() {False, False, False, False, False, False, False}
    Dim filuutPulseInit = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
    Dim oldCurrTest As Integer = 1
    Dim filuutcalcedpulses = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
    Dim filY = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
    Dim filVarY = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
    Dim forPreciseRefVols = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
    Dim forPreciseXdVols = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
    Dim hasSentCurrPulses = New Boolean() {False, False, False, False, False, False, False} 'BOOLEAN
    Dim pulsesForESB = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE

    Dim didItPass As Boolean

    'END FILE STUFF
    Dim currenttest As Integer = 1
    Dim duringwarmup As Boolean = False

    Dim bigtimer As Double = 0.0

    Dim testover As Boolean = False
    Dim testongoing As Boolean = False
    Dim warmuptimer As Double

    Dim hasCalculatedAfterTest As Boolean = False
    Dim continueButtonAvailable As Boolean = False
    'Dim Gb_testgo As Boolean = True


    Dim ourcs As Integer
    Dim ourcsitr As Integer
    Dim refcrcstr As String
    Dim refcrcint As Integer

    Const XD_IN_VOL = 20 + 1
    Const XD_IN_TEMP = 10 + 1
    Const XD_IN_DATE = 1 + 1

    Dim xdInputVol As Double
    Dim xdInputTemp As Double
    Dim xdDate As String

    Dim avgStdRefVolPostTest As Double
    Dim avgStdTestVolPostTest As Double
    Dim processingDone As Boolean = False
    Dim havesScalingFactor As Boolean = False
    'Dim givenxdScaling As Double = 0.0
    Dim goodOldRefTemp As Integer = 0



    'inputlabel, inputpressure, doublepressure, inputambtemp, inputreftemp, inputambhum, 
    Dim s_ref_in(REF_MAX_MEMBERS) As String
    Dim zrefinputlabel As String
    Dim zrefinputpressure As String
    Dim zrefinputambtemp As String
    Dim zrefinputreftemp As String
    Dim zrefinputambhum As String
    Dim weNeedPulseCountxd As Boolean = False
    Dim xdpulseholder As Integer = 0
    Dim toEsbPulses As Integer = 0

    Dim xdWarmUpPulses = New Integer() {0, 0, 0, 0, 0, 0, 0}
    Dim xdInPulses = New Integer() {0, 0, 0, 0, 0, 0, 0}

    Const XD_MAX_MEMBERS = 500
    Dim s_xd_in(XD_MAX_MEMBERS) As String
    Dim gooddata As Boolean = True
    Dim refportgood As Boolean = False
    Dim xdportgood As Boolean = False

    Dim DialogForm As New DialogUsr
    Dim ErrorForm As New ErrorForm
    Dim certForm As New Certification

    Dim consecBadCSVals As Integer = 0
    Dim consecBadCRCVals As Integer = 0

    Dim refFailedConnectionCounter As Integer = 0
    Dim xdFailedConnectionCounter As Integer = 0

    Dim rowNumberCheck As Integer = 1

    Dim rowShouldBeFilled As Boolean = False
    Dim reasonableVals As Boolean = True

    Dim numRealTests As Integer

    Dim debugAbort As Boolean = False

    Dim xdthisinputtype As String = ""


    'for a private sub
    Dim fooflowrate As Double = 0.0
    Dim fooendvol As Double = 0.0
    Dim foowarmup As Double = 0.0
    Dim shouldendonlynum As Boolean = False
    Dim percentoffnew As Double
    Dim intpulseholder As Integer = 0
    Dim newendcurrtest As Boolean = False
    Dim forStringVol As String = ""
    Dim checkingDelay As Integer = 0
    Dim testactive As Boolean = False
    Dim nineninecounter As Integer = 0




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


        'hwatinputambhum = CInt(s_ref_in(REF_AMB_HUM))

    End Sub

    Public Sub findRunnableTests()
        For r As Integer = 1 To NUM_OF_ROWS
            'reset vals
            rowused(r) = False
            Try
                If ((flowratetxtbox(r).Text <> vbNullString) And CDbl(flowratetxtbox(r).Text) > 0) Then
                    If ((endvoltxtbox(r).Text <> vbNullString) And CDbl(endvoltxtbox(r).Text) > 0) Then
                        If ((warmuptxtbox(r).Text <> vbNullString) And CDbl(warmuptxtbox(r).Text) > 0) Then
                            rowused(r) = True
                        End If
                    End If
                End If
            Catch ex As Exception
                rowused(r) = False
            End Try

        Next
    End Sub

    Public Sub disableButtons()
        For q As Integer = 1 To NUM_OF_ROWS
            If (testongoing) Then
                flowratetxtbox(q).BackColor = Color.FromArgb(255, 0, 0, 0)
                endvoltxtbox(q).BackColor = Color.FromArgb(255, 0, 0, 0)
                warmuptxtbox(q).BackColor = Color.FromArgb(255, 0, 0, 0)
                flowratetxtbox(q).Enabled = False
                endvoltxtbox(q).Enabled = False
                warmuptxtbox(q).Enabled = False
            Else
                flowratetxtbox(q).Enabled = True
                endvoltxtbox(q).Enabled = True
                warmuptxtbox(q).Enabled = True
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
        intinputambtemp = CInt(s_ref_in(REF_AMB_TEMP))
        inputreftemp = CInt(s_ref_in(REF_METER_TEMP))
        inputambhum = CInt(s_ref_in(REF_AMB_HUM))
        intpulsecount = CInt(s_ref_in(REF_PULSECOUNT))
        Gs_inputchecksum = s_ref_in(REF_CHECKSUM)
        'check ok val for ref temp
        If (inputreftemp > 0 And inputreftemp < 20000) Then
            goodOldRefTemp = inputreftemp
        Else
            inputreftemp = goodOldRefTemp
        End If
    End Sub

    Public Sub xdUpdateVals()
        Dim aaa = xdCurrStr
        xdInputVol = CDbl(s_xd_in(XD_IN_VOL)) 'krug22
        xdInputTemp = CDbl(s_xd_in(XD_IN_TEMP))
        xdDate = s_xd_in(XD_IN_DATE)
        Dim bruh4 As Double = filuutFlowRate(currenttest)
    End Sub

    Public Sub reWhiteInputsExistOnly()
        For o As Integer = 1 To NUM_OF_ROWS
            If (flowratetxtbox(o).BackColor = Color.FromArgb(255, 255, 215, 0)) Then
                If (flowratetxtbox(o).Text <> vbNullString) Then
                    flowratetxtbox(o).BackColor = Color.FromArgb(255, 255, 255, 255)
                End If
            End If
            If (endvoltxtbox(o).BackColor = Color.FromArgb(255, 255, 215, 0)) Then
                If (endvoltxtbox(o).Text <> vbNullString) Then
                    endvoltxtbox(o).BackColor = Color.FromArgb(255, 255, 255, 255)
                End If
            End If
            If (warmuptxtbox(o).BackColor = Color.FromArgb(255, 255, 215, 0)) Then
                If (warmuptxtbox(o).Text <> vbNullString) Then
                    warmuptxtbox(o).BackColor = Color.FromArgb(255, 255, 255, 255)
                End If
            End If
        Next
        'Color.FromArgb(255, 255, 215, 0)
    End Sub



    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Main_Timer.Tick

        ' Just hitching a ride ---------------------
        'debug22.Text = CStr(xdInputVol) 712 newdo
        'debug22.Text = CStr(testxdvol(currenttest))

        'this is a counter that will make the pc send '99' three times when abort is pressed to reset the seqnum of the esp32, instead of three times, could be another num who knows
        If (nineninecounter > 4) Then
            nineninecounter = 0
        End If
        If (nineninecounter >= 1 And nineninecounter <= 4) Then
            nineninecounter += 1
            refport.Write("999" + vbCrLf)
            'debug22.Text = "999"
        End If


        checkingDelay += 1
        Static counterToesp As Integer = 0
        counterToesp += 1
        If Gb_Update_Screen_Size Then
            Gb_Update_Screen_Size = False
            Update_Screen_Size()
        End If

        'diable inputs if test ongoing
        disableButtons()

        'check to see if we have scaling factor
        If (Not havesScalingFactor) Then
            requestCalibration()
            'loop this ????
        End If

        If (weNeedPulseCountxd) Then
            requestRaw()
        End If

        'update label units based on unit type
        If (Gs_UnitType = "met") Then
            Label7.Text = "Ref Meter" + vbCrLf + "Volume" + vbCrLf + "(Liters)"
            Label8.Text = "Std Ref" + vbCrLf + "Volume" + vbCrLf + "(Liters)"
            Label9.Text = "UUT Meter" + vbCrLf + "Volume" + vbCrLf + "(Liters)"
            Label10.Text = "UUT Std" + vbCrLf + "Volume" + vbCrLf + "(Liters)"
            Label11.Text = "Ref Meter" + vbCrLf + "Temp" + vbCrLf + "(°C)"
            Label12.Text = "UUT Meter" + vbCrLf + "Temp" + vbCrLf + "(°C)"
            pressureLabel0.Text = "Pressure" + vbCrLf + "(mmHg)"
        Else
            If (Gs_UnitType = "imp") Then
                Label7.Text = "Ref Meter" + vbCrLf + "Volume" + vbCrLf + "(Cu Ft.)"
                Label8.Text = "Std Ref" + vbCrLf + "Volume" + vbCrLf + "(Cu. Ft.)"
                Label9.Text = "UUT Meter" + vbCrLf + "Volume" + vbCrLf + "(Cu. Ft.)"
                Label10.Text = "UUT Std Volume" + vbCrLf + "(Cu. Ft)"
                Label11.Text = "Ref Meter" + vbCrLf + "Temp" + vbCrLf + "(°F)"
                Label12.Text = "UUT Meter" + vbCrLf + "Temp" + vbCrLf + "(°F)"
                pressureLabel0.Text = "Pressure" + vbCrLf + "(InchesHg)"
            End If
        End If

        'make inputs visible even when running
        'For bb As Integer = 1 To NUM_OF_ROWS
        '    If (flowratetxtbox1.Enabled = False) Then
        '        flowratetxtbox(bb).ForeColor = Color.FromArgb(255, 255, 255, 255)
        '        endvoltxtbox(bb).ForeColor = Color.FromArgb(255, 255, 255, 255)
        '        warmuptxtbox(bb).ForeColor = Color.FromArgb(255, 255, 255, 255)
        '    End If

        'Next

        'validate user input in real time
        'reWhiteInputsExistOnly()

        If ((consecBadCRCVals > BAD_INPUT_LIMIT) Or (consecBadCSVals > BAD_INPUT_LIMIT)) Then
            'END TEST OR SOMETHING
            'this means there have been BAD_INPUT_LIMIT consecutive failures and something is super wrong so stop the whole thing!
            'TODO FIGURE OUT HOW TO STOP THE WHOLE THING
            'ideas: testongoing = false
            'how do I reinitialize all values? (all values except config values?? AND usr test vol flow rate values)
            'maybe I could make a reinitialize function
        End If

        'antibug11.Text = CStr(usrrefscalingfactor)
        'PARSE REF METER

        Try
            Static ioStr As String = ""
            ioStr = ""
            Gs_currstr = ""
            mainclocklbl.Text = TimeString ' 24 hour time
            newmainclock.Text = TimeString
            If (refport.IsOpen) Then

                If (refport.ReadBufferSize > 0) Then
                    ioStr += Trim(refport.ReadExisting())

                    If (InStr(ioStr, Chr(10)) And ioStr <> "" And ioStr.Length > 15) Then

                        Gs_currstr = ioStr
                        'for debug
                        DEBUG.Text = ioStr
                        goodParseRef()
                        Gs_str = Gs_currstr  ' this is for debugging
                        Dim tempinstr = Gs_str

                        'read input crc
                        Dim startrefcrc As Integer = InStr(tempinstr, "|")
                        Dim endrefcrc As Integer = InStr(startrefcrc, tempinstr, ",")
                        Dim tcrc As String = Mid(tempinstr, startrefcrc + 1, endrefcrc - startrefcrc)
                        refcrcstr = tcrc
                        Try
                            refcrcint = CInt(refcrcstr)
                        Catch ex As Exception
                            refcrcint = 1 ' there's no way it will be this, so vals will not update
                            consecBadCRCVals += 1
                        End Try


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
                            consecBadCRCVals = 0 ' resets bad counter
                        End If

                    End If
                End If
            End If
        Catch ex As Exception

        End Try




        'debugg
        'antibug11.Text = CStr(xdWarmupVols(currenttest))
        'antibug1.Text = "big timer: " & CStr(bigtimer)
        'antibug2.Text = "curr test timer: " + testtimers(currenttest).ToString()
        'antibug3.Text = "total pulse count: " + intpulsecount.ToString()
        'antibug4.Text = "current test: " + currenttest.ToString()
        'antibug6.Text = "during warmup: " + duringwarmup.ToString()
        'antibug5.Text = "curr test pulses: " + testpulses(currenttest).ToString()
        'antibug7.Text = "current warmup pulses: " + warmuppulses(currenttest).ToString()
        'antibug1.Text = "row used 0: " + CStr(rowused(0))
        'antibug2.Text = "row used 1: " + CStr(rowused(1))
        'antibug3.Text = "row used 2: " + CStr(rowused(2))
        'antibug4.Text = "row used 3: " + CStr(rowused(3))
        'antibug5.Text = "row used 4: " + CStr(rowused(4))
        'antibug6.Text = "row used 5: " + CStr(rowused(5))
        'antibug7.Text = "row used 6: " + CStr(rowused(6))
        'end debugg, safe to take out in future

        ''START PARSING FROM DGM---------------------------------------------
        xdIoStr = ""
        xdCurrStr = ""
        Try
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
                        Try
                            xdParsedCheckInt = CInt(xdParsedCheckStr)  ' to do handle if string not int
                        Catch ex As Exception
                            xdParsedCheckInt = 1 'there's no way this will be valid, so vals will not update
                            consecBadCSVals += 1
                        End Try


                        xdCalculatedCS = 0 ' reset just to be sure

                        For j As Integer = 2 To InStr(xdTempInStr, "!")

                            xdCalculatedCS += Asc(Mid(xdTempInStr, j, 1))
                            If (xdCalculatedCS > 9999) Then
                                xdCalculatedCS -= 10000
                            End If
                        Next

                        xdCalculatedCS = 10000 - xdCalculatedCS

                        'DETERIMNE IF TYPE A OR TYPE C
                        'xdInputVol = CDbl(s_xd_in(XD_IN_VOL))
                        Try
                            xdthisinputtype = Trim(s_xd_in(XD_STRING_TYPE))
                            If (xdthisinputtype = "A") Then
                                If (xdCalculatedCS = xdParsedCheckInt) Then
                                    xdUpdateVals()
                                    consecBadCSVals = 0  ' resets bad counter
                                End If
                            Else
                                If (xdthisinputtype = "C") Then
                                    Try
                                        'scan for the scaling factor
                                        xdGivenScaling = s_xd_in(FIND_SF)
                                        havesScalingFactor = True


                                    Catch ex As Exception

                                    End Try
                                Else
                                    If (xdthisinputtype = "R") Then
                                        If (weNeedPulseCountxd) Then
                                            xdpulseholder = s_xd_in(CAL_PULSE_COUNT)
                                            Dim bruh66 = currenttest
                                            Dim bruh1 = xdCurrStr
                                            filuutPulseFinal(oldCurrTest) = s_xd_in(CAL_PULSE_COUNT)
                                            If (Not xdpulseholder = 0) Then
                                                weNeedPulseCountxd = False
                                            End If

                                        End If
                                    End If
                                End If
                            End If
                        Catch ex As Exception

                        End Try

                        'update values if good
                        'If (xdCalculatedCS = xdParsedCheckInt) Then
                        '        xdUpdateVals()
                        '        consecBadCSVals = 0  ' resets bad counter
                        '    End If

                    End If
                End If

            End If
        Catch ex As Exception

        End Try


        'If (debugAbort) Then
        '    Dim bruhbruh As Integer = 9
        '    findRunnableTests()
        '    testongoing = True
        '    duringwarmup = True
        '    currenttest = 1
        'End If
        'update labels with good values **************************************************
        'ref ------------------
        Dim bruhasdf As Boolean = testongoing '''''''''''''''''''''''''''''''
        bigtimerlabel.Text = "Overall Time: " + CStr(bigtimer)
        If (testongoing) Then
            ' refpulselabel(currenttest).Text = CStr(refvols(currenttest))  'omega newdo maybe ican take all these out
            'testtimerlabel(currenttest).Text = CStr(testtimers(currenttest))  'brug1
            reftemplabel(currenttest).Text = CStr(testreftemp(currenttest))
            pressureLabel(currenttest).Text = CStr(pressureArr(currenttest))
            stdVolLabel(currenttest).Text = CStr(stdrefvols(currenttest))


            'dgm --------------------------
            testtemplabel(currenttest).Text = CStr(testxdtemp(currenttest))
            testpulselabel(currenttest).Text = CStr(testxdvol(currenttest))
            xdstdvollabel(currenttest).Text = CStr(testxdstdvol(currenttest))
            ydifflabel(currenttest).Text = CStr(filVarY(currenttest))
        End If


        ''test over???????????????????????????
        'to process after test
        If (testover And Not processingDone) Then
            processingDone = True
            ''''''''''''toFileButton.Visible = True
            'process the vals lmao like average them and move them to a spreadsheet
            'hasCalculatedAfterTest boolean that will go to true after we process everything
            numtests = currenttest - 1
            'endlabel1.Text = "curr test num: " + CStr(currenttest)
            Dim asdf As String
            'find number of real tests
            For t As Integer = 1 To NUM_OF_ROWS
                If (rowused(t) = True) Then
                    numRealTests += 1
                End If
                'numRealTests = t
            Next
            'end find number of real tests
            For k As Integer = 1 To NUM_OF_ROWS
                If (rowused(k) = True) Then
                    avgStdRefVolPostTest += CDbl(stdVolLabel(k).Text) 'error here
                    avgStdTestVolPostTest += CDbl(xdstdvollabel(k).Text)
                    asdf &= stdVolLabel(k).Text + " "
                End If

            Next
            'get hypothetical
            For ee As Integer = 1 To NUM_OF_ROWS
                avghypotheticalxd += CDbl(xdstdvollabel(ee).Text) / xdGivenScaling
            Next
            'get avg
            avghypotheticalxd /= numRealTests
            avgStdRefVolPostTest = Math.Round((avgStdRefVolPostTest / numRealTests), 2)
            avgStdTestVolPostTest = Math.Round((avgStdTestVolPostTest / numRealTests), 2)
            avglabel11.Text = CStr(avgStdRefVolPostTest)
            avglabel22.Text = CStr(avgStdTestVolPostTest)


            'HERE CHANGE TEXT IF VALIDATION OR CALIBRATION**********************
            'avglabel33.Text = CStr(Math.Round((avgStdRefVolPostTest / avgStdTestVolPostTest), 4))
            'If (validateRadioButton.Checked) Then
            '    'this is validation
            '    resultLabel1.Text = "Percentage Off"
            '    avglabel33.Text = CStr(Math.Round(100 - (100 * (avgStdRefVolPostTest / avgStdTestVolPostTest)), 4))
            'End If
            'If (calibrateRadioButton.Checked) Then
            '    resultLabel1.Text = "New Scaling Factor for XD:"
            '    avglabel33.Text = CStr(Math.Round((avgStdRefVolPostTest / avgStdTestVolPostTest), 4))
            'End If
            'HERE!!!!!!!!!!!!!!!!!!!!!!
            resultLabel1.Text = "Calculated Scaling Factor: "
            '''''''''''''''''avglabel33.Text = CStr(Math.Round((avgStdRefVolPostTest / avgStdTestVolPostTest), 4))
            avglabel33.Text = CStr(Math.Round((avgStdRefVolPostTest / avghypotheticalxd), 7))
            percenterrorreallbl.Text = CStr(Math.Round(100 - (100 * (avgStdRefVolPostTest / avgStdTestVolPostTest)), 4)) & "%"
            'check if passed
            percentoffnew = (percenterrorreallbl.Text).Replace("%", "")
            percentoffnew = CDbl(percentoffnew)
            If ((percentoffnew < 5) And percentoffnew > -5) Then
                'change new label to test passed
                percenterrorreallbl.BackColor = Color.FromArgb(255, 0, 255, 0) ' GREEN
                didItPass = True
            Else
                percenterrorreallbl.BackColor = Color.FromArgb(255, 255, 0, 0) ' RED
                didItPass = False
            End If
            'avglabel33.Visible = True
            'percenterrorreallbl.Visible = True
            avglabel1.Visible = True
            avglabel2.Visible = True
            avglabel11.Visible = True
            avglabel22.Visible = True
            'resultLabel1.Text = "New Scaling Factor for XD:"
            'avglabel33.Text = CStr(Math.Round((avgStdRefVolPostTest / avgStdTestVolPostTest), 4))
            'OPTIMUS PRIME

            'MORE TEST OVER STUFF
            btncert.BackColor = Color.FromArgb(255, 50, 220, 50) 'not too bright green
            genUpdateForXL()
        End If

        'others-----------------------

        'If overall test is currently going
        If (testongoing And Gb_testgo) Then
            messagetxtbox.Text = "TEST ONGOING"
            If (Gb_testgo) Then
                'ensure correct string:
                teststatuslabel2.Text = "Running Test: " + CStr(currenttest)

                'END TEST IF NO MORE TEST SPECIFIED
                If (currenttest = 7 Or (currenttest = 6) And (rowused(6) = False)) Then
                    testongoing = False
                    testover = True
                    teststatuslabel2.Text = "Test Over"
                    'HERE UPDATE GS

                End If
            End If

            'If overall test is currently going and end condition not met
            If (testongoing) Then
                If (Gb_testgo) Then
                    bigtimer += 0.1
                    bigtimer = Math.Round(bigtimer, 2)
                End If

                'check for end of warmup
                If (warmuptimer > Val(warmuptxtbox(currenttest).Text)) Then
                    duringwarmup = False
                End If

                'increment warmup timer(s)
                If (duringwarmup) Then
                    checkingDelay = 0
                    'STUFF FOR SENDING TO ESB32:::
                    'maybe we can delay this a tiny bit?
                    'starscream
                    '''''If (Not hasSentCurrPulses(currenttest)) Then
                    '''''    hasSentCurrPulses(currenttest) = True
                    '''''    pulsesForESB(currenttest) = usrrefscalingfactor * CDbl(endvoltxtbox(currenttest).Text) * 1000 * 1000 'not super sure about this!
                    '''''    'Dim bruh55 As Double = CDbl(endvoltxtbox(currenttest).Text)
                    '''''    intpulseholder = CInt(pulsesForESB(currenttest))
                    '''''    refport.Write(CStr(intpulseholder) + vbCrLf) 'OPTIMUS PRIME
                    '''''    'problem child?? it's going negative??

                    '''''    'send the data
                    '''''    'but first calc the pulses
                    '''''    'CHECK FOR NOT ZERO ANBTEMP IN THE NOT WARMUP ONLY
                    '''''End If
                    'END STUFF FOR SENDING TO ESB32
                    If ((currenttest = 2) And warmuptimer > 3.0) Then
                        Dim bruh2 As Integer = 5 ' this is for debugging??
                    End If

                    warmuptimer += 0.1
                    warmuptimer = Math.Round(warmuptimer, 2)
                    warmuptimes(currenttest) += 0.1
                    warmuppulses(currenttest) = intpulsecount
                    xdWarmupVols(currenttest) = Math.Round(xdInputVol, 2)
                    Dim bruh3 As Integer = intpulsecount
                    Dim bruh4 As Double = xdWarmupVols(currenttest)
                    'CONVERT TO IMPERIAL!!!!!!!!!!!************************************!*!*!*!*!*!*!*!*
                    'If (Gs_UnitType = "imp") Then
                    'xdWarmupVols(currenttest) = Math.Round((xdWarmupVols(currenttest) / 28.317), 2) ' gotta test this *********************FIX THIS WE GOTTA MINUS THE WARMUP!!!!!!!!
                    'End If
                End If

                'USE VALS FROM INPUT **********************************************************
                If (Not duringwarmup) Then

                    'find end condition
                    'If (Len(inputambtemp) > 3) Then
                    If (inputambtemp = "12345" And checkingDelay > 20 And testactive) Then
                        newendcurrtest = True
                        Dim bruh66 As Integer = intpulsecount
                    End If
                    'screamstar
                    'send to esb32
                    If (inputambtemp = CStr(currenttest)) Then
                        hasSentCurrPulses(currenttest) = True 'ayo
                    End If
                    If (Not hasSentCurrPulses(currenttest) And (counterToesp Mod 4) = 0) Then
                        'hasSentCurrPulses(currenttest) = True ayo 
                        'for future pulsesForESB(currenttest) = usrrefscalingfactor * CDbl(endvoltxtbox(currenttest).Text) / (0.001) 'not super sure about this!
                        'FRUIT SNACKS
                        'pulsesForESB(currenttest) = CDbl(endvoltxtbox(currenttest).Text) / usrrefscalingfactor 'newdo 712
                        pulsesForESB(currenttest) = CDbl(endvoltxtbox(currenttest).Text) / usrrefscalingfactor
                        Dim bruh66 = CDbl(endvoltxtbox(currenttest).Text)
                        Dim bruh55 As Double = pulsesForESB(currenttest)
                        'CONVERSIONSIMP
                        'convert to imperial here
                        intpulseholder = CInt(pulsesForESB(currenttest))
                        'newdo 712 make this work for imperial
                        If (Gs_UnitType = "imp") Then
                            intpulseholder = CInt(CDbl(intpulseholder) * 28.317) 'convert liters to imperial?
                        End If
                        refport.Write(CStr(intpulseholder) + CStr(currenttest) + vbCrLf) 'OPTIMUS PRIME
                        checkingDelay = 0
                        debug22.Text = (CStr(intpulseholder) + CStr(currenttest))
                        Dim bruh75 As String = (CStr(intpulseholder) + CStr(currenttest) + vbCrLf)
                        'problem child?? it's going negative??

                        'send the data
                        'but first calc the pulses
                        'CHECK FOR NOT ZERO ANBTEMP IN THE NOT WARMUP ONLY
                    End If

                    'ref stuff ------------------
                    testtimers(currenttest) += 0.1
                    testtimers(currenttest) = Math.Round(testtimers(currenttest), 2)
                    'testpulses(currenttest) = intpulsecount - warmuppulses(currenttest)
                    testpulses(currenttest) = intpulsecount 'krug4
                    Dim asdf As Integer = testpulses(currenttest)
                    'dndn
                    Dim fda As Integer = usrrefscalingfactor
                    'refvols(currenttest) = (testpulses(currenttest) * usrrefscalingfactor) 'krug3 usrrefscalingfactor looks ok hurrr
                    'rnrnrn
                    testreftemp(currenttest) = Math.Round(conversions.cIntToDouble(inputreftemp), 2)
                    pressureArr(currenttest) = Math.Round(conversions.cIntToDouble(intpressure), 2)

                    Dim bruhamasdf As Integer = testpulses(currenttest)

                    Dim buasfdghads As Double = (testpulses(currenttest) * usrrefscalingfactor)
                    Dim asfhg As String = CStr(Math.Round((testpulses(currenttest) * usrrefscalingfactor), 2))
                    refvols(currenttest) = Math.Round((testpulses(currenttest) * usrrefscalingfactor), 2) ' krug3 omega optum
                    Dim asfhgdad As Double = refvols(currenttest)
                    Dim ashdglasd As Double = CDbl(conversions.Format4Two((testpulses(currenttest) * usrrefscalingfactor)))
                    refvols(currenttest) = ashdglasd 'CDbl(conversions.Format4Two((testpulses(currenttest) * usrrefscalingfactor)))
                    Dim ghgh As Double = refvols(currenttest)


                    'SOME ABSOLUTE CRAZINESS
                    '''testreftemp(currenttest) = testxdtemp(currenttest)
                    stdrefvols(currenttest) = Math.Round(conversions.standardize(refvols(currenttest), testreftemp(currenttest), pressureArr(currenttest)), 2) ' DO I NEED DIFF VALS FOR THIS *********************

                    'xd stuff --------------------
                    testxdtemp(currenttest) = Math.Round(xdInputTemp, 2) 'COMES IN AS FARENHEIT, I WILL DEFAULT CONVERT TO CELSIUS
                    ' If (units = celsius)
                    '''testxdtemp(currenttest) = Math.Round(conversions.convertFarToCel(testxdtemp(currenttest)), 2)
                    'AGAIN, THIS MAKES IT CELSIUS
                    testxdvol(currenttest) = Math.Round((xdInputVol - xdWarmupVols(currenttest)), 2) 'newdo has to do with krug
                    testxdstdvol(currenttest) = Math.Round(conversions.standardize(testxdvol(currenttest), testxdtemp(currenttest), pressureArr(currenttest)), 2)
                    hypotheticaltestxdstdvol(currenttest) = Math.Round(testxdvol(currenttest) / xdGivenScaling)  'newdo xdgiven scaling must have more time??
                    Dim bruh111 As Double = testxdstdvol(currenttest)
                    Dim bruh222 As Double = testtimers(currenttest)
                    filuutFlowRate(currenttest) = Math.Round((testxdstdvol(currenttest) * 60 / testtimers(currenttest)), 3)    'newdo testtimers is 0?
                    filrefflowrate(currenttest) = Math.Round((stdrefvols(currenttest) * 60 / testtimers(currenttest)), 3)
                    '  If (testtimers(currenttest) >= 30) Then
                    ' Dim bruh99 = stdrefvols(currenttest)
                    'Dim bruh100 = testtimers(currenttest)
                    'Dim bruh101 = filrefflowrate(currenttest)
                    'End If
                    forPreciseRefVols(currenttest) = (testpulses(currenttest) * usrrefscalingfactor)
                    forPreciseRefVols(currenttest) = Math.Round(conversions.standardize(forPreciseRefVols(currenttest), testreftemp(currenttest), pressureArr(currenttest)), 4)
                    forPreciseXdVols(currenttest) = (xdInputVol - xdWarmupVols(currenttest))
                    forPreciseXdVols(currenttest) = Math.Round(conversions.standardize(forPreciseXdVols(currenttest), testxdtemp(currenttest), pressureArr(currenttest)), 4)
                    'FIND Y AND CAL
                    'YYYYYYYYYYYYYYY
                    Dim zasdf As Integer = testpulses(currenttest)
                    Dim asdgdas As Double = usrrefscalingfactor
                    Dim asyo As Integer = intpulsecount
                    Dim bruh123 As Double = forPreciseRefVols(currenttest)
                    Dim bruh123123123 As Double = forPreciseXdVols(currenttest)
                    If (Not forPreciseRefVols(currenttest) = 0 And Not forPreciseXdVols(currenttest) = 0) Then
                        filVarY(currenttest) = Math.Round((1 / forPreciseRefVols(currenttest)) * forPreciseXdVols(currenttest), 4) 'newdo problem here
                    End If
                    'filVarY(currenttest) = (1 / forPreciseRefVols(currenttest))



                    filY(currenttest) = Math.Round(filVarY(currenttest) - 1, 4)

                    filuutcalcedpulses(currenttest) = Math.Round((testxdstdvol(currenttest) * 1000 * xdGivenScaling), 0)


                    'IF IMPERIAL------------------------------------------
                    'newdo 
                    'maybe do the conversions here only for INPUTS like when the user inputs some data
                    '
                    If (Gs_UnitType = "imp") Then
                        testreftemp(currenttest) = Math.Round((conversions.convertCelToFar(testreftemp(currenttest))), 2)   'convert cel to far
                        testxdtemp(currenttest) = Math.Round((conversions.convertCelToFar(testxdtemp(currenttest))), 2)     'convert cel to far
                        pressureArr(currenttest) = Math.Round((pressureArr(currenttest) / 25.4), 2)     'mmHg to inchesHg
                        refvols(currenttest) = Math.Round((refvols(currenttest) / 28.317), 2)     'Liters to cubic feet newdo omega
                        testxdvol(currenttest) = Math.Round((testxdvol(currenttest) / 28.317), 2)     'Liters to cubic feet
                        stdrefvols(currenttest) = Math.Round(conversions.standardize(refvols(currenttest), testreftemp(currenttest), pressureArr(currenttest)), 2)
                        testxdstdvol(currenttest) = Math.Round(conversions.standardize(testxdvol(currenttest), testxdtemp(currenttest), pressureArr(currenttest)), 2)
                        hypotheticaltestxdstdvol(currenttest) = Math.Round((testxdstdvol(currenttest) / xdGivenScaling), 2)
                        filuutFlowRate(currenttest) = Math.Round((filuutFlowRate(currenttest) / 28.317), 3)
                        filrefflowrate(currenttest) = Math.Round((filrefflowrate(currenttest) / 28.317), 3)
                        filuutcalcedpulses(currenttest) = Math.Round((testxdstdvol(currenttest) * 1000 * xdGivenScaling / 28.317), 0) ' THIS CONVERSION WEIRD !!!!$#%@QLK#$FSDLKH Liters to cu ft
                    End If


                    'HERE IS WHERE I DO INIT VALS FOR CERTIFICATION****************************************
                    'SAVE INIT VALS HERE *******************************
                    If (Not thisTestSavedInits(currenttest)) Then
                        'xdGivenScaling
                        thisTestSavedInits(currenttest) = True
                        'now this will only execute once per test

                        'filOrrifice??
                        'filuutPulseInit(currenttest) = Math.Round((hypotheticaltestxdstdvol(currenttest) / xdGivenScaling), 2)   'init pulses idk tho
                        Dim bruh37 As Double = xdWarmupVols(currenttest)
                        'filuutPulseInit(currenttest) = Math.Round((xdWarmupVols(currenttest) / xdGivenScaling), 2)   'init pulses idk tho
                        filuutPulseInit(currenttest) = 0
                        'TODO CONVERT THIS TO INT???
                        'uutpulsetotal
                        filuutInitTemp(currenttest) = testxdtemp(currenttest)
                        filOutletInitTemp(currenttest) = testreftemp(currenttest)
                        filrefInitVol(currenttest) = refvols(currenttest)
                        filrefStdInitVol(currenttest) = stdrefvols(currenttest)
                        'pressure?

                        'Y stuff???
                        'new Y
                        Dim bruha As Integer = intpulsecount
                        Dim bruhz As Double = forPreciseXdVols(currenttest)
                        If (Not forPreciseXdVols(currenttest) = 0) Then
                            newY(currenttest) = Math.Round((forPreciseRefVols(currenttest) / forPreciseXdVols(currenttest)), 4)   'newdo
                        End If
                        'newY(currenttest) = Math.Round((forPreciseRefVols(currenttest) / forPreciseXdVols(currenttest)), 4)   'newdo
                        ydifflabel(currenttest).Text = CStr(filVarY(currenttest))
                        'Dim bruhz As Double = newY(currenttest)
                        'save init vals
                    End If
                    'hardcode updating the textbox vals???
                    'newdo
                    If (Math.Floor(refvols(currenttest)) = Math.Ceiling(refvols(currenttest))) Then
                        forStringVol = CStr(refvols(currenttest)) & ".00"   'krug2
                    Else
                        forStringVol = CStr(refvols(currenttest))
                    End If
                    'do this for more vals??
                    'Math.Floor only works with doubles!
                    'refpulselabel(currenttest).Text = CStr(refvols(currenttest))
                    refpulselabel(currenttest).Text = forStringVol 'krug1  'omega  bl

                    'brug temp to fix timer
                    Dim bruh556 As String = inputambhum
                    testtimers(currenttest) = Math.Round(CInt(inputambhum) / 100, 2)

                    testtimerlabel(currenttest).Text = CStr(testtimers(currenttest)) 'brug1
                    reftemplabel(currenttest).Text = CStr(testreftemp(currenttest))
                    pressureLabel(currenttest).Text = CStr(pressureArr(currenttest))
                    stdVolLabel(currenttest).Text = CStr(stdrefvols(currenttest))


                    'dgm --------------------------
                    testtemplabel(currenttest).Text = CStr(testxdtemp(currenttest))
                    testpulselabel(currenttest).Text = CStr(testxdvol(currenttest))
                    xdstdvollabel(currenttest).Text = CStr(testxdstdvol(currenttest))
                    ydifflabel(currenttest).Text = CStr(filVarY(currenttest))

                    'check for end condition off of pulses/volume
                    'go to next test
                    'START OLD
                    'endconditionbytime
                    'If (refvols(currenttest) > CDbl(endvoltxtbox(currenttest).Text)) Then
                    ''''' If (Len(inputambtemp) > 3) Then
                    ''''' newendcurrtest = True

                    ''''''End If
                    If (newendcurrtest) Then 'maybe stupid to measure by string? but idtso
                        newendcurrtest = False
                        Dim bruh66 As Integer = intpulsecount
                        'WRITE TO XD
                        If (Not filuutPulseFinal(currenttest) = 0) Then
                            weNeedPulseCountxd = False
                        Else
                            weNeedPulseCountxd = True
                        End If
                        If (weNeedPulseCountxd) Then
                            requestRaw()
                            oldCurrTest = currenttest
                        End If
                        'END OLD
                        'start new end condition based on esb


                        ''endstdrefvols(currenttest) = CDbl(stdVolLabel(currenttest).Text)
                        ''endlabel3.Text = CStr(endstdrefvols(currenttest))
                        'SAVE FINAL VALS HERE*****************CERTIFICATION*************************************
                        'filTestTime(currenttest) = testtimers(currenttest)
                        'frog
                        Dim bruh56 As String = inputambhum
                        filTestTime(currenttest) = Math.Round(CInt(inputambhum) / 100, 2)
                        Dim bruh55 As Double = filTestTime(currenttest)
                        testtimerlabel(currenttest).Text = CStr(filTestTime(currenttest)) 'brug1

                        filuutFinalTemp(currenttest) = testxdtemp(currenttest)
                        filOutlsetFinalTemp(currenttest) = testreftemp(currenttest)
                        'filrefFinalVol(currenttest) = xdpulseholder
                        'filrefTotalVol(currenttest) = xdpulseholder
                        'FINALIZE VALS???????????? special case for a temp i forget which one
                        'is final vals here even necessary??


                        If (Not xdpulseholder = 0) Then
                            xdpulseholder = 0
                        End If
                        filrefStdFinalVol(currenttest) = stdrefvols(currenttest)
                        filrefStdTotalVol(currenttest) = stdrefvols(currenttest) + (warmuppulses(currenttest) * usrrefscalingfactor) ' IDK ABT THIS

                        'filuutPulseFinal(currenttest) = Math.Round((xdWarmupVols(currenttest) / xdGivenScaling) + (testxdvol(currenttest) / xdGivenScaling), 2)  'init pulses idk tho
                        'TODO CONVERT THIS TO INT??????
                        'filuutPulseTotal(currenttest) = filuutPulseFinal(currenttest)
                        'filuutPulseTotal(currenttest) = Math.Round(hypotheticaltestxdstdvol(currenttest) / xdGivenScaling) + Math.Round((xdWarmupVols(currenttest) / xdGivenScaling), 2)   'init pulses idk tho
                        'STANDARDDIZED VALS FOR UUT
                        If (Not thisTestSavedFinals(currenttest)) Then
                            'FINAL VALS HERE
                            thisTestSavedFinals(currenttest) = True
                        End If

                        If ((currenttest = 6) And (rowused(6)) = False) Then

                            testongoing = False
                            testover = True
                            teststatuslabel2.Text = "Test Over"
                            messagetxtbox.Text = "TEST OVER"
                            'finaldialogbox = True
                        Else
                            'PAUSE CURRENT TEST AND PROMPT USER TO CONTINUE
                            duringwarmup = True
                            currenttest += 1 'goto next test
                            If (Not currenttest = 7) Then
                                While (rowused(currenttest) = False)
                                    If (currenttest = 7) Then
                                        Exit While
                                    Else
                                        currenttest += 1
                                    End If
                                    If (currenttest = 7) Then
                                        Exit While
                                    End If
                                End While
                            End If

                            If (currenttest >= 7) Then
                                'THE TEST IS OVER **********************************
                                testongoing = False
                                testover = True
                                teststatuslabel2.Text = "Test Over"
                                messagetxtbox.Text = "TEST OVER"
                            End If
                            'If (rowused(currenttest) = False) Then
                            '   currenttest += 1
                            'End If
                            If (testongoing) Then
                                warmuptimer = 0  'reset warmup timer
                                Gb_testgo = False
                                Gs_dialogText = "Change Flow Rate to " + CStr(flowratetxtbox(currenttest).Text) + " then press Continue Test"
                                DialogForm.StartPosition = FormStartPosition.CenterScreen
                                DialogForm.ShowDialog()
                            End If

                        End If

                    End If
                    'end if len or newendcurrtest

                End If


            End If
            'End if testongoing
        End If




    End Sub

    Private Sub dp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'MUST DO THIS TO ACCESS OBJECTS BY INDEX
        flowratetxtbox = ControlArrayUtils.getControlArray(Me, "flowratetxtbox", NUM_OF_ROWS)
        endvoltxtbox = ControlArrayUtils.getControlArray(Me, "endvoltxtbox", NUM_OF_ROWS)
        warmuptxtbox = ControlArrayUtils.getControlArray(Me, "warmuptxtbox", NUM_OF_ROWS)
        refpulselabel = ControlArrayUtils.getControlArray(Me, "refpulselabel", NUM_OF_ROWS)
        testpulselabel = ControlArrayUtils.getControlArray(Me, "testpulselabel", NUM_OF_ROWS)
        reftemplabel = ControlArrayUtils.getControlArray(Me, "reftemplabel", NUM_OF_ROWS)
        testtimerlabel = ControlArrayUtils.getControlArray(Me, "testtimerlabel", NUM_OF_ROWS)
        testtemplabel = ControlArrayUtils.getControlArray(Me, "testtemplabel", NUM_OF_ROWS)
        pressureLabel = ControlArrayUtils.getControlArray(Me, "pressureLabel", NUM_OF_ROWS)
        stdVolLabel = ControlArrayUtils.getControlArray(Me, "stdVolLabel", NUM_OF_ROWS)
        xdstdvollabel = ControlArrayUtils.getControlArray(Me, "xdstdvollabel", NUM_OF_ROWS)
        ydifflabel = ControlArrayUtils.getControlArray(Me, "ydifflabel", NUM_OF_ROWS)
        'resTestLabel = ControlArrayUtils.getControlArray(Me, "resTestLabel", NUM_OF_ROWS)

        rs.FindAllControls(Me)
        Get_Registry_Values()

        rs.ResizeAllLastSaved(Me, Gi_Screen_Size_X, Gi_Screen_Size_Y)
        Me.Width = Gi_Screen_Size_X
        Me.Height = Gi_Screen_Size_Y

    End Sub


    Sub Get_Registry_Values()
        Dim sAvailable As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Apex Instruments\DGM_CAL", "Available", Nothing)  'plan to replace DGM_CAL with DGM_CAL

        If sAvailable = Nothing Then
            'Set default

            Gi_Screen_Size_X = SCREEN_SIZE_MIN_X
            Gi_Screen_Size_Y = SCREEN_SIZE_MIN_Y


            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Apex Instruments\DGM_CAL", "Available", True)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Apex Instruments\DGM_CAL", "Last_Comm_Used", Gs_Last_Comm_Used)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Apex Instruments\DGM_CAL", "Last_IP_Used", Gs_Last_IP_Used)

            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Apex Instruments\DGM_CAL", "Screen_Size_X", Gi_Screen_Size_X)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Apex Instruments\DGM_CAL", "Screen_Size_Y", Gi_Screen_Size_Y)

            'SET THE VALS OF unit type and usr std temp
            'and then write
            Gd_usrStdTemp = 20
            Gs_UnitType = "met"
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Apex Instruments\DGM_CAL", "Unit_Type", Gs_UnitType)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Apex Instruments\DGM_CAL", "Usr_std_temp", Gd_usrStdTemp)

            'My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Apex Instruments\DGM_CAL", "Screen_Size_LeakTest_X", Gi_Screen_Size_LeakTest_X)
            'My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Apex Instruments\DGM_CAL", "Screen_Size_LeakTest_Y", Gi_Screen_Size_LeakTest_Y)

            'My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Apex Instruments\DGM_CAL", "Screen_Size_Cal_X", Gi_Screen_Size_Cal_X)
            'My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Apex Instruments\DGM_CAL", "Screen_Size_Cal_Y", Gi_Screen_Size_Cal_Y)

            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Apex Instruments\DGM_CAL", "WTM_Test_Counts", Gi_WTM_Test_Counts)
        Else
            Gs_Last_Comm_Used = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Apex Instruments\DGM_CAL", "Last_Comm_Used", Nothing)
            'TextBox_IP_.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Apex Instruments\DGM_CAL", "Last_IP_Used", Nothing)

            Gi_Screen_Size_X = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Apex Instruments\DGM_CAL", "Screen_Size_X", Nothing)
            Gi_Screen_Size_Y = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Apex Instruments\DGM_CAL", "Screen_Size_Y", Nothing)

            Gs_UnitType = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Apex Instruments\DGM_CAL", "Unit_Type", Nothing)
            Gd_usrStdTemp = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Apex Instruments\DGM_CAL", "Usr_std_temp", Nothing)

            'Gi_Screen_Size_LeakTest_X = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Apex Instruments\DGM_CAL", "Screen_Size_LeakTest_X", Nothing)
            'Gi_Screen_Size_LeakTest_Y = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Apex Instruments\DGM_CAL", "Screen_Size_LeakTest_Y", Nothing)

            'Gi_Screen_Size_Cal_X = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Apex Instruments\DGM_CAL", "Screen_Size_Cal_X", Nothing)
            'Gi_Screen_Size_Cal_Y = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Apex Instruments\DGM_CAL", "Screen_Size_Cal_Y", Nothing)

            'Gi_WTM_Test_Counts = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Apex Instruments\DGM_CAL", "WTM_Test_Counts", Nothing)

            If (Gi_Screen_Size_X < SCREEN_SIZE_MIN_X) Then Gi_Screen_Size_X = SCREEN_SIZE_MIN_X
            If (Gi_Screen_Size_Y < SCREEN_SIZE_MIN_Y) Then Gi_Screen_Size_Y = SCREEN_SIZE_MIN_Y
            'If (Gi_Screen_Size_LeakTest_X < SCREEN_SIZE_LEAKTEST_MIN_X) Then Gi_Screen_Size_LeakTest_X = SCREEN_SIZE_LEAKTEST_MIN_X
            'If (Gi_Screen_Size_LeakTest_Y < SCREEN_SIZE_LEAKTEST_MIN_Y) Then Gi_Screen_Size_LeakTest_Y = SCREEN_SIZE_LEAKTEST_MIN_Y
            'If (Gi_Screen_Size_Cal_X < SCREEN_SIZE_CAL_MIN_X) Then Gi_Screen_Size_Cal_X = SCREEN_SIZE_CAL_MIN_X
            'If (Gi_Screen_Size_Cal_Y < SCREEN_SIZE_CAL_MIN_Y) Then Gi_Screen_Size_Cal_Y = SCREEN_SIZE_CAL_MIN_Y


        End If

    End Sub

    Public Function send_error()
        Dim ErrorForm As New ErrorForm
        ErrorForm.StartPosition = FormStartPosition.CenterScreen
        ErrorForm.ShowDialog()
    End Function
    Private Sub antibugbutton_Click(sender As Object, e As EventArgs)
        Dim antibug As New antibug
        antibug.StartPosition = FormStartPosition.CenterScreen
        antibug.ShowDialog()

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


    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs)
        'If testongoing Then bigtimer += 0.1
    End Sub

    Private Sub refscalingtxtbox_TextChanged(sender As Object, e As EventArgs) Handles refscalingtxtbox.TextChanged

        ''''' usrrefscalingfactor = CDbl(refscalingtxtbox.Text)
    End Sub

    Private Sub continueButton_Click(sender As Object, e As EventArgs)
        Gb_testgo = True
    End Sub

    Public Sub reInitValsBcBadConnection()
        'reset nearly all values? EXCEPT THOSE OF USER INPUT AND USER CONFIG STUFF
    End Sub

    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles btnconnect.Click
        Dim comgo As Boolean = True
        Dim xdcomgo As Boolean = True
        Dim tempcomport As Integer = 1
        Dim comstr As String = "COM"
        Dim refportsodontmesswith As Integer

        'REF CONNECTION ================================================================================================================================

        'don't try do connect if already connected
        If (refport.IsOpen) Then
            refportgood = True
            comgo = False
        End If

        If (Not refportgood) Then
            'ref connection
            While (comgo)
                Try
                    If (tempcomport > 100) Then
                        If (refFailedConnectionCounter > BAD_CONNECTION_LIMIT) Then
                            comgo = False
                            '''''''''ask dad 
                            Exit While ' ????????????
                        Else
                            refFailedConnectionCounter += 1
                            tempcomport = 1
                        End If
                    End If
                    refport.PortName = comstr + CStr(tempcomport)
                    refport.Open()
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
                        Threading.Thread.Sleep(50)
                        If (giveup > 5) Then
                            zgo = False
                        End If
                    End While
                    If (InStr(1, fooinputstr, "Cal-DGM", 1)) Then 'found it!
                        refportgood = True
                        comgo = False
                        refportsodontmesswith = tempcomport
                    End If
                Catch ex As Exception
                    tempcomport += 1
                End Try
            End While
            'end ref
        End If

        'XD502 Connection============================================================================================================

        'don't try to connect if already connected
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

            'XD connection
            While (xdcomgo)
                Try
                    If (tempcomport > 100) Then
                        If (xdFailedConnectionCounter > BAD_CONNECTION_LIMIT) Then
                            xdcomgo = False
                            ''ASK DAD
                            Exit While
                        Else
                            xdFailedConnectionCounter += 1
                            tempcomport = 1
                        End If
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
                        Threading.Thread.Sleep(50)
                        If (giveup > 5) Then
                            zgo = False
                        End If
                    End While
                    'fooinputstr = SerialPort1.ReadExisting()
                    If (InStr(1, fooinputstr, "-502", 1)) Then
                        xdportgood = True
                        xdcomgo = False
                    End If
                Catch ex As Exception
                    tempcomport += 1
                End Try
            End While
            'end xd connection attempts

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
            ''new stuff
            'If (refportgood) Then
            '    Configure.StartPosition = FormStartPosition.CenterScreen
            '    Configure.ShowDialog()
            '    'pop up config screen and prompt for offset val 
            '    'then try to write the val to the esb32
            '    'catch error and give message if that doesn't work
            'End If
            ''end new stuff
            messagetxtbox.Text = "Message: Both ports connected!"
        End If

    End Sub

    Private Sub btnstart_Click(sender As Object, e As EventArgs) Handles btnstart.Click
        'yuh
        testactive = True
        findRunnableTests()

        'newdo ensure refport good before trying to write?
        refport.Write("999" + vbCrLf)
        ''ensure reasonable vals
        'reasonableVals = True
        'For p As Integer = 1 To NUM_OF_ROWS
        '    If (flowratetxtbox(p).Text <> vbNullString) Then
        '        If ((CDbl(flowratetxtbox(p).Text)) < FLOWRATE_MIN_INPUT_METRIC) Then
        '            reasonableVals = False
        '            'flowrate is too low, make it red then send error
        '            flowratetxtbox(p).BackColor = Color.FromArgb(255, 255, 0, 0)
        '            GS_errorText = "FlowRate must be greater than 1.0 Liters todo imperial"
        '            ErrorForm.StartPosition = FormStartPosition.CenterScreen
        '            ErrorForm.ShowDialog()
        '        End If
        '    End If

        'Next

        ''ensure all rows properly filled out
        ''rowNumberCheck
        ''flowratetxtbox
        ''endvoltxtbox
        ''warmuptxtbox
        'rowShouldBeFilled = False
        'Dim Gold, White
        'Gold = RGB(255, 215, 0)
        'White = RGB(255, 255, 255)
        'For n As Integer = 1 To NUM_OF_ROWS ' THIS CONST IS CONFUSING I NEED TO UPDATE THIS

        '    'TODO write loop to make background white if was yellow then good vals are passed through

        '    'check to see if any filled in.  If any ARE filled in , then highlight the boxes that aren't filled in
        '    If (flowratetxtbox(n).Text <> vbNullString Or endvoltxtbox(n).Text <> vbNullString Or warmuptxtbox(n).Text <> vbNullString) Then  'will trigger if any input in the row is filled out
        '        'check to see if any ohters are finished
        '        If (flowratetxtbox(n).Text = vbNullString) Then
        '            flowratetxtbox(n).BackColor = Color.FromArgb(255, 255, 215, 0)
        '            rowShouldBeFilled = True
        '        End If
        '        If (endvoltxtbox(n).Text = vbNullString) Then
        '            endvoltxtbox(n).BackColor = Color.FromArgb(255, 255, 215, 0)
        '            rowShouldBeFilled = True
        '        End If
        '        If (warmuptxtbox(n).Text = vbNullString) Then
        '            warmuptxtbox(n).BackColor = Color.FromArgb(255, 255, 215, 0)
        '            rowShouldBeFilled = True
        '        End If

        '    End If
        'Next

        'If (rowShouldBeFilled) Then
        '    'send error message if filled in poorly
        '    GS_errorText = "Please Ensure all rows are filled out" + vbCrLf + "If one is todo fix this idk lol"
        '    ErrorForm.StartPosition = FormStartPosition.CenterScreen
        '    ErrorForm.ShowDialog()
        'End If
        'rowNumberCheck = 0 ' reset this val
        ''ensure validation or calibration is checked


        ''MAKE THIS CONDITIONAL ON OTHER STUFF
        If (refportgood And xdportgood And (Not rowShouldBeFilled) And reasonableVals And onlyNumsInInput()) Then
            testongoing = True
            duringwarmup = True
            currenttest = 1
            'save inputs to registry HERE
        End If
    End Sub

    Private Sub btnconfig_Click(sender As Object, e As EventArgs) Handles btnconfig.Click
        Dim configure As New Configure
        configure.StartPosition = FormStartPosition.CenterScreen
        configure.ShowDialog()
    End Sub

    Sub Update_Screen_Size()
        Gi_Screen_Size_X = Me.Width
        Gi_Screen_Size_Y = Me.Height
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Apex Instruments\DGM_CAL", "Screen_Size_X", Gi_Screen_Size_X)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Apex Instruments\DGM_CAL", "Screen_Size_Y", Gi_Screen_Size_Y)

        'Do_Round_Buttons()

    End Sub


    Private Sub Main_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        'If Gb_Allow_Size_Adj = False Then Return
        rs.ResizeAllControls(Me)
        'Gi_Resize_Delay = 2
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim sFileName As String

        If (SaveFileDialog1.ShowDialog() = DialogResult.OK) Then
            sFileName = SaveFileDialog1.FileName
            writeToFile(sFileName)
        End If

    End Sub

    Private Sub writeToFile(ByVal sFileName As String)
        Dim stream_writer As IO.StreamWriter
        Dim printable As String = ""
        'MACHINEOFBRUH"
        stream_writer = New IO.StreamWriter(sFileName)
        'FILEWRITER
        'printable &= "foo"
        'printable &= "bruh"
        'runtime, uutinitpulses, uufinalpulses, uuttotalpulses
        Gs_ForXL = ""
        Dim position As Integer = 15

        For cc As Integer = 1 To NUM_OF_ROWS
            position = 15 + cc
            If (rowused(cc)) Then
                printable &= "Test " + CStr(cc) + ", "
                printable &= "Runtime: " + CStr(testtimerlabel(cc).Text) + ", "
                printable &= "UUT Initial Pulses: " + CStr(Math.Round(filuutPulseInit(cc), 0)) + ", "
                printable &= "UUT Final pulses: " + CStr(Math.Round(filuutPulseFinal(cc), 0)) + ", "
                printable &= "UUT Total pulses: " + CStr(Math.Round(filuutPulseFinal(cc), 0)) + ", "
                printable &= "UUT Initial Temperature: " + CStr(Math.Round(filuutInitTemp(cc), 2)) + ", "
                printable &= "UUT Final Temperature: " + CStr(Math.Round(filuutFinalTemp(cc), 2)) + ", "
                printable &= "Pressure: " + CStr(Math.Round(CDbl(pressureLabel(cc).Text), 2)) + ", "
                printable &= "Ref Initial Volume: 0, "
                printable &= "Ref Final Volume: " + CStr(Math.Round(CDbl(refpulselabel(cc).Text), 2)) + ", "
                printable &= "Ref Total Volume: " + CStr(Math.Round(CDbl(refpulselabel(cc).Text), 2)) + ", "
                printable &= "Outlet Initial Temp: " + CStr(filOutletInitTemp(cc)) + ", "
                printable &= "Outlet Final Temp: " + CStr(filOutlsetFinalTemp(cc)) + ", "
                printable &= "Ref Std Volume: " + CStr(stdVolLabel(cc).Text) + ", "
                printable &= "Ref Std Flow Rate: " + CStr(filrefflowrate(cc)) + ", "
                'Dim bruha As String = xdCurrStr
                printable &= "UUT Totalizer: " + CStr(filuutcalcedpulses(cc)) + ", " 'calculated pulse counts for xd
                'scaling factor for WHOMST? XD I ASSUME bruh
                printable &= "Scaling Factor: " + CStr(xdGivenScaling) + ", "
                'std vol for xd
                printable &= "UUT?? Std Volume: " + CStr(testxdstdvol(cc)) + ", "
                'flow rate for xd
                printable &= "UUT Flow Rate: " + CStr((filuutFlowRate(cc))) + ", "    'TODO PUT THIS SOMEWHERE ELSE ALSO THIS NOT WORKING!!
                'y value
                printable &= "Y Value: " + CStr(filVarY(cc)) + ", "
                'variation
                printable &= "Y Variation: " + CStr(filY(cc)) + ", "
                'delta h
                'delta h @

                'todo change all to crlf
                printable &= vbCrLf

                'for XL
                Gs_ForXL &= "B" + CStr(position) + "~" + CStr(testtimerlabel(cc).Text) + vbCrLf
                Gs_ForXL &= "D" + CStr(position) + "~" + CStr(Math.Round(filuutPulseInit(cc), 0)) + vbCrLf
                Gs_ForXL &= "E" + CStr(position) + "~" + CStr(Math.Round(filuutPulseFinal(cc))) + vbCrLf
                Gs_ForXL &= "F" + CStr(position) + "~" + CStr(Math.Round(filuutPulseFinal(cc))) + vbCrLf
                Gs_ForXL &= "G" + CStr(position) + "~" + CStr(Math.Round(filuutInitTemp(cc), 2)) + vbCrLf
                Gs_ForXL &= "H" + CStr(position) + "~" + CStr(Math.Round(filuutFinalTemp(cc), 2)) + vbCrLf
                Gs_ForXL &= "J" + CStr(position) + "~" + CStr(Math.Round(CDbl(pressureLabel(cc).Text), 2)) + vbCrLf
                'skip something????
                Gs_ForXL &= "K" + CStr(position) + "~" + "0" + vbCrLf
                Gs_ForXL &= "L" + CStr(position) + "~" + CStr(Math.Round(CDbl(refpulselabel(cc).Text), 2)) + vbCrLf
                Gs_ForXL &= "M" + CStr(position) + "~" + CStr(Math.Round(CDbl(refpulselabel(cc).Text), 2)) + vbCrLf
                Gs_ForXL &= "N" + CStr(position) + "~" + CStr(filOutletInitTemp(cc)) + vbCrLf
                Gs_ForXL &= "O" + CStr(position) + "~" + CStr(filOutlsetFinalTemp(cc)) + vbCrLf
                'go to bottom stuff
                position += 12
                Gs_ForXL &= "B" + CStr(position) + "~" + CStr(stdVolLabel(cc).Text) + vbCrLf
                Gs_ForXL &= "C" + CStr(position) + "~" + CStr(filrefflowrate(cc)) + vbCrLf
                Gs_ForXL &= "D" + CStr(position) + "~" + CStr(filuutcalcedpulses(cc)) + vbCrLf
                Gs_ForXL &= "E" + CStr(position) + "~" + CStr(xdGivenScaling) + vbCrLf
                Gs_ForXL &= "F" + CStr(position) + "~" + CStr(testxdstdvol(cc)) + vbCrLf
                Gs_ForXL &= "G" + CStr(position) + "~" + CStr((filuutFlowRate(cc))) + vbCrLf
                Gs_ForXL &= "H" + CStr(position) + "~" + CStr(filVarY(cc)) + vbCrLf
                'SKIP I
                Gs_ForXL &= "J" + CStr(position) + "~" + CStr(filY(cc)) + vbCrLf
                'Gs_ForXL &= "J" + CStr(position) + "~" + CStr(filOutlsetFinalTemp(cc)) + vbCrLf
                'Gs_ForXL &= "K" + CStr(position) + "~" + CStr(filOutlsetFinalTemp(cc)) + vbCrLf

                'misc stuff
                'todo: scaling factor avg (E34), correction factor (Y) average (H(34), 


            End If
        Next
        stream_writer.Write(Gs_ForXL)

        stream_writer.Close()
    End Sub

    Private Sub resetOutput()
        'abortion
        nineninecounter = 1
        ''''''''newdo??????xdGivenScaling = 0.0
        '''''kelvinusrstdtemp = 0.0

        zDGM = "notyet"
        Gs_str = "foo"
        intpulsecount = 0
        '''''''''''''' testpulses = New Integer() {1, 2, 3, 4, 5, 6, 7}
        checksum = 0
        backit = 9999

        xdCurrStr = ""
        xdIoStr = ""
        xdParsedCheckStr = ""
        xdParsedCheckInt = 0
        xdStartCheck = 0
        xdEndCheck = 0
        xdGoodData = False
        xdCalculatedCS = 0

        debugstr = ""
        stritt = 1
        isgood = True
        calchecksum = 0
        inputlabel = ""

        inputpressure = ""
        intpressure = 0
        doublepressure = 0.0

        inputambtemp = ""
        intinputambtemp = 0
        intambtemp = 0
        doubleambtemp = 0.0

        inputreftemp = ""
        intreftemp = 0
        doublereftemp = 0.0

        inputambhum = ""
        intambhum = 0
        doubleambhum = 0.0

        inputpulsecount = ""

        intchecksum = 0
        trimmedcrc = ""

        'NO GOODSKI usrrefscalingfactor = 0.0
        numtests = 0

        finaldiabox = False

        '''''''''''thisDate As Date


        'testpulses = New Integer() {0, 0, 0, 0, 0, 0}
        'NO GOODSKItestendvolume = {0, 0, 0, 0, 0, 0, 0}
        'NO GOODSKIwarmuptimes = {0, 0, 0, 0, 0, 0, 0}
        'NO GOODSKItestusrflowrate = {0, 0, 0, 0, 0, 0, 0}

        'NO GOODSKItesttimers = {0, 0, 0, 0, 0, 0, 0}  ' DOUBLEnewdo
        'NO GOODSKItestwarmups = {0, 0, 0, 0, 0, 0, 0}
        'omgwarmuppulses = {0, 0, 0, 0, 0, 0, 0}
        'omgWarmupVols = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        'omgtestreftemp = {0, 0, 0, 0, 0, 0, 0}  'DOUBLE
        'refvols = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        For i = 0 To 6
            warmuppulses(i) = 0
            xdWarmupVols(i) = 0
            testreftemp(i) = 0
            refvols(i) = 0
            pressureArr(i) = 0
            stdrefvols(i) = 0
            endstdrefvols(i) = 0
            testxdtemp(i) = 0
            testxdvol(i) = 0
            testxdstdvol(i) = 0
            hypotheticaltestxdstdvol(i) = 0
            newY(i) = 0
            experimentY(i) = 0
            filTestTime(i) = 0
            filOrrifice(i) = 0
            filuutPulseFinal(i) = 0
            filuutPulseTotal(i) = 0
            filuutInitTemp(i) = 0
            filuutFinalTemp(i) = 0
            filrefStdInitVol(i) = 0
            filrefStdFinalVol(i) = 0
            filrefStdTotalVol(i) = 0
            filrefInitVol(i) = 0
            filrefFinalVol(i) = 0
            filrefTotalVol(i) = 0
            filOutletInitTemp(i) = 0
            filOutlsetFinalTemp(i) = 0
            filrefflowrate(i) = 0
            filuutFlowRate(i) = 0
            filuutPulseInit(i) = 0
            'oldCurrTest = 1
            filuutcalcedpulses(i) = 0
            filY(i) = 0
            filVarY(i) = 0
            forPreciseRefVols(i) = 0
            forPreciseXdVols(i) = 0
            pulsesForESB(i) = 0
            xdWarmUpPulses(i) = 0
            xdInPulses(i) = 0
        Next
        'omgpressureArr = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        'omgstdrefvols = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        'omgendstdrefvols = {0, 0, 0, 0, 0, 0, 0} ' DOUBLEE

        rowused = {False, False, False, False, False, False, False} ' BOOLEANS

        'omgtestxdtemp = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        'omgtestxdvol = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        'omgtestxdstdvol = {0, 0, 0, 0, 0, 0, 0} 'DOUBLE
        'omghypotheticaltestxdstdvol = {0, 0, 0, 0, 0, 0, 0} 'DOUBLE
        avghypotheticalxd = 0.0 'newdo idk if this should be


        'FILE STUFF
        'omgnewY = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        'omgexperimentY = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        'omgfilTestTime = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        'omgfilOrrifice = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        'omgfiluutPulseFinal = {0, 0, 0, 0, 0, 0, 0}
        'omgfiluutPulseTotal = {0, 0, 0, 0, 0, 0, 0}
        'omgfiluutInitTemp = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        'omgfiluutFinalTemp = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        'omgfilrefStdInitVol = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        'omgfilrefStdFinalVol = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        'omgfilrefStdTotalVol = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE

        'meter pressure?
        'omgfilrefInitVol = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        'omgfilrefFinalVol = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        'omgfilrefTotalVol = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        'omgfilOutletInitTemp = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        'omgfilOutlsetFinalTemp = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        'omgfilrefflowrate = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        'ayoo
        xdflowrate = 0.0 'newdo

        'omgfiluutFlowRate = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        thisTestSavedInits = {False, False, False, False, False, False, False}
        thisTestSavedFinals = {False, False, False, False, False, False, False}

        'omgfiluutPulseInit = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        oldCurrTest = 1
        'omgfiluutcalcedpulses = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        'omgfilY = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        'omgfilVarY = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        'omgforPreciseRefVols = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        'omgforPreciseXdVols = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE

        hasSentCurrPulses = {False, False, False, False, False, False, False} 'BOOLEAN
        'omgpulsesForESB = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE

        didItPass = False

        'END FILE STUFF
        currenttest = 1
        duringwarmup = False

        bigtimer = 0.0

        testover = False
        testongoing = False
        warmuptimer = 0.0

        hasCalculatedAfterTest = False
        continueButtonAvailable = False
        'Gb_testgo As Boolean = True


        ourcs = 0
        ourcsitr = 0
        refcrcstr = ""
        refcrcint = 0


        xdInputVol = 0.0
        xdInputTemp = 0.0
        xdDate = ""

        avgStdRefVolPostTest = 0.0
        avgStdTestVolPostTest = 0.0
        processingDone = False
        havesScalingFactor = False
        'givenxdScaling As Double = 0.0
        goodOldRefTemp = 0



        'inputlabel, inputpressure, doublepressure, inputambtemp, inputreftemp, inputambhum, 
        s_ref_in(REF_MAX_MEMBERS) = ""
        zrefinputlabel = ""
        zrefinputpressure = ""
        zrefinputambtemp = ""
        zrefinputreftemp = ""
        zrefinputambhum = ""
        weNeedPulseCountxd = False
        xdpulseholder = 0
        toEsbPulses = 0

        'omgxdWarmUpPulses = {0, 0, 0, 0, 0, 0, 0}
        'omgxdInPulses = {0, 0, 0, 0, 0, 0, 0}

        s_xd_in(XD_MAX_MEMBERS) = ""
        gooddata = True
        'refportgood = False
        'xdportgood = False


        consecBadCSVals = 0
        consecBadCRCVals = 0

        refFailedConnectionCounter = 0
        xdFailedConnectionCounter = 0

        rowNumberCheck = 1

        rowShouldBeFilled = False
        reasonableVals = True

        numRealTests = 0

        debugAbort = False

        xdthisinputtype = ""


        'for a private sub
        fooflowrate = 0.0
        fooendvol = 0.0
        foowarmup = 0.0
        shouldendonlynum = False
        percentoffnew = 0.0
        intpulseholder = 0
        newendcurrtest = False
        forStringVol = ""
        checkingDelay = 0
        testactive = False

        For aa = 1 To NUM_OF_ROWS
            'ref-------------------------
            refpulselabel(aa).Text = 0
            testtimerlabel(aa).Text = 0
            reftemplabel(aa).Text = 0
            pressureLabel(aa).Text = 0
            stdVolLabel(aa).Text = 0


            'dgm --------------------------
            testtemplabel(aa).Text = 0
            testpulselabel(aa).Text = 0
            xdstdvollabel(aa).Text = 0
        Next

    End Sub

    Private Sub btnabort_Click(sender As Object, e As EventArgs) Handles btnabort.Click
        resetOutput() 'this is putting me at the wrong currNum
        Get_Registry_Values()


        'TODO RESET ALL VALS AND STUFF
        'Me.Close()
    End Sub

    Private Sub toFileButton_Click(sender As Object, e As EventArgs) Handles toFileButton.Click
        Dim sFileName As String

        'If (SaveFileDialog1.ShowDialog() = DialogResult.OK) Then
        '    sFileName = SaveFileDialog1.FileName

        '    writeToFile(sFileName)
        'End If
        writeToFile("certificate.txt")
    End Sub

    Private Function onlyNumsInInput() As Boolean
        fooflowrate = 0.0
        fooendvol = 0.0
        foowarmup = 0.0
        If (Not shouldendonlynum) Then
            For dd As Integer = 1 To NUM_OF_ROWS
                Try
                    usrrefscalingfactor = CDbl(refscalingtxtbox.Text)
                    fooflowrate = CDbl(flowratetxtbox(dd).Text)
                    fooendvol = CDbl(endvoltxtbox(dd).Text)
                    foowarmup = CDbl(warmuptxtbox(dd).Text)
                Catch ex As Exception
                    dd += NUM_OF_ROWS
                    shouldendonlynum = True
                    'todo highlight the problem children newdo
                    'send error form
                    GS_errorText = "Only Use Number in Input"
                    ErrorForm.StartPosition = FormStartPosition.CenterScreen
                    ErrorForm.ShowDialog()
                    'Return
                End Try
            Next
            If (shouldendonlynum) Then
                shouldendonlynum = False
                Return False
            Else
                shouldendonlynum = False
                Return True
            End If

        End If


    End Function

    Public Sub Tx_2_Console(sCommand As String, sValue As String)
        Dim sTemp As String
        Dim sCS As String
        Dim iCS As Integer
        Dim i As Integer
        sTemp = sCommand & sValue & " "
        iCS = 0
        For i = 1 To Len(sTemp)

            iCS += Asc(Mid(sTemp, i, 1))

        Next
        While iCS > 9999

            iCS -= 10000

        End While
        sCS = CStr(iCS)
        While Len(sCS) < 4

            sCS = "0" & sCS

        End While

        sTemp = sBLOCK_START & sTemp & BLOCK_MARKER_CS & sCS & vbCrLf
        'Gs_TXed = sTemp
        'Gi_Tx_Elapse = 0
        'Gs_TX_Debug = sTemp
        Try
            xd502port.Write(sTemp)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub requestCalibration()
        'Public Sub Tx_2_Console(sCommand As String, sValue As String)
        Tx_2_Console("C", "2")
    End Sub

    Private Sub requestRaw()
        Tx_2_Console("V", "2")
    End Sub

    Private Sub btncert_Click(sender As Object, e As EventArgs) Handles btncert.Click
        certForm.StartPosition = FormStartPosition.CenterScreen
        certForm.ShowDialog()
    End Sub

    Private Sub genUpdateForXL()
        thisDate = Today
        Dim zposition As Integer = 15
        updateExpY()
        Gs_ForXL = ""
        'Gs_ForXL &= "Date: " + Today + vbCrLf
        'Gs_ForXL &= "Time: " + CStr(newmainclock.Text) + vbCrLf
        For cc As Integer = 1 To NUM_OF_ROWS
            zposition = 15 + cc
            If (rowused(cc)) Then


                'for XL
                Gs_ForXL &= "B" + CStr(zposition) + "~" + CStr(testtimerlabel(cc).Text) + vbCrLf
                Gs_ForXL &= "D" + CStr(zposition) + "~" + CStr(Math.Round(filuutPulseInit(cc), 0)) + vbCrLf
                Gs_ForXL &= "E" + CStr(zposition) + "~" + CStr(Math.Round(filuutPulseFinal(cc))) + vbCrLf
                Gs_ForXL &= "F" + CStr(zposition) + "~" + CStr(Math.Round(filuutPulseFinal(cc))) + vbCrLf
                Gs_ForXL &= "G" + CStr(zposition) + "~" + CStr(Math.Round(filuutInitTemp(cc), 2)) + vbCrLf
                Gs_ForXL &= "H" + CStr(zposition) + "~" + CStr(Math.Round(filuutFinalTemp(cc), 2)) + vbCrLf
                Gs_ForXL &= "J" + CStr(zposition) + "~" + CStr(Math.Round(CDbl(pressureLabel(cc).Text), 2)) + vbCrLf
                'skip something????
                Gs_ForXL &= "K" + CStr(zposition) + "~" + "0" + vbCrLf
                Gs_ForXL &= "L" + CStr(zposition) + "~" + CStr(Math.Round(CDbl(refpulselabel(cc).Text), 2)) + vbCrLf
                Gs_ForXL &= "M" + CStr(zposition) + "~" + CStr(Math.Round(CDbl(refpulselabel(cc).Text), 2)) + vbCrLf
                Gs_ForXL &= "N" + CStr(zposition) + "~" + CStr(filOutletInitTemp(cc)) + vbCrLf
                Gs_ForXL &= "O" + CStr(zposition) + "~" + CStr(filOutlsetFinalTemp(cc)) + vbCrLf
                'go to bottom stuff
                zposition += 12
                Gs_ForXL &= "B" + CStr(zposition) + "~" + CStr(stdVolLabel(cc).Text) + vbCrLf
                Gs_ForXL &= "C" + CStr(zposition) + "~" + CStr(filrefflowrate(cc)) + vbCrLf
                Gs_ForXL &= "D" + CStr(zposition) + "~" + CStr(filuutcalcedpulses(cc)) + vbCrLf
                Gs_ForXL &= "E" + CStr(zposition) + "~" + CStr(xdGivenScaling) + vbCrLf
                Gs_ForXL &= "F" + CStr(zposition) + "~" + CStr(testxdstdvol(cc)) + vbCrLf
                Gs_ForXL &= "G" + CStr(zposition) + "~" + CStr((filuutFlowRate(cc))) + vbCrLf
                Gs_ForXL &= "H" + CStr(zposition) + "~" + CStr(filVarY(cc)) + vbCrLf
                'SKIP I
                Gs_ForXL &= "J" + CStr(zposition) + "~" + CStr(filY(cc)) + vbCrLf
                '**********SOMEWHERE HERE TRY experimentY(cc)******************
                '''''''''''Gs_ForXL &= "TESTY: " + CStr(experimentY(cc)) + vbCrLf

                'Gs_ForXL &= "J" + CStr(position) + "~" + CStr(filOutlsetFinalTemp(cc)) + vbCrLf
                'Gs_ForXL &= "K" + CStr(position) + "~" + CStr(filOutlsetFinalTemp(cc)) + vbCrLf


            End If
        Next
        'misc stuff
        'todo: scaling factor avg (E34), correction factor (Y) average (H(34),
        If ((CDbl(percenterrorreallbl.Text.Replace("%", "")) < 5.0) And (CDbl(percenterrorreallbl.Text.Replace("%", "")) > -5.0)) Then
            'test passes
            Gs_ForXL &= "O" + CStr(31) + "~" + "PASS" + vbCrLf
        Else
            Gs_ForXL &= "O" + CStr(31) + "~" + "FAIL" + vbCrLf

        End If

        If (Gs_UnitType = "met") Then
            kelvinusrstdtemp = Gd_usrStdTemp + 273.15
        Else
            If (Gs_UnitType = "imp") Then
                kelvinusrstdtemp = conversions.convertFarToCel(Gd_usrStdTemp) + 273.15
            End If
        End If
        kelvinusrstdtemp = Math.Round(kelvinusrstdtemp, 2)
        Gs_ForXL &= "J6~" + CStr(kelvinusrstdtemp) + vbCrLf

        'TODO GIVE UPDATED SCALING FACTOR
        Gs_ForXL &= "O35~" + CStr(Math.Round(CDbl(avglabel33.Text), 7)) + vbCrLf
    End Sub

    Private Sub updateExpY()
        For zz As Integer = 1 To NUM_OF_ROWS
            experimentY(zz) = newY(zz) / xdGivenScaling * (Math.Round((avgStdRefVolPostTest / avghypotheticalxd), 7))
            experimentY(zz) = Math.Round(experimentY(zz), 4)
        Next
    End Sub

    Private Sub fastertimer_Tick(sender As Object, e As EventArgs) Handles fastertimer.Tick
        'Dim permy As Integer = 0
        'lblfrom_esb.Text = "Timer: " + CStr(inputambhum) + vbCrLf + "pulses: "
        'If Not (intinputambtemp = 0) Then
        '    lblfrom_esb.Text = "Timer: " + CStr(inputambhum) + vbCrLf + "pulses: " + CStr(inputambtemp) ' BREAKPOINT THIS PROBLEM CHILD
        'Else
        '    lblfrom_esb.Text = "Timer: " + CStr(inputambhum) + vbCrLf + "pulses: nah"
        'End If

        lblfrom_esb.Text = "Timer: " + CStr(inputambhum) + vbCrLf + "ambhum: " + CStr(inputambtemp)


    End Sub

    Private Sub button_debug_Click(sender As Object, e As EventArgs) Handles button_debug.Click
        refport.Write("999" + vbCrLf)
        'MAKE THIS HAPPEN AUTOMATICALLY INSTEAD OF BY BUTTON
        'ALSO MAKE IT BE A REAL END CONDITIONn
    End Sub

End Class