using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarygardenly.Registration
{
    public interface IUserRepository
    {
        List<User> GetUsers();
    }
}
