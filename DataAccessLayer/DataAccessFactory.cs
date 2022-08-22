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
        public static ISubscription<Subscription, int> SubscriptionDataAccess()
        {
            return new SubscriptionRepo(db);
        }

        //Auth
        public static IRepository<Login, int> LoginDataAccess()
        {
            return new LoginRepo(db);
        }
        public static IAuth<Login, string> AuthDataAccess()
        {
            return new AuthRepo(db);
        }
        
        //Token
        public static IRepository<Token, int> TokenDataAccess()
        {
            return new TokenRepo(db);
        }
        
        public static IAccess<Login, string> TokenDataAccessForFilter()
        {
            return new TokenRepo(db);
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
        //Expans
        public static IRepository<Expans, int> ExpansDataAccess()
        {
            return new ExpansRepo(db);
        }
        public static IRepository<Category, int> CategoryDataAccess()
        {
            return new CategoryRepo(db);
        }
        public static IRepository<Video, int> VideoDataAccess()
        {
            return new VideoRepo(db);
        }
        public static IRepository<FeaturedVideo, int> FeaturedVideoDataAccess()
        {
            return new FeaturedVideoRepo(db);
        }
    }
}
