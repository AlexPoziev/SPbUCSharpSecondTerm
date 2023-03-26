namespace RoutersTest;

using Routers;

public class RouterTests
{
    [TestCase("BlanksOnly.txt")]
    [TestCase("Empty.txt")]
    [TestCase("NegativeBandwidth.txt")]
    [TestCase("NegativeNodeNumber.txt")]
    [TestCase("NoClosingParenthesis.txt")]
    [TestCase("NoColon.txt")]
    [TestCase("NoComma.txt")]
    [TestCase("NoOpeningParenthesis.txt")]
    [TestCase("NotANumber.txt")]
    [TestCase("NotFullTopology.txt")]
    [TestCase("RouterConnectWithItself.txt")]
    public static void ConfigurationOfIncorrectTopologyShouldThrowIncorrectTopologyFormException(string fileName)
    {
        var topology = File.ReadAllLines("../../../TestFiles/" + fileName);

        Assert.Throws<IncorrectFormException>(() => ConfigurationGenerator.Configurate(topology));
    }

    [Test]
    public static void ConfigurationOfNullShouldThrowArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => ConfigurationGenerator.Configurate(null));
    }

    [TestCase("BasicCorrectTest.txt", "BasicCorrectTestResult.txt")]
    [TestCase("ComplicatedCorrectTest.txt", "ComplicatedCorrectTestResult.txt")]
    [TestCase("SingleRouterTest.txt", "SingleRouterTest.txt")]
    public static void ConfigurationWithCorrectDataShouldReturnExpectedResult(string entryFile, string expectedFile)
    {
        var topology = File.ReadAllLines("../../../TestFiles/" + entryFile);
        var expectedResult = File.ReadAllLines("../../../TestFiles/" + expectedFile);

        Assert.That(ConfigurationGenerator.Configurate(topology), Is.EqualTo(expectedResult));
    }

    [TestCase("DisconnectedGraph.txt")]
    [TestCase("DisconnectedGraphWithoutConnections.txt")]
    public static void ConfigurationOfDisconnectedGraphShouldThrowDisconnectedGraphException(string fileName)
    {
        var topology = File.ReadAllLines("../../../TestFiles/" + fileName);

        Assert.Throws<DisconnectedGraphException>(() => ConfigurationGenerator.Configurate(topology));
    }
}
