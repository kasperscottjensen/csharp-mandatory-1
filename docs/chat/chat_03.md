You can read from a file in C# using the StreamReader class or the File.ReadAllText method.

Here's an example of using the StreamReader class to read the contents of a file line by line:

arduino

string filePath = @"C:\example\file.txt";
using (StreamReader reader = new StreamReader(filePath))
{
string line;
while ((line = reader.ReadLine()) != null)
{
Console.WriteLine(line);
}
}

In this example, the StreamReader is initialized with the path of the file to read. The using statement ensures that the StreamReader is properly disposed of when it's no longer needed.

The ReadLine() method is called repeatedly until it returns null, indicating that the end of the file has been reached. Each line of the file is then printed to the console using Console.WriteLine().

Alternatively, you can use the File.ReadAllText method to read the entire contents of a file into a string:

scss

string filePath = @"C:\example\file.txt";
string fileContents = File.ReadAllText(filePath);
Console.WriteLine(fileContents);

In this example, the File.ReadAllText method is called with the path of the file to read. The entire contents of the file are then read into the fileContents variable, which is then printed to the console using Console.WriteLine().