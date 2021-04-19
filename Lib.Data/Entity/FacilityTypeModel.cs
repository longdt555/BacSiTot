using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Data.Entity
{
    [Table("FacilityType")]
    public class FacilityTypeModel : BaseImpactModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int FacilityClassificationId { get; set; } // 0: hospital, 1= clinic, 2= medical service facility
        public virtual IEnumerable<HealthFacilityTypeModel> HealthFacilityTypes { get; set; }

    }
}