using System;

Console.WriteLine("Input numbers separated by space: ");

// nullable
var sequence = Console.ReadLine();
if (sequence == null)
{
    Console.WriteLine("Reading Error");
    return;
}

var stringArray = sequence.Trim().Split(' ');
var intArray = new int[stringArray.Length];

for (var i = 0; i < stringArray.Length; ++i)
{
    if (!int.TryParse(stringArray[i], out intArray[i]))
    {
        Console.WriteLine("Invalid input data");
        return;
    }
}

Sorting.ShellSort.Sort(intArray);

Console.WriteLine("Sorted array: ");
Sorting.Utils.PrintArray(intArray);