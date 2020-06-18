using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Security.Claims;
using System.Timers;

namespace IO.Safe.Watcher
{
    internal class PollingFileWatcher : IFileMonitor
    {

        public event ReadyFileHandler OnReadyFile;
        public event ReadyEmptyDirectoryHandler OnReadyEmptyDirectory;

        private string _target;
        private Timer _pollingTimer;
        


        public PollingFileWatcher(string target, double interval)
        {
            _pollingTimer = new Timer(interval);
            _pollingTimer.Elapsed += PollingTimerOnElapsed;
            
        }

        private void PollingTimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            
        }

        public IEnumerable<FileSystemInfo> CollectFileSystemEntries()
        {
            Directory.EnumerateFileSystemEntries(_target);
            throw new NotImplementedException();
        }
    }
}