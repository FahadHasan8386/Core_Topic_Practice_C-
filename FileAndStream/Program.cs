
var path = "../../../example.txt";

//File.WriteAllText(path, "Hello , world!");

File.WriteAllLines(path, ["Line1", "Line2", "Line3"]);

//if (File.Exists(path))
//    File.Open(path , FileMode.Open);

var lines = File.ReadAllLines(path);

foreach(var line in lines)
{
    Console.WriteLine(line);
}
Console.WriteLine(File.GetLastWriteTime(path));

FileInfo fileinfo = new FileInfo("../../../example.txt");
if(fileinfo.Exists)
{
    Console.WriteLine(fileinfo.FullName);
}
else
{
    Console.WriteLine("File is not found!");
}

Console.WriteLine($"Output of GetCurrentDirectory : {Directory.GetCurrentDirectory()}");

string folder = Directory.GetCurrentDirectory();


///C#  e Directory means folder 
DirectoryInfo dirinfo = new DirectoryInfo(folder);

string projectPath = dirinfo.Parent.Parent.Parent.FullName;

string fullPath = Path.Combine(projectPath, "myfolder", "mysubfolder", "test.txt");

Console.WriteLine(fullPath);










