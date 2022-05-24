

Imports System.IO

Module _Public
    Public Const NUM_OF_ROWS As Integer = 5

    Public Gs_str As String = "foo"
    Public maintimer As Double
    Public warmuptimer As Double
    Public currenttest As String
    Public duringwarmup As Boolean = False
    Public testrecord As Boolean = False
    Public startpressed As Boolean = False
    Public test1time As Double
    Public test1pulses As Integer
    Public testover As Boolean = False
    Public testongoing As Boolean = False
    Public bigtimer As Double
    Public pulsecountduringwarmup As Integer

    'text boxes
    Public test1usrflowrate As Integer
    Public G_testusrflowrate(NUM_OF_ROWS) As Integer ' this is good
    Public test2usrflowrate As Integer
    Public test3usrflowrate As Integer
    Public test4usrflowrate As Integer
    Public test5usrflowrate As Integer
    Public test6usrflowrate As Integer

    Public test1usrendvol As Double
    Public test2usrendvol As Double
    Public test3usrendvol As Double
    Public test4usrendvol As Double
    Public test5usrendvol As Double
    Public test6usrendvol As Double

    Public test1usrwarmup As Double
    Public test2usrwarmup As Double
    Public test3usrwarmup As Double
    Public test4usrwarmup As Double
    Public test5usrwarmup As Double
    Public test6usrwarmup As Double




    Public flowratetxtbox() As TextBox
    Public reftemplabel() As Label

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
End Module




