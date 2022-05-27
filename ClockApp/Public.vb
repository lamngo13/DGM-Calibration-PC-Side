

Imports System.IO

Module _Public

    Public iAccum As UInt16 = &HFFFF
    Public Gs_currstr As String
    Public Gs_inputchecksum As String
    Public Gi_inttrimmedcrc As Integer
    Public Gs_tempunits As String = "Celsius"
    Public testpulses = New Integer() {0, 0, 0, 0, 0, 0, 0}
    Public usrStdTemp As Double = 20 ' 20 degrees celsius
    Public usrStdPressure As Double = 760 '760 mmHg
    Public Gb_testgo As Boolean = True
    Public Gs_dialogText As String
    'dim numbers = New Integer()


    Public crc_table = New UInteger() {&H0, &H1021, &H2042, &H3063, &H4084, &H50A5, &H60C6, &H70E7, &H8108, &H9129, &HA14A, &HB16B,
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






    Public flowratetxtbox() As TextBox
    Public endvoltxtbox() As TextBox
    Public warmuptxtbox() As TextBox
    Public reftemplabel() As Label
    Public refpulselabel() As Label
    Public testpulselabel() As Label
    Public testtimerlabel() As Label
    Public testtemplabel() As Label
    Public pressureLabel() As Label
    Public stdVolLabel() As Label
    Public xdstdvollabel() As Label
    Public resTestLabel() As Label

    Public Gi_BL_Debug As Integer = 0

    Public Class ControlArrayUtils

        'Converts same type of controls on a form to a control array by using the notation ControlName_1, ControlName_2, where the _ can be replaced by any separator string
        Public Shared Function getControlArray(ByVal frm As Object, ByVal controlName As String, ByRef i_Radio_Button_Group_Count As Integer, Optional ByVal separator As String = "") As System.Array
            Dim i As Short
            Dim startOfIndex As Short
            Dim alist As New ArrayList
            Dim controlType As System.Type

            Dim ctl As System.Windows.Forms.Control
            Dim strSuffix As String
            Dim maxIndex As Short = -1           'Default

            'Loop through all controls, looking for controls with the matching name pattern
            'Find the highest indexed control
            'For Each ctl In frm.Controls

            controlType = Nothing

            Dim debug_count As Integer = 0

            For Each ctl In frm.Controls
                debug_count += 1
                startOfIndex = ctl.Name.ToLower.IndexOf(controlName.ToLower)
                If startOfIndex = 0 Then
                    strSuffix = ctl.Name.Substring(controlName.Length)
                    If IsInteger(strSuffix) Then                      'Check that the suffix is an integer (index of the array)
                        If Val(strSuffix) > maxIndex Then maxIndex = Val(strSuffix) 'Find the highest indexed Element
                    End If
                End If
            Next ctl

            'Add to the list of controls in correct order
            i_Radio_Button_Group_Count = 0

            If maxIndex > -1 Then
                For i = 0 To maxIndex
                    Dim aControl As Control = getControlFromName(frm, controlName, i, separator)
                    If Not (aControl Is Nothing) Then
                        controlType = aControl.GetType                        'Save the object Type (uses the last control found as the Type)
                        i_Radio_Button_Group_Count += 1
                    End If
                    alist.Add(aControl)
                Next
            End If

            Return alist.ToArray(controlType)



        End Function



        Public Shared Function IsInteger(ByVal Value As String) As Boolean

            If Value = "" Then Return False

            For Each chr As Char In Value
                If Not Char.IsDigit(chr) Then
                    Return False
                End If
            Next
            Return True
        End Function

        Public Shared Function getControlFromName(ByRef frm As Object, ByVal controlName As String, ByVal index As Short, ByVal separator As String) As System.Windows.Forms.Control

            controlName = controlName & separator & index
            For Each ctl As Control In frm.Controls
                If String.Compare(ctl.Name, controlName, True) = 0 Then
                    Return ctl
                End If
            Next ctl

            Return Nothing            'Could not find this control by name

        End Function



    End Class

    Public Class conversions
        Public Shared Function cIntToDouble(thein As Integer) As Double ' why can't I share this
            Dim returnable As Double
            returnable = thein
            returnable /= 100
            Return returnable
        End Function

        Public Shared Function convertCelToFar(theval As Double) As Double
            theval *= 1.8
            theval += 32
            Return theval
        End Function

        Public Shared Function convertFarToCel(theVal As Double) As Double
            Dim returnable As Double
            theVal -= 32
            returnable = (theVal * (5 / 9))
            Return returnable
        End Function

        Public Shared Function standardize(invol As Double, inTemp As Double, inPressure As Double, inUnits As String) As Double
            Dim returnable As Double
            Dim tempusrStdTemp
            'Volume * (stdtemp/measuredtemp) * (measuredpressure/stdpressure)
            If (inUnits = "Cel") Then
                inTemp += 273.15
                tempusrStdTemp = usrStdTemp + 273.15
                returnable = (invol * (tempusrStdTemp / inTemp) * (usrStdPressure / inPressure))
            End If
            'MAYBE WRONG GOTTA CHECK THIS
            'returnable = (invol * (usrStdTemp / inTemp) * (usrStdPressure / inPressure))
            Return returnable

        End Function

        Public Shared Function roundDouble(inDouble As Double)

        End Function

    End Class


End Module




