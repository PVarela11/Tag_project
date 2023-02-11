using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

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
                    folderDialog.Description = "Select a folder";
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
