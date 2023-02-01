using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TrainReport.FileManipulation
{
    internal class Import
    {
        public int serialNum { get; set; }
        public bool isClean { get; set; }
        public bool isEvaluated { get; set; }
        public bool isComponentReplaced { get; set; }
        public string whichComponents { get; set; }
        public bool finalEvaluation { get; set; }
        public bool approved { get; set; }
        public string finalText { get; set; }
        public int imgCount { get; set; }
        public List<string> initialImagesPath { get; set; }
        public List<string> finalImagesPath { get; set; }


        public Import(string path)
        {
            initialImagesPath = new List<string>();
            int counter = 0;
            string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                Console.WriteLine(file);
                // Do something with the file
                string fileExtension = Path.GetExtension(file);
                if(fileExtension == ".csv")
                {
                    string[] lines = File.ReadAllLines(file, Encoding.GetEncoding("iso-8859-1"));
                    foreach(var line in lines)
                    {
                        var columns = line.Split(',');
                        foreach (var column in columns)
                        {
                            switch(counter){
                                case 0:
                                    serialNum = int.Parse(column);
                                    break;
                                case 1:
                                    imgCount = int.Parse(column);
                                    break;
                                case 2:
                                    isClean = bool.Parse(column);
                                    break;
                                case 3:
                                    isEvaluated = bool.Parse(column);
                                    break;
                                case 4:
                                    isComponentReplaced = bool.Parse(column);
                                    break;
                                case 5:
                                    whichComponents = column;
                                    break;
                                case 6:
                                    finalEvaluation = bool.Parse(column);
                                    break;
                                case 7:
                                    finalText = column;
                                    break;
                            }
                            counter++;
                        }

                    }
                }else if (fileExtension == ".jpg" || fileExtension == ".png" || fileExtension == ".jpeg")
                {
                    initialImagesPath.Add(file);
                }
            }
        }
    }
}
