using System.IO;
using System.Xml.Linq;
using Xunit;

namespace AdmonisTest.Admonis
{
    public class XmlParserServiceTests
    {
        [Fact]
        public void ParseXmlFile_ValidFile_ReturnsXDocument()
        {
            var service = new XmlParserService();
            var result = service.ParseXmlFile("testdata/valid.xml");
            Assert.NotNull(result);
            Assert.IsType<XDocument>(result);
        }

        [Fact]
        public void ParseXmlFile_InvalidFile_ThrowsException()
        {
            var service = new XmlParserService();
            Assert.Throws<FileNotFoundException>(() => service.ParseXmlFile("nonexistent.xml"));
        }
    }
}
