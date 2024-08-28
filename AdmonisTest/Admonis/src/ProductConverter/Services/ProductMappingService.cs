using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdmonisTest.Admonis
{
    public class ProductMappingService : IProductMappingService
    {
        public List<AdmonisProduct> MapProducts(XDocument xmlDoc)
        {
            var products = new List<AdmonisProduct>();
            var productElements = xmlDoc.Descendants("product").Where(p => p.Element("variants") != null);

            foreach (var productElement in productElements)
            {
                var product = new AdmonisProduct
                {
                    CustomerID = int.Parse(productElement.Attribute("product-id")?.Value.Split('-')[0] ?? "0"),
                    Name = productElement.Element("display-name")?.Value,
                    Description = productElement.Element("short-description")?.Value,
                    DescriptionLong = productElement.Element("long-description")?.Value,
                    Brand = productElement.Element("brand")?.Value,
                    VideoLink = productElement.Element("custom-attribute")?.Elements()
                        .FirstOrDefault(e => e.Attribute("attribute-id")?.Value == "F54ProductVideo")?.Value
                };

                MapProductOptions(product, xmlDoc, productElement);
                products.Add(product);
            }

            return products;
        }

        private void MapProductOptions(AdmonisProduct product, XDocument xmlDoc, XElement productElement)
        {
            var variantIds = productElement.Element("variants")?.Elements("variant")
                .Select(v => v.Attribute("product-id")?.Value)
                .Where(id => !string.IsNullOrEmpty(id))
                .ToList();

            if (variantIds == null || !variantIds.Any()) return;

            var variantProducts = xmlDoc.Descendants("product")
                .Where(p => variantIds.Contains(p.Attribute("product-id")?.Value));

            foreach (var variantProduct in variantProducts)
            {
                var option = new AdmonisProductOption
                {
                    optionSugName1 = "צבע",
                    optionSugName1Title = "בחר צבע",
                    optionSugName2 = variantProduct.Elements("custom-attribute")
                        .FirstOrDefault(e => e.Attribute("attribute-id")?.Value == "f54ProductColor")?.Value,
                    optionSugName2Title = "בחר מידה",
                    optionMakat = variantProduct.Attribute("product-id")?.Value,
                    optionName = variantProduct.Elements("custom-attribute")
                        .FirstOrDefault(e => e.Attribute("attribute-id")?.Value == "f54ProductSize")?.Value,
                    optionPrice_Publish = 0 // Default value, adjust if needed
                };

                product.Options.Add(option);
            }
        }
    }
}
