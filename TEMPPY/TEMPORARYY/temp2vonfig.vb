Public Class temp2vonfig
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles configbutton.Click
        Dim tConfigure As New tConfigure
        tConfigure.StartPosition = FormStartPosition.CenterScreen
        tConfigure.ShowDialog()
    End Sub
End Class