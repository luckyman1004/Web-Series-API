using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ICommonRepo<Class, ID>
    {
        List<Class> Get();
        Class Get(ID id);
        bool Create(Class obj);
        bool Update(Class obj);
        bool Delete(ID id);
    }
}
