Public Class dp
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles lblClock.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblClock.Text = TimeString ' 24 hour time
        If (SerialPort1.IsOpen) Then
            If (SerialPort1.ReadBufferSize > 0) Then
                lblsp.Text = SerialPort1.ReadExisting()
            End If
        End If



    End Sub

    Private Sub dp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SerialPort1.PortName = "COM4"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles openCom.Click
        SerialPort1.PortName = "COM4"

        SerialPort1.Open()

    End Sub
End Class
