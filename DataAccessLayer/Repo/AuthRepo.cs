using DataAccessLayer.EntityFramework;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repo
{
    public class AuthRepo : IRepository<Auth, string>
    {
        WebSeriesDBEntities db;
        public AuthRepo(WebSeriesDBEntities db)
        {
            this.db = db;
        }

        public bool Create(Auth obj)
        {
            if (obj == null) return false;
            db.Auths.Add(obj);
            return db.SaveChanges() != 0;
        }                                                                                                  
        public bool Delete(string token)
        {
            if (token == null) return false;
            db.Auths.Remove(db.Auths.FirstOrDefault(del => del.Token.Equals(token)));
            return db.SaveChanges() != 0;
        }

        public List<Auth> Get()
        {
            return db.Auths.ToList();
        }

        public Auth Get(string id)
        {
            return db.Auths.FirstOrDefault(tok => tok.Token.Equals((id)));
        }

        public bool Update(Auth obj)
        {
            if (obj == null) return false;
            var tok = db.Auths.FirstOrDefault(t => t.Token.Equals((t.Token)));
            db.Entry(tok).CurrentValues.SetValues(obj);
            return db.SaveChanges() != 0;
        }
    }
}
