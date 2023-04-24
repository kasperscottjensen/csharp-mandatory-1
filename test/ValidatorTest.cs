namespace mandatory_1.test;
using utility;


public class SampleObject
{
    public string Name { get; set; }
    public int Age { get; set; }
}

public static class ValidatorTest
{
    public static void Test()
    {
        // Create some sample objects to validate
        SampleObject validObject = new SampleObject { Name = "John Doe", Age = 30 };
        SampleObject nullNameObject = new SampleObject { Name = null, Age = 30 };
        SampleObject emptyNameObject = new SampleObject { Name = "", Age = 30 };
        SampleObject zeroAgeObject = new SampleObject { Name = "John Doe", Age = 0 };
        
        // Test the Validator.Validate() method with valid input
        Console.WriteLine("Testing Validator.Validate() with valid input...");
        Validator.Validate(validObject);
        
        // Test the Validator.Validate() method with null name
        Console.WriteLine("Testing Validator.Validate() with null name...");
        try
        {
            Validator.Validate(nullNameObject);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        // Test the Validator.Validate() method with empty name
        Console.WriteLine("Testing Validator.Validate() with empty name...");
        try
        {
            Validator.Validate(emptyNameObject);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        // Test the Validator.Validate() method with zero age
        Console.WriteLine("Testing Validator.Validate() with zero age...");
        try
        {
            Validator.Validate(zeroAgeObject);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

