using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileSystemVisitor.Core;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace FileSystemVisitor.Tests;

[TestClass]
public class FileSystemVisitorTests
{
    private string _rootDir;

    [TestInitialize]
    public void Init()
    {
        _rootDir = Path.Combine(Path.GetTempPath(), "fsvisitor_test_" + Guid.NewGuid());
        Directory.CreateDirectory(_rootDir);
    }

    [TestCleanup]
    public void Cleanup()
    {
        if (Directory.Exists(_rootDir))
            Directory.Delete(_rootDir, recursive: true);
    }

    [TestMethod]
    public void Returns_All_Files_And_Directories_Without_Filter()
    {
        var subDir = Path.Combine(_rootDir, "sub1");
        Directory.CreateDirectory(subDir);
        var file1 = Path.Combine(_rootDir, "file1.txt");
        var file2 = Path.Combine(subDir, "file2.log");
        File.WriteAllText(file1, "data");
        File.WriteAllText(file2, "data");

        var visitor = new FileSystemVisitor.Core.FileSystemVisitor(_rootDir);
        var results = visitor.EnumerateFileSystem().ToList();

        Assert.IsTrue(results.Contains(file1));
        Assert.IsTrue(results.Contains(file2));
        Assert.IsTrue(results.Contains(subDir));
        Assert.AreEqual(3, results.Count);
    }

    [TestMethod]
    public void Returns_OnlyTxt_Files_With_Filter()
    {
        var file1 = Path.Combine(_rootDir, "a.txt");
        var file2 = Path.Combine(_rootDir, "b.docx");
        File.WriteAllText(file1, "data");
        File.WriteAllText(file2, "data");

        var visitor = new FileSystemVisitor.Core.FileSystemVisitor(_rootDir, path => path.EndsWith(".txt"));

        var results = visitor.EnumerateFileSystem().ToList();

        Assert.AreEqual(1, results.Count);
        Assert.IsTrue(results.Single().EndsWith(".txt"));
    }

    [TestMethod]
    public void Exclude_Works_Via_Event()
    {
        var file1 = Path.Combine(_rootDir, "skip.txt");
        var file2 = Path.Combine(_rootDir, "include.txt");
        File.WriteAllText(file1, "data");
        File.WriteAllText(file2, "data");

        var visitor = new FileSystemVisitor.Core.FileSystemVisitor(_rootDir);
        visitor.FilteredFileFound += (s, e) =>
        {
            var args = (FileSystemVisitorEventArgs)e;
            if (args.Path.Contains("skip")) args.Exclude = true;
        };

        var results = visitor.EnumerateFileSystem().ToList();

        Assert.AreEqual(1, results.Count);
        Assert.IsTrue(results.Single().EndsWith("include.txt"));
    }

    [TestMethod]
    public void Abort_Works_Via_Event()
    {
        var file1 = Path.Combine(_rootDir, "a.txt");
        var file2 = Path.Combine(_rootDir, "b.txt");
        var file3 = Path.Combine(_rootDir, "c.txt");
        File.WriteAllText(file1, "1");
        File.WriteAllText(file2, "2");
        File.WriteAllText(file3, "3");

        var visitor = new FileSystemVisitor.Core.FileSystemVisitor(_rootDir);
        int foundFiles = 0;
        visitor.FilteredFileFound += (s, e) =>
        {
            foundFiles++;
            if (foundFiles >= 2)
                ((FileSystemVisitorEventArgs)e).Abort = true;
        };

        var results = visitor.EnumerateFileSystem().ToList();

        Assert.IsTrue(foundFiles <= 2);
        Assert.IsTrue(results.Count <= 2);
    }

    [TestMethod]
    public void Events_Are_Raised()
    {
        File.WriteAllText(Path.Combine(_rootDir, "test.txt"), "data");
        bool started = false, finished = false, fileFound = false, filteredFileFound = false;

        var visitor = new FileSystemVisitor.Core.FileSystemVisitor(_rootDir);
        visitor.Start += (s, e) => started = true;
        visitor.Finish += (s, e) => finished = true;
        visitor.FileFound += (s, e) => fileFound = true;
        visitor.FilteredFileFound += (s, e) => filteredFileFound = true;

        var res = visitor.EnumerateFileSystem().ToList();

        Assert.IsTrue(started);
        Assert.IsTrue(finished);
        Assert.IsTrue(fileFound);
        Assert.IsTrue(filteredFileFound);
    }
}