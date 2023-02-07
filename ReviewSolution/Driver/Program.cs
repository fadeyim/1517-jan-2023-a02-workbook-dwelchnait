// See https://aka.ms/new-console-template for more information
using OOPsReview;
using System.Diagnostics.CodeAnalysis;
using System.Xml.XPath;
//to use JSON IO you require the following using
using System.Text.Json;

Console.WriteLine("OOPs Review Console Driver");

const string PATHNAME = "../../../Employment.csv";
const string PATHNAMEBAD = "../../../BadEmployment.csv";
const string PATHNAMEJSON = "../../../EmploymentJSON.json";
List<Employment> jobs = null;

//ArrayDriver();
//ListCollectionDriver();
//ParseAndTryParseDriver();
//CSVFileIOWrite(PATHNAME);
//jobs = CSVFileIORead(PATHNAME);
//jobs = CSVFileIORead(PATHNAMEBAD);
//OutputEmploymentCollection(jobs);

//create an entire person and output to a json file
//ResidentAddress address = new ResidentAddress(123, "Maple Ave", null, null, "Edmonton", "AB");
//Person me = new Person("Shirely","Ujest",address,jobs);
//SaveAsJson(me, PATHNAMEJSON);

//read a json file and output the data
Person you = null;
you = ReadAsJson(PATHNAMEJSON);
if (you != null)
{
    Console.WriteLine("\nContents of Json Read\n");
    Console.WriteLine($"Person: {you.FullName}");
    Console.WriteLine($"Address: {you.Address.ToString()}");
    OutputEmploymentCollection(you.EmploymentPositions);
}

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
        //employment = Employment.Parse(csvString);

        if (Employment.TryParse(csvString, out employment))
        {
            Console.WriteLine($"Successful Parse. Employment instance contains {employment.ToString()}");
        }
        else
        {
            Console.WriteLine("TryParse Failed");
        }


        //employment = Employment.Parse(csvStringShort);
        //employment = Employment.Parse(csvStringNull);
        //employment = Employment.Parse(csvStringEnum);
        //employment = Employment.Parse(csvStringDate);
        //employment = Employment.Parse(csvStringYears);


        if (Employment.TryParse(csvStringShort, out employment))
        {
            Console.WriteLine($"Successful Parse. Employment instance contains {employment.ToString()}");
        }
        else
        {
            Console.WriteLine("TryParse Failed");
        }

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

void CSVFileIOWrite(string pathname)
{
    List<Employment> jobs = new List<Employment>();
    jobs.Add(new Employment("Worker",SupervisoryLevel.TeamMember,
        new DateTime(2002,7,13),5.5));
    jobs.Add(new Employment("Project Lead", SupervisoryLevel.TeamLeader,
        new DateTime(2008, 2, 3), 10.1));
    jobs.Add(new Employment("Department Head", SupervisoryLevel.DepartmentHead,
        new DateTime(2018, 3, 13), 5.0));

    //create a List<string> that will hold the ToString Employment
    //this collection will then be written to a csv text file using the File class
    List<string> csvlines = new();

    //Place the employment records into the csv line collection
    //using Employment.ToString
    foreach(Employment item in jobs)
    {
        csvlines.Add(item.ToString());
    }

    //write to a text file
    //each row in the text file will represent one Employment instance
    //You could use StreamWriter
    //HOWEVER there a class call File which handles IO in a simpler fashion
    //The Stream classes (Writer/Reader) are good for very very large IO scenarios
    //  or when you may not output/reader the entire collection of records
    //SO, if you are going to process the entire file then using the File class
    //  could be a fast and better choice
    //Reading and Writing a file is done in the same folder as the .exe by default
    //You can use relative addressing to the .exe location to specify your IO file


    File.WriteAllLines(pathname, csvlines);

    Console.WriteLine($"\nCheck out the CSV file at: {Path.GetFullPath(pathname)}");


}

List<Employment> CSVFileIORead(string pathname)
{
    //In this method we will read a csvfile with records representing the
    //  Employment instance
    //We will use the Employment.TryParse to create the Empoyment instance
    //One could use StreamReader to handle this process if
    //  a) you were not going to need to process ALL records
    //  b) input file is extremely large
    //OTHERWISE consider using the File class

    //since we are reading a "unknown" file, we willbe required to use a try/catch
    //  to handle errors in a user friendly manner

    List<Employment> jobs = new();
    Employment job = null;  // a reusable instance for each record
    try
    {
        //using File.ReadAllLines one can input the complete csv (text) file
        //each row in the file will be converted to a string
        //create an array of strings to handle your read
        string[] records = File.ReadAllLines(pathname);

        foreach (string row in records)
        {
            //in this example, we wish to process ALL records in the file
            // we will be required to have a inner try/catch for the parsing of the
            //     input records
            try
            {
                //attempt to convert a comma separate value string into an
                //  instance of Employment
                bool converted = Employment.TryParse(row, out job);

                //one could test the success of the TryParse
                //however, in the set up of this logic, it really is not
                //  necessary as any error would be handled by the catches
                //  and the following logic woould not be executed
                if (converted)
                {
                    jobs.Add(job);
                }
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
        }//eol
    }//eot outer try
    catch (IOException ex)
    {
        Console.WriteLine($"Reading CSV file error: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"UnKnown error: {ex.Message}");
    }
    return jobs;
}

void OutputEmploymentCollection(List<Employment> jobs)
{
    Console.WriteLine("\nCurrent list of employment records\n");
    foreach(var item in jobs)
    {
        Console.WriteLine(item.ToString());
    }
}

void SaveAsJson(Person me, string pathname)
{
    //the term use to write Json files is Serialization
    //the classes used are referred to as serializers
    //with writing we can make the file produce more readable format
    //  using indentation
    //Json is very good at using objects and properties, HOWEVER,
    //  it needs hlep/prompting to work better with fields
    //to help with public fields within an class add and annotation
    //  in front of the field delcaration called [JsonInclude]
    //  also the namespace: using System.Text.Json.Serialization;
    // example (see Residence class)
    //  [JsonInclude]
    //  public string SomeFieldInAClass;
    //create options to use during serialization
    JsonSerializerOptions options = new JsonSerializerOptions
    {
        WriteIndented = true,
        IncludeFields = true
    };
    try
    {
        //remember to case the Serialize<T> to the appropriate class definition
        //this converts your instance to a json string
        string jsonstring = JsonSerializer.Serialize<Person>(me, options);

        //write the json string out to a text file
        File.WriteAllText(pathname, jsonstring);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

Person ReadAsJson (string pathname)
{
    Person person = null;
    try
    {
        //bring in the text
        string jsonstring = File.ReadAllText(pathname);

        //use the deseralizer to unpack the json string into
        // the expected structure <Person>
        person = JsonSerializer.Deserialize<Person>(jsonstring);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    return person;
}