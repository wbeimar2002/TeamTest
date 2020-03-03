using System;
using System.Collections.Generic;
using System.Text;
using TeamTest.Models.Dtos;
using TeamTest.Models.Payloads;

namespace TeamTest.Services.Interfaces
{
    public interface IUserService
    {
        UserDto Authenticate(UserPayload userPayload);
    }
}
