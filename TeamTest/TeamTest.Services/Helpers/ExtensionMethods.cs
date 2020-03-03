using System;
using System.Collections.Generic;
using System.Text;
using TeamTest.Models.Dtos;

namespace TeamTest.Services.Helpers
{
    public static class ExtensionMethods
    {
        public static UserDto WithoutPassword(this UserDto user)
        {
            user.Password = null;
            return user;
        }
    }
}
