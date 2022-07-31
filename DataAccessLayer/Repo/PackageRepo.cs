using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PackageRepo
    {
        static WebSeriesDBEntities db;

        static PackageRepo()
        {
            db = new WebSeriesDBEntities();
        }

        public static List<Package> Get()
        {
            return db.Packages.ToList();
        }

        public static Package Get(int id)
        {
            return db.Packages.FirstOrDefault(p => p.Id == id);
        }

        public static void Create(Package p)
        {
            db.Packages.Add(p);
            db.SaveChanges();
        }

        public static void Update(Package p)
        {
            var edit = db.Packages.FirstOrDefault(package => package.Id == p.Id);
            db.Entry(edit).CurrentValues.SetValues(p);
            db.SaveChanges();
        }

        public static void Delete(int id)
        {
            var del = db.Packages.FirstOrDefault(d => d.Id == id);
            db.Packages.Remove(del);
        }
    }
}
