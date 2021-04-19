using Lib.Data.Entity;

namespace Lib.Repository.Dto
{
    public class HealthFacilityReviewsDto : BaseImpactDto
    {
        public HealthFacilityModel HealthFacility { get; set; }
        public FacilityReviewModel FacilityReview { get; set; } = new FacilityReviewModel();
        public decimal AverageRating { get; set; }
        public int TotalReviews { get; set; } = 0;
    }
}