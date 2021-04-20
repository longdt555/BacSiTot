using Lib.Data.DataContext;
using Lib.Data.Entity;
using Lib.Repository.Repositories.IRepository;

namespace Lib.Repository.Repositories
{
    public class DiseasesRepository : Repository<DiseasesModel>, IDiseasesRepository
    {
        private readonly ApplicationDbContext _db;

        public DiseasesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        
    }
}
