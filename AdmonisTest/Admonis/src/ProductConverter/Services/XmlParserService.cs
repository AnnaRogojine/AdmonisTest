using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdmonisTest.Admonis
{
    public class XmlParserService : IXmlParserService
    {
        public XDocument ParseXmlFile(string filePath)
        {
            return XDocument.Load(filePath);
        }
    }
}
