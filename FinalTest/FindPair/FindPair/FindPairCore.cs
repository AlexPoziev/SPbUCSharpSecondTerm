using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace FindPair;
public class FindPairCore
{
    private int[,] GameMatrix;

    private int pairsLeft;

    private States currentState = States.FirstNumber;

    int previousNumber = -1;

    public FindPairCore(int size)
    {
        if (size <= 0 || size % 2 != 0)
        {
            throw new ArgumentException();
        }

        GameMatrix = CreateGameMatrix(size);
    }

    private static int[,] CreateGameMatrix(int size)
    {
        var valueLimit = size * size / 2 - 1;
        var resultMatrix = new int[size, size];
        var usingNumbersCount = new byte[valueLimit];

        Random random = new ();

        for (int i = 0; i < valueLimit; ++i) 
        {
            for (int j = 0; j < valueLimit; ++j)
            {
                var randomValue = random.Next(valueLimit + 1);
                while (usingNumbersCount[randomValue] != 2)
                {
                    randomValue = random.Next(valueLimit + 1);
                }

                resultMatrix[i, j] = randomValue;
                ++usingNumbersCount[randomValue];
            }
        }

        return resultMatrix;
    }

    private enum States
    {
       FirstNumber,
       SecondNumber,
       GameOver
    }

    public (int, bool) ChoiceMaker((int x, int y) numberCoordinates)
    {
        if (currentState == States.FirstNumber)
        {
            currentState = States.SecondNumber;
            return (GameMatrix[numberCoordinates.x, numberCoordinates.y], false);
        }
        else if (currentState == States.SecondNumber)
        {
            var number = GameMatrix[numberCoordinates.x, numberCoordinates.y];

            if (number == previousNumber)
            {
                --pairsLeft;
                if (pairsLeft == 0)
                {
                    currentState = States.GameOver;
                }

                return (number, true);
            }

            return (number, false);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }
}
