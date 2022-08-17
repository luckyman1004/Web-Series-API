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
    public class ExpansService
    {
        public static List<ExpansModel> Get()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Expans, ExpansModel>();
                c.CreateMap<User, UserModel>();
                c.CreateMap<Login, LoginModel>();
                c.CreateMap<Salary, SalaryModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.ExpansDataAccess();
            var data = mapper.Map<List<ExpansModel>>(da.Get());
            return data;
        }

        public static ExpansModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Expans, ExpansModel>();
                c.CreateMap<User, UserModel>();
                c.CreateMap<Login, LoginModel>();
                c.CreateMap<Salary, SalaryModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.ExpansDataAccess();
            var data = mapper.Map<ExpansModel>(da.Get(id));
            return data;
        }

        public static void Create(ExpansModel exp)
        {
            var config = new MapperConfiguration(c => c.CreateMap<ExpansModel, Expans>());
            var mapper = new Mapper(config);
            var data = mapper.Map<Expans>(exp);
            var isCreated = DataAccessFactory.ExpansDataAccess().Create(data);
            if (!isCreated) throw new Exception("Expans not inserted");
        }

        public static void Update(ExpansModel expans)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ExpansModel, Expans>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<ExpansModel, Expans>(expans);
            var isUpdated = DataAccessFactory.ExpansDataAccess().Update(data);
            if (!isUpdated) throw new Exception("ID's not found or can't updated");
        }

        public static void Delete(int id)
        {
            var isDeleted = DataAccessFactory.ExpansDataAccess().Delete(id);
            if (!isDeleted) throw new Exception("Expans not deleted");
        }
    }
}
