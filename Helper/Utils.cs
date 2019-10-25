using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace WebAppParser.Helper
{
    public class Utils
    {
        
        public static void FilesDeleter(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);

            if (directory.Exists)
            {
                foreach (FileInfo file in directory.GetFiles())
                {
                    file.Delete();
                }
            }
            else
            {
                directory.Create();
            }
        }

        //return list of files in chosen folder 
        public static List<string> FilesInFolder(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);

            List<string> fileNames = new List<string>();
            foreach (FileInfo file in directory.GetFiles())
            {
                fileNames.Add(file.Name);
            }
            return fileNames;
        }

    }
}
