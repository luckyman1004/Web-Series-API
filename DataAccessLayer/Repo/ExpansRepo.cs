using DataAccessLayer.EntityFramework;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repo
{
    public class ExpansRepo : IRepository<Expans, int>
    {
        WebSeriesDBEntities db;
        public ExpansRepo(WebSeriesDBEntities db)
        {
            this.db = db;
        }
        public bool Create(Expans obj)
        {
            if (obj == null) return false;
            db.Expanses.Add(obj);
            return db.SaveChanges() != 0;
        }

        public bool Delete(int id)
        {
            var delete = db.Expanses.Remove(db.Expanses.FirstOrDefault(del => del.Id.Equals(id)));
            if (delete == null) return false;
            return db.SaveChanges() != 0;
        }

        public List<Expans> Get()
        {
            return db.Expanses.ToList();
        }

        public Expans Get(int id)
        {
            return db.Expanses.FirstOrDefault(e => e.Id.Equals((id)));
        }

        public bool Update(Expans obj)
        {
            var exp = db.Expanses.FirstOrDefault(u => u.Id.Equals((obj.Id)));
            if (exp == null) return false;
            db.Entry(exp).CurrentValues.SetValues(obj);
            return db.SaveChanges() != 0;
        }
    }
}
