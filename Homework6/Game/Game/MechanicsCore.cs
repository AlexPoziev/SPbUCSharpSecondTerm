namespace CoinCollectorGame;

public class MechanicsCore
{
    public event EventHandler<CollectCoinEventArgs> OnCoinCollect = (sender, args) => { };

    public event EventHandler<EventArgs> EntryOverGamePortal = (sender, args) => { };

    public Map Map { get; }

    private (int row, int column) currentCoordinates;

    private readonly Coins coins;

    public MechanicsCore(Map map)
    {
        if (map == null)
        {
            throw new ArgumentNullException(nameof(map));
        }

        Map = map;

        var (first, second) = Map.GetRandomFreeSpotCoordinates();


        Map.SetValueInCoordinates((first, second), '@');
        currentCoordinates = (first, second);

        Map.PrintMap();

        CursorValueChanger.Subscribe(Map);

        coins = new(Map);
        coins.AfterAllCoinsCollectEvent += EndGamePortal.EndGamePortalAppereance;
        coins.Subscribe(this);
        OnCoinCollect(this, new CollectCoinEventArgs(currentCoordinates));
    }

    private void MoveCharacter(Direction direction)
    {
        var newCoordinates = TakeCoordinatesAfterDirectionMove(direction);

        if (!Map.IsFreeSpot(newCoordinates))
        {
            return;
        }

        Map.SetValueInCoordinates((currentCoordinates.row, currentCoordinates.column), ' ');
        currentCoordinates = newCoordinates;
        var oldElement = Map.SetValueInCoordinates((newCoordinates.row, newCoordinates.column), '@');

        if (oldElement == 'o')
        {
            OnCoinCollect(this, new CollectCoinEventArgs(currentCoordinates));
        }

        if (oldElement == '§')
        {
            EntryOverGamePortal(this, EventArgs.Empty);
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

