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
                Me.Close()
            End If
        End If
        '    Me.Close()
        'ErrorForm.ShowDialog()
        'GS_errorText = "stuff"
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

    Private Sub Configure_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ErrorForm As New ErrorForm
        ErrorForm.StartPosition = FormStartPosition.CenterScreen
        ErrorForm.ShowDialog()
    End Sub

    Private Sub usrstdtemptxtbox_TextChanged(sender As Object, e As EventArgs) Handles usrstdtemptxtbox.TextChanged
        Gd_usrStdTemp = CDbl(usrstdtemptxtbox.Text)
    End Sub
End Class