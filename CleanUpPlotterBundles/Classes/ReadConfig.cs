using CleanUpPlotterBundles.Interfaces;
using CleanUpPlotterBundles.Models;
using System.IO;
using System.Text.Json;

namespace CleanUpPlotterBundles.Classes
{
    public class ReadConfig : IReadConfig
    {
        #region Fields
        private Fileextensions fileextensions;
        #endregion

        #region Methods
        public Fileextensions ReadConfigFile()
        {
            string configFile = File.ReadAllText(@"./Config/fileextensions.json");
            fileextensions = JsonSerializer.Deserialize<Fileextensions>(configFile);

            return fileextensions;
        }
        #endregion
    }
}
