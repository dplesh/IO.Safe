using System;
using System.IO;
using SystemPath = System.IO.Path;
namespace IO.Safe
{
    public static class Path
    {
        public static string GetTempFolder()
        {
            string tempFolder = SystemPath.Combine(SystemPath.GetTempPath(), Guid.NewGuid().ToString().Substring(0,6));
            System.IO.Directory.CreateDirectory(tempFolder);
            return tempFolder;
        }
    }
}