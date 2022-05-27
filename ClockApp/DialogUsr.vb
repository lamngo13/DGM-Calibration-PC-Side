Public Class DialogUsr
    Private Sub dialogContinueButton_Click(sender As Object, e As EventArgs) Handles dialogContinueButton.Click
        Gb_testgo = True
        Me.Close()
    End Sub

    Private Sub DialogUsr_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dialoglbl.Text = Gs_dialogText
    End Sub
End Class