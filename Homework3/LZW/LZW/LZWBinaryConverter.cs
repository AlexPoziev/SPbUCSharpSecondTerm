namespace LZW;

/// <summary>
/// Utils to convert bits to positive int value and vice versa.
/// </summary>
public static class BinaryConverter
{
    /// <summary>
    /// convert bits, represented like list of bools to positive int value.
    /// </summary>
    /// <param name="bits">bits to convert into int value.</param>
    /// <returns>converted int value</returns>
    /// <exception cref="ArgumentNullException">bits array can't be null.</exception>
    /// <exception cref="ArgumentException">bits array can't be empty.</exception>
    public static int ConvertBitsToInt(List<bool> bits)
    {
        if (bits == null)
        {
            throw new ArgumentNullException(nameof(bits), "Bits list can't be null");
        }

        if (!bits.Any())
        {
            throw new ArgumentException("Bits list can't be null", nameof(bits));
        }

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

        return result;
    }

    /// <summary>
    /// Method to convert positive number to bits, represented like list of bools with fixed size.
    /// </summary>
    /// <param name="bitsCount">the smallest number of bits that should be in the result list.</param>
    /// <param name="number">number that should be converted.</param>
    /// <returns>bits in list of bools form.</returns>
    /// <exception cref="ArgumentException">number should be positive, bitsCount should be more than 0.</exception>
    public static List<bool> ConvertIntToBits(int bitsCount, int number)
    {
        if (number < 0)
        {
            throw new ArgumentException("Number must be positive", nameof(number));
        }

        if (bitsCount <= 0)
        {
            throw new ArgumentException("Number more than 0", nameof(number));
        }

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