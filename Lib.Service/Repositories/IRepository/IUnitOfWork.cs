using System;

namespace Lib.Repository.Repositories.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        IHealthFacilityRepository HealthcareFacility { get; }
        IFacilityReviewRepository FacilityReview { get; }
        IHealthFacilityServiceRepository HealthFacilityService { get; }
        IDiseasesRepository Diseases { get; }


        #region log

        #endregion

        /// <summary>
        /// Commit to DB
        /// </summary>
        void Save();
    }
}
