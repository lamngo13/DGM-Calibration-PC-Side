Public Class Configure
    Private Sub configconfirmbutton_Click(sender As Object, e As EventArgs) Handles configconfirmbutton.Click
        If ((fahrenheitradiobutton.Checked = False) And celsiusradiobutton.Checked = False) Then
            'open an error msg
            Dim ErrorForm As New ErrorForm
            GS_errorText = "Please select a Unit System."
            ErrorForm.StartPosition = FormStartPosition.CenterScreen
            ErrorForm.ShowDialog()
        Else
            If (usrstdtemptxtbox.Text = vbNullString) Then
                Dim ErrorForm As New ErrorForm
                GS_errorText = "Please select a Standard Temperature." + vbCrLf + "(recommended 20 degrees Celsius)"
                ErrorForm.StartPosition = FormStartPosition.CenterScreen
                ErrorForm.ShowDialog()
            Else
                Me.Close()
            End If
            'Me.Close()
        End If

    End Sub

    Private Sub fahrenheitradiobutton_CheckedChanged(sender As Object, e As EventArgs) Handles fahrenheitradiobutton.CheckedChanged
        If (fahrenheitradiobutton.Checked = True) Then
            Gs_tempunits = "Fahrenheit"
            Gs_UnitType = "imperial"
        End If

    End Sub

    Private Sub celsiusradiobutton_CheckedChanged(sender As Object, e As EventArgs) Handles celsiusradiobutton.CheckedChanged
        If (celsiusradiobutton.Checked = True) Then
            Gs_tempunits = "Celsius"
            Gs_UnitType = "metric"
        End If

    End Sub

    Private Sub kelvinradiobutton_CheckedChanged(sender As Object, e As EventArgs)
        Gs_tempunits = "Kelvin"
    End Sub
End Class