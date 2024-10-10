using OpenDialogWindowHandler;
using System.IO;

namespace CoreFW.Helper
{
    public class FileHelper
    {
        public static void ClearFolder(string folder)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(folder);

            FileInfo[] files = directoryInfo.GetFiles();
            foreach (FileInfo file in files)
            {
                file.Delete();
            }

            DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();
            foreach (DirectoryInfo subDirectory in subDirectories)
            {
                subDirectory.Delete(true);
            }
        }

        public static bool CheckIfFileExist(string folder, string fileName)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(folder);
            FileInfo[] fileInfos = directoryInfo.GetFiles(fileName);
            if (fileInfos.Length > 0)
            {
                return true;
            }
            return false;
        }

        public static void CreateDirIfNotExist(string folder)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }

        public static void UploadFile(string filepath, string filename)
        {
            HandleOpenDialog hndOpen = new HandleOpenDialog();
            hndOpen.fileOpenDialog(filepath, filename);
        }
    }
}
