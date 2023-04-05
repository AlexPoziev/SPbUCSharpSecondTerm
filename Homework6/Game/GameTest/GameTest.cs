namespace GameTest;

using CoinCollectorGame;

public class GameTest
{
    private string resultTestsFilesPath = "../../../TestsResults/";

    private string testsFilesPath = "../../../Tests/";

    [TestCase("CellTest.txt", 100, 100)]
    [TestCase("CellTest.txt", -1, -1)]
    [TestCase("PortalTest.txt", 5, 5)]
    public void MainCharacterCoordinatesOutOfRangeOfMapShouldThrowsCharacterStateException(string testMapFileName, int row, int column)
    {
        Assert.Throws<CharacterStateException>(() => new Game(testsFilesPath + testMapFileName, (row, column)));
    }

    [TestCase("CellTest.txt", 0, 0)]
    [TestCase("CellTest.txt", 4, 8)]
    [TestCase("PortalTest.txt", , 5)]
    public void MainCharacterCoordinatesOutOfRangeOfMapShouldThrowsCharacterStateException(string testMapFileName, int row, int column)
    {
        Assert.Throws<CharacterStateException>(() => new Game(testsFilesPath + testMapFileName, (row, column)));
    }
}
