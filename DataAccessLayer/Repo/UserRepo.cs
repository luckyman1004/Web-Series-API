using DataAccessLayer.EntityFramework;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repo
{
    public class UserRepo : IRepository<User, int>
    {
        WebSeriesDBEntities db;
        public UserRepo(WebSeriesDBEntities db)
        {
            this.db = db;
        }
        public bool Create(User obj)
        {
            if (obj == null) return false;
            db.Users.Add(obj);
            return db.SaveChanges() != 0;
        }

        public bool Delete(int id)
        {
            var delete = db.Users.Remove(db.Users.FirstOrDefault(del => del.Id.Equals(id)));
            if (delete == null) return false;
            return db.SaveChanges() != 0;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.FirstOrDefault(u => u.Id.Equals((id)));
        }

        public bool Update(User obj)
        {
            if (obj == null) return false;
            var usr = db.Users.FirstOrDefault(u => u.Id.Equals((obj.Id)));
            if (usr == null) return false;
            db.Entry(usr).CurrentValues.SetValues(obj);
            return db.SaveChanges() != 0;
        }
    }
}
