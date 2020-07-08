using System;
using System.IO;
using Xunit;
using IO.Safe;

namespace IO.Safe.Tests
{
    public class FileTests
    {
        [Fact]
        public void Move_MovesFileToDestination()
        {
            string sourceFile = Path.GetTempFileName();
            string destination = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
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
            string sourceFile = Path.GetTempFileName();
            string destinationDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            string destinationFile = Path.Combine(destinationDirectory, Path.GetFileName(sourceFile));
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
