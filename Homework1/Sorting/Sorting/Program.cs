int[] test = { 3, 2, 1 };

test = Sorting.ShellSort.Sort(test);

Console.WriteLine(test);
foreach(var item in test)
{
    System.Console.WriteLine(item);
}