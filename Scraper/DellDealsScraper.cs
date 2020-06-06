using HtmlAgilityPack;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using web_scraper.Models;

namespace web_scraper.Scraper
{
    /**
     * Has been tested against:
     * http://deals.dell.com/en-us/category/laptops
     * http://deals.dell.com/en-us/category/desktops
     * */
    public class DellDealsScraper : ISiteScraper
    {
        private String url;

        public DellDealsScraper(string url)
        {
            this.url = url;
        }

        public void AddProductsToList(List<Product> list)
        {
            var html = url;
            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            HtmlNodeCollection nodes = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'deal-column') and contains(@class, 'has-tech-specs')]");

            //generate "unique" (for this search) product ids with iterator
            int iterator = 0;
            foreach(HtmlNode node in nodes)
            {
                Product newProduct = new Product();
                newProduct.ProductID = iterator;

                HtmlNode nameDivNode = node.SelectSingleNode(".//div[contains(@class, 'title-wrapper')]");
                HtmlNode nameNode = nameDivNode.SelectSingleNode("./a");
                newProduct.Name = nameDivNode.InnerText.Replace("New ", "");

                newProduct.Brand = "Dell";

                HtmlNode totalPriceNode = node.SelectSingleNode(".//div[contains(@class, 'total-price')]");
                HtmlNode priceNode = totalPriceNode.SelectNodes(".//span")[1];
                String[] modelWords = newProduct.Name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (modelWords.Length >= 3)
                {
                    newProduct.Model = modelWords[1] + " " + modelWords[2];
                }
                else
                {
                    newProduct.Model = "n/a";
                }
                newProduct.Price = Decimal.Parse(priceNode.InnerText, NumberStyles.AllowCurrencySymbol | NumberStyles.Number);

                String detailsUrl = "http://deals.dell.com";
                newProduct.SiteUrl = detailsUrl + nameNode.GetAttributeValue("href", "");

                list.Add(newProduct);
                iterator++;
            }
        }

    }
}
