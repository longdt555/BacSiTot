using System;
using System.Linq;
using BacSiTot.Helpers;
using Lib.Repository.Repositories.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BacSiTot.Controllers
{
    [AllowAnonymous]
    [Route("api/health-facility")]
    [ApiController]
    public class HealthFacilityController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public HealthFacilityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("get-by-id/{id}")]
        public IActionResult GetById(string id)
        {
            var response = new ApiResponse();
            var result = _unitOfWork.HealthcareFacility.GetById(Guid.TryParse(id, out var idGuid) ? idGuid : Guid.Empty);
            response.SetStatusSuccess();
            response.SetData(result);
            return Ok(result);
        }

        [HttpGet("get-top-health-facility")]
        public IActionResult GetTopHealthFacility()
        {
            var response = new ApiResponse();
            var random = new Random();
            var facilityTypes = _unitOfWork.FacilityType.GetAll().Select(x => x.Id).ToList(); // get all facility type ids
            var index = random.Next(facilityTypes.Count());
            var result = _unitOfWork.HealthcareFacility.GetTopHealthFacility(5, facilityTypes[index]);
            response.SetStatusSuccess();
            response.SetData(result);
            return Ok(result);
        }
    }
}