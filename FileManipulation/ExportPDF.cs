using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Events;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Canvas = iText.Layout.Canvas;
using Document = iText.Layout.Document;
using Image = iText.Layout.Element.Image;
using MessageBox = System.Windows.MessageBox;
using Paragraph = iText.Layout.Element.Paragraph;
using Rectangle = iText.Kernel.Geom.Rectangle;

namespace Tåg_project.FileManipulation
{
    internal class ExportPDF
    {
        Text label, value, cleanText, troublesootingText, repairText, newT, summaryText;
        List<Text> texts = new List<Text>();
        public string serialNum { get; set; }
        Document document;
        PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
        public ExportPDF(
            string path,
            List<string> initialimagesPath,
            List<string> finalImagesPath,
            string sNum,
            bool clean,
            bool troubleshoot,
            string observations,
            string process,
            string comments,
            bool result1,
            bool result2,
            bool result3,
            bool repair,
            string summary,
            string labelPath
            )
        {
            #region init vars
            if(summary!= null)
            {
                summaryText = new Text(summary);
            }
            if (clean)
            {
                cleanText = new Text("The PCB was cleaned as it is informed in the instructions manual.");
            }
            else
            {
                cleanText = new Text("The PCB was not cleaned as it is informed in the instructions manual.");
            }
            if (troubleshoot)
            {
                troublesootingText = new Text("The Troubleshooting was done as it is informed in the instructions manual");
            }
            else
            {
                troublesootingText = new Text("The Troubleshooting was not done as it is informed in the instructions manual");
            }
            if (repair)
            {
                repairText = new Text("The PCB was repaired");
            }
            else
            {
                repairText = new Text("The PCB wasn't repaired");
            }

            serialNum = sNum;
            string outputPath = path + "\\Report_" + serialNum + ".pdf";
            #endregion

            try
            {
                // Create a new PDF document
                PdfWriter writer = new PdfWriter(outputPath);
                PdfDocument pdf = new PdfDocument(writer);

                // Add metadata to the document
                pdf.GetDocumentInfo().SetAuthor("© Motion Control i Västerås AB");
                pdf.GetDocumentInfo().SetTitle("Report nº" + serialNum);
                pdf.GetDocumentInfo().SetSubject("Report of the rebuild process of PCBs");
                document = new Document(pdf);

                //Edit Layout
                document.SetMargins(80, 80, 80, 80);

                pdf.AddNewPage();
                var page1 = pdf.GetPage(1);
                var canvas1 = new PdfCanvas(page1);
                pdf.AddEventHandler(PdfDocumentEvent.END_PAGE, new MyEventHandler(this));

                //Add label and title to first page
                document.Add(setTitle("CIRCUIT BOARD REPAIR REPORT"));
                ImageData im = ImageDataFactory.Create(labelPath);
                Image image = new Image(im);
                //image.ScaleToFit(PageSize.A4.GetWidth() / 3, PageSize.A4.GetHeight() / 3);
                //image.ScaleToFit(200, 200);
                document.Add(image);
                document.Add(new Paragraph("\n"));

                //Draw rectangle in first page for the summary
                document.Add(new Paragraph("Summary:"));
                var newY = image.GetImageHeight();
                Rectangle summaryRectangle = new Rectangle(PageSize.A4.GetLeft() + 80, PageSize.A4.GetBottom() + 400, PageSize.A4.GetRight() - 140, 75);
                canvas1.Rectangle(summaryRectangle);
                canvas1.Stroke();

                texts.Add(summaryText);
                texts.Add(troublesootingText);
                texts.Add(repairText);
                addTextRectangle(canvas1, summaryRectangle, texts);
                texts.Clear();

                document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                pdf.AddNewPage();
                var page2 = pdf.GetPage(2);
                var canvas = new PdfCanvas(page2);

                // Add a title to the document
                document.Add(new Paragraph("\n"));

                //First fields
                label = new Text("Serial Number: ").SetFont(font);
                value = new Text(serialNum).SetFont(font).SetUnderline().SetBold();
                Paragraph serialNumParagraph = new Paragraph();
                serialNumParagraph.Add(label).Add(value);
                document.Add(serialNumParagraph);

                label = new Text("Date: ").SetFont(font);
                value = new Text(DateTime.Now.ToString("yyyy-MM-dd")).SetFont(font).SetUnderline().SetBold();
                Paragraph dateParagraph = new Paragraph();
                dateParagraph.Add(label).Add(value);
                document.Add(dateParagraph);

                // Create a rectangle with the specified dimensions and add it to the pdf
                document.Add(new Paragraph("Work Description:"));
                Rectangle rectangle0 = new Rectangle(PageSize.A4.GetLeft() + 80, PageSize.A4.GetBottom() + 540, PageSize.A4.GetRight() - 140, 75);
                canvas.Rectangle(rectangle0);
                canvas.Stroke();

                texts.Add(cleanText);
                texts.Add(troublesootingText);
                texts.Add(repairText);
                addTextRectangle(canvas, rectangle0, texts);
                texts.Clear();

                Paragraph newParagraph = new Paragraph("What was done:");
                newParagraph.SetMarginTop(rectangle0.GetHeight() + 9);
                document.Add(newParagraph);
                float height0 = rectangle0.GetHeight() + 30;
                Rectangle rectangle = new Rectangle(PageSize.A4.GetLeft() + 80, PageSize.A4.GetBottom() + 540 - height0, PageSize.A4.GetRight() - 140, 75);
                canvas.Rectangle(rectangle);
                canvas.Stroke();

                string[] items = process.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                foreach (string item in items)
                {
                    newT = new Text(item);
                    texts.Add(newT);
                }
                items = null;
                addTextRectangle(canvas, rectangle, texts);
                texts.Clear();

                Paragraph observationParagraph = new Paragraph("Other Observations:");
                observationParagraph.SetMarginTop(rectangle.GetHeight() + 9);
                document.Add(observationParagraph);
                float height = rectangle.GetHeight() + 30;
                Rectangle rectangle2 = new Rectangle(PageSize.A4.GetLeft() + 80, PageSize.A4.GetBottom() + 540 - height - height0, PageSize.A4.GetRight() - 140, 75);
                canvas.Rectangle(rectangle2);
                canvas.Stroke();


                items = observations.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                foreach (string item in items)
                {
                    newT = new Text(item);
                    texts.Add(newT);
                }
                items = null;
                addTextRectangle(canvas, rectangle2, texts);
                texts.Clear();

                Paragraph commentsParagraph = new Paragraph("Comments:");
                commentsParagraph.SetMarginTop(rectangle2.GetHeight() + 8);
                document.Add(commentsParagraph);
                float height2 = rectangle2.GetHeight() + 30;
                Rectangle rectangle3 = new Rectangle(PageSize.A4.GetLeft() + 80, PageSize.A4.GetBottom() + 540 - height0 - height - height2, PageSize.A4.GetRight() - 140, 75);
                canvas.Rectangle(rectangle3);
                canvas.Stroke();

                items = comments.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                foreach (string item in items)
                {
                    newT = new Text(item);
                    texts.Add(newT);
                }
                items = null;
                addTextRectangle(canvas, rectangle3, texts);
                texts.Clear();

                //Checkboxes and last rectangle of the first page
                Paragraph resultsParagraph = new Paragraph("Results:");
                resultsParagraph.SetMarginTop(rectangle3.GetHeight() + 8);
                document.Add(resultsParagraph);
                float height3 = rectangle3.GetHeight() + 30 + +height0 + height + height2;
                Rectangle rectangle4 = new Rectangle(PageSize.A4.GetLeft() + 80, PageSize.A4.GetBottom() + 540 - height3, PageSize.A4.GetRight() - 140, 75);
                canvas.Rectangle(rectangle4);
                canvas.Stroke();

                //newT = new Text(observations);
                //texts.Add(newT);
                //addTextRectangle(canvas, rectangle2, texts);
                //texts.Clear();

                // Create an appearance stream for the checkbox
                Rectangle rect = new Rectangle(rectangle4.GetLeft() + 10,
                    rectangle4.GetBottom() + 55, 10, 10);
                canvas.Rectangle(rect);
                if (result1)
                {
                    drawCross(canvas, rect);
                }
                canvas.Stroke();
                canvas.Stroke();
                canvas.BeginText().SetFontAndSize(PdfFontFactory.CreateFont(StandardFonts.HELVETICA), 9)
                .MoveText(rect.GetLeft() + 25, rect.GetBottom()+2)
                .ShowText("Repair made without the guarantie that the board works")
                .EndText();
                //canvas.Release();

                Rectangle rect1 = new Rectangle(rect.SetY(rect.GetBottom() - 20));
                canvas.Rectangle(rect1);
                // Draw a cross
                if (result2)
                {
                    drawCross(canvas, rect1);
                }
                canvas.Stroke();
                canvas.BeginText().SetFontAndSize(PdfFontFactory.CreateFont(StandardFonts.HELVETICA), 9)
                .MoveText(rect1.GetLeft() + 25, rect1.GetBottom()+2)
                .ShowText("No errors were found")
                .EndText();
                //canvas.Release();

                Rectangle rect2 = new Rectangle(rect1.SetY(rect1.GetBottom() - 20));
                canvas.Rectangle(rect2);
                // Draw a cross
                if (result3)
                {
                    drawCross(canvas, rect2);
                }
                canvas.Stroke();
                canvas.BeginText().SetFontAndSize(PdfFontFactory.CreateFont(StandardFonts.HELVETICA), 9)
                .MoveText(rect2.GetLeft() + 25, rect2.GetBottom()+2)
                .ShowText("Repair was done but problem still exists")
                .EndText();
                canvas.Release();


                document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                document.Add(setTitle("Before Cleaning"));
                insertImg(initialimagesPath);

                document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                document.Add(setTitle("After Cleaning"));
                insertImg(finalImagesPath);

                document.Close();
                MessageBox.Show("PDF Created on" + outputPath);
                ShowFile.OpenFile(outputPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
            finally { }
        }

        private void addTextRectangle(PdfCanvas canvas, Rectangle rectangle, List<Text> texts)
        {
            var canvas1 = new Canvas(canvas, rectangle);
            float x = rectangle.GetLeft() + 10;
            float y = rectangle.GetTop() - 20;
            foreach (Text text in texts)
            {
                float width = text.GetText().Length;
                canvas1.Add(new Paragraph(text).SetFontSize(9).SetFixedPosition(x,y,rectangle.GetWidth()));
                y -= 12;
            }
            //canvas.Rectangle(rectangle);
            canvas.Stroke();
        }

        private void drawCross(PdfCanvas canvas, Rectangle rect)
        {
            canvas.Rectangle(rect);
            canvas.MoveTo(rect.GetLeft() + 2, rect.GetBottom() + 2);
            canvas.LineTo(rect.GetRight() - 2, rect.GetTop() - 2);
            canvas.MoveTo(rect.GetLeft() + 2, rect.GetTop() - 2);
            canvas.LineTo(rect.GetRight() - 2, rect.GetBottom() + 2);
        }

        private Paragraph setTitle(string s)
        {
            Paragraph title = new Paragraph(s)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFontSize(24)
                .SetFont(font);
            title.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);

            return title;
        }

        private void insertImg(List<string> images)
        {

            foreach (var img in images)
            {
                // Add an image to the PDF
                ImageData im = ImageDataFactory.Create(img);
                Image image = new Image(im);
                //image.ScaleToFit(PageSize.A4.GetWidth() / 3, PageSize.A4.GetHeight() / 3);
                image.ScaleToFit(200, 200);
                document.Add(image);
                document.Add(new Paragraph("\n"));
            }
            
        }

    }

    internal class MyEventHandler : IEventHandler
    {
        private ExportPDF _anotherClassInstance;

        public MyEventHandler(ExportPDF anotherClassInstance)
        {
            _anotherClassInstance = anotherClassInstance;
        }

        public virtual void HandleEvent(Event @event)
        {
            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;
            PdfDocument pdfDoc = docEvent.GetDocument();
            PdfPage page = docEvent.GetPage();
            int pageNumber = pdfDoc.GetPageNumber(page);
            iText.Kernel.Geom.Rectangle pageSize = page.GetPageSize();
            PdfCanvas pdfCanvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdfDoc);

            //Header
            // Load the image
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (Bitmap original = new Bitmap(Properties.Resources.teste))
                {
                    original.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] imageBytes = memoryStream.ToArray();
                    ImageData image = ImageDataFactory.Create(imageBytes);
                    pdfCanvas.AddImageAt(image, pageSize.GetLeft() + 80, pageSize.GetTop() - 50, false);

                    // Add the text to the middle
                    float textW = font.GetWidth("Report ", 9);
                    float tx = ((pageSize.GetWidth() - textW) / 2);
                    float textY = (pageSize.GetTop() - 50) + image.GetHeight() / 2;
                    pdfCanvas.BeginText()
                        .SetFontAndSize(font, 9)
                        .MoveText(tx, textY)
                        .ShowText("REPORT")
                        .EndText();

                    textW = font.GetWidth(_anotherClassInstance.serialNum, 9);
                    pdfCanvas.BeginText()
                        .SetFontAndSize(font, 9)
                        .MoveText(tx - 1.5, textY - 9)
                        .ShowText(_anotherClassInstance.serialNum)
                        .EndText();


                    // Add the date to the right
                    float dateX = pageSize.GetRight() - 140;
                    pdfCanvas.BeginText()
                        .SetFontAndSize(font, 9)
                        .MoveText(dateX, textY)
                        .ShowText(DateTime.Now.ToString("yyyy-MM-dd"))
                        .EndText();
                }
            }

            //Footer
            pdfCanvas.MoveTo(pageSize.GetLeft() + 20, pageSize.GetBottom() + 31)
                .LineTo(pageSize.GetRight() - 18, pageSize.GetBottom() + 31)
                .Stroke();

            float textWidth = font.GetWidth("© Motion Control i Västerås AB", 9);
            float textX = (pageSize.GetRight() - pageSize.GetLeft() - textWidth) / 2 + pageSize.GetLeft();

            pdfCanvas.BeginText()
                .SetFontAndSize(font, 9)
                .MoveText(textX, pageSize.GetBottom() + 20)
                .ShowText("© Motion Control i Västerås AB")
                .EndText();
            pdfCanvas.BeginText()
                        .SetFontAndSize(font, 9)
                        .MoveText(pageSize.GetRight() - 20, pageSize.GetBottom() + 20)
                        .ShowText(pageNumber.ToString())
                        .EndText();

            pdfCanvas.Release();
        }
        public static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }

}
