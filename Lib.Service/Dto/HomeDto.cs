using System.Collections.Generic;
using Lib.Data.Entity;

namespace Lib.Repository.Dto
{
    public class HomeDto
    {
        public double TotalReviews { get; set; }
        public double TotalHealthFacility { get; set; }
        public IEnumerable<FacilityReviewModel> FacilityReviewModels { get; set; }
        public IEnumerable<HealthFacilityDto> TopGeneralHospital { get; set; }
        public IEnumerable<HealthFacilityDto> TopMedicalClinic { get; set; }
        public IEnumerable<HealthFacilityDto> TopOrientalMedicineClinic { get; set; }
    }
}
