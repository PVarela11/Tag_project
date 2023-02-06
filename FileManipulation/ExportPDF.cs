using iText.Kernel.Pdf;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Layout;
using iText.Layout.Element;
using iText.StyledXmlParser.Jsoup.Safety;
using iText.Layout.Properties;

using Document = iText.Layout.Document;
using Paragraph = iText.Layout.Element.Paragraph;
using Image = iText.Layout.Element.Image;

using System.Collections.Generic;
using System.IO;
using System;
using System.Windows.Controls;
using System.Windows.Documents;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using iText.Kernel.Events;
using iText.Kernel.Colors;
using iText.Kernel.Pdf.Canvas;
using System.Drawing;
using System.Windows.Media;
using Rectangle = iText.Kernel.Geom.Rectangle;
using System.Windows;
using Tåg_project.FileManipulation;
using iText.Commons.Utils;
using System.Reflection;
using iText.StyledXmlParser.Jsoup.Nodes;
using static System.Net.Mime.MediaTypeNames;
using System.Xml;

namespace Tåg_project.FileManipulation
{
    internal class ExportPDF
    {
        public string serialNum { get; set; }
        Document document;
        PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
        public ExportPDF(string path, List<string> initialimagesPath, List<string> finalImagesPath,
            string sNum, bool clean, bool eletricEval, bool replaced, string componentsReplaced,
            bool finalEval, string finalThoughts)
        {
            string outputPath = path + "\\FinalReport_" + serialNum + ".pdf";
            serialNum = sNum;
            // Create a new PDF document
            PdfWriter writer = new PdfWriter(outputPath);
            PdfDocument pdf = new PdfDocument(writer);
            pdf.AddEventHandler(PdfDocumentEvent.END_PAGE, new MyEventHandler(this));

            // Add metadata to the document
            pdf.GetDocumentInfo().SetAuthor("VOV Service Consult");
            pdf.GetDocumentInfo().SetTitle("Report nº" + serialNum);
            pdf.GetDocumentInfo().SetSubject("Report of the rebuild process of old PCBs");
            document = new Document(pdf);

            //Edit Layout
            document.SetMargins(80, 20, 20, 20);

            // Add a title to the document
            //document.Add(setTitle("Report:" + serialNum));


            // Add some data to the document
            document.Add(new Paragraph("This is the automated report nº " + serialNum + ", created on " + System.DateTime.UtcNow + "."));
            document.Add(new Paragraph("The PCB serial number is " + serialNum));
            if (clean)
            {
                document.Add(new Paragraph("The PCB was cleaned as it is informed in the instructions manual."));
            }else
            {
                document.Add(new Paragraph("The PCB was not cleaned as it is informed in the instructions manual."));
            }

            if (eletricEval)
            {
                document.Add(new Paragraph("The Eletrical evaluation was done as it is informed in the instructions manual"));
            }
            else
            {
                document.Add(new Paragraph("The Eletrical evaluation was not done as it is informed in the instructions manual"));
            }

            if(replaced)
            {
                document.Add(new Paragraph("Some components on the PCB were replaced"));
                if (componentsReplaced != null)
                {
                    document.Add(new Paragraph("The replaced components were: " + componentsReplaced));
                }   
            }
            else
            {
                document.Add(new Paragraph("No components on the PCB were replaced"));
            }

            if (finalEval)
            {
                document.Add(new Paragraph("The final eletrical evaluation was approved!"));
            }
            else
            {
                document.Add(new Paragraph("The final eletrical evaluation was not approved!"));
            }

            if (finalThoughts != null)
            {
                document.Add(new Paragraph("Final thoughts on this process:" + "\n" +finalThoughts));
            }

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
            MessageBox.Show("PDF Created at" + outputPath);
            ShowFile.OpenFile(outputPath);
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
            Rectangle pageSize = page.GetPageSize();
            PdfCanvas pdfCanvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdfDoc);

            //Header
            // Load the image
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (Bitmap original = new Bitmap(Properties.Resources.mcLogo__2_))
                {
                    using (Bitmap resized = new Bitmap(original))
                    {
                        resized.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                        byte[] imageBytes = memoryStream.ToArray();
                        ImageData image = ImageDataFactory.Create(imageBytes);
                        pdfCanvas.AddImageAt(image, pageSize.GetLeft() + 20, pageSize.GetTop() - 50, false);

                        // Add the text to the middle
                        float textW = font.GetWidth("Report " + _anotherClassInstance.serialNum, 9);
                        float tx = (pageSize.GetWidth() - textW) / 2;
                        float textY = (pageSize.GetTop() - 50) + image.GetHeight() / 2;
                        pdfCanvas.BeginText()
                            .SetFontAndSize(font, 9)
                            .MoveText(tx, textY)
                            .SetLeading(12)
                            .ShowText("Report " + "\n" + _anotherClassInstance.serialNum)
                            .EndText();


                        // Add the date to the right
                        float dateX = pageSize.GetRight() - 60;
                        pdfCanvas.BeginText()
                            .SetFontAndSize(font, 9)
                            .MoveText(dateX, textY)
                            .ShowText(DateTime.Now.ToString("yyyy-MM-dd"))
                            .EndText();
                    }
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
