using System.Collections.Generic;
using Lib.Repository.Dto.Results;

namespace Lib.Repository.Dto
{
    public class HealthFacilityViewModel
    {
        public HealthFacilityModel HealthFacility { get; set; }
        public FacilityTypeModel FacilityType { get; set; }
        public ModelSearchResult<FacilityReviewModel> FacilityReviews { get; set; }
        public IEnumerable<DiseasesModel> Diseases { get; set; }
        public int TotalReviews { get; set; } = 0;
        public double AverageRating { get; set; }
        public int OneStar { get; set; }
        public int TwoStars { get; set; }
        public int ThreeStars { get; set; }
        public int FourStars { get; set; }
        public int FiveStars { get; set; }

        public SearchModel Search { get; set; }
    }
}