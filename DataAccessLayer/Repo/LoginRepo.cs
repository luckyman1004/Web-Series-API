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
    public class LoginRepo : IRepository<Login, int>, IAuth
    {
        WebSeriesDBEntities db;
        public LoginRepo(WebSeriesDBEntities db)
        {
            this.db = db;
        }

        public Auth Authenticate(Login login)
        {

            Auth auth = null;
            var log = db.Logins.FirstOrDefault(l => l.Email.Equals(login.Email) && l.Password.Equals(login.Password));

            if (log != null)
            {
                string token = Guid.NewGuid().ToString();
                auth = new Auth();
                auth.LoginId = log.Id;
                auth.Token = token;
                auth.LoginTime = DateTime.Now;
                db.Auths.Add(auth);
                db.SaveChanges();
            }
            return auth;
        }

        public bool Create(Login obj)
        {
            if (obj == null) return false;
            db.Logins.Add(obj);
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

        public bool isAuthenticated(string obj)
        {
            throw new NotImplementedException();
        }

        public bool Logout(string obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Login obj)
        {
            var usr = db.Logins.FirstOrDefault(u => u.Id.Equals((obj.Id)));
            if (usr == null) return false;
            db.Entry(usr).CurrentValues.SetValues(obj);
            return db.SaveChanges() != 0;
        }
    }
}
