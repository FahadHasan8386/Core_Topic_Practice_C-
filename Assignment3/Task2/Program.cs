using System;
using System.IO;

class Program
{
    static void Main()
    {
        var splitFileSize = 100L * 1024 * 1024;
        var buffer = new byte[8192];

        // Project folder (where split files will go)
        var projectDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\.."));

        // Large file beside .sln
        var largeFilePath = Path.Combine(projectDirectory, "..", "LargeRandomFile.txt");

        if (!File.Exists(largeFilePath))
        {
            Console.WriteLine("❌ Large file not found: " + largeFilePath);
            return;
        }

        Console.WriteLine("🚀 File splitting started...");

        using (var largeFileStream = new FileStream(largeFilePath, FileMode.Open, FileAccess.Read))
        {
            var splitFileCount = 1;
            var folderCount = 1;

            while (largeFileStream.Position < largeFileStream.Length)
            {
                if ((splitFileCount - 1) % 10 == 0)
                {
                    var newFolderPath = Path.Combine(projectDirectory, "Folder" + folderCount);
                    Directory.CreateDirectory(newFolderPath);
                    folderCount++;
                }

                var currentFolderPath = Path.Combine(projectDirectory, "Folder" + (folderCount - 1));
                Console.WriteLine(currentFolderPath);

                var splitFilePath = Path.Combine(currentFolderPath, "Part" + splitFileCount + ".txt");

                using (var splitStream = new FileStream(splitFilePath, FileMode.Create, FileAccess.Write))
                {
                    long written = 0;
                    while (written < splitFileSize && largeFileStream.Position < largeFileStream.Length)
                    {
                        int bytesRead = largeFileStream.Read(buffer, 0, buffer.Length);
                        splitStream.Write(buffer, 0, bytesRead);
                        written += bytesRead;
                    }
                }

                splitFileCount++;
            }
        }

        Console.WriteLine("🎉 File splitting completed successfully.");
    }
}
