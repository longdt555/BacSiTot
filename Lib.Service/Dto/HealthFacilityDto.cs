using Lib.Data.Entity;

namespace Lib.Repository.Dto
{
    public class HealthFacilityDto
    {
        public HealthFacilityModel HealthFacility { get; set; }
        public int TotalReviews { get; set; } = 0;
        public double AverageRating { get; set; }
        public int OneStar { get; set; }
        public int TwoStars { get; set; }
        public int ThreeStars { get; set; }
        public int FourStars { get; set; }
        public int FiveStars { get; set; }
    }
}