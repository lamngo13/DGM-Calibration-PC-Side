Public Class ErrorForm
    Private Sub exiterrorformbutton_Click(sender As Object, e As EventArgs) Handles exiterrorformbutton.Click
        Me.Close()
    End Sub

    Private Sub ErrorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        errormsglabel.Text = GS_errorText
    End Sub
End Class