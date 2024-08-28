using AdmonisTest.Admonis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdmonisTest.Admonis
{
    public interface IXmlParserService
    {
        XDocument ParseXmlFile(string filePath);
    }
}
