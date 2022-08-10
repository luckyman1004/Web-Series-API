using DataAccessLayer.EntityFramework;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repo
{
    public class VideoRepo : IRepository<Video, int>

    {
        WebSeriesDBEntities db;
        public VideoRepo(WebSeriesDBEntities db)
        {
            this.db = db;
        }

        public bool Create(Video obj)
        {
            if (obj == null) return false;
            db.Videos.Add(obj);
            return db.SaveChanges() != 0;
        }

        public bool Delete(int id)
        {
            var delete = db.Videos.Remove(db.Videos.FirstOrDefault(del => del.Id.Equals(id)));
            if (delete == null) return false;
            return db.SaveChanges() != 0;
        }

        public List<Video> Get()
        {
            return db.Videos.ToList();
        }

        public Video Get(int id)
        {
            return db.Videos.FirstOrDefault(e => e.Id.Equals((id)));
        }

        public bool Update(Video obj)
        {
            var vid = db.Videos.FirstOrDefault(u => u.Id.Equals((obj.Id)));
            if (vid == null) return false;
            db.Entry(vid).CurrentValues.SetValues(obj);
            return db.SaveChanges() != 0;
        }
    }
}
