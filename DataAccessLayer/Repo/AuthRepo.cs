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
    public class AuthRepo : IAuth<Login, string>
    {
        WebSeriesDBEntities db;
        public AuthRepo(WebSeriesDBEntities db)
        {
            this.db = db;
        }

        public Token Authenticate(Login login)
        {
            Token tk = null;
            var log = db.Logins.FirstOrDefault(l => l.Email.Equals(login.Email) && l.Password.Equals(login.Password));
            if (log != null)
            {
                string token = Guid.NewGuid().ToString();
                tk = new Token();
                tk.LoginId = log.Id;
                tk.TokenData = token;
                tk.LoginTime = DateTime.Now;
                db.Tokens.Add(tk);
                db.SaveChanges();
            }
            return tk;
        }

        public Login GetByEmail(string email)
        {
            return db.Logins.FirstOrDefault(e => e.Email.Equals((email))); 
        }

        public bool isAuthenticated(string token)
        {
            if (token == null) return false;
            return  db.Tokens.Any(tok => tok.TokenData.Equals((token)) && tok.ExpiredAt == null);
        }

        public bool Logout(string token)
        {
            if (token == null) return false;
            var result = db.Tokens.FirstOrDefault(tok => tok.TokenData.Equals(token));
            if (result != null)
            {
                result.ExpiredAt = DateTime.Now;
                db.Tokens.Add(result);
                db.SaveChanges();
                return db.SaveChanges() != 0;
            }
            return false;
        }
    }
}
