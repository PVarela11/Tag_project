using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tåg_project.FileManipulation
{
    internal class ShowFile
    {
        public static void OpenFile(string path) 
        {
            string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string projectDirectory = Directory.GetParent(currentDirectory).Parent.FullName;
            string resourcePath = Path.Combine(projectDirectory, "Resources", path);
            if (File.Exists(resourcePath))
            {
                Process.Start(resourcePath);
            }
            else
            {
                MessageBox.Show("The file does not exist.");
            }
        }
    }
}
