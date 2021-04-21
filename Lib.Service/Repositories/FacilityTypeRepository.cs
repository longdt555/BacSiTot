using Lib.Data.DataContext;
using Lib.Data.Entity;
using Lib.Repository.Repositories.IRepository;

namespace Lib.Repository.Repositories
{
    public class FacilityTypeRepository : Repository<FacilityTypeModel>, IFacilityTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public FacilityTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}