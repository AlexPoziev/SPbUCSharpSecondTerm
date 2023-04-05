// "Licensed to the Apache Software Foundation (ASF) under one or more contributor license agreements;
// and tos You under the Apache License, Version 2.0. "

namespace CoinCollectorGame;

/// <summary>
/// Class that implement path finder in grid.
/// </summary>
public static class PathFinder
{
    /// <summary>
    /// Method that check does exist path from start coordinates to finish coordinates.
    /// </summary>
    /// <param name="start">start coordinates.</param>
    /// <param name="finish">finish coordinates.</param>
    /// <param name="mapMatrix">matrix of the map.</param>
    /// <param name="freeSpotSigns">Set of signs, which u can go through.</param>
    /// <returns>true if path exists, false -- doesn't.</returns>
    /// <exception cref="ArgumentNullException">mapMatrix and freeSpotSigns can't be null.</exception>
    public static bool DoesPathExist((int row, int column) start, (int row, int column) finish, char[,] mapMatrix, HashSet<char> freeSpotSigns)
    {
        if (mapMatrix == null)
        {
            throw new ArgumentNullException(nameof(mapMatrix));
        }

        if (freeSpotSigns == null)
        {
            throw new ArgumentNullException(nameof(freeSpotSigns));
        }

        var height = mapMatrix.GetLength(0);
        var width = mapMatrix.GetLength(1);

        var vertices = new int[width * height * 5];
        for (int i = 0; i < width * height * 5; ++i)
        {
            vertices[i] = -1;
        }

        IndexVertices(mapMatrix, (height, width), vertices, freeSpotSigns);

        var startIndex = (start.row * 5 * width) + (5 * start.column);

        var finishIndex = (finish.row * 5 * width) + (5 * finish.column);

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
                    var index = (i * 5 * matrixSize.width) + (5 * j);
                    verticies[index] = index;

                    if (j > 0 && verticies[index - 5] == index - 5)
                    {
                        verticies[index - 2] = index;
                        verticies[index + 2] = index - 5;
                    }

                    if (i > 0 && verticies[index - (matrixSize.width * 5)] == index - (matrixSize.width * 5))
                    {
                        verticies[index - (matrixSize.width * 5) + 4] = index;
                        verticies[index + 1] = index - (matrixSize.width * 5);
                    }
                }
            }
        }
    }
}