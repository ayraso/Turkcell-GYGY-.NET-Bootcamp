// Max, Min, Mean

/*
 * UInt64.MaxValue = 18,446,744,073,709,551,615     ulong
 *  Int64.MaxValue =  9,223,372,036,854,775,807     long
 *  Int32.MaxValue =  2,147,483,647                 int
 *  Int16.MaxValue = 32,767                         short
 */

// For-Loop
try
{
    System.Console.WriteLine("### Enter the number of random integers you want to generate.");
    System.Console.WriteLine("### The integer numbers will be generated in the interval [-100.000, 100.000].");
    System.Console.WriteLine($"### Greatest number that may be entered is {Int16.MaxValue}."); 
    
    System.Console.Write(">>> ");
    Int16 numOfInts = Convert.ToInt16(Console.ReadLine());
    Int32[] array = new Int32[numOfInts];

    Random randomNumberGenerator = new Random();    
    for(int i=0; i<numOfInts; i++) 
    {
        array[i] = randomNumberGenerator.Next(-100000, 100001);
    }
    Console.WriteLine($"### {numOfInts} sized array has been created.");

    Int64 max  = array[0];
    Int64 min  = array[0];
    Int64 sum  = 0;
    for(int i=1; i<numOfInts; i++)
    {
        if      (array[i] > max) max = array[i];
        else if (array[i] < min) min = array[i];
        checked{ sum += array[i];}
    }

    Double mean = (Double)(sum / numOfInts);
    System.Console.WriteLine("\n### Here are the evaluation results.");
    System.Console.WriteLine($"### Minimum is {min}.");
    System.Console.WriteLine($"### Maximum is {max}.");
    System.Console.WriteLine($"### Mean    is {mean}.");
}
catch (Exception ex)
{
    Console.WriteLine($"### Something went wrong: {ex.Message}");
}
