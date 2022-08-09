using DataAccessLayer.EntityFramework;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repo
{
    public class SalaryRepo : IRepository<Salary, int>
    {
        WebSeriesDBEntities db;
        public SalaryRepo(WebSeriesDBEntities db)
        {
            this.db = db;
        }

        public bool Create(Salary obj)
        {
            if (obj == null) return false;
            db.Salarys.Add(obj);
            return db.SaveChanges() != 0;
        }

        public bool Delete(int id)
        {
            var delete = db.Salarys.Remove(db.Salarys.FirstOrDefault(del => del.Id.Equals(id)));
            if (delete == null) return false;
            return db.SaveChanges() != 0;
        }

        public List<Salary> Get()
        {
            return db.Salarys.ToList();
        }

        public Salary Get(int id)
        {
            return db.Salarys.FirstOrDefault(s => s.Id.Equals((id)));
        }

        public bool Update(Salary obj)
        {
            var sal = db.Salarys.FirstOrDefault(u => u.Id.Equals((obj.Id)));
            if (sal == null) return false;
            db.Entry(sal).CurrentValues.SetValues(obj);
            return db.SaveChanges() != 0;
        }
    }
}
