using iText.Kernel.Pdf;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Font;
using Document = iText.Layout.Document;
using Paragraph = iText.Layout.Element.Paragraph;
using Image = iText.Layout.Element.Image;
using System.Collections.Generic;
using System.IO;
using iText.StyledXmlParser.Jsoup.Safety;
using System;

namespace TrainReport.FileManipulation
{
    internal class ExportPDF
    {
        Document document;
        public ExportPDF(string path, List<string> initialimagesPath, List<string> finalImagesPath,
            int serialNum, bool clean, bool eletricEval, bool replaced, string componentsReplaced,
            bool finalEval, string finalThoughts)
        {
            string outputPath = path + "\\FinalReport_" + serialNum + ".pdf";

            // Create a new PDF document
            //PdfDocument pdf = new PdfDocument(new PdfWriter(new FileStream(outputPath, FileMode.Create)));
            // Create a new PDF document
            PdfDocument pdf = new PdfDocument(new PdfWriter(outputPath));
            // Add metadata to the document
            pdf.GetDocumentInfo().SetAuthor("VOV Service Consult");
            pdf.GetDocumentInfo().SetTitle("Report:" + serialNum);
            pdf.GetDocumentInfo().SetSubject("Report of the rebuild process of old PCBs");
            document = new Document(pdf);

            // Add a title to the document
            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            Paragraph title = new Paragraph("Report:" + serialNum)
                .SetFontSize(24)
                .SetFont(font);
            document.Add(title);

            // Add some data to the document
            document.Add(new Paragraph("This is the automated report nº " + serialNum));
            document.Add(new Paragraph("The PCB serial number: " + serialNum));
            document.Add(new Paragraph("Was the PCB cleaned ? " + clean));
            document.Add(new Paragraph("Was the eletrical evaluation done ? " + eletricEval));
            document.Add(new Paragraph("Was any of the PCB Components Replaced ? " + replaced));
            if(replaced)
            {
                document.Add(new Paragraph("The replaced components: " + componentsReplaced));
            }
            document.Add(new Paragraph("Was the final eletrical evaluation done ? " + finalEval));
            document.Add(new Paragraph("Final thoughts on this process " + finalThoughts));


            foreach (var img in initialimagesPath)
            {
                insertImg(img);
            }

            foreach (var img in finalImagesPath)
            {
                insertImg(img);
            }
            //string csvPath = path + "/data.csv";
            //string[] csvData = File.ReadAllLines(csvPath);
            //using (var reader = new StreamReader(csvPath))
            //{
            //    while (!reader.EndOfStream)
            //    {
                    //var line = reader.ReadLine();
                    //var values = line.Split(',');
                    //foreach (var value in values)
                    //{
                    //    switch (count)
                    //    {
                    //        case 0:
                    //            p = new Paragraph("The PCB serial number: " + values[0]);
                    //            break;
                    //        case 1:
                    //            p = new Paragraph("The PCB was cleaned: " + values[1]);
                    //            break;
                    //        case 2:
                    //            p = new Paragraph("Number of images: " + values[2]);
                    //            break;
                    //    }
                    //    //p.SetTextAlignment(TextAlignment.LEFT).SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA));
                    //    document.Add(p);
                    //    count++;
                    //}
                    // Add an image to the 
                     //document.Add(new Paragraph().SetSpacingAfter(1));
                    //}
                //}
            //}

            // Close the document
            document.Close();
        }

        private void insertImg(string img)
        {
            // Add an image to the PDF
            // Create an instance of the Image class
            //Image im = new Image(ImageDataFactory.Create(img));
            ImageData im = ImageDataFactory.Create(img);
            //Resize image depend upon your need
            //float width = im.GetWidth();
            //float height = im.GetHeight();
            //float scale = 140f / width;
            //width *= scale;
            //height *= scale;
            //im.SetWidth(width);
            //im.SetHeight(height);
            //Give space before image
            //document.Add(new Paragraph().SetSpacingBefore(10));
            document.Add(new Paragraph("\n\n"));
            //Add image
            document.Add(new Image(im));
            //Give some space after the image
        }
    }
}
