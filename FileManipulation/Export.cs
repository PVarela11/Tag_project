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

        public Export(int serialNum, bool clean, List<string> imagesPath, int imgCount, bool finish, string s) 
        {
            createImg(imagesPath, imgCount);
            path = s + "/Report_" + serialNum;
            // Create a list of data to be converted to CSV
            List<string[]> data = new List<string[]>
            {
                new string[] {serialNum.ToString(), clean.ToString(),imgCount.ToString()},
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
                    //Write the image to the folder
                    WriteImages(imgCount, imagesPath);
                }
                else
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
                    // Write the data to a CSV file
                    WriteCSV(filePath, data);
                    //Write the image to the folder
                    WriteImages(imgCount, imagesPath);
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

        private void WriteImages(int imgCount, List<string> imagesPath)
        {
            if (imgCount == 1)
            {
                imagesPath[0] = Path.Combine(path, imgName);
                if (!CheckIfImageExists(path, imagesPath[0]))
                {
                    using (FileStream stream = new FileStream(imagesPath[0], FileMode.Create))
                    {
                        image.Save(stream, ImageFormat.Jpeg);
                    }
                    return;
                }
            }
            else
            {
                for (int i = 0; i < imgCount; i++)
                {
                    imgName = Path.GetFileName(imagesPath[i]);
                    imagesPath[i] = Path.Combine(path, imgName);
                    if (!CheckIfImageExists(path, imagesPath[i]))
                    {
                        images[i].Save(imagesPath[i], ImageFormat.Jpeg);
                        using (FileStream stream = new FileStream(imagesPath[i], FileMode.Create))
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
                    sw.WriteLine(string.Join(",", row));
                }
                sw.Close();
            }
        }

        private void createImg(List<string> imgPath, int imgCount)
        {
            if(imgCount == 1)
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
                    for (int i = 0; i < imgCount; i++)
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
