using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Data.Entity
{
    [Table("HealthFacility")]
    public class HealthFacilityModel : BaseModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Commune { get; set; } // phường, xã
        public string LogoUrl { get; set; }
        public string BannerUrl { get; set; }
        public string ThumbnailImageUrl { get; set; }
        public string Website { get; set; }
        public string PhoneNumber { get; set; }
        public string FanPage { get; set; }
        public string Description { get; set; }
        public string Bio { get; set; }
        public string WorkingTime { get; set; }
        public virtual IEnumerable<FacilityReviewModel> FacilityReviews { get; set; }
        public virtual IEnumerable<HealthFacilityServiceModel> HealthFacilityServices { get; set; }
        public virtual IEnumerable<HealthFacilityTypeModel> HealthFacilityTypes { get; set; }
    }
}