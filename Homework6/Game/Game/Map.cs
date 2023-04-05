// "Licensed to the Apache Software Foundation (ASF) under one or more contributor license agreements;
// and tos You under the Apache License, Version 2.0. "

namespace CoinCollectorGame;

/// <summary>
/// Class that implement 2-dimensional map.
/// </summary>
public class Map
{
    /// <summary>
    /// Basic sign of map empty point.
    /// </summary>
    private readonly char emptyPointSign = ' ';

    private readonly char[,] mapMatrix;

    /// <summary>
    /// Initializes a new instance of the <see cref="Map"/> class.
    /// </summary>
    /// <param name="content">string array of map.</param>
    public Map(string[] content)
    {
        if (content == null || content.Contains(null))
        {
            throw new ArgumentNullException(nameof(content));
        }

        if (!content.Any())
        {
            throw new InvalidMapException("Map can't be empty");
        }

        var maxWidth = int.MinValue;

        foreach (var element in content)
        {
            maxWidth = Math.Max(maxWidth, element.Length);
        }

        FreePointSigns = new () { 'o', emptyPointSign };

        mapMatrix = new char[content.Length, maxWidth];

        var freePointsCount = 0;

        for (var i = 0; i < content.Length; ++i)
        {
            int currentIndex;
            for (currentIndex = 0; currentIndex < content[i].Length; ++currentIndex)
            {
                if (content[i][currentIndex] == emptyPointSign)
                {
                    ++freePointsCount;
                }

                mapMatrix[i, currentIndex] = content[i][currentIndex];
            }

            while (currentIndex < maxWidth)
            {
                ++freePointsCount;
                mapMatrix[i, currentIndex] = emptyPointSign;
                ++currentIndex;
            }
        }

        if (freePointsCount < 3)
        {
            throw new InvalidMapException("Map must to contain at least 2 empty points.");
        }
    }

    /// <summary>
    /// Subject for map changing event.
    /// </summary>
    public event EventHandler<MapChangeEventArgs> OnMapChange = (sender, args) => { };

    /// <summary>
    /// Gets set of signs, which some entity can go through.
    /// </summary>
    public HashSet<char> FreePointSigns { get; private set; }

    /// <summary>
    /// Gets Size of map.
    /// </summary>
    public (int height, int width) Size => (mapMatrix.GetLength(0), mapMatrix.GetLength(1));

    /// <summary>
    /// Method to set new value in coordinates.
    /// </summary>
    /// <param name="coordinates">coordinates, value which will be changed.</param>
    /// <param name="newValue">new value for coordinates.</param>
    /// <returns>Value before changes.</returns>
    /// <exception cref="ArgumentOutOfRangeException">coordinates must to be in map size range.</exception>
    public char SetValueInCoordinates((int row, int column) coordinates, char newValue)
    {
        if (coordinates.column >= mapMatrix.GetLength(1) || coordinates.column < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(coordinates), "Column value out of range");
        }

        if (coordinates.row >= mapMatrix.GetLength(0) || coordinates.row < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(coordinates.row), "Row value out of range");
        }

        var oldValue = mapMatrix[coordinates.row, coordinates.column];

        mapMatrix[coordinates.row, coordinates.column] = newValue;

        OnMapChange?.Invoke(this, new MapChangeEventArgs(coordinates.row, coordinates.column, newValue));

        return oldValue;
    }

    /// <summary>
    /// Method to check does coordinates containes in the map range.
    /// </summary>
    /// <returns>true in range, false -- doesn't.</returns>
    public bool IsInMapRange((int row, int column) coordinates)
            => coordinates.column < mapMatrix.GetLength(1) && coordinates.column >= 0
            && coordinates.row < mapMatrix.GetLength(0) && coordinates.row >= 0;

    /// <summary>
    /// Method to check can entity go through coordinates.
    /// </summary>
    /// <returns>true if it can, false -- can't.</returns>
    public bool IsFreePoint((int row, int column) coordinates)
           => IsInMapRange(coordinates) && FreePointSigns.Contains(mapMatrix[coordinates.row, coordinates.column]);

    /// <summary>
    /// Method to check can entity go from startCoordinates to FinishCoordinates in the map.
    /// </summary>
    /// <returns>true if it can, false -- it can't.</returns>
    public bool IsAchievable((int row, int column) startCoordinates, (int row, int column) finishCoordinates)
            => PathFinder.DoesPathExist(startCoordinates, finishCoordinates, mapMatrix, FreePointSigns);

    /// <summary>
    /// Method to get random empty point in the map, that you can achieve form startCoordinates.
    /// </summary>
    /// <returns>coordinates of random free and achievable point.</returns>
    public (int, int) GetRandomEmptyAchievablePointCoordinates((int row, int column) startCoordinates)
    {
        var random = new Random();

        int column;
        int row;

        while (true)
        {
            column = random.Next(mapMatrix.GetLength(1));
            row = random.Next(mapMatrix.GetLength(0));

            if (mapMatrix[row, column] == emptyPointSign && IsAchievable(startCoordinates, (row, column)))
            {
                break;
            }
        }

        return (row, column);
    }

    /// <summary>
    /// Method to get random point in the map.
    /// </summary>
    /// <returns>coordinates of random free point.</returns>
    public (int, int) GetRandomEmptyPointCoordinates()
    {
        var random = new Random();

        int column;
        int row;

        while (true)
        {
            column = random.Next(mapMatrix.GetLength(1));
            row = random.Next(mapMatrix.GetLength(0));

            if (mapMatrix[row, column] == emptyPointSign)
            {
                break;
            }
        }

        return (row, column);
    }

    /// <summary>
    /// Print Map in console.
    /// </summary>
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

    /// <summary>
    /// Method to write map in file.
    /// </summary>
    /// <param name="fileName">File name.</param>
    public void WriteMapInFile(string fileName)
    {
        using (var file = new StreamWriter(fileName))
        {
            for (int i = 0; i < mapMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < mapMatrix.GetLength(1); j++)
                {
                    file.Write(mapMatrix[i, j]);
                }

                file.WriteLine();
            }
        }
    }

    /// <summary>
    /// Method to add new sign to free point signs set.
    /// </summary>
    public void AddFreePointSign(char newSign) => FreePointSigns.Add(newSign);
}
