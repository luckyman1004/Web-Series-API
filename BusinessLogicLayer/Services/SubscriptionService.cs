using AutoMapper;
using BusinessEntityLayer;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class SubscriptionService
    {
        public static List<SubscriptionModel> Get()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Subscription, SubscriptionModel>();
                c.CreateMap<Package, PackageModel>();
                c.CreateMap<User, UserModel>();
                c.CreateMap<Login, LoginModel>();
                c.CreateMap<Salary, SalaryModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.SubscriptionDataAccess();
            var data = mapper.Map<List<SubscriptionModel>>(da.Get());
            return data;
        }

        public static List<string> GetSubscriptions()
        {

            var da = DataAccessFactory.SubscriptionDataAccess();
            var data = da.Get().Select(n => n.Id);
            return (List<string>)data;
        }

        public static void Create(SubscriptionModel p)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<SubscriptionModel, Subscription>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Subscription>(p);
            var da = DataAccessFactory.SubscriptionDataAccess();
            da.Create(data);
        }

        public static void Update(SubscriptionModel p)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<SubscriptionModel, Subscription>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Subscription>(p);
            DataAccessFactory.SubscriptionDataAccess().Update(data);
        }

        public static void Delete(SubscriptionModel p)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<SubscriptionModel, Subscription>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Subscription>(p);
            DataAccessFactory.SubscriptionDataAccess().Delete(data);
        }
    }
}
