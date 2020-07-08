using System;
using System.ComponentModel;
using System.Net;
using IO.Safe.Watcher.PollingFileWatcher;

namespace IO.Safe.Watcher
{
    public class FileSystemWatcher : IFileSystemMonitor
    {

        public event EventHandler<ReadyFileEventArgs> OnReadyFile;
        public event EventHandler<ReadyEmptyDirectoryHandlerArgs> OnReadyEmptyDirectory;

        private const double DefaultPollingInterval = 10000;

        private string _target;
        private System.IO.FileSystemWatcher _liveWatcher;
        private PollingFileSystemWatcher _pollingSystemWatcher;


        public FileSystemWatcher(string target, double interval, string filter = "*")
        {
            _liveWatcher = new System.IO.FileSystemWatcher(target, filter);
            _pollingSystemWatcher = new PollingFileSystemWatcher(target, interval, true);
            _pollingSystemWatcher.OnReadyFile += PollingSystemWatcherOnOnReadyFile;
            _pollingSystemWatcher.OnReadyEmptyDirectory += PollingSystemWatcherOnOnReadyEmptyDirectory;
        }

        public void Start()
        {
            _liveWatcher.EnableRaisingEvents = true;
            _pollingSystemWatcher.Start();
        }

        public void Stop()
        {
            _liveWatcher.EnableRaisingEvents = false;
            _pollingSystemWatcher.Stop();
        }

        private void PollingSystemWatcherOnOnReadyEmptyDirectory(object sender, ReadyEmptyDirectoryHandlerArgs args)
        {
            throw new System.NotImplementedException();
        }

        private void PollingSystemWatcherOnOnReadyFile(object sender, ReadyFileEventArgs args)
        {
            throw new System.NotImplementedException();
        }


    }
}
