Imports PdfSharp
Imports PdfSharp.Drawing
Imports PdfSharp.Pdf

Public Class Certification

    Sub makePDF()
        ' Create a new PDF document
        Dim document As PdfDocument = New PdfDocument
        document.Info.Title = "Created with PDFsharp"

        ' Create an empty page
        Dim page As PdfPage = document.AddPage

        ' Get an XGraphics object for drawing
        Dim gfx As XGraphics = XGraphics.FromPdfPage(page)

        ' Draw crossing lines
        Dim pen As XPen = New XPen(XColor.FromArgb(255, 0, 0))
        gfx.DrawLine(pen, New XPoint(0, 0), New XPoint(page.Width.Point, page.Height.Point))
        gfx.DrawLine(pen, New XPoint(page.Width.Point, 0), New XPoint(0, page.Height.Point))

        ' Draw an ellipse
        gfx.DrawEllipse(pen, 3 * page.Width.Point / 10, 3 * page.Height.Point / 10, 2 * page.Width.Point / 5, 2 * page.Height.Point / 5)

        ' Create a font
        Dim font As XFont = New XFont("Verdana", 20, XFontStyle.Bold)

        ' Draw the text


        gfx.DrawString("Hello, World!", font, XBrushes.Black,
    New XRect(0, 0, page.Width.Point, page.Height.Point), XStringFormats.Center)

        Dim str As String
        str = txtCertUUTModel.Text
        gfx.DrawString(str, font, XBrushes.Black,
            New XRect(0, 0, page.Width.Point, page.Height.Point), XStringFormats.Center)

        ' Save the document...
        Dim filename As String = "HelloWorld.pdf"
        document.Save(filename)

        ' ...and start a viewer.
        Process.Start(filename)

    End Sub


    Private Sub flowratetxtbox6_TextChanged(sender As Object, e As EventArgs) Handles txtCertUUTModel.TextChanged

    End Sub

    Private Sub Certification_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'AZN grab values from main screen
        foo.Text = Main.flowratetxtbox1.Text

        ' gave compile error
        '  For o As Integer = 1 To 6
        'flowratetxtbox(o).Text = Main.flowratetxtbox(o).Text   
        'Next

        Dim strArray(6) As String
        ', endvoltxtbox(6) As String, warmuptxtbox(6) As String, refpulselabel(6) As String, stdVolLabel(6) As String, testpulselabel(6) As String, xdstdvollabel(6) As String, reftemplabel(6) As String, testtemplabel(6) As String, pressureLabel(6) As String,
        'testtimerlabel(6) As String

        strArray(1) = Main.flowratetxtbox1.Text
        strArray(2) = Main.flowratetxtbox2.Text
        strArray(3) = Main.flowratetxtbox3.Text
        strArray(4) = Main.flowratetxtbox4.Text
        strArray(5) = Main.flowratetxtbox5.Text
        strArray(6) = Main.flowratetxtbox6.Text

        flowratetxtbox1.Text = strArray(1)

        ' For o As Integer = 1 To 6
        'flowratetxtbox(o).Text = Main.flowratetxtbox(o).Text
        '

    End Sub

    Private Sub btnstart_Click(sender As Object, e As EventArgs) Handles btnstart.Click
        makePDF()
    End Sub

    Private Sub foo_TextChanged(sender As Object, e As EventArgs) Handles foo.TextChanged

    End Sub
End Class