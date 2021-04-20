namespace Lib.Repository.Dto
{
    public class FacilityTypeDto : BaseImpactDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int FacilityClassificationId { get; set; } // 0: hospital, 1= clinic, 2= medical service facility
        public string FacilityClassificationName =>
            FacilityClassificationId == 1 ? "Bệnh viện" :
            FacilityClassificationId == 2 ? "Phòng khám" :
            FacilityClassificationId == 3 ? "Cơ sở Dịch vụ Y tế" : "Không xác định";
    }
}
