Public Class Configure
    Private Sub configconfirmbutton_Click(sender As Object, e As EventArgs) Handles configconfirmbutton.Click
        Me.Close()
    End Sub

    Private Sub fahrenheitradiobutton_CheckedChanged(sender As Object, e As EventArgs) Handles fahrenheitradiobutton.CheckedChanged
        Gs_tempunits = "Fahrenheit"
    End Sub

    Private Sub celsiusradiobutton_CheckedChanged(sender As Object, e As EventArgs) Handles celsiusradiobutton.CheckedChanged
        Gs_tempunits = "Celsius"
    End Sub

    Private Sub kelvinradiobutton_CheckedChanged(sender As Object, e As EventArgs) Handles kelvinradiobutton.CheckedChanged
        Gs_tempunits = "Kelvin"
    End Sub
End Class