using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using IO.Safe.Watcher.PollingFileWatcher;
using IO.Safe;
using Xunit;

namespace IO.Safe.Watcher.Tests
{
    public class PollingFileSystemWatcherTests
    {

        [Fact]
        public async void StartPolling_RaisesEventWithFiles()
        {
            string pollingDirectory = Path.GetTempPath() + Guid.NewGuid();
            int fileCount = 10;
            Directory.CreateDirectory(pollingDirectory);

            PollingFileSystemWatcher watcher = new PollingFileSystemWatcher(pollingDirectory, 1000, true);
            watcher.Start();
            string fileSourcePath = Path.GetTempFileName();
            await Assert.RaisesAsync<ReadyFileEventArgs>(handler => watcher.OnReadyFile += handler,
                handler => watcher.OnReadyFile -= handler, () =>
                {
                    IO.Safe.File.MoveToDirectory(fileSourcePath, pollingDirectory);
                    Task.Delay(5000).Wait();
                    return Task.FromResult(0);
                });
        }
    }
}
