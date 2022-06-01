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
        foo.Text = Main.flowratetxtbox1.Text
    End Sub

    Private Sub btnstart_Click(sender As Object, e As EventArgs) Handles btnstart.Click
        makePDF()
    End Sub
End Class