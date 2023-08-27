using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contract
{
    public interface IUserService
    {
        public Task Register(RegisterUserModel registerUserModel);
        public Task<UserDto> Login(LoginUserModel loginUserModel);
    }
}
