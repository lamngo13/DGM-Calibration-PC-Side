﻿Public Class Configure
    Private Sub configconfirmbutton_Click(sender As Object, e As EventArgs) Handles configconfirmbutton.Click
        If ((fahrenheitradiobutton.Checked = False) And celsiusradiobutton.Checked = False) Then
            GS_errorText = "choose a unit type"
            ErrorForm.ShowDialog()
        Else
            If (usrstdtemptxtbox.Text = vbNullString) Then
                GS_errorText = "enter a standard temp"
                ErrorForm.ShowDialog()
            Else
                Try
                    Gd_usrStdTemp = CDbl(usrstdtemptxtbox.Text)
                    'save Gs_unittype to registry
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Apex Instruments\DGM_CAL", "Unit_Type", Gs_UnitType)
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Apex Instruments\DGM_CAL", "Usr_std_temp", Gd_usrStdTemp)
                    Me.Close()

                Catch ex As Exception
                    GS_errorText = "enter a number"
                    ErrorForm.ShowDialog()
                End Try
                'Me.Close()
            End If
        End If
        '    Me.Close()
        'ErrorForm.ShowDialog()
        'GS_errorText = "stuff"
    End Sub

    Private Sub fahrenheitradiobutton_CheckedChanged(sender As Object, e As EventArgs) Handles fahrenheitradiobutton.CheckedChanged
        If (fahrenheitradiobutton.Checked = True) Then
            Gs_tempunits = "Fahrenheit"
            Gs_UnitType = "imp"
        End If


    End Sub

    Private Sub celsiusradiobutton_CheckedChanged(sender As Object, e As EventArgs) Handles celsiusradiobutton.CheckedChanged
        If (celsiusradiobutton.Checked = True) Then
            Gs_tempunits = "Celsius"
            Gs_UnitType = "met"
        End If

    End Sub

    Private Sub Configure_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ErrorForm As New ErrorForm
        ErrorForm.StartPosition = FormStartPosition.CenterScreen
        tempoffsetlabel1.Text = CStr(Gd_Ref_Offset)
        If (tempoffsetlabel1.Text.Length < 2) Then
            'make it yellow
            tempoffsetlabel1.BackColor = Color.FromArgb(255, 200, 200, 0)
        Else
            'make it white
            tempoffsetlabel1.BackColor = Color.FromArgb(255, 255, 255, 255)
        End If
    End Sub

    Private Sub restoredefaultsbutton_Click(sender As Object, e As EventArgs) Handles restoredefaultsbutton.Click
        Gs_UnitType = "met"
        Gd_usrStdTemp = 20
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Apex Instruments\DGM_CAL", "Unit_Type", Gs_UnitType)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Apex Instruments\DGM_CAL", "Usr_std_temp", Gd_usrStdTemp)
        Me.Close()
    End Sub

    Private Sub tempoffsetlabel1_TextChanged(sender As Object, e As EventArgs) Handles tempoffsetlabel1.TextChanged
        'make it so that a string doesn't work here!@
        Gd_Ref_Offset = CDbl(tempoffsetlabel1.Text)
    End Sub
End Class