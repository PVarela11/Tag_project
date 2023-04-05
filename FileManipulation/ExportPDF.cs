using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Events;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Xobject;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Pdfa;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Windows.Documents;
using Tåg_project.Properties;
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
        Text label, value, cleanText, troublesootingText, repairText, newT, summaryText, storageText, repairingText, cleaningText, upgradeText;
        List<Text> texts = new List<Text>();
        int componentCounter = 1, titleCounter = 1, subtitleCounter = 1, imageCounter = 1, pages = 1;
        float docLeftMargin, docRightMargin, documentWidth;
        Image imageBeforeFront1, imageBeforeFront2, imageBeforeFront3, imageBeforeBack1, imageBeforeBack2, imageBeforeBack3,
            imageAfterFront1, imageAfterFront2, imageAfterFront3, imageAfterBack1, imageAfterBack2, imageAfterBack3;
        ImageData im;
        Paragraph title;
        //byte[] imageBytes;
        public string serialNum { get; set; }
        List<string> componentStates = new List<string>(new string[]{"Good state","Damaged","Not functional"});
        public bool pageChanged { get; set; }
        Document document;
        PdfFont font = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
        float x; float y;
        public ExportPDF(
            string path,
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
            List<Component> listaComponentes,
            bool storage,
            bool cleaning,
            bool repairing,
            bool upgrade,
            string arrivalTime)
        {
            #region init vars
            if (storage)
            {
                storageText = new Text("The order was to store the components").SetFont(font);
            }
            if (cleaning)
            {
                cleaningText = new Text("The order was to clean the components").SetFont(font);
            }
            if (repairing)
            {
                repairingText = new Text("The order was to repair the components").SetFont(font);
            }
            if (upgrade)
            {
                upgradeText = new Text("The order was to upgraded the components").SetFont(font);
            }
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

            string outputPath = path + "\\Report_" + sNum + ".pdf";
            serialNum = sNum.Substring(0,5) + "-" + sNum.Substring(5,2);
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
                //pages++;
                var page1 = pdf.GetPage(1);
                var canvas1 = new PdfCanvas(page1);
                pdf.AddEventHandler(PdfDocumentEvent.END_PAGE, new MyEventHandler(this));

                #region First page "Label"
                //Add label and title to first page
                document.Add(setTitle(("REPORT CONCERNING CLEANING AND DISASSEMBLY OF PCB " + serialNum + "\n\n")).SetFontSize(24).SetFont(font));
                ImageData im = ImageDataFactory.Create(labelPath);
                Image image = new Image(im);
                docLeftMargin = document.GetLeftMargin();
                docRightMargin = document.GetRightMargin();
                documentWidth = PageSize.A4.GetWidth() - docLeftMargin - docRightMargin;
                image.ScaleToFit(documentWidth, (PageSize.A4.GetHeight() / 2));
                float imageWidth = image.GetImageScaledWidth();
                float imageHeight = image.GetImageScaledHeight();
                float pageTop = PageSize.A4.GetTop();
                float pageBottom = PageSize.A4.GetBottom();
                
                if (documentWidth > imageWidth)
                {
                    float x = (documentWidth - imageWidth) / 2;
                }
                image.SetHorizontalAlignment(HorizontalAlignment.CENTER);
                image.SetMarginLeft(x);
                
                document.Add(image);
                
                if (imageHeight > pageTop)
                {
                    imageHeight = PageSize.A4.GetHeight() / 2;
                }
                float bellowImg = PageSize.A4.GetTop() - (imageHeight + 80 + 48);
                
                Rectangle summaryRectangle = new Rectangle(PageSize.A4.GetLeft() + 80, bellowImg - 230, PageSize.A4.GetRight() - 160, 150);
                
                
                canvas1.Rectangle(summaryRectangle);
                canvas1.Stroke();

                //texts.Add(cleanText);
                //texts.Add(troublesootingText);
                //texts.Add(repairText);

                texts.Add(new Text("Summary:\n").SetFont(font).SetBold());
                texts.Add(new Text("AOLAOLAOLAOLAOLAOLAOLAOLAOLAOLAOLAO "));
                texts.Add(new Text("AOLAOLAOLAOLAOLAOLAOLAOLAOLAOLAOLAO "));
                texts.Add(new Text("AOLAOLAOLAOLAOLAOLAOLAOLAOLAOLAOLAO "));
                texts.Add(new Text("AOLAOLAOLAOLAOLAOLAOLAOLAOLAOLAOLAO "));
                //texts.Add(summaryText);

                //texts.Add(troublesootingText);
                //texts.Add(repairText);


                addTextRectangle(canvas1, summaryRectangle, texts);
                texts.Clear();


                document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                pages++;
                #endregion

                #region Second page "Info"
                //pdf.AddNewPage();

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

                Paragraph newParagraph = new Paragraph("Order:").SetFont(font).SetBold();
                newParagraph.SetMarginTop(rectangle0.GetHeight() + 9);
                document.Add(newParagraph);
                float height0 = rectangle0.GetHeight() + 30;
                Rectangle rectangle = new Rectangle(x, y - height0, PageSize.A4.GetRight() - 140, 75);
                canvas.Rectangle(rectangle);
                canvas.Stroke();

                string[] items = process.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                //foreach (string item in items)
                //{
                //    newT = new Text(item);
                //    texts.Add(newT);
                //}
                items = null;
                texts.Add(storageText);
                texts.Add(cleaningText);
                texts.Add(repairingText);
                texts.Add(upgradeText);
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
                //foreach (string item in items)
                //{
                //    newT = new Text(item);
                //    texts.Add(newT);
                //}
                items = null;
                texts.Add(new Text(arrivalTime.ToString()));
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
                .ShowText("Repair made without the guarantee that the board works")
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

                
                if (listaComponentes.Count > 0 && checkComponents(listaComponentes))
                {
                    #region Third page "Catalog"
                    titleCounter++;
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                    document.Add(new Paragraph((titleCounter + "   Catalog\n")).SetFont(font).SetFontSize(14).SetMarginTop(0f).SetBold());
                    document.Add(new Paragraph((titleCounter + "." + subtitleCounter + "  Components Information:\n")).SetFont(font).SetFontSize(12).SetMarginTop(0f).SetBold());
                    InsertComponent(pdf, listaComponentes);
                    titleCounter++;
                    #endregion
                    #region Cleaning
                    //Cleaning
                    //document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                    //pdf.AddNewPage();
                    pages++;
                    //var pageX = pdf.GetPage(pages);
                    //var canvasX = new PdfCanvas(pageX);
                    document.Add(new Paragraph(titleCounter + "   Components Cleaning\n\n").SetFont(font).SetFontSize(14).SetMarginTop(0f).SetBold());
                    document.Add(new Paragraph(titleCounter + "." + subtitleCounter +" Before Cleaning\n").SetFont(font).SetFontSize(12).SetMarginTop(0f).SetBold());

                    // Create a new table with two columns
                    float tableWidth = PageSize.A4.GetWidth() - document.GetLeftMargin() - document.GetRightMargin();
                    //Table table = new Table(UnitValue.CreatePointArray(new float[] { tableWidth / 2, tableWidth / 2 }));
                    var table = new iText.Layout.Element.Table(new float[] { 1, 1 }).UseAllAvailableWidth();
                    table.SetFixedLayout();
                    var emptyCell = new Cell().SetBorder(Border.NO_BORDER);
                    //var resto = listaComponentes.Count() % 3;
                    componentCounter = 0;

                    foreach (Component comp in listaComponentes)
                    {
                        if (componentCounter == 1 || componentCounter == 2)
                        {
                            title = new Paragraph(("\n\n" + titleCounter + "." + subtitleCounter + "." + (componentCounter + 1) + " " + comp.name + "\n")).SetFont(font).SetFontSize(10).SetMarginTop(0f).SetBold();
                        }
                        else title = new Paragraph((titleCounter + "." + subtitleCounter + "." + (componentCounter + 1) + " " + comp.name + "\n")).SetFont(font).SetFontSize(10).SetMarginTop(0f).SetBold();

                        // Create two new cells for the descriptions
                        var titleCell = new Cell().Add(title).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingRight(5).SetTextAlignment(TextAlignment.LEFT);

                        // Create six Image objects
                        im = ImageDataFactory.Create(comp.componentBeforeFrontImage1);
                        imageBeforeFront1 = new Image(im);
                        im = ImageDataFactory.Create(comp.componentBeforeBackImage1);
                        imageBeforeBack1 = new Image(im);

                        if (comp.componentBeforeFrontImage2 != null)
                        {
                            im = ImageDataFactory.Create(comp.componentBeforeFrontImage2);
                            imageBeforeFront2 = new Image(im);
                        }
                        else imageBeforeFront2 = ResourceImage();

                        if (comp.componentBeforeFrontImage3 != null)
                        {
                            im = ImageDataFactory.Create(comp.componentBeforeFrontImage3);
                            imageBeforeFront3 = new Image(im);
                        }
                        else imageBeforeFront3 = ResourceImage();

                        if (comp.componentBeforeBackImage2 != null)
                        {
                            im = ImageDataFactory.Create(comp.componentBeforeBackImage2);
                            imageBeforeBack2 = new Image(im);
                        }
                        else imageBeforeBack2 = ResourceImage();

                        if (comp.componentBeforeBackImage3 != null)
                        {
                            im = ImageDataFactory.Create(comp.componentBeforeBackImage3);
                            imageBeforeBack3 = new Image(im);
                        }
                        else imageBeforeBack3 = ResourceImage();

                        //image.ScaleToFit(175,175);

                        imageBeforeFront1.SetMaxHeight(140);
                        imageBeforeFront1.SetMaxWidth(175);
                        imageBeforeBack1.SetMaxHeight(140);
                        imageBeforeBack1.SetMaxWidth(175);
                        imageBeforeBack1.SetHorizontalAlignment(HorizontalAlignment.RIGHT);

                        imageBeforeFront2.SetMaxHeight(140);
                        imageBeforeFront2.SetMaxWidth(175);
                        imageBeforeBack2.SetMaxHeight(140);
                        imageBeforeBack2.SetMaxWidth(175);
                        imageBeforeBack2.SetHorizontalAlignment(HorizontalAlignment.RIGHT);

                        imageBeforeFront3.SetMaxHeight(140);
                        imageBeforeFront3.SetMaxWidth(175);
                        imageBeforeBack3.SetMaxHeight(140);
                        imageBeforeBack3.SetMaxWidth(175);
                        imageBeforeBack3.SetHorizontalAlignment(HorizontalAlignment.RIGHT);

                        Cell cell1 = new Cell().Add(imageBeforeFront1).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingRight(10);
                        Cell cell2 = new Cell().Add(imageBeforeBack1).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingLeft(10);
                        Cell cell3 = new Cell().Add(imageBeforeFront2).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingRight(10);
                        Cell cell4 = new Cell().Add(imageBeforeBack2).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingLeft(10);
                        Cell cell5 = new Cell().Add(imageBeforeFront3).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingRight(10);
                        Cell cell6 = new Cell().Add(imageBeforeBack3).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingLeft(10);

                        // Create six Paragraph objects for the descriptions
                        var description1 = new Paragraph("Figure." + imageCounter + " " + comp.name + " before cleaning front side\n\n").SetFontSize(9).SetFont(font);
                        imageCounter++;
                        var description2 = new Paragraph("Figure." + imageCounter + " " + comp.name + " before cleaning back side\n\n").SetFontSize(9).SetFont(font).SetTextAlignment(TextAlignment.RIGHT);
                        imageCounter++;// Create two Paragraph objects for the descriptions
                        var description3 = new Paragraph("Figure." + imageCounter + " " + comp.name + " before cleaning front side\n\n").SetFontSize(9).SetFont(font);
                        imageCounter++;
                        var description4 = new Paragraph("Figure." + imageCounter + " " + comp.name + " before cleaning back side\n\n").SetFontSize(9).SetFont(font).SetTextAlignment(TextAlignment.RIGHT);
                        imageCounter++;// Create two Paragraph objects for the descriptions
                        var description5 = new Paragraph("Figure." + imageCounter + " " + comp.name + " before cleaning front side\n\n").SetFontSize(9).SetFont(font);
                        imageCounter++;
                        var description6 = new Paragraph("Figure." + imageCounter + " " + comp.name + " before cleaning back side\n\n").SetFontSize(9).SetFont(font).SetTextAlignment(TextAlignment.RIGHT);
                        imageCounter++;

                        // Create six new cells for the descriptions
                        var descriptionCell1 = new Cell().Add(description1).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingRight(5).SetTextAlignment(TextAlignment.LEFT);
                        var descriptionCell2 = new Cell().Add(description2).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingLeft(5).SetTextAlignment(TextAlignment.LEFT);
                        var descriptionCell3 = new Cell().Add(description3).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingRight(5).SetTextAlignment(TextAlignment.LEFT);
                        var descriptionCell4 = new Cell().Add(description4).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingLeft(5).SetTextAlignment(TextAlignment.LEFT);
                        var descriptionCell5 = new Cell().Add(description5).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingRight(5).SetTextAlignment(TextAlignment.LEFT);
                        var descriptionCell6 = new Cell().Add(description6).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingLeft(5).SetTextAlignment(TextAlignment.LEFT);

                        // Add the description cells to the second row of the table
                        table.AddCell(titleCell);
                        table.AddCell(emptyCell);

                        // Add the images to the table
                        table.AddCell(cell1);
                        table.AddCell(cell2);

                        // Add the description cells to the second row of the table
                        table.AddCell(descriptionCell1);
                        table.AddCell(descriptionCell2);

                        // Add the images to the table
                        table.AddCell(cell3);
                        table.AddCell(cell4);

                        // Add the description cells to the second row of the table
                        table.AddCell(descriptionCell3);
                        table.AddCell(descriptionCell4);

                        // Add the images to the table
                        table.AddCell(cell5);
                        table.AddCell(cell6);

                        // Add the description cells to the second row of the table
                        table.AddCell(descriptionCell5);
                        table.AddCell(descriptionCell6);

                        componentCounter++;
                        subtitleCounter++;
                        document.Add(table);
                        if(componentCounter < listaComponentes.Count)
                        {
                            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                            table = new iText.Layout.Element.Table(new float[] { 1, 1 }).UseAllAvailableWidth();
                            table.SetFixedLayout();
                        }
                    }
                    table = new iText.Layout.Element.Table(new float[] { 1, 1 }).UseAllAvailableWidth();
                    table.SetFixedLayout();
                    //var resto = listaComponentes.Count() % 3;
                    componentCounter = 0;
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                    document.Add(new Paragraph(titleCounter + "." + subtitleCounter + " After Cleaning\n").SetFont(font).SetFontSize(14).SetMarginTop(0f).SetBold());
                    //AddComponentsAfterCleaning(listaComponentes, table, emptyCell);
                    #endregion
                }
                document.Close();
                MessageBox.Show("PDF Created on" + outputPath);
                ShowFile.OpenFile(outputPath);
            }
            catch (Exception ex)
            {
                document.Close();
                MessageBox.Show(ex.Message);
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
            finally { }
        }

        private bool checkComponents(List<Component> listaComponentes)
        {
            foreach(Component comp in listaComponentes)
            {
                if(comp.componentBeforeFrontImage1 == null && comp.componentAfterFrontImage1 == null)
                {
                    return false;
                }
            }
            return true;
        }

        private void AddComponentsAfterCleaning(List<Component> listaComponentes, iText.Layout.Element.Table table, Cell emptyCell)
        {
            componentCounter = 0;
            foreach (Component comp in listaComponentes)
            {
                if (componentCounter == 1 || componentCounter == 2)
                {
                    title = new Paragraph(("\n\n" + titleCounter + "." + subtitleCounter + "." + (componentCounter+1) + " " + comp.name + " After Cleaning\n")).SetFont(font).SetFontSize(10).SetMarginTop(0f).SetBold();
                }
                else title = new Paragraph((titleCounter + "." + subtitleCounter + "." + (componentCounter + 1) + " " + comp.name + " After Cleaning\n")).SetFont(font).SetFontSize(10).SetMarginTop(0f).SetBold();

                // Create two new cells for the descriptions
                var titleCell = new Cell().Add(title).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingRight(5).SetTextAlignment(TextAlignment.LEFT);

                // Create six Image objects
                im = ImageDataFactory.Create(comp.componentAfterFrontImage1);
                imageAfterFront1 = new Image(im);
                im = ImageDataFactory.Create(comp.componentAfterBackImage1);
                imageAfterBack1 = new Image(im);

                if (comp.componentAfterFrontImage2 != null)
                {
                    im = ImageDataFactory.Create(comp.componentAfterFrontImage2);
                    imageAfterFront2 = new Image(im);
                }
                else imageAfterFront2 = ResourceImage();

                if (comp.componentAfterFrontImage3 != null)
                {
                    im = ImageDataFactory.Create(comp.componentAfterFrontImage3);
                    imageAfterFront3 = new Image(im);
                }
                else imageAfterFront3 = ResourceImage();

                if (comp.componentAfterBackImage2 != null)
                {
                    im = ImageDataFactory.Create(comp.componentAfterBackImage2);
                    imageAfterBack2 = new Image(im);
                }
                else imageAfterBack2 = ResourceImage();

                if (comp.componentAfterBackImage3 != null)
                {
                    im = ImageDataFactory.Create(comp.componentAfterBackImage3);
                    imageAfterBack3 = new Image(im);
                }
                else imageAfterBack3 = ResourceImage();

                //image.ScaleToFit(175,175);

                imageAfterFront1.SetMaxHeight(140);
                imageAfterFront1.SetMaxWidth(175);
                imageAfterBack1.SetMaxHeight(140);
                imageAfterBack1.SetMaxWidth(175);
                imageAfterBack1.SetHorizontalAlignment(HorizontalAlignment.RIGHT);

                imageAfterFront2.SetMaxHeight(140);
                imageAfterFront2.SetMaxWidth(175);
                imageAfterBack2.SetMaxHeight(140);
                imageAfterBack2.SetMaxWidth(175);
                imageAfterBack2.SetHorizontalAlignment(HorizontalAlignment.RIGHT);

                imageAfterFront3.SetMaxHeight(140);
                imageAfterFront3.SetMaxWidth(175);
                imageAfterBack3.SetMaxHeight(140);
                imageAfterBack3.SetMaxWidth(175);
                imageAfterBack3.SetHorizontalAlignment(HorizontalAlignment.RIGHT);

                Cell cell1 = new Cell().Add(imageAfterFront1).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingRight(10);
                Cell cell2 = new Cell().Add(imageAfterBack1).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingLeft(10);
                Cell cell3 = new Cell().Add(imageAfterFront2).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingRight(10);
                Cell cell4 = new Cell().Add(imageAfterBack2).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingLeft(10);
                Cell cell5 = new Cell().Add(imageAfterFront3).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingRight(10);
                Cell cell6 = new Cell().Add(imageAfterBack3).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingLeft(10);

                // Create six Paragraph objects for the descriptions
                var description1 = new Paragraph("Figure." + imageCounter + " " + comp.name + " After cleaning front side").SetFontSize(9).SetFont(font);
                imageCounter++;
                var description2 = new Paragraph("Figure." + imageCounter + " " + comp.name + " After cleaning back side").SetFontSize(9).SetFont(font).SetTextAlignment(TextAlignment.RIGHT);
                imageCounter++;// Create two Paragraph objects for the descriptions
                var description3 = new Paragraph("Figure." + imageCounter + " " + comp.name + " After cleaning front side").SetFontSize(9).SetFont(font);
                imageCounter++;
                var description4 = new Paragraph("Figure." + imageCounter + " " + comp.name + " After cleaning back side").SetFontSize(9).SetFont(font).SetTextAlignment(TextAlignment.RIGHT);
                imageCounter++;// Create two Paragraph objects for the descriptions
                var description5 = new Paragraph("Figure." + imageCounter + " " + comp.name + " After cleaning front side").SetFontSize(9).SetFont(font);
                imageCounter++;
                var description6 = new Paragraph("Figure." + imageCounter + " " + comp.name + " After cleaning back side").SetFontSize(9).SetFont(font).SetTextAlignment(TextAlignment.RIGHT);
                imageCounter++;

                // Create six new cells for the descriptions
                var descriptionCell1 = new Cell().Add(description1).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingRight(5).SetTextAlignment(TextAlignment.LEFT);
                var descriptionCell2 = new Cell().Add(description2).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingLeft(5).SetTextAlignment(TextAlignment.LEFT);
                var descriptionCell3 = new Cell().Add(description3).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingRight(5).SetTextAlignment(TextAlignment.LEFT);
                var descriptionCell4 = new Cell().Add(description4).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingLeft(5).SetTextAlignment(TextAlignment.LEFT);
                var descriptionCell5 = new Cell().Add(description5).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingRight(5).SetTextAlignment(TextAlignment.LEFT);
                var descriptionCell6 = new Cell().Add(description6).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingLeft(5).SetTextAlignment(TextAlignment.LEFT);

                // Add the description cells to the second row of the table
                table.AddCell(titleCell);
                table.AddCell(emptyCell);

                // Add the images to the table
                table.AddCell(cell1);
                table.AddCell(cell2);

                // Add the description cells to the second row of the table
                table.AddCell(descriptionCell1);
                table.AddCell(descriptionCell2);

                // Add the images to the table
                table.AddCell(cell3);
                table.AddCell(cell4);

                // Add the description cells to the second row of the table
                table.AddCell(descriptionCell3);
                table.AddCell(descriptionCell4);

                // Add the images to the table
                table.AddCell(cell5);
                table.AddCell(cell6);

                // Add the description cells to the second row of the table
                table.AddCell(descriptionCell5);
                table.AddCell(descriptionCell6);

                componentCounter++;
                subtitleCounter++;
                // Add the table to the document
                document.Add(table);
                if (componentCounter < listaComponentes.Count)
                {
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                    table = new iText.Layout.Element.Table(new float[] { 1, 1 }).UseAllAvailableWidth();
                    table.SetFixedLayout();
                }
            }
        }

        private Image ResourceImage()
        {
            // Load the replacement image from resources
            System.Drawing.Bitmap replacementBitmap = Resources.image_placeholder;
            // Convert the bitmap to a byte array
            byte[] imageDataBytes;
            using (MemoryStream stream = new MemoryStream())
            {
                replacementBitmap.Save(stream, replacementBitmap.RawFormat);
                imageDataBytes = stream.ToArray();
            }
            // Create an ImageData object from the byte array
            ImageData imageData = ImageDataFactory.Create(imageDataBytes);
            //return imageData;
            // Create an iText.Layout.Element.Image object from the ImageData object
            var tempImage = new Image(imageData);
            return tempImage;
        }

        //Writes a list of all the components and then shows each one
        private void InsertComponent(PdfDocument pdf, List<Component> listaComponentes)
        {
            //int i = 0;
            Paragraph text;
            pageChanged = false;
            foreach (Component comp in listaComponentes)
            {
                text = new Paragraph("\0\t\t" + "• Component " + componentCounter + " - " + serialNum + "-" + comp.name);
                document.Add(text.SetFontSize(12).SetFont(font).SetBold());

                label = new Text("\0\t\t\t" + "Units: ").SetFontSize(12).SetFont(font);
                value = new Text(comp.quantity).SetFontSize(12).SetFont(font).SetBold();
                text = new Paragraph();
                text.Add(label).Add(value);
                document.Add(text);

                label = new Text("\0\t\t\t" + "Location: ").SetFontSize(12).SetFont(font);
                value = new Text(comp.location).SetFontSize(12).SetFont(font).SetBold();
                text = new Paragraph();
                text.Add(label).Add(value);
                document.Add(text);

                label = new Text("\0\t\t\t" + "Component state: ").SetFontSize(12).SetFont(font);
                value = new Text(componentStates[comp.state]).SetFontSize(12).SetFont(font).SetBold();
                text = new Paragraph();
                text.Add(label).Add(value);
                document.Add(text);

                componentCounter++;            
            }
            //document.Add(new Paragraph("\n"));
            //componentCounter = 1;
            //for (i = 0; i < listaComponentes.Count; i++)
            //{
            //    text = new Paragraph(titleCounter + "." + subtitleCounter + "." + componentCounter + "  " + listaComponentes[i].name);
            //    document.Add(text.SetFontSize(9).SetFont(font).SetBold());
            //    //text = new Paragraph(listaComponentes[i].description);
            //    text = new Paragraph(listaComponentes[i].location);
            //    document.Add(text.SetFontSize(8).SetFont(font).SetMarginTop(0f));
            //    ImageData im = ImageDataFactory.Create(listaComponentes[i].componentBeforeFrontImage1);
            //    Image image = new Image(im);
            //    //image.ScaleToFit(175,175);
            //    image.SetMaxHeight(140);
            //    image.SetMaxWidth(175);
            //    image.ScaleToFit(documentWidth, (PageSize.A4.GetHeight() / 2));
            //    document.Add(image);
            //    text = new Paragraph("Figure " + imageCounter + ".  " + listaComponentes[i].name);
            //    document.Add(text.SetFontSize(9).SetFont(font));
            //    componentCounter++;
            //    imageCounter++;
            //    if ((i + 1) % 3 == 0 && (i+1)<listaComponentes.Count && !pageChanged)
            //    {
            //        document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
            //        pages++;
            //    }
            //}
            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
            pages++;
        }

        private void addTextRectangle(PdfCanvas canvas, Rectangle rectangle, List<Text> texts)
        {
            var canvas1 = new Canvas(canvas, rectangle);
            float x = rectangle.GetLeft() + 5;
            float y = rectangle.GetTop() - 20;
            foreach (Text text in texts)
            {
                if (text != null)
                {
                    //float width = text.GetText().Length;
                    canvas1.Add(new Paragraph(text).SetFont(font).SetFixedPosition(x, y, rectangle.GetWidth() - 10));
                    y -= 20;
                }
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
    //Every time a new page is created this function creates a header and a footer
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
                using (Bitmap original = new Bitmap(Properties.Resources.mc_2))
                {
                    original.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] imageBytes = memoryStream.ToArray();
                    ImageData image = ImageDataFactory.Create(imageBytes);
                    pdfCanvas.AddImageAt(image, pageSize.GetLeft() + 80, pageSize.GetTop() - 52, false);
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
            _anotherClassInstance.pageChanged = true;
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
