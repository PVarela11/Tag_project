using System;
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
        public string path { get; set; }
        public string initialImagesFolder { get; set; }
        public string finalImagesFolder { get; set; }
        public string labelImagesFolder { get; set; }
        public List<string> labelList { get; set; }
        DirectoryInfo di;
        public Export(
            string serialNum,
            bool clean,
            List<string> initialImages,
            List<string> finalImages,
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
            string labelPath
            )
        {
            if (labelPath != null)
            {
                labelList = new List<string>();
                labelList.Add(labelPath);
            }
            string tempPath = "";
            string tempReportNum = serialNum.Substring(8);
            string subPath = s.Substring(s.Length - 8);
            if (tempReportNum != subPath && isNumeric(subPath))
            {
                tempPath = s.Replace(subPath, tempReportNum);
            }
            else tempPath = s;
            Console.WriteLine(tempPath);
            if(serialNum.Length > 8)
            {
                serialNum = serialNum.Substring(4);
            }
            string report = "\\" + serialNum;

            if (!tempPath.Contains(report))
            {
                path = tempPath + report;
            }
            else path = tempPath;
            initialImagesFolder = path + "\\BeforeClean";
            finalImagesFolder = path + "\\AfterClean";
            labelImagesFolder = path + "\\Label";

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
                    if (Directory.Exists(initialImagesFolder) && (initialImages.Count > 0))
                    {
                        createImg(initialImages);
                        WriteImages(initialImages, initialImagesFolder);
                    }
                    else if (finalImages.Count > 0)
                    {
                        // Try to create the directory.
                        di = Directory.CreateDirectory(finalImagesFolder);
                        di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                        //di.Attributes = FileAttributes.Directory | FileAttributes.Normal;
                        createImg(finalImages);
                        WriteImages(finalImages, finalImagesFolder);
                    }
                    if (Directory.Exists(finalImagesFolder) && (finalImages.Count > 0))
                    {
                        createImg(finalImages);
                        WriteImages(finalImages, finalImagesFolder);
                    }
                    else if (finalImages.Count > 0)
                    {
                        // Try to create the directory.
                        di = Directory.CreateDirectory(finalImagesFolder);
                        di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                        //di.Attributes = FileAttributes.Directory | FileAttributes.Normal;
                        createImg(finalImages);
                        WriteImages(finalImages, finalImagesFolder);
                    }
                    if (Directory.Exists(labelImagesFolder) && (labelPath != null))
                    {
                            createImg(labelList);
                            WriteImages(labelList, labelImagesFolder);
                    }
                    else if (labelPath != null)
                    {
                        // Try to create the directory.
                        di = Directory.CreateDirectory(finalImagesFolder);
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
                    if (Directory.Exists(initialImagesFolder) && (initialImages.Count > 0))
                    {
                        //Write the image to the folder
                        createImg(initialImages);
                        WriteImages(initialImages, initialImagesFolder);
                    }
                    else if (initialImages.Count > 0)
                    {
                        //Write the image to the folder
                        // Try to create the directory.
                        di = Directory.CreateDirectory(initialImagesFolder);
                        di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                        createImg(initialImages);
                        WriteImages(initialImages, initialImagesFolder);
                    }

                    if (Directory.Exists(finalImagesFolder) && (finalImages.Count > 0))
                    {
                        createImg(finalImages);
                        WriteImages(finalImages, finalImagesFolder);
                    }
                    else if (finalImages.Count > 0)
                    {
                        // Try to create the directory.
                        di = Directory.CreateDirectory(finalImagesFolder);
                        di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                        createImg(finalImages);
                        WriteImages(finalImages, finalImagesFolder);
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
            finally { }
            System.Windows.MessageBox.Show("File Exported Succesfully!");
        }


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
            string imagePath = Path.Combine(path, imageName);

            // Check if the file already exists
            if (File.Exists(imagePath))
            {
                Console.WriteLine("The image already exists");
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
                    if (list.Any(a => a.Contains(file)))
                    {
                        Console.WriteLine("The file is present in the list.");
                    }
                    else { File.Delete(file); }
                    
                }
            }
        }

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

        private void createImg(List<string> imgPath)
        {
            if (imgPath.Count == 1)
            {
                try
                {
                    imgName = Path.GetFileName(imgPath[0]);
                    Console.WriteLine(imgName);
                    image = new Bitmap(imgPath[0]);
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
                        image = new Bitmap(imgPath[i]);
                        images.Add(image);
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
