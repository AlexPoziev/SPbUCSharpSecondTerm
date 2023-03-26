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
    [TestCase("NoOpenningParenthesis.txt")]
    [TestCase("NotANumber.txt")]
    [TestCase("NotFullTopology.txt")]
    [TestCase("RouterConnectWithItself.txt")]
    public static void ConfigurationOfIncorrectTopologyShouldThrowIncorrectTopologyFormException(string fileName)
    {
        var topology = File.ReadAllLines("../../../TestFiles/" + fileName);

        Assert.Throws<IncorrectTopologyFormException>(() => ConfigurationGenerator.Configurate(topology));
    }

}
