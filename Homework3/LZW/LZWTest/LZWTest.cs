namespace LZWTest;

using LZW;

public class Tests
{
    [TestCase("../../../testFiles/bible.txt")]
    [TestCase("../../../testFiles/BinFile.bin")]
    [TestCase("../../../testFiles/consoleBuild.sh")]
    [TestCase("../../../testFiles/document.tex")]
    [TestCase("../../../testFiles/hh7.golden.exe")]
    [TestCase("../../../testFiles/pdfTest.pdf")]
    [TestCase("../../../testFiles/VerbsEnglish.xlsx")]
    public void FileAfterCompressAndDecompressShouldBeTheSame(string filePath)
    {
        var expectedResult = File.ReadAllBytes(filePath);

        LZWArchiver.Compress(filePath);
        LZWArchiver.Decompress(filePath + ".zipped");

        var actualResult = File.ReadAllBytes(filePath);
        File.Delete(filePath + ".zipped");

        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    [Test]
    public void EmptyFileCompressShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => LZWArchiver.Compress("../../../testFiles/empty.txt"));
    }

    [Test]
    public void EmptyFileDecompressShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => LZWArchiver.Decompress("../../../testFiles/empty.txt"));
    }

    [Test]
    public void NotExistsFileCompressShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => LZWArchiver.Compress("../../../testFiles/exist"));
    }

    [Test]
    public void NotExistsFileDecompressShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => LZWArchiver.Decompress("../../../testFiles/exist"));
    }
}
