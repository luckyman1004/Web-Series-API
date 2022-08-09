using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IPackage<T, ID>
    {
        List<T> Get();
        T Get(ID id);
        void Create(T obj);
        void Update(T obj);
        void Delete(T e);
    }
}
