namespace CoinCollectorGame;

public class Game
{
    public event EventHandler<EventArgs> OnCoinCollect = (sender, args) => { };

    private readonly Map map;

    private (int row, int column) currentCoordinates;

    private readonly CursorValueChanger cursor = new();

    private readonly Coins coins;

    public Game(string fileName)
    {
        if (!File.Exists(fileName))
        {
            throw new ArgumentException("File doesn't exist", nameof(fileName));
        }

        var content = File.ReadAllLines(fileName);

        map = new Map(content);

        var (first, second) = map.GetRandomFreeSpotCoordinates();

        map.SetValueInCoordinates((first, second), '@');
        currentCoordinates = (first, second);

        coins = new(map);
        coins.Subscribe(this);

        map.PrintMap();

        cursor.Subscribe(map);
    }

    private void MoveCharacter(Direction direction)
    {
        var newCoordinates = TakeCoordinatesAfterDirectionMove(direction);

        if (!map.IsFreeSpot(newCoordinates))
        {
            return;
        }

        map.SetValueInCoordinates((currentCoordinates.row, currentCoordinates.column), ' ');
        currentCoordinates = newCoordinates;
        var oldElement = map.SetValueInCoordinates((newCoordinates.row, newCoordinates.column), '@');

        if (oldElement == 'o')
        {
            OnCoinCollect(this, EventArgs.Empty);
        }
    }

    private (int row, int column) TakeCoordinatesAfterDirectionMove(Direction direction) =>
        direction switch
        {
            Direction.Left => (currentCoordinates.row, currentCoordinates.column - 1),
            Direction.Up => (currentCoordinates.row - 1, currentCoordinates.column),
            Direction.Down => (currentCoordinates.row + 1, currentCoordinates.column),
            Direction.Right => (currentCoordinates.row, currentCoordinates.column + 1),
            _ => throw new ArgumentException("Unexpected behaviour"),
        };

    public void OnLeft(object? sender, EventArgs args)
    {
        MoveCharacter(Direction.Left);
    }

    public void OnRight(object? sender, EventArgs args)
    {
        MoveCharacter(Direction.Right);
    }

    public void OnDown(object? sender, EventArgs args)
    {
        MoveCharacter(Direction.Down);
    }

    public void OnUp(object? sender, EventArgs args)
    {
        MoveCharacter(Direction.Up);
    }

    private enum  Direction
    {
        Left,
        Up,
        Down,
        Right,
    }
}

