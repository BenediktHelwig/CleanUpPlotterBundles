using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanUpPlotterBundles.Interfaces;
using CleanUpPlotterBundles.Models;

namespace CleanUpPlotterBundles.Classes
{
    public class Filter
    {
        #region Fields
        private IReadConfig _readConfig;
        private IReadDirectory _readDirectory;
        #endregion

        #region Properties
        private Fileextensions fileextensions;

        public Fileextensions Fileextensions
        {
            get { return fileextensions; }
            set { fileextensions = value; }
        }

        private List<string> paths;

        public List<string> Paths
        {
            get { return paths; }
            set { paths = value; }
        }
        #endregion

        #region Constructor
        public Filter(IReadConfig readConfig, IReadDirectory readDirectory, string mainpath)
        {
            _readConfig = readConfig;
            _readDirectory = readDirectory;

            Fileextensions = _readConfig.ReadConfigFile();
            Paths = _readDirectory.GetFilepathsToCopy(mainpath);
        }
        #endregion
    }
}
