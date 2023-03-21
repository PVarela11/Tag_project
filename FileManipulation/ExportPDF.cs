﻿using iText.IO.Font.Constants;
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
        Text label, value, cleanText, troublesootingText, repairText, newT, summaryText;
        List<Text> texts = new List<Text>();
        int componentCounter = 1, titleCounter = 1, subtitleCounter = 1, imageCounter = 1, pages = 1;
        float docLeftMargin, docRightMargin, documentWidth;
        Image imageBefore1, imageBefore2, imageBefore3, imageBefore4, imageBefore5, imageBefore6,
            imageAfter1, imageAfter2, imageAfter3, imageAfter4, imageAfter5, imageAfter6;
        Paragraph title;
        byte[] imageBytes;
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
                summaryText = new Text(summary).SetFont(font).SetFontSize(10);
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
                //image.SetMaxHeight(PageSize.A4.GetHeight() / 2);
                //image.SetMaxWidth(documentWidth);
                image.ScaleToFit(documentWidth, (PageSize.A4.GetHeight() / 2));
                float imageWidth = image.GetImageScaledWidth();
                //image.ScaleToFit(imageWidth, PageSize.A4.GetHeight() / 2);
                float imageHeight = image.GetImageScaledHeight();
                Console.WriteLine(image.GetImageScaledHeight());
                Console.WriteLine(image.GetImageScaledWidth());
                float pageTop = PageSize.A4.GetTop();
                float pageBottom = PageSize.A4.GetBottom();
                

                if (documentWidth > imageWidth)
                {
                    float x = (documentWidth - imageWidth) / 2;
                }
                //if (imageWidth < imageHeight)
                //{
                image.SetHorizontalAlignment(HorizontalAlignment.CENTER);
                image.SetMarginLeft(x);
                //}
                ////image.ScaleToFit(610, 264);
                
                document.Add(image);
                //document.Add(new Paragraph("\n\n\n\n"));

                //Draw rectangle in first page for the summary
                //document.Add(new Paragraph("Summary:").SetFont(font).SetBold().SetFontSize(10));
                
                if (imageHeight > pageTop)
                {
                    imageHeight = PageSize.A4.GetHeight() / 2;
                }
                float bellowImg = PageSize.A4.GetTop() - (imageHeight + 80 + 48);
                
                
                Rectangle summaryRectangle = new Rectangle(PageSize.A4.GetLeft() + 80, bellowImg - 200, PageSize.A4.GetRight() - 160, 100);
                
                
                canvas1.Rectangle(summaryRectangle);
                canvas1.Stroke();

                texts.Add(new Text("Summary:\n").SetFont(font).SetBold());
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
                if (listaComponentes.Count > 0)
                {
                    titleCounter++;
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                    document.Add(new Paragraph((titleCounter + "   Components\n")).SetFont(font).SetFontSize(14).SetMarginTop(0f).SetBold());
                    document.Add(new Paragraph((titleCounter + "." + subtitleCounter + "  Components List:\n")).SetFont(font).SetFontSize(12).SetMarginTop(0f).SetBold());
                    InsertComponent(pdf, listaComponentes);
                    titleCounter++;
                    //Cleaning
                    //document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                    //pdf.AddNewPage();
                    pages++;
                    var pageX = pdf.GetPage(pages);
                    var canvasX = new PdfCanvas(pageX);
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
                        ImageData im1 = ImageDataFactory.Create(comp.componentBeforeFrontImage1);
                        ImageData im4 = ImageDataFactory.Create(comp.componentBeforeBackImage1);
                        

                        imageBefore1 = new Image(im1);
                        imageBefore4 = new Image(im4);

                        if (comp.componentBeforeFrontImage2 != null)
                        {
                            ImageData im2 = ImageDataFactory.Create(comp.componentBeforeFrontImage2);
                            imageBefore2 = new Image(im2);
                        }
                        else imageBefore2 = ResourceImage();

                        if (comp.componentBeforeFrontImage3 != null)
                        {
                            ImageData im3 = ImageDataFactory.Create(comp.componentBeforeFrontImage3);
                            imageBefore3 = new Image(im3);
                        }
                        else imageBefore3 = ResourceImage();

                        if (comp.componentBeforeBackImage2 != null)
                        {
                            ImageData im5 = ImageDataFactory.Create(comp.componentBeforeBackImage2);
                            imageBefore5 = new Image(im5);
                        }
                        else imageBefore5 = ResourceImage();

                        if (comp.componentBeforeBackImage3 != null)
                        {
                            ImageData im6 = ImageDataFactory.Create(comp.componentBeforeBackImage3);
                            imageBefore6 = new Image(im6);
                        }
                        else imageBefore6 = ResourceImage();

                        //image.ScaleToFit(175,175);

                        imageBefore1.SetMaxHeight(140);
                        imageBefore1.SetMaxWidth(175);
                        imageBefore2.SetMaxHeight(140);
                        imageBefore2.SetMaxWidth(175);
                        imageBefore2.SetHorizontalAlignment(HorizontalAlignment.RIGHT);

                        imageBefore3.SetMaxHeight(140);
                        imageBefore3.SetMaxWidth(175);
                        imageBefore4.SetMaxHeight(140);
                        imageBefore4.SetMaxWidth(175);
                        imageBefore4.SetHorizontalAlignment(HorizontalAlignment.RIGHT);

                        imageBefore5.SetMaxHeight(140);
                        imageBefore5.SetMaxWidth(175);
                        imageBefore6.SetMaxHeight(140);
                        imageBefore6.SetMaxWidth(175);
                        imageBefore6.SetHorizontalAlignment(HorizontalAlignment.RIGHT);

                        Cell cell1 = new Cell().Add(imageBefore1).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingRight(10);
                        Cell cell2 = new Cell().Add(imageBefore2).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingLeft(10);
                        Cell cell3 = new Cell().Add(imageBefore3).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingRight(10);
                        Cell cell4 = new Cell().Add(imageBefore4).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingLeft(10);
                        Cell cell5 = new Cell().Add(imageBefore5).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingRight(10);
                        Cell cell6 = new Cell().Add(imageBefore6).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingLeft(10);

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
                        //if (compCounter == 3 && compCounter)
                        //{
                        //    if(compCounter >= listaComponentes.Count)
                        //    {
                        //        document.Add(table);
                        //    }
                        //    else
                        //    {
                        //        // If the combined height is greater than the available height, add a new page
                        //        document.Add(table);
                        //        document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                        //        table = new iText.Layout.Element.Table(new float[] { 1, 1 }).UseAllAvailableWidth();
                        //        table.SetFixedLayout();
                        //        compCounter = 0;
                        //    }
                        //}
                        // Add the table to the document
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
                    AddComponentsAfterCleaning(listaComponentes, table, emptyCell);
                }
                #endregion

                #region after and before clean
                //document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                //document.Add(setTitle("Before Cleaning").SetFont(font));
                //if (initialImages.Count > 6)
                //{
                //    insertImg(initialImages.Take(6).ToList());
                //    initialImages.RemoveRange(0, 6);
                //}
                //else
                //{
                //    insertImg(initialImages);
                //    initialImages.Clear();
                //}
                //
                //
                //document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                //document.Add(setTitle("After Cleaning").SetFont(font));
                //if (finalImages.Count > 6)
                //{
                //    insertImg(finalImages.Take(6).ToList());
                //    finalImages.RemoveRange(0, 6);
                //}
                //else
                //{
                //    insertImg(finalImages);
                //    finalImages.Clear();
                //}
                //
                //if (initialImages.Count > 0)
                //{
                //    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                //    document.Add(setTitle("More before cleaning images").SetFont(font));
                //    insertImg(initialImages);
                //}
                //
                //if (finalImages.Count > 0)
                //{
                //    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                //    document.Add(setTitle("More after cleaning images").SetFont(font));
                //    insertImg(finalImages);
                //}
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
                ImageData im1 = ImageDataFactory.Create(comp.componentAfterFrontImage1);
                ImageData im4 = ImageDataFactory.Create(comp.componentAfterBackImage1);


                imageAfter1 = new Image(im1);
                imageAfter4 = new Image(im4);

                if (comp.componentAfterFrontImage2 != null)
                {
                    ImageData im2 = ImageDataFactory.Create(comp.componentAfterFrontImage2);
                    imageAfter2 = new Image(im2);
                }
                else imageAfter2 = ResourceImage();

                if (comp.componentAfterFrontImage3 != null)
                {
                    ImageData im3 = ImageDataFactory.Create(comp.componentAfterFrontImage3);
                    imageAfter3 = new Image(im3);
                }
                else imageAfter3 = ResourceImage();

                if (comp.componentAfterBackImage2 != null)
                {
                    ImageData im5 = ImageDataFactory.Create(comp.componentAfterBackImage2);
                    imageAfter5 = new Image(im5);
                }
                else imageAfter5 = ResourceImage();

                if (comp.componentAfterBackImage3 != null)
                {
                    ImageData im6 = ImageDataFactory.Create(comp.componentAfterBackImage3);
                    imageAfter6 = new Image(im6);
                }
                else imageAfter6 = ResourceImage();

                //image.ScaleToFit(175,175);

                imageAfter1.SetMaxHeight(140);
                imageAfter1.SetMaxWidth(175);
                imageAfter2.SetMaxHeight(140);
                imageAfter2.SetMaxWidth(175);
                imageAfter2.SetHorizontalAlignment(HorizontalAlignment.RIGHT);

                imageAfter3.SetMaxHeight(140);
                imageAfter3.SetMaxWidth(175);
                imageAfter4.SetMaxHeight(140);
                imageAfter4.SetMaxWidth(175);
                imageAfter4.SetHorizontalAlignment(HorizontalAlignment.RIGHT);

                imageAfter5.SetMaxHeight(140);
                imageAfter5.SetMaxWidth(175);
                imageAfter6.SetMaxHeight(140);
                imageAfter6.SetMaxWidth(175);
                imageAfter6.SetHorizontalAlignment(HorizontalAlignment.RIGHT);

                Cell cell1 = new Cell().Add(imageAfter1).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingRight(10);
                Cell cell2 = new Cell().Add(imageAfter2).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingLeft(10);
                Cell cell3 = new Cell().Add(imageAfter3).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingRight(10);
                Cell cell4 = new Cell().Add(imageAfter4).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingLeft(10);
                Cell cell5 = new Cell().Add(imageAfter5).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingRight(10);
                Cell cell6 = new Cell().Add(imageAfter6).SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).SetPaddingLeft(10);

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
                //if (compCounter == 3 && compCounter)
                //{
                //    if(compCounter >= listaComponentes.Count)
                //    {
                //        document.Add(table);
                //    }
                //    else
                //    {
                //        // If the combined height is greater than the available height, add a new page
                //        document.Add(table);
                //        document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                //        table = new iText.Layout.Element.Table(new float[] { 1, 1 }).UseAllAvailableWidth();
                //        table.SetFixedLayout();
                //        compCounter = 0;
                //    }
                //}
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

        private void InsertComponent(PdfDocument pdf, List<Component> listaComponentes)
        {
            int i = 0;
            Paragraph text;

            foreach (Component comp in listaComponentes)
            {
                text = new Paragraph("\0\t\t" + "• Component " + componentCounter + " - " + comp.name);
                document.Add(text.SetFontSize(12).SetFont(font));
                componentCounter++;
            }
            document.Add(new Paragraph("\n"));
            componentCounter = 1;
            for (i = 0; i < listaComponentes.Count; i++)
            {
                text = new Paragraph(titleCounter + "." + subtitleCounter + "." + componentCounter + "  " + listaComponentes[i].name);
                document.Add(text.SetFontSize(9).SetFont(font).SetBold());
                text = new Paragraph(listaComponentes[i].description);
                document.Add(text.SetFontSize(8).SetFont(font).SetMarginTop(0f));
                ImageData im = ImageDataFactory.Create(listaComponentes[i].componentAfterFrontImage1);
                Image image = new Image(im);
                //image.ScaleToFit(175,175);
                image.SetMaxHeight(140);
                image.SetMaxWidth(175);
                image.ScaleToFit(documentWidth, (PageSize.A4.GetHeight() / 2));
                document.Add(image);
                text = new Paragraph("Figure " + imageCounter + ".  " + listaComponentes[i].name);
                document.Add(text.SetFontSize(9).SetFont(font));
                componentCounter++;
                imageCounter++;
                if ((i + 1) % 3 == 0 && (i+1)<listaComponentes.Count)
                {
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                    pages++;
                }
            }
            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
            pages++;
        }

        private void addTextRectangle(PdfCanvas canvas, Rectangle rectangle, List<Text> texts)
        {
            var canvas1 = new Canvas(canvas, rectangle);
            float x = rectangle.GetLeft() + 10;
            float y = rectangle.GetTop() - 20;
            foreach (Text text in texts)
            {
                float width = text.GetText().Length;
                canvas1.Add(new Paragraph(text).SetFont(font).SetFixedPosition(x,y,rectangle.GetWidth()));
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
