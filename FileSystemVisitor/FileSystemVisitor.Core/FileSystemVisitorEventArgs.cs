using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystemVisitor.Core
{
    public class FileSystemVisitorEventArgs : EventArgs
    {
        public string Path { get; }
        public bool Abort { get; set; } = false;
        public bool Exclude { get; set; } = false;

        public FileSystemVisitorEventArgs(string path)
        {
            Path = path;
        }
    }
}
