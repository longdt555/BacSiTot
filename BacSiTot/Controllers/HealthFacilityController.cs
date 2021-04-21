using System;
using BacSiTot.Helpers;
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

        [HttpGet("get-by-id/{id}")]
        public IActionResult GetById(string id)
        {
            var response = new ApiResponse();
            var result = _unitOfWork.HealthcareFacility.GetById(Guid.Parse(id));
            response.SetStatusSuccess();
            response.SetData(result);
            return Ok(result);
        }
    }
}