using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace web_scraper.Data
{
    public class TvRepository : ITvRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public TvRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Tv> AllTv
        {
            get
            {
                return _applicationDbContext.Tv.Include(c => c.Category);
            }
        }

        public Tv GetTvById(int tvId)
        {
            return _applicationDbContext.Tv.FirstOrDefault(p => p.TvId == tvId);
        }
    }
}
