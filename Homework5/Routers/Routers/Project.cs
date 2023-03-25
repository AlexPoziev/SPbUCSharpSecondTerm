using Routers;

var testString = File.ReadAllLines("./test.txt");
var test = new ConfigurationGenerator();

File.WriteAllLines("./testResult.txt", test.Configurate(testString));