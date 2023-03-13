using Algorithms;

namespace LZW;

public static class LZWArchiver
{
    public static double Compress(string filePath)
    {
        var fileByteContent = File.ReadAllBytes(filePath);

        (fileByteContent, var lastElementIndex) = BWT.DirectBWT(fileByteContent);

        var newFilePath = filePath + ".zipped";
        File.Create(newFilePath).Close();

        var bytesForLastIndex = (int)Math.Log2(lastElementIndex) / 8 + 1;

        var lastIndexBits = LZWUtils.ConvertIntToBits(bytesForLastIndex * 8, lastElementIndex);

        var listFileContent = fileByteContent.ToList();

        for (int j = 0; j < bytesForLastIndex; ++j)
        {
            var newByte = new List<bool>();

            for (int i = 0; i < 8; ++i)
            {
                newByte.Insert(0, lastIndexBits.Last());
                lastIndexBits.RemoveAt(lastIndexBits.Count - 1);
            }

            listFileContent.Insert(0, (byte)LZWUtils.ConvertBitsToInt(newByte));
        }

        listFileContent.Insert(0, (byte)bytesForLastIndex);

        var tempFilePath = "./tempZipFile";
        File.WriteAllBytes(tempFilePath, listFileContent.ToArray());

        var encoder = new LZWEncode();
        encoder.Encode(tempFilePath, newFilePath);

        var test = File.ReadAllBytes(newFilePath);

        var firstFileSize = (new FileInfo(filePath)).Length;
        var secondFileSize = (new FileInfo(newFilePath)).Length;

        return (double)secondFileSize / (double)firstFileSize;
    }

    public static void Decompress(string filePath)
    {
        var newFilePath = filePath.Substring(0, filePath.LastIndexOf('.'));

        File.Create(newFilePath).Close();

        var decoder = new LZWDecode();
        decoder.Decode(filePath, newFilePath);

        var bytes = File.ReadAllBytes(newFilePath).ToList();

        var lastIndexSize = bytes.First();
        bytes.RemoveAt(0);

        var lastIndexBitsList = new List<bool>();
        for (int i = 0; i < lastIndexSize; ++i)
        {
            lastIndexBitsList.AddRange(LZWUtils.ConvertIntToBits(8, bytes.First()));
            bytes.RemoveAt(0);
        }

        var lastIndex = LZWUtils.ConvertBitsToInt(lastIndexBitsList);

        File.WriteAllBytes(newFilePath, BWT.InverseBWT(bytes.ToArray(), lastIndex));
    }
}

