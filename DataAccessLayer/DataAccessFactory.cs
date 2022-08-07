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
        public static IMywatchlist<Mywatchlist, int> MywatchlistDataAccess()
        {
            return new MywatchlistRepo(db);
        }

        public static IRepository<Auth, string> AuthDataAccess()
        {
            return new AuthRepo(db);
        }

        public static IRepository<User, int> UserDataAccess()
        {
            return new UserRepo(db);
        }

    }
}
