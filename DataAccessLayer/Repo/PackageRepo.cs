using DataAccessLayer.EntityFramework;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PackageRepo : IRepository<Package, int>
    {
        WebSeriesDBEntities db;

        public PackageRepo(WebSeriesDBEntities db)
        {
            this.db = db;
        }

        public void Create(Package obj)
        {
            db.Packages.Add(obj);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var del = db.Packages.FirstOrDefault(d => d.Id == id);
            db.Packages.Remove(del);
        }

        public List<Package> Get()
        {
            return db.Packages.ToList();
        }

        public Package Get(int id)
        {
            return db.Packages.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Package obj)
        {
            var edit = db.Packages.FirstOrDefault(package => package.Id == obj.Id);
            db.Entry(edit).CurrentValues.SetValues(obj);
            db.SaveChanges();
        }
    }
}
