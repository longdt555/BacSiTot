using Lib.Data.Entity;

namespace Lib.Repository.Dto
{
    public class HealthFacilityServiceDto:BaseImpactModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DiseasesModel DiseasesModel { get; set; }
    }
}