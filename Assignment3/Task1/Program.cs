using System;
using System.IO;

class Program
{
    static Random random = new Random(DateTime.Now.Millisecond);

    static void Main(string[] args)
    {
        ///total byte 
        long totalBytes = 5L * 1024 * 1024 * 1024;

      
        string current_Directory = Directory.GetCurrentDirectory();

        string solution_Directory = Directory.GetParent(current_Directory).Parent.Parent.Parent.FullName;

        string filePath = Path.Combine(solution_Directory, "LargeRandomFile.txt");

     
        Console.WriteLine("Generating file...");

        ///Byte by byte write for 5 GB
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            for (long i = 0; i < totalBytes; i++)
            {
                byte b = (byte)GetRandomChar();
                fs.WriteByte(b);
            }
        }

        Console.WriteLine("Completed generating.");
    }

    static char GetRandomChar()
    {
        return (char)random.Next('A', 'Z');
    }
}
