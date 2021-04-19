using System;
using System.ComponentModel.DataAnnotations;

namespace Lib.Repository.Dto
{
    public class BaseDto
    {
        [Key]
        public Guid Id { get; set; }

        public BaseDto()
        {
            this.Id = Guid.NewGuid();
        }

        public DateTime? CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}