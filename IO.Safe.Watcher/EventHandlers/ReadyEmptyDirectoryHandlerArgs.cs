using System;
using System.IO;

namespace IO.Safe.Watcher
{
    public class ReadyEmptyDirectoryHandlerArgs
    {
        public DirectoryInfo ReadyDirectory { get; set; }
        public DateTime TimeReady { get; set; }
    }
}