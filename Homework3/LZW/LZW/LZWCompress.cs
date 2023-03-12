using Algorithms;

namespace LZW;

public static class LZWZip
{
    public static double Compress(string filePath)
    {
        string fileContent = Convert.ToBase64String(File.ReadAllBytes(filePath));

        (fileContent, var lastElementIndex) = BWT.DirectBWT(fileContent);

        var newFilePath = filePath.Substring(0, filePath.LastIndexOf('.')) + ".zipped";
        File.Create(newFilePath).Close();

        var test = new FileInfo(filePath);
        var tempFilePath = "./tempZipFile";
        File.WriteAllText(tempFilePath, fileContent);

        var bytes = File.ReadAllBytes(tempFilePath).ToList<byte>();

        var bytesForLastIndex = (int)Math.Log2(lastElementIndex) / 8 + 1;

        var lastIndexBits = LZWUtils.ConvertIntToBits(bytesForLastIndex * 8, lastElementIndex);

        for (int j = 0; j < bytesForLastIndex; ++j)
        {
            var newByte = new List<bool>();

            for (int i = 0; i < 8; ++i)
            {
                newByte.Insert(0, lastIndexBits.Last());
                lastIndexBits.RemoveAt(lastIndexBits.Count - 1);
            }

            bytes.Insert(0, (byte)LZWUtils.ConvertBitsToInt(newByte));
        }

        bytes.Insert(0, (byte)bytesForLastIndex);

        File.WriteAllBytes(tempFilePath, bytes.ToArray());

        var encoder = new LZWEncode();
        encoder.Encode(filePath, newFilePath);

        var firstFileSize = (new FileInfo(filePath)).Length;
        var secondFileSize = (new FileInfo(newFilePath)).Length;

        return (double)secondFileSize / (double)firstFileSize;
    }
}

