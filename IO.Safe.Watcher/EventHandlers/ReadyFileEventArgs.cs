using System;
using System.IO;

namespace IO.Safe.Watcher
{
    public class ReadyFileEventArgs
    {
        public FileInfo ReadyFile { get; set; }
        public DateTime TimeReady { get; set; }

    }
}