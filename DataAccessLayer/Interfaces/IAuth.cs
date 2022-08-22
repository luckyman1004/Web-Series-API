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
        Token Authenticate(Login login);
        T GetByEmail(ID email);
        bool isAuthenticated(ID obj);
        bool Logout(ID obj);
    }
}
