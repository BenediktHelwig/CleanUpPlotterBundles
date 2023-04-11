using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
