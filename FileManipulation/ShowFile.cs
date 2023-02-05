using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tåg_project.FileManipulation
{
    internal class ShowFile
    {
        public static void OpenFile(string path) 
        {
            Process mydoc = new Process();
            mydoc.StartInfo.FileName = path;
            mydoc.Start();
        }
    }
}
