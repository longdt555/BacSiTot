using System.Collections.Generic;

namespace Lib.Repository.Dto
{
    public class SearchViewModel
    {
        public IEnumerable<DiseasesModel> Diseases { get; set; }
        public SearchModel Search { get; set; }
    }
}
