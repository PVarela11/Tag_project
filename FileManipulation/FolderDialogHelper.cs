using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tåg_project.FileManipulation
{
    public static class FolderDialogHelper
    {
        public static string SelectedPath { get; private set; }

        public static string SelectedFolder()
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    SelectedPath = folderDialog.SelectedPath;
                    Console.WriteLine("You selected: " + SelectedPath);
                    return SelectedPath;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
