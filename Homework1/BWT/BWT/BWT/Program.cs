var test = "banana";
(var newString, var lastElement) = Algorithms.BWT.DirectBWT(test);
Console.WriteLine($"{newString}, {lastElement}, {Algorithms.BWT.inverseBWT("nnbaaa", 3)}");