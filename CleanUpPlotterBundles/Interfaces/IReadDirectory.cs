using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanUpPlotterBundles.Interfaces
{
    public interface IReadDirectory
    {
        #region Methods
        List<string> GetFilepathsToCopy(string path);
        #endregion
    }
}
