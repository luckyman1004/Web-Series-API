
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

        public static void Authenticate(LoginModel login)
        {
            var authModel  = new AuthModel();
            var config = new MapperConfiguration(c => c.CreateMap<LoginModel,Login>());
            var mapper = new Mapper(config);
            var data = mapper.Map<LoginModel, Login>(login);
            var result = DataAccessFactory.AuthDataAccess().Authenticate(data);

            //var authModel = new AuthModel();
            if (result != null)
            {
                authModel.Token = result.Token;
                authModel.LoginId = result.LoginId;
            }
            if (result == null)
            {
                throw new Exception("User not found");
            } 
        }
    }
}
