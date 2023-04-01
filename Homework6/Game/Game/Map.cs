namespace CoinCollectorGame;

public class Map
{
    private readonly char[,] mapMatrix;

    public Map(string[] content)
    {
        if (content == null || content.Contains(null))
        {
            throw new ArgumentNullException(nameof(content));
        }

        if (!content.Any())
        {
            throw new ArgumentException("Map can't be empty");
        }

        var maxWidth = int.MinValue;

        foreach(var element in content)
        {
            maxWidth = Math.Max(maxWidth, element.Length);
        }
        
        mapMatrix = new char[content.Length, maxWidth];

        var freeSpotsCount = 0;

        for (var i = 0; i < maxWidth; ++i)
        {
            int currentIndex;
            for (currentIndex = 0; currentIndex < content[i].Length; ++currentIndex)
            {
                if (content[i][currentIndex] == ' ')
                {
                    ++freeSpotsCount;
                }

                mapMatrix[i, currentIndex] = content[i][currentIndex];
            }

            while (currentIndex < maxWidth)
            {
                ++freeSpotsCount;
                mapMatrix[i, currentIndex] = ' ';
                ++maxWidth;
            }
        }

        if (freeSpotsCount < 2)
        {
            throw new ArgumentException("Map must to contain at least 2 empty spots.");
        }
    }

    public void SetValueInCoordinates(int row, int column, char newValue)
    {
        mapMatrix[row, column] = newValue;
    }

    public (int, int) GetRandomFreeSpotCoordinates()
    {
        var random = new Random();

        int column;
        int row;

        while (true)
        {
            column = random.Next(mapMatrix.GetLength(0));
            row = random.Next(mapMatrix.GetLength(1));

            if (mapMatrix[row, column] == ' ')
            {
                break;
            }
        }

        return (row, column);
    }

    public void PrintMap()
    {
        for (int i = 0; i < mapMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < mapMatrix.GetLength(1); j++)
            {
                Console.Write(mapMatrix[i, j]);
            }

            Console.WriteLine();
        }
    }

    
}

