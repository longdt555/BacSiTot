using Lib.Data.DataContext;
using Lib.Data.Entity;
using Lib.Repository.Repositories.IRepository;

namespace Lib.Repository.Repositories
{
    public class HealthFacilityServiceRepository : Repository<HealthFacilityServiceModel>, IHealthFacilityServiceRepository
    {
        private readonly ApplicationDbContext _db;

        public HealthFacilityServiceRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}