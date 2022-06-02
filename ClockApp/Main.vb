Public Class Main

    Dim rs As New Resizer 'TODO MORE OF THIS ALSO WRITE TO REGISTRY

    Const NUM_OF_ROWS As Integer = 6

    Const REF_INPUT_LABEL As Integer = 1
    Const REF_INPUT_PRESSURE As Integer = 2
    Const REF_AMB_TEMP As Integer = 3
    Const REF_METER_TEMP As Integer = 4
    Const REF_AMB_HUM As Integer = 5
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

    Dim intchecksum As Integer
    Dim trimmedcrc As String = ""

    Dim usrrefscalingfactor As Double
    Dim numtests As Integer

    Dim finaldiabox As Boolean = False

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
    Dim endstdrefvols = New Double() {0, 0, 0, 0, 0, 0, 0} ' DOUBLE

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



    'inputlabel, inputpressure, doublepressure, inputambtemp, inputreftemp, inputambhum, 
    Dim s_ref_in(REF_MAX_MEMBERS) As String
    Dim zrefinputlabel As String
    Dim zrefinputpressure As String
    Dim zrefinputambtemp As String
    Dim zrefinputreftemp As String
    Dim zrefinputambhum As String
    Dim weNeedPulseCountxd As Boolean = False
    Dim xdpulseholder As Integer = 0

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
        inputreftemp = CInt(s_ref_in(REF_METER_TEMP))
        inputambhum = CInt(s_ref_in(REF_AMB_HUM))
        intpulsecount = CInt(s_ref_in(REF_PULSECOUNT))
        Gs_inputchecksum = s_ref_in(REF_CHECKSUM)
    End Sub

    Public Sub xdUpdateVals()
        Dim aaa = xdCurrStr
        xdInputVol = CDbl(s_xd_in(XD_IN_VOL))
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
        If Gb_Update_Screen_Size Then
            Gb_Update_Screen_Size = False
            Update_Screen_Size()
        End If

        'diable inputs if test ongoing
        disableButtons()

        'check to see if we have scaling factor
        If (Not havesScalingFactor) Then
            requestCalibration()
            'loop this !
        End If

        If (weNeedPulseCountxd) Then
            requestRaw()
        End If

        'update label units based on unit type
        If (Gs_UnitType = "met") Then
            Label7.Text = "Ref Meter" + vbCrLf + "Volume" + vbCrLf + "(Litres)"
            Label8.Text = "Std Ref" + vbCrLf + "Volume" + vbCrLf + "(Litres)"
            Label9.Text = "Test Meter" + vbCrLf + "Volume" + vbCrLf + "(Litres)"
            Label10.Text = "Std Test" + vbCrLf + "Volume" + vbCrLf + "(Litres)"
            Label11.Text = "Ref Meter" + vbCrLf + "Temp" + vbCrLf + "(°C)"
            Label12.Text = "Test Meter" + vbCrLf + "Temp" + vbCrLf + "(°C)"
            pressureLabel0.Text = "Pressure" + vbCrLf + "(mmHg)"
        Else
            If (Gs_UnitType = "imp") Then
                Label7.Text = "Volume" + vbCrLf + "(Cu Ft.)"
                Label8.Text = "Volume" + vbCrLf + "(Cu. Ft.)"
                Label9.Text = "Volume" + vbCrLf + "(Cu. Ft.)"
                Label10.Text = "Volume" + vbCrLf + "(Cu. Ft)"
                Label11.Text = "Temp" + vbCrLf + "(°F)"
                Label12.Text = "Temp" + vbCrLf + "(°F)"
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
            refpulselabel(currenttest).Text = CStr(refvols(currenttest))
            testtimerlabel(currenttest).Text = CStr(testtimers(currenttest))
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
                    If ((currenttest = 2) And warmuptimer > 3.0) Then
                        Dim bruh2 As Integer = 5
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

                    'ref stuff ------------------
                    testtimers(currenttest) += 0.1
                    testtimers(currenttest) = Math.Round(testtimers(currenttest), 2)
                    testpulses(currenttest) = intpulsecount - warmuppulses(currenttest)
                    refvols(currenttest) = (testpulses(currenttest) * usrrefscalingfactor)
                    testreftemp(currenttest) = Math.Round(conversions.cIntToDouble(inputreftemp), 2)
                    pressureArr(currenttest) = Math.Round(conversions.cIntToDouble(intpressure), 2)
                    refvols(currenttest) = Math.Round((testpulses(currenttest) * usrrefscalingfactor), 2)
                    'SOME ABSOLUTE CRAZINESS
                    '''testreftemp(currenttest) = testxdtemp(currenttest)
                    stdrefvols(currenttest) = Math.Round(conversions.standardize(refvols(currenttest), testreftemp(currenttest), pressureArr(currenttest)), 2) ' DO I NEED DIFF VALS FOR THIS *********************

                    'xd stuff --------------------
                    testxdtemp(currenttest) = Math.Round(xdInputTemp, 2) 'COMES IN AS FARENHEIT, I WILL DEFAULT CONVERT TO CELSIUS
                    ' If (units = celsius)
                    '''testxdtemp(currenttest) = Math.Round(conversions.convertFarToCel(testxdtemp(currenttest)), 2)
                    'AGAIN, THIS MAKES IT CELSIUS
                    testxdvol(currenttest) = Math.Round((xdInputVol - xdWarmupVols(currenttest)), 2)
                    testxdstdvol(currenttest) = Math.Round(conversions.standardize(testxdvol(currenttest), testxdtemp(currenttest), pressureArr(currenttest)), 2)
                    hypotheticaltestxdstdvol(currenttest) = Math.Round(testxdvol(currenttest) / xdGivenScaling)
                    filuutFlowRate(currenttest) = Math.Round((testxdstdvol(currenttest) * 60 / testtimers(currenttest)), 3)
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
                    filVarY(currenttest) = Math.Round((1 / forPreciseRefVols(currenttest)) * forPreciseXdVols(currenttest), 4)
                    filY(currenttest) = Math.Round(filVarY(currenttest) - 1, 4)

                    filuutcalcedpulses(currenttest) = Math.Round((testxdstdvol(currenttest) * 1000 * xdGivenScaling), 0)


                    'IF IMPERIAL------------------------------------------
                    If (Gs_UnitType = "imp") Then
                        testreftemp(currenttest) = Math.Round((conversions.convertCelToFar(testreftemp(currenttest))), 2)   'convert cel to far
                        testxdtemp(currenttest) = Math.Round((conversions.convertCelToFar(testxdtemp(currenttest))), 2)     'convert cel to far
                        pressureArr(currenttest) = Math.Round((pressureArr(currenttest) / 25.4), 2)     'mmHg to inchesHg
                        refvols(currenttest) = Math.Round((refvols(currenttest) / 28.317), 2)     'litres to cubic feet
                        testxdvol(currenttest) = Math.Round((testxdvol(currenttest) / 28.317), 2)     'litres to cubic feet
                        stdrefvols(currenttest) = Math.Round(conversions.standardize(refvols(currenttest), testreftemp(currenttest), pressureArr(currenttest)), 2)
                        testxdstdvol(currenttest) = Math.Round(conversions.standardize(testxdvol(currenttest), testxdtemp(currenttest), pressureArr(currenttest)), 2)
                        hypotheticaltestxdstdvol(currenttest) = Math.Round((testxdstdvol(currenttest) / xdGivenScaling), 2)
                        filuutFlowRate(currenttest) = Math.Round((filuutFlowRate(currenttest) / 28.317), 3)
                        filrefflowrate(currenttest) = Math.Round((filrefflowrate(currenttest) / 28.317), 3)
                        filuutcalcedpulses(currenttest) = Math.Round((testxdstdvol(currenttest) * 1000 * xdGivenScaling / 28.317), 0) ' THIS CONVERSION WEIRD !!!!$#%@QLK#$FSDLKH litres to cu ft
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
                        newY(currenttest) = Math.Round((forPreciseRefVols(currenttest) / forPreciseXdVols(currenttest)), 4)
                        ydifflabel(currenttest).Text = CStr(filVarY(currenttest))
                        Dim bruhz As Double = newY(currenttest)
                        'save init vals
                    End If

                    'check for end condition off of pulses/volume
                    'go to next test
                    If (refvols(currenttest) > CDbl(endvoltxtbox(currenttest).Text)) Then
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


                        ''endstdrefvols(currenttest) = CDbl(stdVolLabel(currenttest).Text)
                        ''endlabel3.Text = CStr(endstdrefvols(currenttest))
                        'SAVE FINAL VALS HERE*****************CERTIFICATION*************************************
                        filTestTime(currenttest) = testtimers(currenttest)
                        filuutFinalTemp(currenttest) = testxdtemp(currenttest)
                        filOutlsetFinalTemp(currenttest) = testreftemp(currenttest)
                        'filrefFinalVol(currenttest) = xdpulseholder
                        'filrefTotalVol(currenttest) = xdpulseholder
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
        usrrefscalingfactor = CDbl(refscalingtxtbox.Text)
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
            messagetxtbox.Text = "Message: Both ports connected!"
        End If
    End Sub

    Private Sub btnstart_Click(sender As Object, e As EventArgs) Handles btnstart.Click

        findRunnableTests()
        ''ensure reasonable vals
        'reasonableVals = True
        'For p As Integer = 1 To NUM_OF_ROWS
        '    If (flowratetxtbox(p).Text <> vbNullString) Then
        '        If ((CDbl(flowratetxtbox(p).Text)) < FLOWRATE_MIN_INPUT_METRIC) Then
        '            reasonableVals = False
        '            'flowrate is too low, make it red then send error
        '            flowratetxtbox(p).BackColor = Color.FromArgb(255, 255, 0, 0)
        '            GS_errorText = "FlowRate must be greater than 1.0 Litres todo imperial"
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
        testtimers = {0, 0, 0, 0, 0, 0, 0}  ' DOUBLE
        testwarmups = {0, 0, 0, 0, 0, 0, 0}
        warmuppulses = {0, 0, 0, 0, 0, 0, 0}
        xdWarmupVols = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        testreftemp = {0, 0, 0, 0, 0, 0, 0}  'DOUBLE
        refvols = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        pressureArr = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        stdrefvols = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        endstdrefvols = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        testxdtemp = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        testxdvol = {0, 0, 0, 0, 0, 0, 0} ' DOUBLE
        testxdstdvol = {0, 0, 0, 0, 0, 0, 0} 'DOUBLE
        currenttest = 1
        testongoing = False
        testover = False
        duringwarmup = True
        Gb_testgo = True
        debugAbort = True
        warmuptimer = 0

        For aa As Integer = 1 To NUM_OF_ROWS
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
                    fooflowrate = CDbl(flowratetxtbox(dd).Text)
                    fooendvol = CDbl(endvoltxtbox(dd).Text)
                    foowarmup = CDbl(warmuptxtbox(dd).Text)
                Catch ex As Exception
                    dd += NUM_OF_ROWS
                    shouldendonlynum = True
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
        Dim zposition As Integer = 15
        updateExpY()
        Gs_ForXL = ""
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

                'Gs_ForXL &= "J" + CStr(position) + "~" + CStr(filOutlsetFinalTemp(cc)) + vbCrLf
                'Gs_ForXL &= "K" + CStr(position) + "~" + CStr(filOutlsetFinalTemp(cc)) + vbCrLf

                'misc stuff
                'todo: scaling factor avg (E34), correction factor (Y) average (H(34),
            End If
        Next

    End Sub

    Private Sub updateExpY()
        For zz As Integer = 1 To NUM_OF_ROWS
            experimentY(zz) = newY(zz) / xdGivenScaling * (Math.Round((avgStdRefVolPostTest / avghypotheticalxd), 7))
            experimentY(zz) = Math.Round(experimentY(zz), 4)
        Next
    End Sub
End Class