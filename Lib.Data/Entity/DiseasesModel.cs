using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Data.Entity
{
    [Table("Diseases")]
    public class DiseasesModel : BaseImpactModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<HealthFacilityServiceModel> HealthFacilityServices { get; set; }
    }
}