﻿using Algorithms;

namespace LZW;

/// <summary>
/// Class of archiver based on LZW algorithm.
/// </summary>
public static class LZWArchiver
{

    /// <summary>
    /// Method to compress file. Create new file with name: <fileName>.zipped
    /// </summary>
    /// <param name="filePath">path to file that need to be compressed</param>
    /// <returns>Сompression ratio</returns>
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

        File.Delete(tempFilePath);

        var firstFileSize = (new FileInfo(filePath)).Length;
        var secondFileSize = (new FileInfo(newFilePath)).Length;

        return (double)secondFileSize / (double)firstFileSize;
    }

    /// <summary>
    /// Method to decompress file with extension <.zipped>. Create new file with same name except .zipped
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

        try
        {
            decoder.Decode(filePath, newFilePath);
        }
        catch
        {
            throw new ArgumentException("Trying to decompress empty file", nameof(filePath));
        }

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