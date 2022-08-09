using DataAccessLayer.EntityFramework;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repo
{
    public class MywatchlistRepo : IMywatchlist<Mywatchlist,int>
    {
        WebSeriesDBEntities db;
        
        public MywatchlistRepo(WebSeriesDBEntities db)
        {
            this.db = db;
        
        }

        public void Create(Mywatchlist obj)
        {
            db.Mywatchlists.Add(obj);
            db.SaveChanges();
        }

        //public bool Delete(int id)
        //{
        //    var obj = Get(id);
        //    db.Mywatchlists.Remove(obj);
        //    return db.SaveChanges() > 0;
        //}

        public void Delete(Mywatchlist e)
        {
            var n = db.Mywatchlists.FirstOrDefault(en => en.Id == e.Id);
            db.Mywatchlists.Remove(n);
            db.SaveChanges();
        }

        public List<Mywatchlist> Get() 
        {
            return db.Mywatchlists.ToList();
        }

        public Mywatchlist Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Mywatchlist obj)
        {
            var edit = db.Mywatchlists.FirstOrDefault(mywatchlist => mywatchlist.Id == obj.Id);
            db.Entry(edit).CurrentValues.SetValues(obj);
            db.SaveChanges();
        }
    }
}
