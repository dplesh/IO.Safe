using System.ComponentModel;
using System.Net;

namespace IO.Safe.Watcher
{
    public class FileSystemWatcher
    {

        private const double DefaultPollingInterval = 10000;

        private string _target;
        private System.IO.FileSystemWatcher _liveWatcher;
        private IO.Safe.Watcher.PollingFileWatcher _pollingWatcher;


        public FileSystemWatcher(string target, double interval, string filter = "*")
        {
            _liveWatcher = new System.IO.FileSystemWatcher(target, filter);
            _pollingWatcher = new PollingFileWatcher(target, interval);
        }
    }
}
