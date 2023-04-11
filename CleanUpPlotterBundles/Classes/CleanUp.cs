using CleanUpPlotterBundles.Interfaces;
using CleanUpPlotterBundles.Models;
using System.Collections.Generic;
using System.IO;

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
                _filesToCopy = _readDirectory.GetFilesToCopy(path);
            }
        }
        #endregion
    }
}
