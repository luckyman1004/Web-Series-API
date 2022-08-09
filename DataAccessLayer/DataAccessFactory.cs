using DataAccessLayer.EntityFramework;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataAccessFactory
    {
        static WebSeriesDBEntities db;
        static DataAccessFactory()
        {
            db = new WebSeriesDBEntities();
        }

        public static IPackage<Package, int> PackageDataAccess()
        {
            return new PackageRepo(db);
        }

        //Auth
        public static IRepository<Auth, string> AuthDataAccess()
        {
            return new AuthRepo(db);
        }
        //User
        public static IRepository<User, int> UserDataAccess()
        {
            return new UserRepo(db);
        }
        //Salary
        public static IRepository<Salary, int> SalaryDataAccess()
        {
            return new SalaryRepo(db);
        }

    }
}
