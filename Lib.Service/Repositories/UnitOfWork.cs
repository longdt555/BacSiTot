using Lib.Data.DataContext;
using Lib.Repository.Repositories.IRepository;

namespace Lib.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            FacilityReview = new FacilityReviewRepository(_db);
            HealthcareFacility = new HealthFacilityRepository(_db);
            HealthFacilityService = new HealthFacilityServiceRepository(_db);
            Diseases = new DiseasesRepository(_db);
            FacilityType = new FacilityTypeRepository(_db);
        }


        #region

        public IHealthFacilityRepository HealthcareFacility { get; private set; }
        public IFacilityReviewRepository FacilityReview { get; private set; }
        public IHealthFacilityServiceRepository HealthFacilityService { get; private set; }
        public IDiseasesRepository Diseases { get; private set; }
        public IFacilityTypeRepository FacilityType { get; private set; }

        #endregion

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}