Public Class Configure
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
    End Sub

End Class