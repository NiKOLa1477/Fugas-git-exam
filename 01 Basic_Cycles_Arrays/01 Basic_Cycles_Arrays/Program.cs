//Task1. Year of birth from age
int age;
Console.WriteLine("Enter your age:");
while (!Int32.TryParse(Console.ReadLine(), out age))
    Console.WriteLine("Wrong format. Value must be an integer");
Console.WriteLine($"Your birth year is {DateTime.Now.Year - age}");
Console.WriteLine();

//Task2. Multiplication table of a value
double value;
Console.WriteLine("Enter a value:");
while (!Double.TryParse(Console.ReadLine(), out value))
    Console.WriteLine("Wrong format. Value must be a number");
for (int i = 0; i <= 10; i++)
    Console.WriteLine($"{value} * {i} = {value * i}");
Console.WriteLine();

//Task3. Average of negative values in array
int LENGTH = 10, lim = 10;
var rand = new Random();
int[] array = new int[LENGTH];
for (int i = 0; i < LENGTH; i++)
    array[i] = rand.Next(2 * lim + 1) - lim;
Console.WriteLine("Your array:");
for (int i = 0; i < LENGTH; i++)
    Console.Write($"{array[i]} | ");
Console.WriteLine($"\nAverage of negative values equal {array.Where(i => i < 0).Average()}");
Console.WriteLine();

//Task4. Pascal triangle output
int linesCount;
Console.WriteLine("Enter lines count:");
while (!Int32.TryParse(Console.ReadLine(), out linesCount))
    Console.WriteLine("Wrong format. Value must be an integer");
int maxLineLength = 2 * linesCount - 1; // Length of the last line of triangle including spaces
int[,] PasTrArr = new int[linesCount, maxLineLength];
for (int i = 0; i < linesCount; i++) {
    for (int j = 0; j < maxLineLength; j++) {       
        if (j >= (maxLineLength - 2*i) / 2 //check if j belong to the current triangle line
            && j < maxLineLength - ((maxLineLength - 2 * i) / 2)) // 2*i is length of the current triangle line
        {
            if (i == 0 || i == linesCount - 1 // adding the first line value and the first and last values of last line
                && (j - 1 < 0 || j + 1 == maxLineLength)) PasTrArr[i, j] = 1; // if calculate them there is index out of array exep.
            else PasTrArr[i, j] = PasTrArr[i - 1, j - 1] + PasTrArr[i - 1, j + 1];
        }        
    }
}
for (int i = 0; i < linesCount; i++) {
    for (int j = 0; j < maxLineLength; j++) {
        if (PasTrArr[i, j] == 0) Console.Write(" ".ToString().PadLeft(linesCount / 4 + 1));
        else Console.Write($"{PasTrArr[i, j].ToString().PadRight(linesCount / 4 + 1)}");
    }
    Console.WriteLine();
}
Console.WriteLine();

//Task5. Output unique elements in array
LENGTH = 50; lim = 10;
array = new int[LENGTH];
for (int i = 0; i < LENGTH; i++)
    array[i] = rand.Next(lim + 1);
Console.WriteLine("Your array:");
for (int i = 0; i < LENGTH; i++)
    Console.Write($"{array[i]} | ");
Console.WriteLine("\nUnique values:");
foreach (int item in array.Distinct().ToArray())
    Console.Write($"{item} | ");