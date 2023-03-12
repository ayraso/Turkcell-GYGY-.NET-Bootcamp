// Max, Min, Mean

/*
 * UInt64.MaxValue = 18,446,744,073,709,551,615     ulong
 *  Int64.MaxValue =  9,223,372,036,854,775,807     long
 *  Int32.MaxValue =  2,147,483,647                 int
 *  Int16.MaxValue = 32,767                         short
 */

// While-Loop
try
{
    System.Console.WriteLine("### Enter the number of random integers you want to generate.");
    System.Console.WriteLine("### The integer numbers will be generated in the interval [-100.000, 100.000].");
    System.Console.WriteLine($"### Greatest number that may be entered is {Int16.MaxValue}.");

    System.Console.Write(">>> ");
    Int16 numOfInts = Convert.ToInt16(Console.ReadLine());
    Int32[] array = new Int32[numOfInts];

    Random randomNumberGenerator = new Random();
    int i = 0;
    while ( i < numOfInts)
    {
        array[i] = randomNumberGenerator.Next(-100000, 100001);
        i++;
    }
    Console.WriteLine($"### {numOfInts} sized array has been created.");

    Int64 max = array[0];
    Int64 min = array[0];
    Int64 sum = 0;

    i = 1;
    while ( i < numOfInts)
    {
        if (array[i] > max) max = array[i];
        else if (array[i] < min) min = array[i];
        checked { sum += array[i]; }
        i++;
    }
    Double mean = (Double)(sum / numOfInts);

    System.Console.WriteLine("### Select the operation you want to perform.");
    System.Console.WriteLine("### Operations: max, min, mean");

    System.Console.Write(">>> ");
    String operation = Convert.ToString(Console.ReadLine());

    switch (operation)
    {
        // I know the optimal solution is that converting the input to lowercase letter string.
        // I created a scenerio to use case's as well.
        case "max":
        case "Max":
        case "MAX":
            System.Console.WriteLine($"### Maximum is {max}.");
            break;
        case "min":
        case "Min":
        case "MIN":
            System.Console.WriteLine($"### Minimum is {min}.");
            break;
        case "mean":
        case "Mean":
        case "MEAN":
            System.Console.WriteLine($"### Mean    is {mean}.");
            break;
    }   
}
catch (Exception ex)
{
    Console.WriteLine($"### Something went wrong: {ex.Message}");
}