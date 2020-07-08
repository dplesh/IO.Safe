using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;

namespace IO.Safe.Watcher.PollingFileWatcher
{
    public class PollingFileSystemWatcher : IFileSystemMonitor
    {
        public event EventHandler<ReadyFileEventArgs> OnReadyFile;
        public event EventHandler<ReadyEmptyDirectoryHandlerArgs> OnReadyEmptyDirectory;

        private DirectoryInfo _target;
        private Timer _pollingTimer;

        private ConcurrentDictionary<string, byte> _filesToIgnore;

        public PollingFileSystemWatcher(string target, double interval, bool autoIgnoreRaisedFiles = true)
        {
            _target = new DirectoryInfo(target);
            _filesToIgnore = new ConcurrentDictionary<string, byte>();

            _pollingTimer = new Timer(interval);
            _pollingTimer.Elapsed += PollingTimerOnElapsed;
        }

        public void Start()
        {
            _pollingTimer.Start();
        }

        public void Stop()
        {
            _pollingTimer.Stop();
        }

        public bool Ignore(string file)
        {
            if (!file.StartsWith(_target.FullName))
            {
                throw new InvalidOperationException("File is not contained in watcher target directory.");
            }

            return _filesToIgnore.TryAdd(file, default);
        }

        public void Disignore(string file)
        {
            _filesToIgnore.TryRemove(file, out _);
        }

        private void PollingTimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            foreach (FileSystemInfo info in CollectEntriesInTarget())
            {
                if (info is FileInfo)
                {
                    if (!Ignore(info.FullName))
                    {
                        return;
                    }

                    OnReadyFile?.Invoke(this, new ReadyFileEventArgs
                    { ReadyFile = info as FileInfo, TimeReady = DateTime.Now });

                }
                else
                {
                    if (!Ignore(info.FullName))
                    {
                        return;
                    }
                    OnReadyEmptyDirectory?.BeginInvoke(this,
                        new ReadyEmptyDirectoryHandlerArgs
                        { ReadyDirectory = info as DirectoryInfo, TimeReady = DateTime.Now }, null, null);
                    
                }
            }
        }

        public IEnumerable<FileSystemInfo> CollectEntriesInTarget()
        {
            return _target.EnumerateFileSystemInfos("*", SearchOption.AllDirectories)
                .Where(info =>
                {
                    // All files...
                    if (info is FileInfo)
                    {
                        return true;
                    }

                    // ...and empty directories.
                    return !((DirectoryInfo)info).EnumerateFiles("*").Any();
                });
        }
    }
}