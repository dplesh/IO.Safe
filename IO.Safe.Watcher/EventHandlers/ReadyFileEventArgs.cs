using System;
using System.IO;

namespace IO.Safe.Watcher
{
    public class ReadyFileEventArgs : EventArgs
    {
        public FileInfo ReadyFile { get; set; }
        public DateTime TimeReady { get; set; }

    }
}