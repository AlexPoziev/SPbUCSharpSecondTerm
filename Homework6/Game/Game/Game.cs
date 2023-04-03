namespace CoinCollectorGame;

public class Game
{
    readonly EventLoop looper;

    private Map GameMap { get; }

    private MechanicsCore core;

    public Game(string fileName)
    {
        if (!File.Exists(fileName))
        {
            throw new ArgumentException("File doesn't exist", nameof(fileName));
        }

        var content = File.ReadAllLines(fileName);

        GameMap = new Map(content);

        looper = new();

        core = new(GameMap);

        core.EntryGameOverPortal += Stop;
    }

    public void Launch()
    {
        looper.LeftHandler += core.OnLeft;
        looper.RightHandler += core.OnRight;
        looper.UpHandler += core.OnUp;
        looper.DownHandler += core.OnDown;

        looper.Run();
    }

    private void Stop(object? sender, EventArgs args)
    {
        looper.LeftHandler -= core.OnLeft;
        looper.RightHandler -= core.OnRight;
        looper.UpHandler -= core.OnUp;
        looper.DownHandler -= core.OnDown;

        Console.Clear();

        Console.WriteLine("""
            Congratulations!!!
            You managed to get out of a scary two-dimensional location.

            To exit, press ESCAPE key.
            """);
    }
}