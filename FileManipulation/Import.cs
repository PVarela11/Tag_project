using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace Tåg_project.FileManipulation
{
    internal class Import
    {
        public string serialNum { get; set; }
        public bool isClean { get; set; }
        public List<string> initialImagesPath { get; set; }
        public List<string> finalImagesPath { get; set; }
        public bool result1 { get; set; }
        public bool result2 { get; set; }
        public bool result3 { get; set; }
        public string comments { get; set; }
        public string observations { get; set; }
        public string process { get; set; }
        public bool repair { get; set; }
        public bool troubleshoot { get; set; }
        public string summary { get; set; }
        public string labelPath { get; set; }
        public List<Component> components { get; set; }

        public Import(string path)
        {
            string name, description;
            string[] lines;
            initialImagesPath = new List<string>();
            finalImagesPath = new List<string>();
            int counter = 0;
            try
            {
                string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
                foreach (string file in files)
                {
                    Console.WriteLine(file);
                    // Do something with the file
                    string fileExtension = Path.GetExtension(file);
                    if (fileExtension == ".csv" && file.Contains("data"))
                    {
                        lines = File.ReadAllLines(file, Encoding.GetEncoding("iso-8859-1"));
                        foreach (var line in lines)
                        {
                            var columns = line.Split('|');
                            foreach (var column in columns)
                            {
                                switch (counter)
                                {
                                    case 0:
                                        serialNum = column;
                                        break;
                                    case 1:
                                        isClean = bool.Parse(column);
                                        break;
                                    case 2:
                                        observations = column.Replace("!r!n", "\r\n");
                                        break;
                                    case 3:
                                        comments = column.Replace("!r!n", "\r\n"); ;
                                        break;
                                    case 4:
                                        process = column.Replace("!r!n", "\r\n"); ;
                                        break;
                                    case 5:
                                        troubleshoot = bool.Parse(column);
                                        break;
                                    case 6:
                                        repair = bool.Parse(column);
                                        break;
                                    case 7:
                                        result1 = bool.Parse(column);
                                        break;
                                    case 8:
                                        result2 = bool.Parse(column);
                                        break;
                                    case 9:
                                        result3 = bool.Parse(column);
                                        break;
                                    case 10:
                                        summary = column.Replace("!r!n", "\r\n"); ;
                                        break;

                                }
                                counter++;
                            }

                        }
                    }
                    else if (fileExtension == ".jpg" || fileExtension == ".png" || fileExtension == ".jpeg")
                    {
                        //if (file.Contains("\\AfterClean"))
                        //{
                        //    finalImagesPath.Add(file);
                        //}
                        //else if (file.Contains("\\BeforeClean"))
                        //{
                        //    initialImagesPath.Add(file);
                        //}
                        if (file.Contains("\\Label"))
                        {
                            labelPath = file;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("The process failed: {0}", ex.ToString());
                Console.WriteLine("Error: " + ex.Message);
                MessageBox.Show("There was an error with the import of the file");
                serialNum = null;
               // break;
            }
            finally { }

            try
            {
                components = new List<Component>();
                counter = 0;
                string teste = path + "\\Components\\components.csv";
                string newPath = path + "\\Components";
                //string[] files = Directory.GetFiles(newPath, "*.*", SearchOption.AllDirectories);
                //foreach (string file in files)
                //{
                //    string fileExtension = Path.GetExtension(file);
                //    if (fileExtension == ".csv")
                //    {
                if (File.Exists(teste))
                {
                    lines = File.ReadAllLines(teste, Encoding.GetEncoding("iso-8859-1"));
                    foreach (var line in lines)
                    {
                        Component component = new Component();
                        var columns = line.Split('|');
                        foreach (var column in columns)
                        {
                            switch (counter)
                            {
                                case 0:
                                    component.name = column;
                                    name = column.ToString().Replace("!r!n", "\r\n"); ;
                                    break;

                                case 1:
                                    component.description = column;
                                    description = column.Replace("!r!n", "\r\n");
                                    break;
                            }
                            counter++;
                        }
                        GetImages(component, newPath);
                        counter = 0;
                        //components.Add(new Component(name, description))
                    }
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("The process failed: {0}", ex.ToString());
                Console.WriteLine("Error: " + ex.Message);
                MessageBox.Show("There was an error with the import of the file");
                serialNum = null;
                // break;
            }
            finally { }
        }

        private void GetImages(Component component, string newPath)
        {
            string newPath2 = newPath + "\\" + component.name;
            string[] files = Directory.GetFiles(newPath2, "*.*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                string fileExtension = Path.GetExtension(file);
                if (fileExtension == ".jpg" || fileExtension == ".png" || fileExtension == ".jpeg")
                {
                    if (file.Contains("ComponentBeforeIMG1"))
                    {
                        component.componentBeforeImage1 = file;
                    }
                    else if (file.Contains("ComponentBeforeIMG2"))
                    {
                        component.componentBeforeImage2 = file;
                    }
                    else if (file.Contains("ComponentBeforeIMG3"))
                    {
                        component.componentBeforeImage3 = file;
                    }
                    else if (file.Contains("ComponentAfterIMG1"))
                    {
                        component.componentAfterImage1 = file;
                    }
                    else if (file.Contains("ComponentAfterIMG2"))
                    {
                        component.componentAfterImage2 = file;
                    }
                    else if (file.Contains("ComponentAfterIMG3"))
                    {
                        component.componentAfterImage3 = file;
                    }
                }
            }
            components.Add(component);
        }
    }
}
