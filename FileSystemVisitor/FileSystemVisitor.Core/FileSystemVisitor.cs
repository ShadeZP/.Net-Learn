using System.Collections.Generic;
using System.IO;

namespace FileSystemVisitor.Core
{
    public class FileSystemVisitor
    {
        private readonly string _startPath;
        private readonly Func<string, bool>? _filter;
        private bool _aborted;

        public event EventHandler? Start;
        public event EventHandler? Finish;

        public event EventHandler<FileSystemVisitorEventArgs>? FileFound;
        public event EventHandler<FileSystemVisitorEventArgs>? DirectoryFound;
        public event EventHandler<FileSystemVisitorEventArgs>? FilteredFileFound;
        public event EventHandler<FileSystemVisitorEventArgs>? FilteredDirectoryFound;

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
            Start?.Invoke(this, EventArgs.Empty);
            _aborted = false;
            try
            {
                foreach (var entry in EnumerateFileSystemInternal(_startPath))
                {
                    if (_aborted)
                        break;

                    if (_filter == null || _filter(entry))
                        yield return entry;
                }
            }
            finally
            {
                Finish?.Invoke(this, EventArgs.Empty);
            }
        }

        private IEnumerable<string> EnumerateFileSystemInternal(string path)
        {
            if (_aborted)
                yield break;

            foreach (var dir in Directory.GetDirectories(path))
            {
                var dirEventArgs = new FileSystemVisitorEventArgs(dir);
                DirectoryFound?.Invoke(this, dirEventArgs);

                if (dirEventArgs.Abort)
                {
                    _aborted = true;
                    yield break;
                }

                bool isIncluded = _filter == null || _filter(dir);
                if (isIncluded)
                {
                    var filteredDirArgs = new FileSystemVisitorEventArgs(dir);
                    FilteredDirectoryFound?.Invoke(this, filteredDirArgs);

                    if (filteredDirArgs.Abort)
                    {
                        _aborted = true;
                        yield break;
                    }

                    if (!filteredDirArgs.Exclude)
                        yield return dir;
                }
                foreach (var sub in EnumerateFileSystemInternal(dir))
                {
                    if (_aborted) yield break;
                    yield return sub;
                }
            }
            foreach (var file in Directory.GetFiles(path))
            {
                if (_aborted)
                    yield break;

                var fileEventArgs = new FileSystemVisitorEventArgs(file);
                FileFound?.Invoke(this, fileEventArgs);

                if (fileEventArgs.Abort)
                {
                    _aborted = true;
                    yield break;
                }

                bool isIncluded = _filter == null || _filter(file);
                if (isIncluded)
                {
                    var filteredFileArgs = new FileSystemVisitorEventArgs(file);
                    FilteredFileFound?.Invoke(this, filteredFileArgs);

                    if (filteredFileArgs.Abort)
                    {
                        _aborted = true;
                        yield break;
                    }

                    if (!filteredFileArgs.Exclude)
                        yield return file;
                }
            }
        }
    }
}