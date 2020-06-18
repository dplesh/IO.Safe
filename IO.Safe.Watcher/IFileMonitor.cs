using System;
using System.Collections.Generic;
using System.Text;

namespace IO.Safe.Watcher
{
    internal interface IFileMonitor
    {
        event ReadyFileHandler OnReadyFile;
        event ReadyEmptyDirectoryHandler OnReadyEmptyDirectory;
    }
}
