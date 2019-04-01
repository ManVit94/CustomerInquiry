using Microsoft.AspNetCore.Mvc;
using CustomerInquiry.Services;

namespace CustomerInquiry.WebApi.Controllers
{
    public class BaseApiController : ControllerBase
    {
        protected IActionResult ReturnResult(ServiceResult serviceResult)
        {
            switch (serviceResult.Status)
            {
                case ServiceResultStatus.Success:
                    return NoContent();
                case ServiceResultStatus.NotFound:
                    return NotFound();
                case ServiceResultStatus.Error:
                default:
                    return BadRequest();
            }
        }

        protected IActionResult ReturnResult<TResult>(ServiceResult<TResult> serviceResult)
        {
            switch (serviceResult.Status)
            {
                case ServiceResultStatus.Success:
                    return Ok(serviceResult.Data);
                case ServiceResultStatus.NotFound:
                    return NotFound();
                case ServiceResultStatus.Error:
                default:
                    return BadRequest();
            }
        }
    }
}