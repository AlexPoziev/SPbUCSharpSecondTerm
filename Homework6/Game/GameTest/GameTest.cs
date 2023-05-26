namespace GameTest;

using System.Data.Common;
using CoinCollectorGame;
using static CoinCollectorGame.MechanicsCore;

public class GameTest
{
    private readonly string resultTestsFilesPath = "../../../TestsResults/";

    private readonly string testsFilesPath = "../../../Tests/";

    private readonly string tempFileName = "tempTest.txt";

    [TestCase("CellTest.txt", 100, 100)]
    [TestCase("CellTest.txt", -1, -1)]
    [TestCase("PortalTest.txt", 5, 5)]
    public void MainCharacterCoordinatesOutOfRangeOfMapShouldThrowsCharacterStateException(string testMapFileName, int row, int column)
    {
        Assert.Throws<CharacterStateException>(() => new Game(testsFilesPath + testMapFileName, (row, column)));
    }

    [TestCase("CellTest.txt", 0, 0)]
    [TestCase("CellTest.txt", 4, 8)]
    [TestCase("PortalTest.txt", 0, 0)]
    public void MainCharacterCoordinatesOnNotFreePointOfMapShouldThrowsCharacterStateException(string testMapFileName, int row, int column)
    {
        Assert.Throws<CharacterStateException>(() => new Game(testsFilesPath + testMapFileName, (row, column)));
    }

    [Test]
    public void CreatingGameWithMapThatHasLessThanTwoFreePointShouldThrowsInvalidMapException()
    {
        string fileName = "NotEnoughSpaceTest.txt";

        Assert.Throws<InvalidMapException>(() => new Game(testsFilesPath + fileName));
    }

    [TestCase("CellTest.txt", "CellMoveLeftTestResult.txt", 2, 4, Move.Direction.Left)]
    [TestCase("CellTest.txt", "CellMoveRightTestResult.txt", 2, 4, Move.Direction.Right)]
    [TestCase("CellTest.txt", "CellMoveUpTestResult.txt", 2, 4, Move.Direction.Up)]
    [TestCase("CellTest.txt", "CellMoveDownTestResult.txt", 2, 4, Move.Direction.Down)]
    [TestCase("NoWallTest.txt", "MoveInNoWallTestResult.txt", 2, 8, Move.Direction.Right)]
    [TestCase("CellTest.txt", "CellMoveInWallTest.txt", 2, 1, Move.Direction.Left)]
    [TestCase("PortalTest.txt", "PortalTestResult.txt", 2, 3, Move.Direction.Left)]
    public void MoveShouldAppearExpectedResult(string fileName, string fileNameWithExpectedResult, int row, int column, Move.Direction direction)
    {
        var game = new Game(testsFilesPath + fileName, (row, column), false);

        game.Core.Movement.MoveCharacter(direction);

        game.GameMap.WriteMapInFile(tempFileName);

        var actualResult = File.ReadAllLines(tempFileName);

        File.Delete(tempFileName);

        Assert.That(actualResult, Is.EqualTo(File.ReadAllLines(resultTestsFilesPath + fileNameWithExpectedResult)));
    }

    [Test]
    public void MoveOnCoinShouldBePossibleAndCreateNewOne()
    {
        var testFileName = "CoinTest.txt";
        var testResultFileName = "CoinTestResult.txt";
        var startingCoordinates = (2, 2);

        var game = new Game(testsFilesPath + testFileName, startingCoordinates, true);

        game.Core.Movement.MoveCharacter(Move.Direction.Left);

        game.GameMap.WriteMapInFile(tempFileName);

        var actualResult = File.ReadAllLines(tempFileName);

        File.Delete(tempFileName);

        Assert.That(actualResult, Is.EqualTo(File.ReadAllLines(resultTestsFilesPath + testResultFileName)));
    }
}
