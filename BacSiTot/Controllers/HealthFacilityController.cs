using System;
using System.Linq;
using Lib.Repository.Dto.Parameters;
using Lib.Repository.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BacSiTot.Controllers
{
    [Route("api/health-facility")]
    [ApiController]
    public class HealthFacilityController : BaseController
    {

        private readonly IUnitOfWork _unitOfWork;
        public HealthFacilityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("{id}")]
        public IActionResult Index(string id)
        {
            var result = _unitOfWork.HealthcareFacility.GetById(Guid.Parse(id));

            result.FacilityReviews = _unitOfWork.FacilityReview.GetAllByHealthFacilityId(new ModelSearchParameter<FacilityReviewParam>
            {
                Filter = new FacilityReviewParam
                {
                    HealthFacilityId = id
                },
                PageSize = 3,
                PageNumber = 1
            });

            // get list of unique diseases id
            var diseasesIds = _unitOfWork.HealthFacilityService.GetAll()
                .Where(x => x.HealthFacilityId.ToString().Equals(id))
                .GroupBy(x => x.DiseasesId).Select(x => x.Key).ToList();

            result.Diseases = _unitOfWork.Diseases.GetAll().Where(x => diseasesIds.Contains(x.Id));

            return Ok(result);
        }
    }
}
