// See https://aka.ms/new-console-template for more information
using OOPsReview;

Console.WriteLine("OOPs Review Console Driver");

//ArrayDriver();
//ListCollectionDriver();
ParseAndTryParseDriver();

void ArrayDriver()
{
    Console.WriteLine("\n\nReview of Arrays\n");

    Employment employment = null;
    Employment[] employments = new Employment[10];
    int physicalSize = 10;
    int logicalSize = 0;
    string inputValue = "n";
    int index = 0;

    for (int i = 0; i < physicalSize; i++)
    {
        employments[i] = GetEmploymentRecord();
        logicalSize++;
        Console.Write("\nAnother Employment Record (y,n): ");
        inputValue = Console.ReadLine();
        if (inputValue.ToLower().Equals("n"))
        {
            i = physicalSize;
        }
    }

    Console.WriteLine($"\n Employment Records {logicalSize}");
    while (index < logicalSize)
    {
        Console.WriteLine($"Record {index} is {employments[index].ToString()}");
        index++; //don't forget to increment your index when you use while loops
    }
}

void ListCollectionDriver()
{
    Console.WriteLine("\n\nReview of List<T> collection\n");

    Employment employment = null;
    List<Employment> employments = new List<Employment>(); //an empty list 
    string inputValue = "n";
    int index = 0;

    do
    {
        employments.Add(GetEmploymentRecord());

        Console.Write("\nAnother Employment Record (y,n): ");
        inputValue = Console.ReadLine();
    } while (inputValue.ToLower().Equals("y"));

    Console.WriteLine($"\n Employment Records {employments.Count}\n");
    Console.WriteLine($"\n foreach traverse - front to back\n");
    //first traverse of the collection uses the foreach
    foreach (Employment item in employments)
    {
        //front to back
        //sequencial
        //loop controls the movement of instance to instance
        //pre-test loop
        Console.WriteLine($"Record is {item.ToString()}");

    }

    Console.WriteLine($"\n array type traverse - back to front\n");
    //second traverse of the collection using index referencing
    //IF you are using index referencing YOU MAY decide the direction
    //  of travel
    //in this example, we will travel back to front
    index = employments.Count - 1; //.Count is the natural count NOT index
    while (index >= 0)
    {
        Console.WriteLine($"Record {index} is {employments[index].ToString()}");
        index--; //don't forget to increment your index when you use while loops
    }
}



void ParseAndTryParseDriver()
{
    Console.WriteLine("\n\nCreating a Parse and TryParse for Employment\n");

    Employment employment = null;
    string csvString = "Boss,Owner,Jul 12 1976,45.1";
    string csvStringShort = "Boss,Owner,45.1";
    string csvStringNull = ",Owner,Jul 12 1976,45.1";
    string csvStringEnum = "Boss,Bad,Jul 12 1976,45.1";
    string csvStringDate = "Boss,Owner,Jul 12 2026,45.1";
    string csvStringYears = "Boss,Owner,Jul 12 1976,-45.1";

    //catches for a try/catch must be coded specific to general
    try
    {
        employment = Employment.Parse(csvString);
        Console.WriteLine($"Successful Parse. Employment instance contains {employment.ToString()}");
        
        //employment = Employment.Parse(csvStringShort);
        //employment = Employment.Parse(csvStringNull);
        //employment = Employment.Parse(csvStringEnum);
        //employment = Employment.Parse(csvStringDate);
        //employment = Employment.Parse(csvStringYears);


        Console.WriteLine($"Successful Parse. Employment instance contains {employment.ToString()}");

    }
    catch (FormatException ex)
    {
        Console.WriteLine($"\n\t\tError Format: {ex.Message}\n ");
    }
    catch (ArgumentNullException ex)
    {
        Console.WriteLine($"\n\t\tError Null Exception: {ex.Message}\n ");
    }
    catch (ArgumentOutOfRangeException ex)
    {
        Console.WriteLine($"\n\t\tError Range: {ex.Message}\n ");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"\n\t\tError Argument: {ex.Message}\n ");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\n\t\tError: {ex.Message}\n ");
    }
}

    Employment GetEmploymentRecord()
{
    string inputValue;
    Employment newRecord = new Employment();
    Console.Write("\nEnter the position title:");
    newRecord.Title = Console.ReadLine();
    Console.Write("Enter starting Date: eg Jul 12 2002:");
    newRecord.CorrectStartDate(DateTime.Parse(Console.ReadLine()));
    Console.Write("Enter the number of years in the position: ");
    newRecord.Years = double.Parse(Console.ReadLine());
    return newRecord;
}

