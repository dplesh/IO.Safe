using System;
using System.Collections.Generic;
using System.Text;

namespace IO.Safe.Watcher
{
    internal interface IFileSystemMonitor
    {
        event EventHandler<ReadyFileEventArgs> OnReadyFile;
        event EventHandler<ReadyEmptyDirectoryHandlerArgs> OnReadyEmptyDirectory;

        void Start();
        void Stop();
    }
}
