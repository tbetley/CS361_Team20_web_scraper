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
     * https://www.newegg.com/p/pl?N=100019096%204814
     * */
    public class NewEggScraper : ISiteScraper
    {
        private String url;

        public NewEggScraper(String url)
        {
            this.url = url;
        }
        public void AddProductsToList(List<Product> list)
        {
            var html = url;
            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            //one div with class 'item-container' per product

            HtmlNodeCollection nodes = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'item-container')]");

            foreach (HtmlNode node in nodes)
            {
                Product newProduct = new Product();

                HtmlNode linkNode = node.SelectSingleNode(".//a[contains(@class, 'item-img')]");
                newProduct.SiteUrl = linkNode.GetAttributeValue("href", url);

                var htmlDetails = newProduct.SiteUrl;
                var htmlDetailsDoc = web.Load(htmlDetails);

                HtmlNode specsNode = htmlDetailsDoc.DocumentNode.SelectSingleNode(".//div[contains(@id, 'Specs')]");

                if(specsNode != null)
                {
                    HtmlNode brandNode = specsNode.SelectSingleNode(".//dd");
                    newProduct.Brand = brandNode.InnerText;

                    HtmlNode nameNode = specsNode.SelectNodes(".//dd")[2];
                    newProduct.Brand = nameNode.InnerText;


                }
                else
                {
                    newProduct.Name = "foo";
                    newProduct.Brand = "nah";
                }

                newProduct.Model = "a";
                newProduct.Price = 2.4M;
                /*
                newProduct.Brand = "Acer";
                HtmlNode partNumberNode = node.SelectSingleNode(".//div[contains(@class, 'product-code')]");
                HtmlNode modelNode = partNumberNode.SelectSingleNode(".//span");
                newProduct.Model = modelNode.InnerText;
                HtmlNode priceNode = node.SelectSingleNode(".//span[@data-price-type='finalPrice']");
                if (priceNode != null)
                {
                    newProduct.Price = Decimal.Parse(priceNode.InnerText, NumberStyles.AllowCurrencySymbol | NumberStyles.Number);
                }
                else
                {
                    newProduct.Price = 0.0M;
                }
                */

                list.Add(newProduct);
            }
        }
    }
}
