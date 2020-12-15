using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// This list will contain all the absolute paths to the image files.
        /// </summary>
        static List<string> s_allPictureFiles = new List<string>(1024);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Find the drives that are cameras.
            //It should be the drive with the DCIM folder at the root of it.
            string[] drives = Environment.GetLogicalDrives();

            for (int i = 0; i < drives.Length; i++)
            {
                string pathToDCIM = Path.Combine(drives[i], "DCIM");
                if(Directory.Exists(pathToDCIM))
                {
                    LoadAllImages(pathToDCIM);
                }
            }

            Application.Run(new ListPicturesForm());
        }

        static void LoadAllImages(string path)
        {
            foreach (string file in Directory.EnumerateFiles(path))
                s_allPictureFiles.Add(file);
            foreach (string folder in Directory.EnumerateDirectories(path))
                LoadAllImages(folder);
        }
    }
}
