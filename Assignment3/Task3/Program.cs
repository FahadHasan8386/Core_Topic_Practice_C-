using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        var bufferSize = 8192;

        var task3Project = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\.."));
 
        var solutionFolder = Directory.GetParent(task3Project).FullName;

        
        var task2Folder = Directory.GetDirectories(solutionFolder).FirstOrDefault(dir => Directory.GetDirectories(dir, "Folder*").Any());

        if (task2Folder == null)
        {
            Console.WriteLine("Could not find Task2 project folder");
            return;
        }

        //Console.WriteLine("Task2 folder found: " + task2Folder);

        var folderPaths = Directory.GetDirectories(task2Folder, "Folder*").OrderBy(f => f).ToList();

        if (folderPaths.Count == 0)
        {
            Console.WriteLine("Split folders found in Task2.");
            return;
        }

        var allFiles = folderPaths.SelectMany(folder => Directory.GetFiles(folder, "Part*.txt").OrderBy(f => f)).ToList();

        allFiles.Reverse();

        
        var mergedFilePath = Path.Combine(task2Folder, "MergedReverseFile.txt");

        Console.WriteLine($"Merging {allFiles.Count} files in reverse order into: {mergedFilePath}");

        using (var outputStream = new FileStream(mergedFilePath, FileMode.Create, FileAccess.Write))
        {
            byte[] buffer = new byte[bufferSize];

            foreach (var filePath in allFiles)
            {
                using (var inputStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    int bytesRead;
                    while ((bytesRead = inputStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        outputStream.Write(buffer, 0, bytesRead);
                    }
                }
                //Console.WriteLine("Merged: " + Path.GetFileName(filePath));
            }
        }

        Console.WriteLine("Files merged in reverse order successfully!");
    }
}
