﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_scraper.Data
{
    public class Tv
    {
        public int TvId { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string ImageThumbnailUrl { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
