using Lib.Data.Entity;
using Lib.Repository.Dto;
using Lib.Repository.Dto.Parameters;
using Lib.Repository.Dto.Results;

namespace Lib.Repository.Repositories.IRepository
{
    public interface IFacilityReviewRepository : IRepository<FacilityReviewModel>
    {
        HealthFacilityReviewsDto GetByHealthFacilityId(string healthFacilityId);
        ModelSearchResult<FacilityReviewModel> GetAllByHealthFacilityId(ModelSearchParameter<FacilityReviewParam> objParam);
        void AddNewReview(FacilityReviewModel model, string healthFacilityId);
    }
}