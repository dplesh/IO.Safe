using System;
using System.IO;
using Xunit;
using Path = System.IO.Path;

namespace IO.Safe.Tests
{
    public class FileTests
    {
        [Fact]
        public void Move_MovesFileToDestination()
        {
            string sourceFile = System.IO.Path.GetTempFileName();
            string destination = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid().ToString());
            try
            {
                File.Move(sourceFile, destination);
                Assert.True(System.IO.File.Exists(destination));
            }
            finally
            {
                System.IO.File.Delete(sourceFile);
                System.IO.File.Delete(destination);
            }
        }

        [Fact]
        public void MoveToDirectory_MovesFileToDirectory()
        {
            string sourceFile = System.IO.Path.GetTempFileName();
            string destinationDirectory = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid().ToString());
            string destinationFile = System.IO.Path.Combine(destinationDirectory, System.IO.Path.GetFileName(sourceFile));
            try
            {
                File.MoveToDirectory(sourceFile, destinationDirectory);
                Assert.True(System.IO.File.Exists(destinationFile));
            }
            finally
            {
                System.IO.File.Delete(sourceFile);
                System.IO.Directory.Delete(destinationDirectory, true);
            }

        }

        
    }
}
