using System.Collections.Generic;
using System.IO;

namespace FileSystemVisitor.Core
{
    public class FileSystemVisitor
    {
        private readonly string _startPath;
        private readonly Func<string, bool>? _filter;

        public FileSystemVisitor(string startPath)
        {
            _startPath = startPath;
            _filter = null;
        }
        public FileSystemVisitor(string startPath, Func<string, bool> filter)
        {
            _startPath = startPath;
            _filter = filter;
        }

        public IEnumerable<string> EnumerateFileSystem()
        {
            foreach (var entry in EnumerateFileSystemInternal(_startPath))
            {
                if (_filter == null || _filter(entry))
                    yield return entry;
            }
        }

        private IEnumerable<string> EnumerateFileSystemInternal(string path)
        {
            foreach (var dir in Directory.GetDirectories(path))
            {
                yield return dir;
                foreach (var sub in EnumerateFileSystemInternal(dir))
                    yield return sub;
            }
            foreach (var file in Directory.GetFiles(path))
            {
                yield return file;
            }
        }
    }
}