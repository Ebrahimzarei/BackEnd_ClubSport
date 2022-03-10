using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.UserServices
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
    }
}
