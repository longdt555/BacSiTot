using System.Collections.Generic;
using Lib.Data.Entity;
using Lib.Repository.Dto.Results;

namespace Lib.Repository.Dto
{
    public class HealthFacilityDto
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
    }
}