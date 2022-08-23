using BusinessEntityLayer;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repo
{
    public class LoginRepo : IRepository<Login, int>
    {
        WebSeriesDBEntities db;
        public LoginRepo(WebSeriesDBEntities db)
        {
            this.db = db;
        }

        public bool Create(Login obj)
        {
            User user = new User();
            if (obj == null) return false;
            user.LoginId = obj.Id;
            db.Logins.Add(obj);
            db.Users.Add(user);
            return db.SaveChanges() != 0;
        }

        public bool Delete(int id)
        {
            var delete = db.Logins.Remove(db.Logins.FirstOrDefault(del => del.Id.Equals(id)));
            var deleteUser = db.Users.Remove(db.Users.FirstOrDefault(del => del.LoginId.Equals(id)));
            if (delete == null && deleteUser == null) return false;
            return db.SaveChanges() != 0;
        }
        
        public List<Login> Get()
        {
            return db.Logins.ToList();
        }
        
        public Login Get(int id)
        {
            return db.Logins.FirstOrDefault(u => u.Id.Equals((id)));
        }

        public bool Update(Login obj)
        {
            if (obj == null) return false;
            var usr = db.Logins.FirstOrDefault(u => u.Id.Equals((obj.Id)));
            if (usr == null) return false;
            db.Entry(usr).CurrentValues.SetValues(obj);
            return db.SaveChanges() != 0;
        }
    }
}
