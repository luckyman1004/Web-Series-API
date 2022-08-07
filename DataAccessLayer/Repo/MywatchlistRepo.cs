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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var del = db.Mywatchlists.FirstOrDefault(d => d.Id == id);
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
            throw new NotImplementedException();
        }
    }
}
