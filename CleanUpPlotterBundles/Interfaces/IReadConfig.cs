using CleanUpPlotterBundles.Models;

namespace CleanUpPlotterBundles.Interfaces
{
    public interface IReadConfig
    {
        #region Methods
        Fileextensions ReadConfigFile();
        #endregion
    }
}
