using AdmonisTest.Admonis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmonisTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var xmlParserService = new XmlParserService();
            var productMappingService = new ProductMappingService();

            var xmlDoc = xmlParserService.ParseXmlFile("data/Product.xml");
            var products = productMappingService.MapProducts(xmlDoc);

            // Output or further processing of the mapped products
            foreach (var product in products)
            {
                Console.WriteLine($"Product: {product.Name}");
                Console.WriteLine($"Options: {product.Options.Count}");
                Console.WriteLine();
            }
        }
    }
}
