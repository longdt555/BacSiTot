using Lib.Data.Entity;

namespace Lib.Repository.Dto
{
    public class FacilityTypeDto : BaseImpactDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int FacilityClassificationId { get; set; } // 0: hospital, 1= clinic, 2= medical service facility
        public string FacilityClassificationName =>
            FacilityClassificationId is 1 ? "Bệnh viện" :
            FacilityClassificationId is 2 ? "Phòng khám" :
            FacilityClassificationId is 3 ? "Cơ sở Dịch vụ Y tế" : "Không xác định";
    }
}
