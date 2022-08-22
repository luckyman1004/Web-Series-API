
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
    public class LoginService
    {
        public static void Create(LoginModel login)
        {
            login.Role = "User";
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<LoginModel, Login>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Login>(login);
            var isCreated = DataAccessFactory.LoginDataAccess().Create(data);
            if (!isCreated) throw new Exception("User not created");
        }
        
        public static LoginModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Login, LoginModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.LoginDataAccess();
            var data = mapper.Map<LoginModel>(da.Get(id));
            return data;
        }
    }
}
