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
    public class UserService
    {
        public static List<UserModel> Get()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserModel>();
                c.CreateMap<Login, LoginModel>();
                c.CreateMap<Salary, SalaryModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.UserDataAccess();
            var data = mapper.Map<List<UserModel>>(da.Get());
            return data;
        }

        public static UserModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserModel>();
                c.CreateMap<Login, LoginModel>();
                c.CreateMap<Salary, SalaryModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.UserDataAccess();
            var data = mapper.Map<UserModel>(da.Get(id));
            return data;
        }

        public static void Create(UserModel u)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<UserModel, User>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<User>(u);
            var isCreated = DataAccessFactory.UserDataAccess().Create(data);
            if (!isCreated) throw new Exception("User not created");
        }

        public static void Update(UserModel user)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<UserModel, User>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<UserModel, User>(user);
            var isUpdated = DataAccessFactory.UserDataAccess().Update(data);
            if (!isUpdated) throw new Exception("User not updated");
        }

        public static void Delete(int id)
        {
            var isDeleted = DataAccessFactory.UserDataAccess().Delete(id);
            if (!isDeleted) throw new Exception("User not deleted");
        }
    }
}
