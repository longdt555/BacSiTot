using System;
using System.ComponentModel.DataAnnotations;

namespace Lib.Repository.Dto
{
    public class BaseImpactDto
    {
        [Key]
        public Guid Id { get; set; }

        public BaseImpactDto()
        {
            this.Id = Guid.NewGuid();
        }

        public bool IsDeleted { get; set; } = false;
    }
}