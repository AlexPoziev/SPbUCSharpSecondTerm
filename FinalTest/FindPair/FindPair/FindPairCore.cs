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
    private readonly int[,] GameMatrix;

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
        var valueLimit = size * size / 2;
        var resultMatrix = new int[size, size];
        var usingNumbersCount = new byte[valueLimit];

        Random random = new ();

        for (int i = 0; i < size; ++i) 
        {
            for (int j = 0; j < size; ++j)
            {
                var randomValue = random.Next(valueLimit);
                while (usingNumbersCount[randomValue] == 2)
                {
                    randomValue = random.Next(valueLimit);
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

    public (int value, bool needToClose, bool isPair) ChoiceMaker((int x, int y) numberCoordinates)
    {
        if (currentState == States.FirstNumber)
        {
            currentState = States.SecondNumber;
            previousNumber = GameMatrix[numberCoordinates.x, numberCoordinates.y];

            return (previousNumber, false, false);
        }
        else if (currentState == States.SecondNumber)
        {
            var number = GameMatrix[numberCoordinates.x, numberCoordinates.y];

            currentState = States.FirstNumber;

            if (number == previousNumber)
            {
                --pairsLeft;
                if (pairsLeft == 0)
                {
                    currentState = States.GameOver;
                }

                return (number, false, true);
            }

            previousNumber = -1;

            return (number, true, false);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }
}
