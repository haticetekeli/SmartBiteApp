using SmartBite.Business.Services.Auth.Models.Request;
using SmartBite.Core.ResponseManager;

namespace SmartBite.Business.Services.Auth.Abstract
{
    public interface IAuthService
    {
        Task<BaseResponseModel> LoginAsync(LoginRequestModel requestModel);
        Task<BaseResponseModel> RegisterAsync(RegisterRequestModel requestModel);
    }
}
