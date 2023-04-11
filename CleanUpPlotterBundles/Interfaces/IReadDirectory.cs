using System.Collections.Generic;
using System.IO;

namespace CleanUpPlotterBundles.Interfaces
{
    public interface IReadDirectory
    {
        #region Methods
        List<FileInfo> GetFilesToCopy(string path);
        List<string> GetDirectories(string path);
        List<FileInfo> GetFiles(string path);
        #endregion
    }
}
