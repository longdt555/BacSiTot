using BacSiTot.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace BacSiTot.Controllers
{
    [Route("api/statistic")]
    [ApiController]
    public class StatisticController : BaseController
    {
        [HttpGet("get-system-statistics")]
        public IActionResult GetSystemStatistics()
        {
            var response = new ApiResponse();

            response.SetStatusSuccess();
            return Ok();
        }
    }
}