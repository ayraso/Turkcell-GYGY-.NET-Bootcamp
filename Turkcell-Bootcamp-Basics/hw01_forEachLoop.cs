// Max, Min, Mean

/*
 * UInt64.MaxValue = 18,446,744,073,709,551,615     ulong
 *  Int64.MaxValue =  9,223,372,036,854,775,807     long
 *  Int32.MaxValue =  2,147,483,647                 int
 *  Int16.MaxValue = 32,767                         short
 */

// For-Each-Loop

bool flag=false;
do
{
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
        while (i < numOfInts)
        {
            array[i] = randomNumberGenerator.Next(-100000, 100001);
            i++;
        }
        Console.WriteLine($"### {numOfInts} sized array has been created.");

        Int64 max = array[0];
        Int64 min = array[0];
        Int64 sum = 0;

        foreach (Int64 x in array)
        {
            if (x > max) max = x;
            else if (x < min) min = x;
            checked { sum += x; }
        }

        Double mean = (Double)(sum / numOfInts);



        bool operatorFlag = false;
        do
        {
            System.Console.WriteLine("### Select the operation you want to perform.");
            System.Console.WriteLine("### Operations: max, min, mean, all(max, min, mean)");

            System.Console.Write(">>> ");
            String operation = Convert.ToString(Console.ReadLine());

            switch (operation)
            {
                // I know the optimal solution is that converting the input to lowercase letter string.
                // I created a scenerio to use case's as well.
                case "max":
                case "Max":
                case "MAX":
                    System.Console.WriteLine($"### Maximum is {max}.\n");
                    operatorFlag = true;
                    break;
                case "min":
                case "Min":
                case "MIN":
                    System.Console.WriteLine($"### Minimum is {min}.\n");
                    operatorFlag = true;
                    break;
                case "mean":
                case "Mean":
                case "MEAN":
                    System.Console.WriteLine($"### Mean    is {mean}.\n");
                    operatorFlag = true;
                    break;
                case "all":
                case "All":
                case "ALL":
                    System.Console.WriteLine("\n### Here are the evaluation results.");
                    System.Console.WriteLine($"### Minimum is {min}.");
                    System.Console.WriteLine($"### Maximum is {max}.");
                    System.Console.WriteLine($"### Mean    is {mean}.\n");
                    operatorFlag = true;
                    break;
                default:
                    System.Console.WriteLine("\n### Your operator input is invalid.\n");
                    operatorFlag = false;
                    break;
            }
        } while (!operatorFlag);

    }
    catch (Exception ex)
    {
        Console.WriteLine($"\n### Something went wrong: {ex.Message}\n");
        flag = false;
    }
}
while (!flag);
