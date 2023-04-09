// "Licensed to the Apache Software Foundation (ASF) under one or more contributor license agreements;
// and tos You under the Apache License, Version 2.0. "

namespace Calculator;

/// <summary>
/// Class that holds some useful utils for calculator working.
/// </summary>
public static class CalculatorUtils
{
    /// <summary>
    /// Method to check are two float numbers equal.
    /// </summary>
    /// <returns>true if equal, else -- false.</returns>
    public static bool AreFloatsEqual(float firstNumber, float secondNumber)
    {
        var delta = 0.000001f;

        return Math.Abs(firstNumber - secondNumber) < delta;
    }

    /// <summary>
    /// Method to check is char value operation sign ( '+' '-' '*' '/' '%' ).
    /// </summary>
    /// <returns>true if operation sign, else -- false.</returns>
    public static bool IsOperationSign(char sign)
            => sign == '+' || sign == '-' || sign == '*' || sign == '/' || sign == '%';

    /// <summary>
    /// Method to calculate result by two float operands and operation ( '+' '-' '*' '/' '%' ).
    /// </summary>
    /// <returns>result of operation.</returns>
    /// <exception cref="DivideByZeroException">.</exception>
    /// <exception cref="ArgumentException">Operation not in list : '+' '-' '*' '/' '%'.</exception>
    public static float PerformArithmeticalOperation(float firstNumber, float secondNumber, char operation)
    {
        switch (operation)
        {
            case '+':
                return firstNumber + secondNumber;

            case '-':
                return firstNumber - secondNumber;

            case '*':
                return firstNumber * secondNumber;

            case '/':
                if (AreFloatsEqual(0.0f, secondNumber))
                {
                    throw new DivideByZeroException();
                }

                return firstNumber / secondNumber;

            case '%':
                return secondNumber / 100 * firstNumber;

            default:
                throw new ArgumentException("Not operation sign");
        }
    }

    /// <summary>
    /// Method to calculate result by two float operands in string representation and operation ( '+' '-' '*' '/' '%' ).
    /// </summary>
    /// <returns>result of operation.</returns>
    /// <exception cref="ArgumentException">Operation not in list : '+' '-' '*' '/' '%', or operands not a float numbers.</exception>
    public static string PerformTwoFloatStringsOperation(string firstNumberString, string secondNumberString, char sign)
    {
        if (!float.TryParse(firstNumberString, out var firstNumber))
        {
            throw new ArgumentException("Not a number", nameof(firstNumberString));
        }

        if (!float.TryParse(secondNumberString, out var secondNumber))
        {
            throw new ArgumentException("Not a number", nameof(firstNumberString));
        }

        return PerformArithmeticalOperation(firstNumber, secondNumber, sign).ToString();
    }
}
