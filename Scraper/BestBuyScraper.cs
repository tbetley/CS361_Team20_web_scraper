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
     * Has been tested against:
     * http://bestbuy.com/site/tvs/all-flat-screen-tvs/abcat0101001.c?id=abcat0101001
     * http://www.bestbuy.com/site/laptop-computers/all-laptops/pcmcat138500050001.c?id=pcmcat138500050001
     * */
    public class BestBuyScraper : ISiteScraper
    {
        private String url;

        public BestBuyScraper(String url)
        {
            this.url = url;
        }

        public void AddProductsToList(List<Product> list)
        {
            var html = url;
            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            HtmlNodeCollection nodes = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'shop-sku-list-item')]");

            foreach (HtmlNode node in nodes)
            {
                Product newProduct = new Product();

                HtmlNode nameDivNode = node.SelectSingleNode(".//h4[contains(@class, 'sku-header')]");
                HtmlNode nameNode = nameDivNode.SelectSingleNode("./a");
                //products end up with names like "Brand - Name - More - Details"
                String fullTitle = System.Net.WebUtility.HtmlDecode(nameDivNode.InnerText);
                newProduct.Name = fullTitle.Replace("New!", "");
                newProduct.Brand = fullTitle.Split(" - ")[0].Replace("New!", "");

                HtmlNode totalPriceNode = node.SelectSingleNode(".//div[contains(@class, 'priceView-hero-price') and contains(@class, 'priceView-customer-price')]");
                HtmlNode priceNode = totalPriceNode.SelectSingleNode(".//span");
                newProduct.Price = Decimal.Parse(priceNode.InnerText, NumberStyles.AllowCurrencySymbol | NumberStyles.Number);

                HtmlNode skuModelNode = node.SelectSingleNode(".//div[contains(@class, 'sku-model')]");
                HtmlNode modelNode = skuModelNode.SelectSingleNode(".//span[contains(@class, 'sku-value')]");
                newProduct.Model = modelNode.InnerText;



                String detailsUrl = "http://bestbuy.com";
                newProduct.SiteUrl = detailsUrl + nameNode.GetAttributeValue("href", "");

                list.Add(newProduct);
            }

        }
    }
}
