namespace LZW;

using Algorithms;

/// <summary>
/// Class of archiver based on LZW algorithm.
/// </summary>
public static class LZWArchiver
{
    /// <summary> Method to compress file. Create new file with name:.<fileName>.zipped </summary>
    /// <param name="filePath">path to file that need to be compressed</param>
    /// <returns> Сompression ratio </returns>
    /// <exception cref="ArgumentException">File must to exists and to be not empty</exception>
    public static double Compress(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new ArgumentException("No file with this path exists", nameof(filePath));
        }

        var fileByteContent = File.ReadAllBytes(filePath);
        if (fileByteContent == null || !fileByteContent.Any())
        {
            throw new ArgumentException("Trying to compress empty file", nameof(filePath));
        }

        (fileByteContent, var lastElementIndex) = BWT.DirectBWT(fileByteContent);

        var bytesForLastIndex = lastElementIndex == 0 ? 1 : ((int)Math.Log2(lastElementIndex) / 8) + 1;

        var lastIndexBits = BinaryConverter.ConvertIntToBits(bytesForLastIndex * 8, lastElementIndex);

        var listFileContent = fileByteContent.ToList();

        for (int j = 0; j < bytesForLastIndex; ++j)
        {
            var newByte = new List<bool>();

            for (int i = 0; i < 8; ++i)
            {
                newByte.Insert(0, lastIndexBits.Last());
                lastIndexBits.RemoveAt(lastIndexBits.Count - 1);
            }

            listFileContent.Insert(0, (byte)BinaryConverter.ConvertBitsToInt(newByte));
        }

        listFileContent.Insert(0, (byte)bytesForLastIndex);

        var encoder = new LZWEncode();

        var newFilePath = filePath + ".zipped";

        File.WriteAllBytes(newFilePath, encoder.Encode(listFileContent.ToArray()));

        var firstFileSize = new FileInfo(filePath).Length;
        var secondFileSize = new FileInfo(newFilePath).Length;

        return (double)firstFileSize / (double)secondFileSize;
    }

    /// <summary>
    /// Method to decompress file with extension.<.zipped>. Create new file with same name except .zipped
    /// </summary>
    /// <param name="filePath">path to file that need to be compressed</param>
    /// <exception cref="ArgumentException">File must to exists and not to be compises only of extension/exception>
    public static void Decompress(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new ArgumentException("No file with this path exists", nameof(filePath));
        }

        var newFilePath = filePath.Substring(0, filePath.LastIndexOf('.'));
        if (newFilePath == string.Empty)
        {
            throw new ArgumentException("File name comprises only of extension", nameof(filePath));
        }

        File.Create(newFilePath).Close();

        var decoder = new LZWDecode();

        var valueToDecode = File.ReadAllBytes(filePath);

        try
        {
           valueToDecode = decoder.Decode(valueToDecode);
        }
        catch
        {
            throw new ArgumentException("Trying to decompress empty file", nameof(filePath));
        }

        var bytes = valueToDecode.ToList();

        var lastIndexSize = bytes.First();
        bytes.RemoveAt(0);

        var lastIndexBitsList = new List<bool>();
        for (int i = 0; i < lastIndexSize; ++i)
        {
            lastIndexBitsList.AddRange(BinaryConverter.ConvertIntToBits(8, bytes.First()));
            bytes.RemoveAt(0);
        }

        var lastIndex = BinaryConverter.ConvertBitsToInt(lastIndexBitsList);

        File.WriteAllBytes(newFilePath, BWT.InverseBWT(bytes.ToArray(), lastIndex));
    }
}