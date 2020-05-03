using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_scraper.Data
{
    public interface ITvRepository
    {
        IEnumerable<Tv> AllTv { get; }

        Tv GetTvById(int tvId);
    }
}
