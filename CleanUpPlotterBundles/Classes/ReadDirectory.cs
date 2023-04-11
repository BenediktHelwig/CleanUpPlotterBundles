using CleanUpPlotterBundles.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CleanUpPlotterBundles.Classes
{
    public class ReadDirectory : IReadDirectory
    {
        #region Fields
        private List<FileInfo> filepathsToCopy = new List<FileInfo>();
        #endregion

        #region Methods

        #region Interface_Methods
        public List<FileInfo> GetFilesToCopy(string path)
        {
            SetListOfFilesToCopy(path);
            return filepathsToCopy;
        }

        public List<string> GetDirectories(string path)
        {
            return Directory.GetDirectories(path).ToList();
        }

        public List<FileInfo> GetFiles(string path)
        {
            List<FileInfo> fileInfos = new List<FileInfo>();
            string[] files = Directory.GetFiles(path);
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo file = new FileInfo(files[i]);
                fileInfos.Add(file);
            }
            return fileInfos;
        }
        #endregion

        #region Class_Methods
        public void SetListOfFilesToCopy(string path)
        {
            string[] filepaths = Directory.GetFiles(path);
            if (filepaths.Length == 0)
            {
                string[] directories = Directory.GetDirectories(path);
                for (int i = 0; i < directories.Length; i++)
                {
                    SetListOfFilesToCopy(Directory.GetFileSystemEntries(path)[i]);
                }
            }
            else
            {
                for (int i = 0; i < filepaths.Length; i++)
                {
                    FileInfo file = new FileInfo(filepaths[i]);
                    filepathsToCopy.Add(file);
                }
            }
        }
        #endregion

        #endregion
    }
}
