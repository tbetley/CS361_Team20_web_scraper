using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using web_scraper.Models;

namespace web_scraper.Scraper
{
    /**
     * has been tested against:
     * https://store.acer.com/en-us/laptops?product_list_limit=25
     * https://store.acer.com/en-us/desktops?product_list_limit=25
     * */
    public class AcerStoreScraper : ISiteScraper
    {
        private String url;

        public AcerStoreScraper(String url)
        {
            this.url = url;
        }
        public void AddProductsToList(List<Product> list)
        {
            var html = url;
            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            //one div with class 'product-item-details' per product

            HtmlNodeCollection nodes = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'product-item-details')]");

            //generate "unique" (for this search) product ids with iterator
            int iterator = 0;
            foreach (HtmlNode node in nodes)
            {
                Product newProduct = new Product();
                newProduct.ProductID = iterator;

                HtmlNode linkNode = node.SelectSingleNode(".//a[contains(@class, 'product-item-link')]");
                newProduct.Name = linkNode.InnerText;
                newProduct.SiteUrl = linkNode.GetAttributeValue("href", url);

                newProduct.Brand = "Acer";
                HtmlNode partNumberNode = node.SelectSingleNode(".//div[contains(@class, 'product-code')]");
                HtmlNode modelNode = partNumberNode.SelectSingleNode(".//span");
                newProduct.Model = modelNode.InnerText;

                HtmlNode priceSpan = node.SelectSingleNode(".//span[contains(@class, 'weee') and contains(@class, 'price-final_price')]");
                HtmlNode priceNode = priceSpan.SelectSingleNode(".//span[contains(@class, 'price')]");
                newProduct.Price = Decimal.Parse(priceNode.InnerText, NumberStyles.AllowCurrencySymbol | NumberStyles.Number);

                list.Add(newProduct);
                iterator++;
            }
        }
    }
}
