using Algorithms;

namespace LZW;

public static class LZWZip
{
    public static double Compress(string filePath)
    {
        var testik = File.ReadAllBytes(filePath);
        File.WriteAllBytes("./test.zip", testik);
        testik = File.ReadAllBytes(filePath);

        string fileContent = Convert.ToHexString(File.ReadAllBytes(filePath));

        (fileContent, var lastElementIndex) = BWT.DirectBWT(fileContent);

        var newFilePath = filePath.Substring(0, filePath.LastIndexOf('.')) + ".zipka";
        File.Create(newFilePath).Close();

        fileContent = fileContent.Replace('-', '+');
        fileContent = fileContent.Replace('_', '/');

        var test = new FileInfo(filePath);
        var tempFilePath = "./tempZipFile";
        var lengthTest = fileContent.Length;
        File.WriteAllBytes(tempFilePath, Convert.FromHexString(fileContent));


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
        encoder.Encode(tempFilePath, newFilePath);

        var firstFileSize = (new FileInfo(filePath)).Length;
        var secondFileSize = (new FileInfo(newFilePath)).Length;

        return (double)secondFileSize / (double)firstFileSize;
    }
}

