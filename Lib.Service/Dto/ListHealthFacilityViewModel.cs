using System.Collections.Generic;

namespace Lib.Repository.Dto
{
    public class ListHealthFacilityViewModel
    {
        public ListHealthFacilityViewModel()
        {
            HeathFacilityList = new List<HealthFacilityViewModel>();
        }
        public List<HealthFacilityViewModel> HeathFacilityList { get; set; }
        public SearchModel Search { get; set; }
        public double TotalCount { get; set; }
    }
}