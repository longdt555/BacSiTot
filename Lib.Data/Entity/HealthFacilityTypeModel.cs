using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Data.Entity
{
    [Table("HealthFacilityType")]
    public class HealthFacilityTypeModel:BaseImpactModel
    {
        public Guid HealthFacilityId { get; set; }

        [ForeignKey("HealthFacilityId")]
        public virtual HealthFacilityModel HealthFacility { get; set; }

        public Guid FacilityTypeId { get; set; }

        [ForeignKey("FacilityTypeId")]
        public virtual FacilityTypeModel FacilityType { get; set; }
    }
}
