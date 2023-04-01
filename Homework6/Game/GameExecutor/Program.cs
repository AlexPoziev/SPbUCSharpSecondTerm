using CoinCollectorGame;

var eventLoop = new EventLoop();
var game = new Game(args[0]);

eventLoop.LeftHandler += game.OnLeft;
eventLoop.RightHandler += game.OnRight;
eventLoop.UpHandler += game.OnUp;
eventLoop.DownHandler += game.OnDown;

eventLoop.Run();
