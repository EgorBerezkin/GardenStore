using System;
using System.Collections.Generic;

namespace Librarygardenly.Registration
{
    public interface IUserRepository
    {
        List<User> GetUsers();
    }
}
