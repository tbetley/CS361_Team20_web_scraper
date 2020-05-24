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
     * tested against
     * https://americanbarbell.com/collections/olympic-bars
     * */
    public class AmericanBarbellScraper : ISiteScraper
    {
        private String url;

        public AmericanBarbellScraper(String url)
        {
            this.url = url;
        }

        public void AddProductsToList(List<Product> list)
        {
            var html = url;
            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            //one div with class 'product-details' per product

            HtmlNodeCollection nodes = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'product-details')]");

            foreach (HtmlNode node in nodes)
            {
                Product newProduct = new Product();

                HtmlNode linkNode = node.SelectSingleNode(".//a[contains(@class, 'product-title')]");
                newProduct.Name = linkNode.InnerText;
                String baseUrl = "http://americanbarbell.com";
                newProduct.SiteUrl = baseUrl + linkNode.GetAttributeValue("href", url);

                newProduct.Brand = "American Barbell";
                newProduct.Model = "n/a";

                HtmlNode priceDiv = node.SelectSingleNode(".//div[contains(@class, 'price-regular')]");
                HtmlNode priceSpan = priceDiv.SelectSingleNode(".//span");
                newProduct.Price = Decimal.Parse(priceSpan.InnerText, NumberStyles.AllowCurrencySymbol | NumberStyles.Number);

                list.Add(newProduct);
            }
        }
    }
}
