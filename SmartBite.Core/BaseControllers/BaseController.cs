using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartBite.Core.ResponseManager;

namespace SmartBite.Core.BaseControllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult HandleResponse(BaseResponseModel responseModel)
        {
            return StatusCode(responseModel.StatusCode, responseModel);
        }

        protected IActionResult HandleResponse<T>(BaseResponseModel<T> responseModel)
        {
            return StatusCode(responseModel.StatusCode, responseModel);
        }
    }
}
