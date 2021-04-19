using System;
using System.Collections.Generic;

namespace Lib.Repository.Repositories.IRepository
{
    public interface IHealthFacilityRepository : IRepository<HealthFacilityModel>
    {
        HealthFacilityViewModel GetById(Guid id);
        IEnumerable<HealthFacilityViewModel> GetTopHealthFacilityByAverageRating(int take, Guid healthFacilityType);
    }
}
