﻿using iText.Kernel.Pdf;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Forms;
using iText.Forms.Fields;

using Document = iText.Layout.Document;
using Paragraph = iText.Layout.Element.Paragraph;
using Image = iText.Layout.Element.Image;

using System.Collections.Generic;
using System.IO;
using System;
using iText.Kernel.Events;
using iText.Kernel.Pdf.Canvas;
using System.Drawing;
using System.Windows;
using System.Windows.Documents.DocumentStructures;
using Rectangle = iText.Kernel.Geom.Rectangle;
using iText.Kernel.Pdf.Annot;
using System.Windows.Controls;
using iText.Layout;
using Canvas = iText.Layout.Canvas;
using iText.Kernel.Colors;
using System.Windows.Media.Media3D;
using iText.StyledXmlParser.Node;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.StyledXmlParser.Jsoup.Nodes;
using TextAlignment = iText.Layout.Properties.TextAlignment;
using Newtonsoft.Json.Linq;
using System.Drawing.Printing;
using System.Windows.Shapes;
using static System.Net.WebRequestMethods;
using System.Text;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace Tåg_project.FileManipulation
{
    internal class ExportPDF
    {
        Text label,value,cleanText, troublesootingText, componentsText, whichComponentsText, 
            finalEvaluationText, repairText, observationsText;
        List<Text> texts= new List<Text>();
        public string serialNum { get; set; }
        Document document;
        PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
        public ExportPDF(string path, List<string> initialimagesPath, List<string> finalImagesPath,
            string sNum, bool clean, bool eletricEval, bool replaced, string componentsReplaced,
            bool finalEval, string finalThoughts, string observations, string process, string comments, bool result1, bool result2, bool result3)
        {
            #region init vars
            if (clean)
            {
                cleanText = new Text("The PCB was cleaned as it is informed in the instructions manual.");
            }
            else
            {
                cleanText = new Text("The PCB was not cleaned as it is informed in the instructions manual.");
            }
            if (eletricEval)
            {
                troublesootingText = new Text("The Eletrical evaluation was done as it is informed in the instructions manual");
            }
            else
            {
                troublesootingText = new Text("The Eletrical evaluation was not done as it is informed in the instructions manual");
            }
            if (replaced)
            {
                componentsText = new Text("Some components on the PCB were replaced");
                if (componentsReplaced != null)
                {
                    whichComponentsText = new Text("The replaced components were: " + componentsReplaced);
                }
            }
            else
            {
                componentsText = new Text("No components on the PCB were replaced");
            }
            if (finalEval)
            {
                finalEvaluationText = new Text("The final eletrical evaluation was approved!");
            }
            else
            {
                finalEvaluationText = new Text("The final eletrical evaluation was not approved!");
            }
            if (finalThoughts != null)
            {
                observationsText = new Text("Final thoughts on this process:" + "\n" + finalThoughts);
            }
            serialNum = sNum;
            string outputPath = path + "\\Report_" + serialNum + ".pdf";
            #endregion

            // Create a new PDF document
            PdfWriter writer = new PdfWriter(outputPath);
            PdfDocument pdf = new PdfDocument(writer);
            pdf.AddNewPage();
            var page = pdf.GetPage(1);
            var canvas = new PdfCanvas(page);
            pdf.AddEventHandler(PdfDocumentEvent.END_PAGE, new MyEventHandler(this));

            // Add metadata to the document
            pdf.GetDocumentInfo().SetAuthor("© Motion Control i Västerås AB");
            pdf.GetDocumentInfo().SetTitle("Report nº" + serialNum);
            pdf.GetDocumentInfo().SetSubject("Report of the rebuild process of PCBs");
            document = new Document(pdf);

            //Edit Layout
            document.SetMargins(80, 80, 80, 80);

            // Add a title to the document
            document.Add(setTitle("CIRCUIT BOARD REPAIR REPORT"));
            document.Add(new Paragraph("\n"));


            // Add some data to the document
            //document.Add(new Paragraph("This is the automated report nº " + serialNum + ", created on " + System.DateTime.UtcNow + "."));
            //document.Add(new Paragraph("The PCB serial number is " + serialNum));

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

            repairText = new Text("TESTEEE");
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

            Text newT = new Text(process);
            texts.Add(newT);
            addTextRectangle(canvas, rectangle, texts);
            texts.Clear();

            Paragraph observationParagraph = new Paragraph("Other Observations:");
            observationParagraph.SetMarginTop(rectangle.GetHeight()+9);
            document.Add(observationParagraph);
            float height = rectangle.GetHeight() + 30;
            Rectangle rectangle2 = new Rectangle(PageSize.A4.GetLeft() + 80, PageSize.A4.GetBottom() + 540 - height - height0, PageSize.A4.GetRight() - 140, 75);
            canvas.Rectangle(rectangle2);
            canvas.Stroke();

            newT = new Text(observations);
            texts.Add(newT);
            addTextRectangle(canvas, rectangle2, texts);
            texts.Clear();

            Paragraph commentsParagraph = new Paragraph("Comments:");
            commentsParagraph.SetMarginTop(rectangle2.GetHeight() + 8);
            document.Add(commentsParagraph);
            float height2 = rectangle2.GetHeight() + 30;
            Rectangle rectangle3 = new Rectangle(PageSize.A4.GetLeft() + 80, PageSize.A4.GetBottom() + 540 - height0 - height - height2, PageSize.A4.GetRight() - 140, 75);
            canvas.Rectangle(rectangle3);
            canvas.Stroke();

            newT = new Text(comments);
            texts.Add(newT);
            addTextRectangle(canvas, rectangle3, texts);
            texts.Clear();

            //Checkboxes and last rectangle of the first page
            Paragraph resultsParagraph = new Paragraph("Results:");
            resultsParagraph.SetMarginTop(rectangle3.GetHeight() + 8);
            document.Add(resultsParagraph);
            float height3 = rectangle3.GetHeight() + 30 + + height0 + height + height2;
            Rectangle rectangle4 = new Rectangle(PageSize.A4.GetLeft() + 80, PageSize.A4.GetBottom() + 540 - height3, PageSize.A4.GetRight() - 140, 75);
            canvas.Rectangle(rectangle4);
            canvas.Stroke();

            newT = new Text(observations);
            texts.Add(newT);
            addTextRectangle(canvas, rectangle2, texts);
            texts.Clear();

            // Create an appearance stream for the checkbox
            Rectangle rect = new Rectangle(rectangle4.GetLeft() + 15,
                rectangle4.GetBottom() + 55, 10, 10);
            canvas.Rectangle(rect);
            if (result1)
            {
                drawCross(canvas, rect);
            }
            canvas.Stroke();
            canvas.Stroke();
            canvas.BeginText().SetFontAndSize(PdfFontFactory.CreateFont(StandardFonts.HELVETICA), 12)
            .MoveText(rect.GetLeft()+25, rect.GetBottom())
            .ShowText("Repair made without the guarantie that the board works")
            .EndText();
            //canvas.Release();

            Rectangle rect1 = new Rectangle(rect.SetY(rect.GetBottom()-20));
            canvas.Rectangle(rect1);
            // Draw a cross
            if (result2)
            {
                drawCross(canvas, rect1);
            }
            canvas.Stroke();
            canvas.BeginText().SetFontAndSize(PdfFontFactory.CreateFont(StandardFonts.HELVETICA), 12)
            .MoveText(rect1.GetLeft() + 25, rect1.GetBottom())
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
            canvas.BeginText().SetFontAndSize(PdfFontFactory.CreateFont(StandardFonts.HELVETICA), 12)
            .MoveText(rect2.GetLeft() + 25, rect2.GetBottom())
            .ShowText("Repair was done but problem still exists")
            .EndText();
            canvas.Release();

            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
            document.Add(setTitle("Before Repair"));
            foreach (var img in initialimagesPath)
            {
                insertImg(img);
            }

            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
            document.Add(setTitle("After Repair"));
            foreach (var img in finalImagesPath)
            {
                insertImg(img);
            }
            document.Close();
            MessageBox.Show("PDF Created on" + outputPath);
            ShowFile.OpenFile(outputPath);
        }

        private void addTextRectangle(PdfCanvas canvas, Rectangle rectangle, List<Text> texts)
        {
            var canvas1 = new Canvas(canvas, rectangle);
            foreach(Text text in texts)
            {
                canvas1.Add(new Paragraph(text).SetFontSize(9));
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

        //public Cell getCell(String text, TextAlignment alignment, bool underline)
        //{
        //    PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
        //    var paragraph = new Paragraph(text);
        //    if (underline)
        //    {
        //        paragraph.SetFont(font).SetUnderline().SetBold();
        //    }
        //    Cell cell = new Cell().Add(new Paragraph(text));
        //    cell.SetPadding(0);
        //    cell.SetTextAlignment(alignment);
        //    cell.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
        //    return cell;
        //}

        private Paragraph setTitle(string s)
        {
            Paragraph title = new Paragraph(s)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFontSize(24)
                .SetFont(font);
            title.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);

            return title;
        }

        private void insertImg(string img)
        {
            // Add an image to the PDF
            ImageData im = ImageDataFactory.Create(img);
            Image image = new Image(im);
            image.ScaleToFit(PageSize.A4.GetWidth() / 2, PageSize.A4.GetHeight() / 2);
            document.Add(image);
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
            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
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
                    float textW = font.GetWidth("Report ",9);
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
                        .MoveText(tx-1.5, textY - 9)
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
