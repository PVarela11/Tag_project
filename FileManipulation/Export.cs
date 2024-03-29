﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace Tåg_project.FileManipulation
{
    internal class Export
    {
        Bitmap image;
        List<Image> images;
        string imgName;
        DirectoryInfo di;
        List<string[]> componentsData = new List<string[]>();
        public string path { get; set; }
        public string finalImagesFolder { get; set; }
        public string labelImagesFolder { get; set; }
        public string componentsFolder { get; set; }
        public string componentsImagesFolder { get; set; }
        public List<string> labelList { get; set; }
        public List<Component> components { get; set; }
        public Export(
            string serialNum,
            bool clean,
            string s,
            string observations,
            string comments,
            string process,
            bool troubleshoot,
            bool repair,
            bool result1,
            bool result2,
            bool result3,
            bool isImported,
            string summary,
            string labelPath,
            List<Component> listaComponentes
,
            bool storage,
            bool cleaning,
            bool repairing,
            bool upgrade,
            string arrivalDate)
        {
            //Add label image path to a list so it can be used by the function
            if (labelPath != null)
            {
                labelList = new List<string>();
                labelList.Add(labelPath);
            }
            //Add components info to list so it can be inserted to the csv file
            if (listaComponentes != null) 
            {
                components = listaComponentes;
                foreach (Component comp in components)
                {
                    var x = new string[]
                    {
                        comp.name,
                        //comp.description,
                        comp.quantity,
                        comp.location,
                        comp.state.ToString(),
                    };
                    componentsData.Add(x);
                }
            }
            string tempPath = "";
            string tempReportNum = serialNum.Substring(8);
            string subPath = s.Substring(s.Length - 8);
            //Error prevention on the serial number
            if (tempReportNum != subPath && isNumeric(subPath))
            {
                tempPath = s.Replace(subPath, tempReportNum);
            }
            else tempPath = s;
            Console.WriteLine(tempPath);
            //Error prevention on the serial number
            if (serialNum.Length > 8)
            {
                serialNum = serialNum.Substring(8);
            }
            string report = serialNum;
            string lastTwo = tempPath.Substring(tempPath.Length - 1);
            if (!tempPath.Contains(report))
            {
                if (lastTwo == "\\")
                {
                    path = tempPath + report;
                }
                else
                {
                    path = tempPath + "\\" + report;
                }
            }
            else path = tempPath;
            labelImagesFolder = path + "\\Label";

            componentsFolder = path + "\\Components";
            string componentsCSVPath = componentsFolder + "/components.csv";

            // Create a list of data to be converted to CSV
            List<string[]> data = new List<string[]>
            {
                new string[]
                {
                    serialNum.ToString(),
                    clean.ToString(),
                    observations,
                    comments,
                    process,
                    troubleshoot.ToString(),
                    repair.ToString(),
                    result1.ToString(),
                    result2.ToString(),
                    result3.ToString(),
                    summary,
                    storage.ToString(),
                    cleaning.ToString(),
                    repairing.ToString(),
                    upgrade.ToString(),
                    arrivalDate.ToString(),
                },
            };
            // Specify the directory you want to manipulate.
            string filePath = path + "/data.csv";

            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                    Console.WriteLine("That path exists already.");
                    if(!isImported)
                    {
                        DialogResult cancel = System.Windows.Forms.MessageBox.Show(
                            "The report you are creating already exists, if you continue the old one will be overrided." +
                            "\nDo you wish to continue ?", "Override", (MessageBoxButtons)MessageBoxButton.YesNo, (MessageBoxIcon)MessageBoxImage.Warning);
                        if (cancel== DialogResult.No)
                        {
                            return;
                        }
                    }
                    // Write the data to a CSV file
                    WriteCSV(filePath, data);
                    if (components.Count>0)
                    {
                        if (Directory.Exists(componentsFolder))
                        {
                            //Write csv
                            WriteCSV(componentsCSVPath, componentsData);
                            //Write the images in the specific subfolder
                            //CreateComponentsImage(componentsFolder, listaComponents)
                            CreateSubFolders(componentsFolder);
                        }
                        else
                        {
                            //Try create folder components
                            di = Directory.CreateDirectory(componentsFolder);
                            di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                            Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(componentsFolder));
                            //Write csv
                            WriteCSV(componentsCSVPath, componentsData);
                            //Create subfolders 1 per component
                            CreateSubFolders(componentsFolder);
                        }
                    }
                    if (Directory.Exists(labelImagesFolder) && (labelPath != null))
                    {
                            createImg(labelList);
                            WriteImages(labelList, labelImagesFolder);
                    }
                    else if (labelPath != null)
                    {
                        // Try to create the directory.
                        di = Directory.CreateDirectory(labelImagesFolder);
                        di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                        //di.Attributes = FileAttributes.Directory | FileAttributes.Normal;
                        createImg(labelList);
                        WriteImages(labelList, labelImagesFolder);
                    }
                }
                else
                {
                    // Try to create the directory.
                    di = Directory.CreateDirectory(path);
                    Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
                    // Write the data to a CSV file
                    WriteCSV(filePath, data);
                    if (Directory.Exists(labelImagesFolder) && (labelPath != null))
                    {
                        createImg(labelList);
                        WriteImages(labelList, labelImagesFolder);
                    }
                    else if (labelPath != null)
                    {
                        // Try to create the directory.
                        di = Directory.CreateDirectory(labelImagesFolder);
                        di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                        //di.Attributes = FileAttributes.Directory | FileAttributes.Normal;
                        createImg(labelList);
                        WriteImages(labelList, labelImagesFolder);
                    }   
                    if (components.Count > 0)
                    {
                        //Try create folder components
                        di = Directory.CreateDirectory(componentsFolder);
                        di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                        Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(componentsFolder));
                        //Write csv
                        WriteCSV(componentsCSVPath, componentsData);
                        //Create subfolders 1 per component
                        CreateSubFolders(componentsFolder);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
            finally { }
            System.Windows.MessageBox.Show("File Exported Succesfully!");
        }

        //Create folder for each component
        private void CreateSubFolders(string componentsFolder)
        {
            List<string> aux = new List<string>();
            foreach (Component comp in components)
            {
                aux.Add(comp.componentBeforeFrontImage1);
                aux.Add(comp.componentBeforeFrontImage2);
                aux.Add(comp.componentBeforeFrontImage3);

                aux.Add(comp.componentAfterFrontImage1);
                aux.Add(comp.componentAfterFrontImage2);
                aux.Add(comp.componentAfterFrontImage3);

                aux.Add(comp.componentBeforeBackImage1);
                aux.Add(comp.componentBeforeBackImage2);
                aux.Add(comp.componentBeforeBackImage3);

                aux.Add(comp.componentAfterBackImage1);
                aux.Add(comp.componentAfterBackImage2);
                aux.Add(comp.componentAfterBackImage3);
                string folder = componentsFolder + "\\" + comp.name;
                if (!Directory.Exists(folder))
                {
                    di = Directory.CreateDirectory(folder);
                }
               createImg(aux);
               InsertImages(comp, folder, aux);
               aux.Clear();
            }
            
        }

        //Insert every component images with the right name
        private void InsertImages(Component comp, string folder, List<string> aux)
        {
            string imgPath;
            string fileExtension;
            deleteOldImages(folder, aux);
            for(int i=0; i<=11; i++)
            {
                if (i==0 && comp.componentBeforeFrontImage1 != null)
                {
                    fileExtension = Path.GetExtension(comp.componentBeforeFrontImage1);
                    imgPath = folder + "/ComponentBeforeFrontIMG1" + fileExtension;
                    //deleteOldImages(newPath, imagesList);
                    if (!CheckIfImageExists(folder, "ComponentBeforeFrontIMG1" + fileExtension))
                    {
                        using (FileStream stream = new FileStream(imgPath, FileMode.Create))
                        {
                            images[i].Save(stream, ImageFormat.Jpeg);
                        }
                    }

                }
                else if (i == 1 && comp.componentBeforeFrontImage2 != null)
                {
                    fileExtension = Path.GetExtension(comp.componentBeforeFrontImage2);
                    imgPath = folder + "/ComponentBeforeFrontIMG2" + fileExtension;
                    if (!CheckIfImageExists(folder, "ComponentBeforeFrontIMG2" + fileExtension))
                    {
                        using (FileStream stream = new FileStream(imgPath, FileMode.Create))
                        {
                            images[i].Save(stream, ImageFormat.Jpeg);
                        }
                    }
                }
                else if (i == 2 && comp.componentBeforeFrontImage3 != null)
                {
                    fileExtension = Path.GetExtension(comp.componentBeforeFrontImage3);
                    imgPath = folder + "/ComponentBeforeFrontIMG3" + fileExtension;
                    if (!CheckIfImageExists(folder, "ComponentBeforeFrontIMG3" + fileExtension))
                    {
                        using (FileStream stream = new FileStream(imgPath, FileMode.Create))
                        {
                            images[i].Save(stream, ImageFormat.Jpeg);
                        }
                    }
                }
                else if (i == 3 && comp.componentAfterFrontImage1 != null)
                {
                    fileExtension = Path.GetExtension(comp.componentAfterFrontImage1);
                    imgPath = folder + "/ComponentAfterFrontIMG1" + fileExtension;
                    if (!CheckIfImageExists(folder, "ComponentAfterFrontIMG1" + fileExtension))
                    {
                        using (FileStream stream = new FileStream(imgPath, FileMode.Create))
                        {
                            images[i].Save(stream, ImageFormat.Jpeg);
                        }
                    }
                }
                else if (i == 4 && comp.componentAfterFrontImage2 != null)
                {
                    fileExtension = Path.GetExtension(comp.componentAfterFrontImage2);
                    imgPath = folder + "/ComponentAfterFrontIMG2" + fileExtension;
                    if (!CheckIfImageExists(folder, "ComponentAfterFrontIMG2" + fileExtension))
                    {
                        using (FileStream stream = new FileStream(imgPath, FileMode.Create))
                        {
                            images[i].Save(stream, ImageFormat.Jpeg);
                        }
                    }
                }
                else if (i == 5 && comp.componentAfterFrontImage3 != null)
                {
                    fileExtension = Path.GetExtension(comp.componentAfterFrontImage3);
                    imgPath = folder + "/ComponentAfterFrontIMG3" + fileExtension;
                    if (!CheckIfImageExists(folder, "ComponentAfterFrontIMG3" + fileExtension))
                    {
                        using (FileStream stream = new FileStream(imgPath, FileMode.Create))
                        {
                            images[i].Save(stream, ImageFormat.Jpeg);
                        }
                    }
                }
                else if (i == 6 && comp.componentBeforeBackImage1 != null)
                {
                    fileExtension = Path.GetExtension(comp.componentBeforeBackImage1);
                    imgPath = folder + "/ComponentBeforeBackIMG1" + fileExtension;
                    //deleteOldImages(newPath, imagesList);
                    if (!CheckIfImageExists(folder, "ComponentBeforeBackIMG1" + fileExtension))
                    {
                        using (FileStream stream = new FileStream(imgPath, FileMode.Create))
                        {
                            images[i].Save(stream, ImageFormat.Jpeg);
                        }
                    }

                }
                else if (i == 7 && comp.componentBeforeBackImage2 != null)
                {
                    fileExtension = Path.GetExtension(comp.componentBeforeBackImage2);
                    imgPath = folder + "/ComponentBeforeBackIMG2" + fileExtension;
                    if (!CheckIfImageExists(folder, "ComponentBeforeBackIMG2" + fileExtension))
                    {
                        using (FileStream stream = new FileStream(imgPath, FileMode.Create))
                        {
                            images[i].Save(stream, ImageFormat.Jpeg);
                        }
                    }
                }
                else if (i == 8 && comp.componentBeforeBackImage3 != null)
                {
                    fileExtension = Path.GetExtension(comp.componentBeforeBackImage3);
                    imgPath = folder + "/ComponentBeforeBackIMG3" + fileExtension;
                    if (!CheckIfImageExists(folder, "ComponentBeforeBackIMG3" + fileExtension))
                    {
                        using (FileStream stream = new FileStream(imgPath, FileMode.Create))
                        {
                            images[i].Save(stream, ImageFormat.Jpeg);
                        }
                    }
                }
                else if (i == 9 && comp.componentAfterBackImage1 != null)
                {
                    fileExtension = Path.GetExtension(comp.componentAfterBackImage1);
                    imgPath = folder + "/ComponentAfterBackIMG1" + fileExtension;
                    if (!CheckIfImageExists(folder, "ComponentAfterBackIMG1" + fileExtension))
                    {
                        using (FileStream stream = new FileStream(imgPath, FileMode.Create))
                        {
                            images[i].Save(stream, ImageFormat.Jpeg);
                        }
                    }
                }
                else if (i == 10 && comp.componentAfterBackImage2 != null)
                {
                    fileExtension = Path.GetExtension(comp.componentAfterBackImage2);
                    imgPath = folder + "/ComponentAfterBackIMG2" + fileExtension;
                    if (!CheckIfImageExists(folder, "ComponentAfterBackIMG2" + fileExtension))
                    {
                        using (FileStream stream = new FileStream(imgPath, FileMode.Create))
                        {
                            images[i].Save(stream, ImageFormat.Jpeg);
                        }
                    }
                }
                else if (i == 11 && comp.componentAfterBackImage3 != null)
                {
                    fileExtension = Path.GetExtension(comp.componentAfterBackImage3);
                    imgPath = folder + "/ComponentAfterBackIMG3" + fileExtension;
                    if (!CheckIfImageExists(folder, "ComponentAfterBackIMG3" + fileExtension))
                    {
                        using (FileStream stream = new FileStream(imgPath, FileMode.Create))
                        {
                            images[i].Save(stream, ImageFormat.Jpeg);
                        }
                    }
                }
            }
        }

        //Checks if string is only numbers
        private bool isNumeric(string subPath)
        {
            bool aux = true;
            foreach (char c in subPath)
            {
                if (!Char.IsDigit(c))
                {
                    aux = false;
                    break;
                }
            }
            return aux;
        }

        bool CheckIfImageExists(string directory, string imageName)
        {
            // Check if the directory exists
            if (!Directory.Exists(path))
            {
                Console.WriteLine("The directory does not exist");
                return false;
            }

            // Get the full path of the image
            string imagePath = Path.Combine(directory, imageName);

            // Check if the file already exists
            if (File.Exists(imagePath))
            {
                Console.WriteLine("The image already exists");
                //File.Delete(imagePath);
                return true;
            }
            return false;
        }

        private void deleteOldImages(string folder, List<String> list)
        {
            if (Directory.Exists(folder))
            {
                string[] files = Directory.GetFiles(folder);
                foreach (string file in files)
                {
                    if (list.Where(a => a != null).Any(a => a.Contains(file)))
                    {
                        Console.WriteLine("The file is present in the list.: {0}", file);
                    }
                    else
                    {
                        Console.WriteLine("The file was deleted.: {0}", file);
                        File.Delete(file); 
                    }
                    
                }
            }
        }

        //For label TODO:Join with createImg
        private void WriteImages(List<string> imagesList, string newPath)
        {
            deleteOldImages(newPath, imagesList);
            if (imagesList.Count == 1)
            {
                imagesList[0] = Path.Combine(newPath, imgName);
                if (!CheckIfImageExists(newPath, imagesList[0]))
                {
                    using (FileStream stream = new FileStream(imagesList[0], FileMode.Create))
                    {
                        image.Save(stream, ImageFormat.Jpeg);
                    }
                    return;
                }
            }
            else
            {
                for (int i = 0; i < imagesList.Count; i++)
                {
                    imgName = Path.GetFileName(imagesList[i]);
                    imagesList[i] = Path.Combine(newPath, imgName);
                    if (!CheckIfImageExists(newPath, imagesList[i]))
                    {
                        images[i].Save(imagesList[i], ImageFormat.Jpeg);
                        using (FileStream stream = new FileStream(imagesList[i], FileMode.Create))
                        {
                            images[i].Save(stream, ImageFormat.Jpeg);
                        }
                    }
                }
            }
        }

        private void WriteCSV(string filePath, List<string[]> data)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.GetEncoding("ISO-8859-1")))
            {
                foreach (string[] row in data)
                {
                    for (int i = 0; i < row.Length; i++)
                    {
                        row[i] = row[i].Replace("\r\n", "!r!n");
                    }
                    sw.WriteLine(string.Join("|", row));
                }
                sw.Close();
            }
        }

        //Turns paths of inside a list to a list of images
        private void createImg(List<string> imgPath)
        {
            if (imgPath.Count == 1)
            {
                try
                {
                    if (imgPath[0] != null)
                    {
                        imgName = Path.GetFileName(imgPath[0]);
                        Console.WriteLine(imgName);
                        image = new Bitmap(imgPath[0]);
                    }
                }
                catch (System.IO.FileNotFoundException)
                {
                    System.Windows.MessageBox.Show("The following path to the image does not exist: " + imgPath);
                }
            }
            else
            {
                try
                {

                    images = new List<Image>();
                    for (int i = 0; i < imgPath.Count; i++)
                    {
                        if (imgPath[i] != null)
                        {
                            image = new Bitmap(imgPath[i]);
                            images.Add(image);
                        }
                        else
                        {
                            Bitmap placeHolder = new Bitmap(Properties.Resources.image_placeholder);
                            images.Add(placeHolder);
                        }
                    }
                }
                catch (System.IO.FileNotFoundException)
                {
                    System.Windows.MessageBox.Show("Image not found!");
                }

                finally { }
            }
        }
    }
}
