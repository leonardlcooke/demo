using Disco.Extensions;
using Disco.Extensions.Abstractions.Corporate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo
{
    public class CustomUserService
    {
        IUserService _userService;

        public CustomUserService(IUserService userService)
        {
            _userService = userService;
        }

        public static UserData[] GetAllUsers(GetAllUsersRequest request)
        {
            List<UserData> v = new List<UserData>();

            //foreach (var user in _userService.GetUsers())
            //{

            //}

            return v.ToArray();
        }
    }

    public class GetAllUsersRequest : CommandRequest
    {
        public string Id { get; set; }
    }

    public class UserData
    {
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
