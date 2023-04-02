namespace CoinCollectorGame;

public static class EndGamePortal
{    
    public static void EndGamePortalAppereance(object? sender, EndGameEventArgs args)
    {
        const char portalSign = '§';

        args.GameMap.AddFreeSpotSign(portalSign);

        (int row, int column) = args.GameMap.GetRandomFreeSpotCoordinates();

        args.GameMap.SetValueInCoordinates((row, column), portalSign);

        Console.SetCursorPosition(0, args.GameMap.Size.height + 1);
        Console.WriteLine($"You collected All Coins!!! Go to the End Portal '§'");
    }
}

