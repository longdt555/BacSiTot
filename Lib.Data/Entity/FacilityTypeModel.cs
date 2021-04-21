using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Data.Entity
{
    [Table("FacilityType")]
    public class FacilityTypeModel : BaseImpactModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string FacilityClassificationId { get; set; } //  hospital, clinic,medical service facility
        public virtual IEnumerable<HealthFacilityTypeModel> HealthFacilityTypes { get; set; }

    }
}