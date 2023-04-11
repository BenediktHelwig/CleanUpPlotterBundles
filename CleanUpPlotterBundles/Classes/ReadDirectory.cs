using CleanUpPlotterBundles.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanUpPlotterBundles.Classes
{
    public class ReadDirectory : IReadDirectory
    {
        #region Fields
        private string[] filepathsToCopy = new string[] { };
        #endregion

        #region Methods
        public string[] GetFilepathsToCopy(string path)
        {
            SetListOfFilepathsToCopy(path);
            return filepathsToCopy;
        }

        public void SetListOfFilepathsToCopy(string path)
        {
            string[] filepaths = Directory.GetFiles(path);
            if (filepaths.Length == 0)
            {
                for (int i = 0; i < Directory.GetFileSystemEntries(path).Length; i++)
                {
                    SetListOfFilepathsToCopy(Directory.GetFileSystemEntries(path)[i]);
                }
            }
            else
            {
                for (int i = 0; i < filepaths.Length; i++)
                {
                    filepathsToCopy.Add(filepaths[i]);
                }
            }
        }
        #endregion
    }
}
