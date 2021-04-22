using System.Collections.Generic;

namespace Lib.Repository.Dto.Results
{
    public class ModelSearchResult<T>
    {
        public IEnumerable<T> Data { get; set; }

        public int TotalCount { get; set; }

        public int CurrentPage { get; set; }
    }
}