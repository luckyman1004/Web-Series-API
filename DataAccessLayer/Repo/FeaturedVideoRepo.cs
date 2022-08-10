using DataAccessLayer.EntityFramework;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repo
{
    public class FeaturedVideoRepo : IRepository<FeaturedVideo, int>
    {
        WebSeriesDBEntities db;
        public FeaturedVideoRepo(WebSeriesDBEntities db)
        {
            this.db = db;
        }
        public bool Create(FeaturedVideo obj)
        {
            if (obj == null) return false;
            db.FeaturedVideos.Add(obj);
            return db.SaveChanges() != 0;
        }

        public bool Delete(int id)
        {
            var delete = db.FeaturedVideos.Remove(db.FeaturedVideos.FirstOrDefault(del => del.Id.Equals(id)));
            if (delete == null) return false;
            return db.SaveChanges() != 0;
        }

        public List<FeaturedVideo> Get()
        {
            return db.FeaturedVideos.ToList();
        }

        public FeaturedVideo Get(int id)
        {
            return db.FeaturedVideos.FirstOrDefault(e => e.Id.Equals((id)));
        }

        public bool Update(FeaturedVideo obj)
        {
            var f = db.FeaturedVideos.FirstOrDefault(u => u.Id.Equals((obj.Id)));
            if (f == null) return false;
            db.Entry(f).CurrentValues.SetValues(obj);
            return db.SaveChanges() != 0;
        }
    }
}
