using System;
using System.Collections.Generic;
using Lib.Data.Entity;
using Lib.Repository.Dto;

namespace Lib.Repository.Repositories.IRepository
{
    public interface IHealthFacilityRepository : IRepository<HealthFacilityModel>
    {
        HealthFacilityDto GetById(Guid id);
        IEnumerable<HealthFacilityDto> GetTopHealthFacilityByAverageRating(int take, Guid healthFacilityType);
    }
}
