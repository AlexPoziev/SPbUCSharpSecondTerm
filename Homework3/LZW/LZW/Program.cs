using Trees;
using LZW;

if (args.Length < 2)
{
    Console.WriteLine("Not enough arguments");
}

if (args[1] == "-c")
{
    Console.WriteLine("Compressing File...\n");

    var encoder = new LZWEncode();
    var tempFilePath = args[0] + ".zipped";
    File.Create(tempFilePath).Close();
    try
    {
        encoder.Encode(args[0], args[0] + ".zipped");
    }
    catch
    {
        Console.WriteLine("Compression Failed.");
        return;
    }

    var withoutBWTCompressRatio = (double)new FileInfo(tempFilePath).Length / (double)new FileInfo(args[0]).Length;

    File.Delete(tempFilePath);

    double bwtCompressRatio;
    try
    {
        bwtCompressRatio = LZWArchiver.Compress(args[0]);
    }
    catch
    {
        Console.WriteLine("Compression Failed.");
        return;
    }

    Console.WriteLine($"Compression ratio with BWT: {bwtCompressRatio}");
    Console.WriteLine($"Compression ratio without BWT: {withoutBWTCompressRatio}");
}
else if (args[1] == "-u")
{
    try
    {
        LZWArchiver.Decompress(args[0]);
    }
    catch
    {
        Console.WriteLine("Decompression Failed");
        return;
    }

    Console.WriteLine("Decompression was successful");

    File.Delete(args[0]);
}
else
{
    Console.WriteLine("Incorrect key, only -c to compress and -u to decompress");
    Console.WriteLine("Please, Try again");
}