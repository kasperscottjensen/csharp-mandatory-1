namespace mandatory_1.utility;
using System.Reflection;

public static class Validator
{
    
    public static void Validate<T>(T obj)
    {
        PropertyInfo[] properties = typeof(T).GetProperties();
        
        foreach (PropertyInfo property in properties)
        {
            
            // Test string properties for null and empty
            if (property.PropertyType == typeof(string))
            {
                string value = (string)property.GetValue(obj)!;
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("exception: string is null or empty");
                }
            }
            
            // Test integer properties for default value
            else if (property.PropertyType == typeof(int))
            {
                int value = (int)property.GetValue(obj)!;
                if (value == 0)
                {
                    throw new Exception("exception: integer has default value");
                }
            }
        }
    }
    
}