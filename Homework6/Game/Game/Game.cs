namespace CoinCollectorGame;

public class Game
{
    private readonly Map map;

    private (int row, int column) currentCoordinates;

    private CursorValueChanger cursor = new CursorValueChanger();

    public Game(string fileName)
    {
        if (!File.Exists(fileName))
        {
            throw new ArgumentException("File doensn't exist", nameof(fileName));
        }

        var content = File.ReadAllLines(fileName);

        map = new Map(content);

        var (first, second) = map.GetRandomFreeSpotCoordinates();

        map.SetValueInCoordinates((first, second), '@');
        currentCoordinates = (first, second);

        map.PrintMap();

        cursor.Subscribe(map);
    }

    private void MoveCharacter(Direction direction)
    {
        var newCoordinates = TakeCoordinatesAfterDirectionMove(direction);

        if (!map.IsInMapRange(newCoordinates))
        {
            return;
        }

        map.SetValueInCoordinates((currentCoordinates.row, currentCoordinates.column), ' ');
        map.SetValueInCoordinates((newCoordinates.row, newCoordinates.column), '@');
    }

    private (int row, int column) TakeCoordinatesAfterDirectionMove(Direction direction) =>
        direction switch
        {
            Direction.Left => (currentCoordinates.row, currentCoordinates.column - 1),
            Direction.Up => (currentCoordinates.row + 1, currentCoordinates.column),
            Direction.Down => (currentCoordinates.row - 1, currentCoordinates.column),
            Direction.Right => (currentCoordinates.row, currentCoordinates.column + 1),
            _ => throw new ArgumentException("Not direction"),
        };

    public void OnLeft(object sender, EventArgs args)
    {
        MoveCharacter(Direction.Left);
    }

    public void OnRight(object sender, EventArgs args)
    {
        MoveCharacter(Direction.Right);
    }

    public void OnDown(object sender, EventArgs args)
    {
        MoveCharacter(Direction.Down);
    }

    public void OnUp(object sender, EventArgs args)
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

