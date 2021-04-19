using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Data.Entity
{
    [Table("HealthFacilityService")]
    public class HealthFacilityServiceModel : BaseImpactModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid HealthFacilityId { get; set; }
        [ForeignKey("HealthFacilityId")]
        public virtual HealthFacilityModel HealthFacility { get; set; }

        public Guid DiseasesId { get; set; }
        [ForeignKey("DiseasesId")]
        public virtual DiseasesModel Diseases { get; set; }
    }
}