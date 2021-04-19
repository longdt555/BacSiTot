using System.Collections.Generic;

namespace Lib.Repository.Dto
{
    public class HomeViewModel
    {
        public double TotalReviews { get; set; }
        public double TotalHealthFacility { get; set; }
        public IEnumerable<FacilityReviewModel> FacilityReviewModels { get; set; }
        public IEnumerable<HealthFacilityViewModel> TopGeneralHospital { get; set; }
        public IEnumerable<HealthFacilityViewModel> TopMedicalClinic { get; set; }
        public IEnumerable<HealthFacilityViewModel> TopOrientalMedicineClinic { get; set; }
        public SearchModel Search { get; set; }
    }
}
