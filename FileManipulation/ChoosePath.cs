using System;
using System.Windows.Forms;

namespace Tåg_project.FileManipulation
{
    internal class ChoosePath
    {
        public static string NewPath()
        {
            //serialNum = num;
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.RootFolder = Environment.SpecialFolder.DesktopDirectory;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string path = dialog.SelectedPath;
                    Console.WriteLine("You selected: " + path);
                    return path;
                }
                else return null;
            }
        }
    }
}
