namespace CoinCollectorGame;

public class Game
{
    private Map map;
    private (int, int) currentCoordinates;

    public Game(string fileName)
    {
        if (!File.Exists(fileName))
        {
            throw new ArgumentException("File doensn't exist" ,nameof(fileName));
        }

        var content = File.ReadAllLines(fileName);

        map = new Map(content);


    }
}

