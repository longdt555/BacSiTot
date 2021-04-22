using System;

namespace Lib.Repository.Repositories.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IHealthFacilityRepository HealthcareFacility { get; }
        IFacilityReviewRepository FacilityReview { get; }
        IHealthFacilityServiceRepository HealthFacilityService { get; }
        IDiseasesRepository Diseases { get; }
        IFacilityTypeRepository FacilityType { get; }
        IMasterDataRepository MasterData{ get; }


        #region log

        #endregion

        /// <summary>
        /// Commit to DB
        /// </summary>
        void Save();
    }
}