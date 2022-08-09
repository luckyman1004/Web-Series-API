using DataAccessLayer.EntityFramework;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repo
{
    public class SubscriptionRepo : ISubscription<Subscription, int>
    {
        WebSeriesDBEntities db;

        public SubscriptionRepo(WebSeriesDBEntities db)
        {
            this.db = db;
        }
        public void Create(Subscription obj)
        {
            db.Subscriptions.Add(obj);
            db.SaveChanges();
        }

        public void Delete(Subscription e)
        {
            var n = db.Subscriptions.FirstOrDefault(en => en.Id == e.Id);
            db.Subscriptions.Remove(n);
            db.SaveChanges();
        }

        public List<Subscription> Get()
        {
            return db.Subscriptions.ToList();
        }

        public Subscription Get(int id)
        {
            return db.Subscriptions.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Subscription obj)
        {
            var edit = db.Subscriptions.FirstOrDefault(subscription => subscription.Id == obj.Id);
            db.Entry(edit).CurrentValues.SetValues(obj);
            db.SaveChanges();
        }
    }
}
