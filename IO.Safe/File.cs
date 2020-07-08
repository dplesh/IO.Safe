using System;
using System.IO;

namespace IO.Safe
{
    public class File
    {

        public static void Move(string source, string destination, bool overwrite = true)
        {
            InternalMove(source, destination, overwrite);
        }

        public static void MoveToDirectory(string source, string destination, bool overwrite = true)
        {
            string fileName = Path.GetFileName(source);
            if (fileName == null)
            {
                throw new ArgumentException("Source path is an invalid path.", nameof(source));
            }

            string destinationFile = Path.Combine(destination, fileName);
            InternalMove(source, destinationFile, overwrite);
        }

        private static void InternalMove(string source, string destination, bool overwrite)
        {
            string directoryName = Path.GetDirectoryName(destination);
            if (directoryName == null)
            {
                throw new ArgumentException("Destination path is an invalid path.", nameof(destination));
            }
            Directory.CreateDirectory(directoryName);
            if (overwrite && System.IO.File.Exists(destination))
            {
                System.IO.File.Delete(destination);
            }

            System.IO.File.Move(source, destination);
        }
    }
}
