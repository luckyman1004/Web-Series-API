using DataAccessLayer.EntityFramework;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repo
{
    public class TokenRepo : IRepository<Token, int>
    {
        WebSeriesDBEntities db;
        public TokenRepo(WebSeriesDBEntities db)
        {
            this.db = db;
        }

        public bool Create(Token obj)
        {
            if (obj == null) return false;
            db.Tokens.Add(obj);
            return db.SaveChanges() != 0;
        }

        public bool Delete(int id)
        {
            var delete = db.Tokens.Remove(db.Tokens.FirstOrDefault(del => del.Id.Equals(id)));
            if (delete == null) return false;
            return db.SaveChanges() != 0;
        }

        public List<Token> Get()
        {
            return db.Tokens.ToList();
        }

        public Token Get(int id)
        {
            return db.Tokens.FirstOrDefault(tok => tok.TokenData.Equals((id)));
        }

        public bool Update(Token obj)
        {
            if (obj == null) return false;
            var tok = db.Tokens.FirstOrDefault(t => t.Id.Equals((obj.Id)));
            db.Entry(tok).CurrentValues.SetValues(obj);
            return db.SaveChanges() != 0;
        }
    }
}
