Imports PdfSharp
Imports PdfSharp.Drawing
Imports PdfSharp.Pdf

Public Class Certification

    Const NUM_OF_ROWS As Integer = 6
    Dim dialogForm As New DialogUsr


    Private Sub flowratetxtbox6_TextChanged(sender As Object, e As EventArgs) Handles txtCertUUTModel.TextChanged

    End Sub

    Private Sub Certification_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'AZN grab values from main screen
        flowratetxtbox = ControlArrayUtils.getControlArray(Me, "flowratetxtbox", NUM_OF_ROWS)
        endvoltxtbox = ControlArrayUtils.getControlArray(Me, "endvoltxtbox", NUM_OF_ROWS)
        warmuptxtbox = ControlArrayUtils.getControlArray(Me, "warmuptxtbox", NUM_OF_ROWS)
        refpulselabel = ControlArrayUtils.getControlArray(Me, "refpulselabel", NUM_OF_ROWS)
        testpulselabel = ControlArrayUtils.getControlArray(Me, "testpulselabel", NUM_OF_ROWS)
        reftemplabel = ControlArrayUtils.getControlArray(Me, "reftemplabel", NUM_OF_ROWS)
        testtimerlabel = ControlArrayUtils.getControlArray(Me, "testtimerlabel", NUM_OF_ROWS)
        testtemplabel = ControlArrayUtils.getControlArray(Me, "testtemplabel", NUM_OF_ROWS)
        pressureLabel = ControlArrayUtils.getControlArray(Me, "pressureLabel", NUM_OF_ROWS)
        stdVolLabel = ControlArrayUtils.getControlArray(Me, "stdVolLabel", NUM_OF_ROWS)
        xdstdvollabel = ControlArrayUtils.getControlArray(Me, "xdstdvollabel", NUM_OF_ROWS)

        Dim strArray(6) As String

        strArray(1) = Main.flowratetxtbox1.Text
        strArray(2) = Main.flowratetxtbox2.Text
        strArray(3) = Main.flowratetxtbox3.Text
        strArray(4) = Main.flowratetxtbox4.Text
        strArray(5) = Main.flowratetxtbox5.Text
        strArray(6) = Main.flowratetxtbox6.Text

        For o As Integer = 1 To NUM_OF_ROWS
            flowratetxtbox(o).Text = strArray(o)
        Next

        strArray(1) = Main.endvoltxtbox1.Text
        strArray(2) = Main.endvoltxtbox2.Text
        strArray(3) = Main.endvoltxtbox3.Text
        strArray(4) = Main.endvoltxtbox4.Text
        strArray(5) = Main.endvoltxtbox5.Text
        strArray(6) = Main.endvoltxtbox6.Text

        For o As Integer = 1 To NUM_OF_ROWS
            endvoltxtbox(o).Text = strArray(o)
        Next

        strArray(1) = Main.warmuptxtbox1.Text
        strArray(2) = Main.warmuptxtbox2.Text
        strArray(3) = Main.warmuptxtbox3.Text
        strArray(4) = Main.warmuptxtbox4.Text
        strArray(5) = Main.warmuptxtbox5.Text
        strArray(6) = Main.warmuptxtbox6.Text

        For o As Integer = 1 To NUM_OF_ROWS
            warmuptxtbox(o).Text = strArray(o)
        Next

        strArray(1) = Main.refpulselabel1.Text
        strArray(2) = Main.refpulselabel2.Text
        strArray(3) = Main.refpulselabel3.Text
        strArray(4) = Main.refpulselabel4.Text
        strArray(5) = Main.refpulselabel5.Text
        strArray(6) = Main.refpulselabel6.Text

        For o As Integer = 1 To NUM_OF_ROWS
            refpulselabel(o).Text = strArray(o)
        Next

        strArray(1) = Main.testpulselabel1.Text
        strArray(2) = Main.testpulselabel2.Text
        strArray(3) = Main.testpulselabel3.Text
        strArray(4) = Main.testpulselabel4.Text
        strArray(5) = Main.testpulselabel5.Text
        strArray(6) = Main.testpulselabel6.Text

        For o As Integer = 1 To NUM_OF_ROWS
            testpulselabel(o).Text = strArray(o)
        Next

        strArray(1) = Main.reftemplabel1.Text
        strArray(2) = Main.reftemplabel2.Text
        strArray(3) = Main.reftemplabel3.Text
        strArray(4) = Main.reftemplabel4.Text
        strArray(5) = Main.reftemplabel5.Text
        strArray(6) = Main.reftemplabel6.Text

        For o As Integer = 1 To NUM_OF_ROWS
            reftemplabel(o).Text = strArray(o)
        Next

        strArray(1) = Main.testtimerlabel1.Text
        strArray(2) = Main.testtimerlabel2.Text
        strArray(3) = Main.testtimerlabel3.Text
        strArray(4) = Main.testtimerlabel4.Text
        strArray(5) = Main.testtimerlabel5.Text
        strArray(6) = Main.testtimerlabel6.Text

        For o As Integer = 1 To NUM_OF_ROWS
            testtimerlabel(o).Text = strArray(o)
        Next

        strArray(1) = Main.testtemplabel1.Text
        strArray(2) = Main.testtemplabel2.Text
        strArray(3) = Main.testtemplabel3.Text
        strArray(4) = Main.testtemplabel4.Text
        strArray(5) = Main.testtemplabel5.Text
        strArray(6) = Main.testtemplabel6.Text

        For o As Integer = 1 To NUM_OF_ROWS
            testtemplabel(o).Text = strArray(o)
        Next

        strArray(1) = Main.pressureLabel1.Text
        strArray(2) = Main.pressureLabel2.Text
        strArray(3) = Main.pressureLabel3.Text
        strArray(4) = Main.pressureLabel4.Text
        strArray(5) = Main.pressureLabel5.Text
        strArray(6) = Main.pressureLabel6.Text

        For o As Integer = 1 To NUM_OF_ROWS
            pressureLabel(o).Text = strArray(o)
        Next

        strArray(1) = Main.stdVolLabel1.Text
        strArray(2) = Main.stdVolLabel2.Text
        strArray(3) = Main.stdVolLabel3.Text
        strArray(4) = Main.stdVolLabel4.Text
        strArray(5) = Main.stdVolLabel5.Text
        strArray(6) = Main.stdVolLabel6.Text

        For o As Integer = 1 To NUM_OF_ROWS
            stdVolLabel(o).Text = strArray(o)
        Next

        strArray(1) = Main.xdstdvollabel1.Text
        strArray(2) = Main.xdstdvollabel2.Text
        strArray(3) = Main.xdstdvollabel3.Text
        strArray(4) = Main.xdstdvollabel4.Text
        strArray(5) = Main.xdstdvollabel5.Text
        strArray(6) = Main.xdstdvollabel6.Text

        For o As Integer = 1 To NUM_OF_ROWS
            xdstdvollabel(o).Text = strArray(o)
        Next

    End Sub

    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click

        ' Gs_ForXL &= "B" + CStr(zposition) + "~" + CStr(testtimerlabel(cc).Text) + vbCrLf

        ' array is 9 by 2, start 0 so declare as 8 by 1
        Dim certInfo(,) As String = New String(14, 1) {
            {"c6", txtCertUUTModel.Text},
            {"c7", txtCertUUTSerial.Text},
            {"c8", txtCertDGMModel.Text},
            {"c9", txtCertDGMSerial.Text},
            {"c10", txtInitialGamma.Text},
            {"f6", txtCertBarPressure.Text},
            {"f7", txtCertAmbTemp.Text},
            {"f8", txtCertHumidity.Text},
            {"f9", txtCertAltitude.Text},
            {"j7", "760"},
            {"m6", txtWTMModel.Text},
            {"m7", txtCertDueDate.Text},
            {"m8", txtCertTherm.Text},
            {"o6", txtCertSerial.Text},
            {"o7", txtCertGamma.Text}
        }


        For n As Integer = 0 To 14
            Gs_ForXL &= certInfo(n, 0) + "~" + certInfo(n, 1) + vbCrLf
        Next
        'MsgBox(Gs_ForXL)
        Dim sFileName As String
        If (SaveFileDialog1.ShowDialog() = DialogResult.OK) Then
            sFileName = SaveFileDialog1.FileName
            Dim stream_writer As System.IO.StreamWriter
            Dim printable As String = ""
            'MACHINEOFBRUH"
            stream_writer = New System.IO.StreamWriter(sFileName)

            'Dim fileContents As String = Gs_ForXL


            stream_writer.Write(Gs_ForXL)

            stream_writer.Close()
            Gs_dialogText = "File saved successfully."
            dialogForm.StartPosition = FormStartPosition.CenterScreen
            dialogForm.ShowDialog()
        End If


    End Sub

    Private Sub Label33_Click(sender As Object, e As EventArgs) Handles Label33.Click

    End Sub
End Class