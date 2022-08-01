using DataAccessLayer.EntityFramework;
using DataAccessLayer.Interfaces;
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

        public static IRepository<Package, int> PackageDataAccess()
        {
            return new PackageRepo(db);
        }
    }
}
