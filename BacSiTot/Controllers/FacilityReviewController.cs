using Microsoft.AspNetCore.Mvc;
using BacSiTot.Helpers;
using Lib.Common.Helpers;
using Lib.Data.Entity;
using Lib.Repository.Dto.Parameters;
using Lib.Repository.Repositories.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace BacSiTot.Controllers
{
    [AllowAnonymous]
    [Route("api/facility-review")]
    [ApiController]
    public class FacilityReviewController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public FacilityReviewController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("get-all-by-health-facility-id")]
        public IActionResult GetAllByHealthFacilityId([FromBody] ModelSearchParameter<FacilityReviewParam> model)
        {
            var response = new ApiResponse();
            var result =
                _unitOfWork.FacilityReview.GetAllByHealthFacilityId(model);
            response.SetData(result);
            response.SetStatusSuccess();
            return Ok(response);
        }

        [HttpPost("save")]
        public IActionResult Save([FromBody] FacilityReviewModel model, [FromQuery] string healthFacilityId)
        {
            var response = new ApiResponse();
            try
            {
                _unitOfWork.FacilityReview.Save(model, healthFacilityId);
                response.SetStatusSuccess();
                return Ok(response);
            }
            catch (AppException ex)
            {
                response.SetStatusFailed();
                response.SetMessage(StatusCodes.Status404NotFound, ex.Message);
                return Ok(response);
            }
        }
    }
}