using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


namespace TrainReport.FileManipulation
{
    internal class Export
    {
        Bitmap image;
        List<Image> images;
        string imgName;
        public string path { get; set; }
        public string initialImagesFolder { get; set; }
        public string finalImagesFolder { get; set; }

        public Export(string serialNum, bool clean, bool isEvaluated,
            bool isComponentReplaced, string whichComponents, bool finalEvaluation,
            string finalText, List<string> initialImages, List<string> finalImages, int imgCount, string s) 
        {
            string report = "\\Report_" + serialNum;
            
            if (!s.Contains(report))
            {
                path = s + report;
            }
            else path = s;
            initialImagesFolder = path + "\\BeforeRepair";
            finalImagesFolder = path + "\\AfterRepair";
            // Create a list of data to be converted to CSV
            List<string[]> data = new List<string[]>
            {
                new string[] {serialNum.ToString(), imgCount.ToString(), clean.ToString(), isEvaluated.ToString(), isComponentReplaced.ToString(), whichComponents, finalEvaluation.ToString(), finalText},
            };

            // Specify the directory you want to manipulate.
            string filePath = path + "/data.csv";


            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                    Console.WriteLine("That path exists already.");
                    // Write the data to a CSV file
                    WriteCSV(filePath, data);
                    if (Directory.Exists(initialImagesFolder))
                    {
                        //Write the image to the folder
                        if (initialImages.Count > 0)
                        {
                            createImg(initialImages);
                            WriteImages(initialImages, initialImagesFolder);
                        }
                    }
                    else
                    {
                        //Write the image to the folder
                        if (initialImages.Count > 0)
                        {
                            // Try to create the directory.
                            DirectoryInfo di = Directory.CreateDirectory(initialImagesFolder);
                            di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                            //di.Attributes = FileAttributes.Directory | FileAttributes.Normal;
                            createImg(initialImages);
                            WriteImages(initialImages, initialImagesFolder);
                        }
                    }

                    if (Directory.Exists(finalImagesFolder))
                    {
                        if (finalImages.Count > 0)
                        {
                            createImg(finalImages);
                            WriteImages(finalImages, finalImagesFolder);
                        }
                    }
                    else 
                    {
                        if (finalImages.Count > 0)
                        {
                            // Try to create the directory.
                            DirectoryInfo di = Directory.CreateDirectory(finalImagesFolder);
                            di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                            //di.Attributes = FileAttributes.Directory | FileAttributes.Normal;
                            createImg(finalImages);
                            WriteImages(finalImages, finalImagesFolder);
                        }
                    }   
                }
                else
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
                    // Write the data to a CSV file
                    WriteCSV(filePath, data);
                    if (Directory.Exists(initialImagesFolder))
                    {
                        //Write the image to the folder
                        if (initialImages.Count > 0)
                        {
                            createImg(initialImages);
                            WriteImages(initialImages, initialImagesFolder);
                        }
                    }
                    else
                    {
                        //Write the image to the folder
                        if (initialImages.Count > 0)
                        {
                            // Try to create the directory.
                            DirectoryInfo dn = Directory.CreateDirectory(initialImagesFolder);
                            dn.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                            createImg(initialImages);
                            WriteImages(initialImages, initialImagesFolder);
                        }
                    }

                    if (Directory.Exists(finalImagesFolder))
                    {
                        if (finalImages.Count > 0)
                        {
                            createImg(finalImages);
                            WriteImages(finalImages, finalImagesFolder);
                        }
                    }
                    else
                    {
                        if (finalImages.Count > 0)
                        {
                            // Try to create the directory.
                            DirectoryInfo dn = Directory.CreateDirectory(finalImagesFolder);
                            dn.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                            createImg(finalImages);
                            WriteImages(finalImages, finalImagesFolder);
                        }
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

        private void WriteImages(List<string> imagesList, string newPath)
        {
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
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (string[] row in data)
                {
                    sw.WriteLine(string.Join("|", row));
                }
                sw.Close();
            }
        }

        private void createImg(List<string> imgPath)
        {
            if(imgPath.Count == 1)
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
