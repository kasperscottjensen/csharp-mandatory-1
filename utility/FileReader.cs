namespace mandatory_1.utility;

public static class FileReader
{
    
    private const string BaseDir = "../../../assets/";

    public static List<string?[]> ReadFile(string path)
    {
        List<string?[]> data = new List<string?[]>();
        StreamReader reader = new StreamReader(BaseDir + path);
        
        reader.ReadLine();
        
        while (!reader.EndOfStream)
        {
            string? line = reader.ReadLine();
            string?[] array = line!.Split(',');
            data.Add(array);
        }
        return data;
    }

    public static string[] GetFiles(string path)
    {
        return Directory.GetFiles(BaseDir + path);
    }

}