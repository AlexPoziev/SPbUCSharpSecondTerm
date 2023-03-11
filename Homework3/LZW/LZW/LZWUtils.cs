namespace LZW;

public static class LZWUtils
{
    public static byte ConvertBitsToByte(List<bool> bits)
    {
        int result = 0;
        var index = 0;

        foreach (var bit in bits)
        {
            if (bit)
            {
                result |= 1 << (bits.Count - index - 1);
            }

            ++index;
        }

        return (byte)result;
    }

    public static List<bool> ConvertIntToBits(int bitsCount, int number)
    {
        var bits = new List<bool>();

        while (number > 0)
        {
            if ((number & 1) == 1)
            {
                bits.Add(true);
            }
            else
            {
                bits.Add(false);
            }

            number >>= 1;
        }

        while (bits.Count < bitsCount)
        {
            bits.Add(false);
        }

        bits.Reverse();

        return bits;
    }
}

