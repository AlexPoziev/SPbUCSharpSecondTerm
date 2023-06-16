// <copyright file="Project.cs" author="Aleksey Poziev">
// Copyright (c) Aleksey Poziev. All rights reserved.
// </copyright>

using Routers;

if (args.Length < 2)
{
    Console.WriteLine("Not enough arguments");
    return 0;
}

if (!File.Exists(args[0]))
{
    Console.WriteLine("File with topology doesn't exist");
    return 0;
}

if (args[1] == null)
{
    Console.WriteLine("Input file path can't be null");
}

var fileContent = File.ReadAllLines(args[0]);
if (fileContent == null)
{
    Console.WriteLine("File content can't be null");
    return -1;
}
else if (!fileContent.Any())
{
    Console.WriteLine("File with topology can't be empty");
    return 0;
}

try
{
    fileContent = ConfigurationGenerator.Configurate(fileContent);
}
catch (DisconnectedGraphException)
{
    Console.Error.WriteLine("Topology from the file isn't connected");
    return 1;
}
catch (IncorrectFormException e)
{
    Console.WriteLine(e.Message);
    return 0;
}

try
{
    File.WriteAllLines(args[1], fileContent);
}
catch (DirectoryNotFoundException)
{
    Console.WriteLine("Directory for input file doesn't exist");
    return 0;
}

return 0;