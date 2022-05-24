Public Class Main

    Public Function send_error()
        Dim ErrorForm As New ErrorForm
        ErrorForm.StartPosition = FormStartPosition.CenterScreen
        ErrorForm.ShowDialog()
    End Function
    Private Sub antibugbutton_Click(sender As Object, e As EventArgs) Handles antibugbutton.Click
        Dim antibug As New antibug
        antibug.StartPosition = FormStartPosition.CenterScreen
        antibug.ShowDialog()

    End Sub

    Private Sub ConfigureButton_Click(sender As Object, e As EventArgs) Handles configurebutton.Click
        Dim configure As New Configure
        configure.StartPosition = FormStartPosition.CenterScreen
        configure.ShowDialog()
    End Sub

End Class