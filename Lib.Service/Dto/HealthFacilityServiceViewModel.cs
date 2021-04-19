namespace Lib.Repository.Dto
{
    public class HealthFacilityServiceViewModel:BaseImpactModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DiseasesModel DiseasesModel { get; set; }
    }
}