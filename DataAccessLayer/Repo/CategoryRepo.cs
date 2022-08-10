using DataAccessLayer.EntityFramework;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repo
{
    public class CategoryRepo : IRepository<Category, int>
    {

        WebSeriesDBEntities db;
        public CategoryRepo(WebSeriesDBEntities db)
        {
            this.db = db;
        }

        public bool Create(Category obj)
        {
            if (obj == null) return false;
            db.Categories.Add(obj);
            return db.SaveChanges() != 0;
        }

        public bool Delete(int id)
        {
            var delete = db.Categories.Remove(db.Categories.FirstOrDefault(del => del.Id.Equals(id)));
            if (delete == null) return false;
            return db.SaveChanges() != 0;
        }

        public List<Category> Get()
        {
            return db.Categories.ToList();
        }

        public Category Get(int id)
        {
            return db.Categories.FirstOrDefault(e => e.Id.Equals((id)));
        }

        public bool Update(Category obj)
        {
            var cat = db.Categories.FirstOrDefault(u => u.Id.Equals((obj.Id)));
            if (cat == null) return false;
            db.Entry(cat).CurrentValues.SetValues(obj);
            return db.SaveChanges() != 0;
        }
    }
}
