namespace CoinCollectorGame;

public static class PathFinder
{
    public static bool DoesPathExist((int row, int column) start, (int row, int column) finish, char[,] mapMatrix, HashSet<char> freeSpotSigns)
    {
        var height = mapMatrix.GetLength(0);
        var width = mapMatrix.GetLength(1);

        var vertices = new int[width * height * 5];
        for (int i = 0; i < width * height * 5; ++i)
        {
            vertices[i] = -1;
        }

        IndexVertices(mapMatrix, (height, width), vertices, freeSpotSigns);

        var startIndex = start.row * 5 *  width + 5 * start.column;

        var finishIndex = finish.row * 5 * width + 5 * finish.column;

        var queue = new LinkedList<int>();

        queue.AddLast(startIndex);

        vertices[startIndex] = -1;

        while (queue.Any())
        {
            var currentValue = queue.First!.Value;
            queue.RemoveFirst();

            if (currentValue == finishIndex)
            {
                return true;
            }

            for (var i = currentValue + 1; i < currentValue + 5; ++i)
            {
                var key = vertices[i];
                if (vertices[i] == -1 || vertices[key] != key)
                {
                    continue;
                }

                vertices[key] = vertices[key + (5 - (i - currentValue))];
                queue.AddLast(key);
            }
        }

        return false;
    }

    private static void IndexVertices(char[,] mapMatrix, (int height, int width) matrixSize, int[] verticies, HashSet<char> freeSpotSigns)
    {
        for (var i = 0; i < matrixSize.height; ++i)
        {
            for (var j = 0; j < matrixSize.width; ++j)
            {
                if (freeSpotSigns.Contains(mapMatrix[i, j]) || mapMatrix[i, j] == '@')
                {
                    var index = i * 5 * matrixSize.width + 5 * j;
                    verticies[index] = index;

                    if (j > 0 && verticies[index - 5] == index - 5)
                    {
                        verticies[index - 2] = index;
                        verticies[index + 2] = index - 5;
                    }

                    if (i > 0 && verticies[index - matrixSize.width * 5] == index - matrixSize.width * 5)
                    {
                        verticies[index - matrixSize.width * 5 + 4] = index;
                        verticies[index + 1] = index - matrixSize.width * 5;
                    }
                }
            }
        }
    }
}

