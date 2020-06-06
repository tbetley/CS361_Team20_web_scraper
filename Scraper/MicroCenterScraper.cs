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
    public class MicroCenterScraper : ISiteScraper
    {
        private String url;

        public MicroCenterScraper(string url)
        {
            this.url = url;
        }

        public void AddProductsToList(List<Product> list)
        {
            var html = url;
            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            HtmlNodeCollection nodes = htmlDoc.DocumentNode.SelectNodes("//li[contains(@class, 'product_wrapper')]");

            //generate "unique" (for this search) product ids with iterator
            int iterator = 0;
            foreach (HtmlNode node in nodes)
            {
                Product newProduct = new Product();
                newProduct.ProductID = iterator;

                HtmlNode nameDivNode = node.SelectSingleNode(".//div[contains(@class, 'result_right')]");
                HtmlNode detailsNode = nameDivNode.SelectSingleNode(".//div[contains(@class, 'details')]");
                HtmlNode DetailWrapperNode = detailsNode.SelectSingleNode(".//div[contains(@class, 'detail_wrapper')]");
                HtmlNode skuNode = DetailWrapperNode.SelectSingleNode(".//p[contains(@class, 'sku')]");
              
               
                nameDivNode = DetailWrapperNode.SelectSingleNode(".//div[contains(@class, 'pDescription')]");
                HtmlNode nameModelNode = nameDivNode.SelectSingleNode(".//div[contains(@class, 'normal')]");
                nameDivNode = nameModelNode.SelectSingleNode("./h2");
                HtmlNode nameNode = nameDivNode.SelectSingleNode("./a");

                newProduct.Name = nameDivNode.InnerText;
                String fullTitle = nameDivNode.InnerText;
                String[] word = fullTitle.Split(' ', StringSplitOptions.RemoveEmptyEntries);
         
                    newProduct.Brand = word[1];
                newProduct.Model = word[2];

                String detailsUrl = "https://www.microcenter.com/";
                newProduct.SiteUrl = detailsUrl + nameNode.GetAttributeValue("href", "");

                HtmlNode priceNode = detailsNode.SelectSingleNode(".//div[contains(@class, 'price_wrapper')]");
                priceNode = priceNode.SelectSingleNode(".//div[contains(@class, 'price')]");
                priceNode = priceNode.SelectSingleNode("./span");
                newProduct.Price = Decimal.Parse(priceNode.InnerText, NumberStyles.AllowCurrencySymbol | NumberStyles.Number);
                
                list.Add(newProduct);
                iterator++;
            }
        }

    }
}
