using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IAuth<T, ID>
    {
        Auth Authenticate(User user);
        bool isAuthenticated(string obj);
        bool Logout(string obj);

    }
}
