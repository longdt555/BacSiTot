using System;
using System.ComponentModel.DataAnnotations;

namespace Lib.Data.Entity
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; }

        public BaseModel()
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