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
    public class SalaryService
    {
        public static List<SalaryModel> Get()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserModel>();
                c.CreateMap<Login, LoginModel>();
                c.CreateMap<Salary, SalaryModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.SalaryDataAccess();
            var data = mapper.Map<List<SalaryModel>>(da.Get());
            return data;
        }

        public static SalaryModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Salary, SalaryModel>();
                c.CreateMap<User, UserModel>();
                c.CreateMap<Login, LoginModel>();
            }); 
            var mapper = new Mapper(config);
            var da = DataAccessFactory.SalaryDataAccess();
            var data = mapper.Map<SalaryModel>(da.Get(id));
            return data;
        }

        public static void Create(SalaryModel s)
        {
            var config = new MapperConfiguration(c => c.CreateMap<SalaryModel, Salary>());
            var mapper = new Mapper(config);
            var data = mapper.Map<Salary>(s);
            var isCreated = DataAccessFactory.SalaryDataAccess().Create(data);
            if (!isCreated) throw new Exception("Salary not inserted");
        }

        public static void Update(SalaryModel salary)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<SalaryModel, Salary>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<SalaryModel, Salary>(salary);
            var isUpdated = DataAccessFactory.SalaryDataAccess().Update(data);
            if (!isUpdated) throw new Exception("Salary not updated");
        }

        public static void Delete(int id)
        {
            var isDeleted = DataAccessFactory.SalaryDataAccess().Delete(id);
            if (!isDeleted) throw new Exception("Salary not deleted");
        }
    }
}
