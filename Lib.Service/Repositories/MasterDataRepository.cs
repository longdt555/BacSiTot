using Lib.Data.DataContext;
using Lib.Data.Entity;
using Lib.Repository.Repositories.IRepository;

namespace Lib.Repository.Repositories
{
    public class MasterDataRepository : Repository<MasterDataModel>, IMasterDataRepository
    {
        private readonly ApplicationDbContext _db;

        public MasterDataRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}