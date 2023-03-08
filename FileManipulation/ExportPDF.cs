using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Events;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Documents;
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
        int componentCounter = 1, titleCounter = 1, subtitleCounter = 1, imageCounter = 1, pages = 1;
        Image imageBefore, imageAfter;
        Paragraph title;
        public string serialNum { get; set; }
        Document document;
        PdfFont font = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
        float x; float y;
        public ExportPDF(
            string path,
            List<string> initialImagesPath,
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
            string labelPath,
            List<Component> listaComponentes
            )
        {
            #region init vars
            List<string> initialImages = new List<string>();
            List<string> finalImages = new List<string>();
            initialImages = initialImagesPath.ToList();
            finalImages = finalImagesPath.ToList();
            if (summary!= null)
            {
                summaryText = new Text(summary).SetFont(font);
            }
            if (clean)
            {
                cleanText = new Text("The PCB was cleaned as it is informed in the instructions manual.").SetFont(font);
            }
            else
            {
                cleanText = new Text("The PCB was not cleaned as it is informed in the instructions manual.").SetFont(font);
            }
            if (troubleshoot)
            {
                troublesootingText = new Text("The Troubleshooting was done as it is informed in the instructions manual").SetFont(font);
            }
            else
            {
                troublesootingText = new Text("The Troubleshooting was not done as it is informed in the instructions manual").SetFont(font);
            }
            if (repair)
            {
                repairText = new Text("The PCB was repaired").SetFont(font);
            }
            else
            {
                repairText = new Text("The PCB wasn't repaired").SetFont(font);
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
                document = new Document(pdf).SetFont(font);

                //Edit Layout
                document.SetMargins(80, 80, 80, 80);
                pdf.AddNewPage();
                pages++;
                var page1 = pdf.GetPage(1);
                var canvas1 = new PdfCanvas(page1);
                pdf.AddEventHandler(PdfDocumentEvent.END_PAGE, new MyEventHandler(this));

                #region First page "Label"
                //Add label and title to first page
                document.Add(setTitle(("\n" + "REPORT CONCERNING CLEANING AND DISASSEMBLY OF PCB " + serialNum + "\n\n")).SetFontSize(24).SetFont(font));
                ImageData im = ImageDataFactory.Create(labelPath);
                Image image = new Image(im);
                //image.ScaleToFit(PageSize.A4.GetWidth() / 3, PageSize.A4.GetHeight() / 3);
                //image.ScaleToFit(200, 200);
                document.Add(image);
                document.Add(new Paragraph("\n\n\n\n"));

                //Draw rectangle in first page for the summary
                document.Add(new Paragraph("Summary:").SetFont(font).SetBold());
                var newY = image.GetImageHeight();
                Rectangle summaryRectangle = new Rectangle(PageSize.A4.GetLeft() + 80, PageSize.A4.GetBottom() + 220, PageSize.A4.GetRight() - 160, 100);
                canvas1.Rectangle(summaryRectangle);
                canvas1.Stroke();

                texts.Add(summaryText);
                //texts.Add(troublesootingText);
                //texts.Add(repairText);
                addTextRectangle(canvas1, summaryRectangle, texts);
                texts.Clear();

                document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                #endregion

                #region Second page "Info"
                pdf.AddNewPage();
                pages++;
                var page2 = pdf.GetPage(2);
                var canvas = new PdfCanvas(page2);

                //First fields
                label = new Text("Serial Number: ").SetFont(font).SetBold();
                value = new Text(serialNum).SetFont(font).SetUnderline();
                Paragraph serialNumParagraph = new Paragraph();
                serialNumParagraph.Add(label).Add(value);
                document.Add(serialNumParagraph);

                label = new Text("Date: ").SetFont(font).SetBold();
                value = new Text(DateTime.Now.ToString("yyyy-MM-dd")).SetFont(font).SetUnderline();
                Paragraph dateParagraph = new Paragraph();
                dateParagraph.Add(label).Add(value);
                document.Add(dateParagraph);

                // Create a rectangle with the specified dimensions and add it to the pdf
                x = PageSize.A4.GetLeft() + 80;
                y = PageSize.A4.GetBottom() + 612;
                document.Add(new Paragraph("Work Description:").SetFont(font).SetBold());
                Rectangle rectangle0 = new Rectangle(x, y, PageSize.A4.GetRight() - 140, 75);
                canvas.Rectangle(rectangle0);
                canvas.Stroke();

                texts.Add(cleanText);
                texts.Add(troublesootingText);
                texts.Add(repairText);
                addTextRectangle(canvas, rectangle0, texts);
                texts.Clear();

                Paragraph newParagraph = new Paragraph("What was done:").SetFont(font).SetBold();
                newParagraph.SetMarginTop(rectangle0.GetHeight() + 9);
                document.Add(newParagraph);
                float height0 = rectangle0.GetHeight() + 30;
                Rectangle rectangle = new Rectangle(x, y - height0, PageSize.A4.GetRight() - 140, 75);
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

                Paragraph observationParagraph = new Paragraph("Other Observations:").SetFont(font).SetBold();
                observationParagraph.SetMarginTop(rectangle.GetHeight() + 9);
                document.Add(observationParagraph);
                float height = rectangle.GetHeight() + 30;
                Rectangle rectangle2 = new Rectangle(x, y - height - height0, PageSize.A4.GetRight() - 140, 75);
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

                Paragraph commentsParagraph = new Paragraph("Comments:").SetFont(font).SetBold();
                commentsParagraph.SetMarginTop(rectangle2.GetHeight() + 8);
                document.Add(commentsParagraph);
                float height2 = rectangle2.GetHeight() + 30;
                Rectangle rectangle3 = new Rectangle(x, y - height0 - height - height2, PageSize.A4.GetRight() - 140, 75);
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
                Paragraph resultsParagraph = new Paragraph("Results:").SetFont(font).SetBold();
                resultsParagraph.SetMarginTop(rectangle3.GetHeight() + 8);
                document.Add(resultsParagraph);
                float height3 = rectangle3.GetHeight() + 30 + +height0 + height + height2;
                Rectangle rectangle4 = new Rectangle(PageSize.A4.GetLeft() + 80, PageSize.A4.GetBottom() + 612 - height3, PageSize.A4.GetRight() - 140, 75);
                canvas.Rectangle(rectangle4);
                canvas.Stroke();

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
                #endregion

                #region Third page "Components"
                titleCounter++;
                document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                document.Add(new Paragraph((titleCounter + ".   Components\n")).SetFont(font).SetFontSize(14).SetMarginTop(0f).SetBold());
                InsertComponent(pdf, listaComponentes);
                //Cleaning
                document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                titleCounter++;
                document.Add(new Paragraph((titleCounter + ".   Components Cleaning\n")).SetFont(font).SetFontSize(14).SetMarginTop(0f).SetBold());
                var pageX = pdf.GetPage(pages);
                var canvasX = new PdfCanvas(pageX);

                // Create a new table with two columns
                float tableWidth = PageSize.A4.GetWidth() - document.GetLeftMargin() - document.GetRightMargin();
                //Table table = new Table(UnitValue.CreatePointArray(new float[] { tableWidth / 2, tableWidth / 2 }));
                var table = new iText.Layout.Element.Table(new float[] { 1, 1 }).UseAllAvailableWidth();
                table.SetFixedLayout();
                var emptyCell = new Cell().SetBorder(Border.NO_BORDER);
                //var resto = listaComponentes.Count() % 3;
                var compCounter = 0;

                foreach (Component comp in listaComponentes)
                {
                    if (compCounter == 1 || compCounter == 2)
                    {
                        title = new Paragraph(("\n\n" + titleCounter + "." + subtitleCounter + " " + comp.name + " Cleaning\n")).SetFont(font).SetFontSize(14).SetMarginTop(0f).SetBold();
                    }
                    else title = new Paragraph((titleCounter + "." + subtitleCounter + " " + comp.name + " Cleaning\n")).SetFont(font).SetFontSize(14).SetMarginTop(0f).SetBold();
                        
                    // Create two new cells for the descriptions
                    var titleCell = new Cell().Add(title).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingRight(5).SetTextAlignment(TextAlignment.LEFT);

                    // Create two Image objects
                    ImageData im1 = ImageDataFactory.Create(comp.componentBeforeImg);
                    ImageData im2 = ImageDataFactory.Create(comp.componentAfterImg);
                    
                    imageBefore = new Image(im1);
                    imageAfter = new Image(im2);
                    //image.ScaleToFit(175,175);
                    imageBefore.SetMaxHeight(140);
                    imageBefore.SetMaxWidth(175);
                    imageAfter.SetMaxHeight(140);
                    imageAfter.SetMaxWidth(175);
                    imageAfter.SetHorizontalAlignment(HorizontalAlignment.RIGHT);

                    Cell cell1 = new Cell().Add(imageBefore).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingRight(10);
                    Cell cell2 = new Cell().Add(imageAfter).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingLeft(10);

                    // Create two Paragraph objects for the descriptions
                    var description1 = new Paragraph("Figure." + imageCounter + " " + comp.name +" before cleaning").SetFontSize(9).SetFont(font);
                    imageCounter++;
                    var description2 = new Paragraph("Figure." + imageCounter + " " + comp.name + " after cleaning").SetFontSize(9).SetFont(font).SetTextAlignment(TextAlignment.RIGHT);
                    imageCounter++;

                    // Create two new cells for the descriptions
                    var descriptionCell1 = new Cell().Add(description1).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingRight(5).SetTextAlignment(TextAlignment.LEFT);
                    var descriptionCell2 = new Cell().Add(description2).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingLeft(5).SetTextAlignment(TextAlignment.LEFT);
                    // Add the description cells to the second row of the table
                    table.AddCell(titleCell);
                    table.AddCell(emptyCell);
                    // Add the images to the table
                    table.AddCell(cell1);
                    table.AddCell(cell2);
                    // Add the description cells to the second row of the table
                    table.AddCell(descriptionCell1);
                    table.AddCell(descriptionCell2);
                    compCounter++;
                    subtitleCounter++;
                    if (compCounter == 3)
                    {
                        // If the combined height is greater than the available height, add a new page
                        document.Add(table);
                        document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                        table = new iText.Layout.Element.Table(new float[] { 1, 1 }).UseAllAvailableWidth();
                        table.SetFixedLayout();
                        compCounter = 0;
                    }
                }

                // Add the table to the document
                document.Add(table);

                #endregion

                #region after and before clean
                document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                document.Add(setTitle("Before Cleaning").SetFont(font));
                if (initialImages.Count > 6)
                {
                    insertImg(initialImages.Take(6).ToList());
                    initialImages.RemoveRange(0, 6);
                }
                else
                {
                    insertImg(initialImages);
                    initialImages.Clear();
                }


                document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                document.Add(setTitle("After Cleaning").SetFont(font));
                if (finalImages.Count > 6)
                {
                    insertImg(finalImages.Take(6).ToList());
                    finalImages.RemoveRange(0, 6);
                }
                else
                {
                    insertImg(finalImages);
                    finalImages.Clear();
                }

                if (initialImages.Count > 0)
                {
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                    document.Add(setTitle("More before cleaning images").SetFont(font));
                    insertImg(initialImages);
                }

                if (finalImages.Count > 0)
                {
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                    document.Add(setTitle("More after cleaning images").SetFont(font));
                    insertImg(finalImages);
                }
                #endregion

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

        private void InsertComponent(PdfDocument pdf, List<Component> listaComponentes)
        {
            int i = 0;
            Paragraph text;

            for (i = 0; i < listaComponentes.Count; i++)
            {
                text = new Paragraph(titleCounter + "." + subtitleCounter + "." + componentCounter + "  " + listaComponentes[i].name);
                document.Add(text.SetFontSize(9).SetFont(font).SetBold());
                text = new Paragraph(listaComponentes[i].description);
                document.Add(text.SetFontSize(8).SetFont(font).SetMarginTop(0f));
                ImageData im = ImageDataFactory.Create(listaComponentes[i].componentImg);
                Image image = new Image(im);
                //image.ScaleToFit(175,175);
                image.SetMaxHeight(140);
                image.SetMaxWidth(175);
                document.Add(image);
                text = new Paragraph("Figure " + imageCounter + ".  " + listaComponentes[i].name);
                document.Add(text.SetFontSize(9).SetFont(font));
                componentCounter++;
                imageCounter++;
                if ((i + 1) % 3 == 0)
                {
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                    pages++;
                }
            }
        }

        private void addTextRectangle(PdfCanvas canvas, Rectangle rectangle, List<Text> texts)
        {
            var canvas1 = new Canvas(canvas, rectangle);
            float x = rectangle.GetLeft() + 10;
            float y = rectangle.GetTop() - 20;
            foreach (Text text in texts)
            {
                float width = text.GetText().Length;
                canvas1.Add(new Paragraph(text).SetFontSize(9).SetFont(font).SetFixedPosition(x,y,rectangle.GetWidth()));
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
            pdfCanvas.MoveTo(pageSize.GetLeft() + 65, pageSize.GetBottom() + 40)
                .LineTo(pageSize.GetRight() - 65, pageSize.GetBottom() + 40)
                .Stroke();

            float textWidth = font.GetWidth("© Motion Control i Västerås AB", 9);
            float textX = (pageSize.GetRight() - pageSize.GetLeft() - textWidth) / 2 + pageSize.GetLeft();

            pdfCanvas.BeginText()
                .SetFontAndSize(font, 9)
                .MoveText(textX, pageSize.GetBottom() + 29)
                .ShowText("© Motion Control i Västerås AB")
                .EndText();
            pdfCanvas.BeginText()
                        .SetFontAndSize(font, 9)
                        .MoveText(pageSize.GetRight() - 72, pageSize.GetBottom() + 29)
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
