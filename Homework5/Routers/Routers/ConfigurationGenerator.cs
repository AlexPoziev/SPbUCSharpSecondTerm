namespace Routers;

public class ConfigurationGenerator
{
    public void Configurate(string filePath, string newFilePath)
    {
        if (!File.Exists(filePath))
        {
            throw new ArgumentException("File doesn't exists");
        }

        var links = new List<Link>();

        var topology = File.ReadAllLines(filePath);

        for (int i = 0; i < topology.Length; ++i)
        {
            var currentNumberOfRouter = topology[i][0];

            var currentSubstring = topology[i][2..].Split('.');
            
        }
    }

    private List<Link> SplitTopology(string[] topology)
    {
        if (topology == null)
        {
            throw new ArgumentNullException(nameof(topology));
        }

        var links = new List<Link>();

        for (int i = 0; i < topology.Length; ++i)
        {
            var currentIndex = 0;
            var firstNodeNumber = StringParseUtils.TryGetNumberUntilSign(':', ref currentIndex, topology[i]);

            var currentLinksSubstrings = topology[i][(currentIndex + 1)..].Split(',');

            for (int j = 0; j < currentLinksSubstrings.Length; ++j)
            {
                currentIndex = 0;

                if (currentLinksSubstrings[j][currentIndex] != ' ')
                {
                    throw new IncorrectTopologyFormException("Not enough space after ':' or ','");
                }

                ++currentIndex;

                StringParseUtils.TryGetNumberUntilSign(' ', ref currentIndex, currentLinksSubstrings[j]);

            }
        }

        return links;
    }
}

