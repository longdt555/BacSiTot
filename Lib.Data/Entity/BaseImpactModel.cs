using System;
using System.ComponentModel.DataAnnotations;

namespace Lib.Data.Entity
{
    public class BaseImpactModel
    {
        [Key]
        public Guid Id { get; set; }

        public BaseImpactModel()
        {
            this.Id = Guid.NewGuid();
        }

        public bool IsDeleted { get; set; } = false;
    }
}