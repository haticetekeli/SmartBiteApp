using Microsoft.EntityFrameworkCore.Metadata;
using SmartBite.Business.Services.Auth.Abstract;
using SmartBite.Business.Services.Auth.Models.Request;
using SmartBite.Core.ResponseManager;
using SmartBite.DataAccess.UnitOfWork.Abstract;

namespace SmartBite.Business.Services.Auth.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponseModel> LoginAsync(LoginRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponseModel> RegisterAsync(RegisterRequestModel requestModel)
        {
            throw new NotImplementedException();
        }
    }
}
