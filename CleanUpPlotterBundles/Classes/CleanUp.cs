using CleanUpPlotterBundles.Interfaces;
using CleanUpPlotterBundles.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CleanUpPlotterBundles.Classes
{
    public class CleanUp
    {
        #region Fields
        private IReadConfig _readConfig;
        private IReadDirectory _readDirectory;
        private Fileextensions _fileextensions;
        private List<string> _paths;
        private List<FileInfo> _filesToCopy;
        private List<string> _directoriesToDelete = new List<string>();
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public CleanUp(IReadConfig readConfig, IReadDirectory readDirectory, string mainpath)
        {
            _readConfig = readConfig;
            _readDirectory = readDirectory;

            _fileextensions = _readConfig.ReadConfigFile();
            CleanUpBundle(mainpath);
        }
        #endregion
        #region Methods
        private void CleanUpBundle(string mainpath)
        {
            _paths = _readDirectory.GetDirectories(mainpath);

            foreach (string path in _paths)
            {
                SetDirectoriesToDelete(_readDirectory.GetDirectories(path));
                _filesToCopy = _readDirectory.GetFilesToCopy(path);

                CopyFiles(path);
            }
            foreach (var directory in _directoriesToDelete)
            {
                Directory.Delete(directory, true);
            }
        }

        private void SetDirectoriesToDelete(List<string> directoryDeleteList)
        {
            foreach (string directory in directoryDeleteList)
            {
                _directoriesToDelete.Add(directory);
            }
        }

        private void RemoveFromDirectoriesToDelete(string path)
        {
            _directoriesToDelete.Remove(path);
        }

        private void CopyFiles(string path)
        {
            for (int i = 0; i < _fileextensions.fileextension.Length; i++)
            {
                string extension = _fileextensions.fileextension[i];
                string trimExtension = extension.Trim('.').ToUpper();

                string sourcePath = path;
                string destPath = Path.Combine(path, trimExtension);

                RemoveFromDirectoriesToDelete(destPath);

                Directory.CreateDirectory(destPath);
                List<FileInfo> onlyOneType = _filesToCopy.Where(x => x.FullName.EndsWith(extension))
                                                         .Select(x => x).ToList();

                foreach (var file in onlyOneType)
                {
                    FileInfo destFile = new FileInfo(Path.Combine(destPath, file.Name));
                    if (destFile.Exists)
                    {
                        if (file.Length > destFile.Length)
                        {
                            file.CopyTo(destFile.FullName, true);
                        }
                    }
                    else
                    {
                        file.CopyTo(destFile.FullName);
                    }
                    if (file.Exists)
                    {
                        if (file.FullName != destFile.FullName)
                        {
                            file.Delete();
                        }
                        _filesToCopy.Remove(file);
                    }
                }
            }
        }
        #endregion
    }
}
