using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_scraper.Models;

namespace web_scraper.Scraper
{
    public static class Scraper
    {

        public static List<Product> SearchByCategory(Category searchCategory)
        {
            List<Product> list = new List<Product>();
            foreach (ISiteScraper scraper in searchCategory.sites)
            {
                scraper.AddProductsToList(list);
                /*
                for(int i = 0; i < 3; i++)
                {
                    list.Add(new Product
                    {
                        ProductID = idCounter,
                        Name = String.Format("product{0}", idCounter),
                        Model = "anything",
                        Brand = "Maker Company",
                        Price = (decimal)(idCounter + 0.99),
                        ImageUrl = String.Format("{0}/pic.png", url),
                        SiteUrl = url
                    });
                    idCounter++;
                }
                */

            }

            return list;
        }
    }


}