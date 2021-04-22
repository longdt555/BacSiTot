using System;

namespace Lib.Repository.Dto.Parameters
{
    public class ModelSearchParameter<T>
    {
        public int Id { get; set; }
        public T Filter { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }

    public class FacilityReviewParam
    {
        public Guid HealthFacilityId { get; set; }
    }
}