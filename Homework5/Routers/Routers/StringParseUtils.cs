// <copyright file="StringParseUtils.cs" author="Aleksey Poziev">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// Class that performs useful method to parse string.
/// </summary>
public static class StringParseUtils
{
    /// <summary>
    /// Method that try to get a number from string starting from currentIndex until defined sign.
    /// </summary>
    /// <param name="sign">sign, until which pick number.</param>
    /// <param name="currentIndex">currentIndex reference.</param>
    /// <param name="currentString">string to work with.</param>
    /// <returns>number from string from currentIndex to first 'sign' in string.</returns>
    /// <exception cref="ArgumentNullException">currentString must be not null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">currentIndex must be larger than 0 and less than currentString size.</exception>
    /// <exception cref="ArgumentException">If no 'sign' in string of found value not a number.</exception>
    public static int GetNumberUntilSign(char sign, ref int currentIndex, string currentString)
    {
        if (currentString == null)
        {
            throw new ArgumentNullException(nameof(currentString));
        }

        if (currentIndex >= currentString.Length || currentIndex < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(currentIndex));
        }

        var newStringNumber = new System.Text.StringBuilder();

        while (currentIndex < currentString.Length && currentString[currentIndex] != sign)
        {
            newStringNumber.Append(currentString[currentIndex]);
            ++currentIndex;
        }

        if (currentIndex == currentString.Length)
        {
            throw new ArgumentException($"Not enough '{sign}' sign");
        }

        if (!int.TryParse(newStringNumber.ToString(), out var newNumber))
        {
            throw new ArgumentException($"'{newStringNumber}' must to be a number");
        }

        return newNumber;
    }

    /// <summary>
    /// Method to check is index in range.
    /// If index out of range -- throw exception, else just go further.
    /// </summary>
    /// <param name="expression">string that should contain index.</param>
    /// <exception cref="ArgumentException">If index out of string.</exception>
    public static void IsInRange(string expression, int index)
    {
        if (index > expression.Length || index < 0)
        {
            throw new ArgumentException("String not full");
        }
    }
}