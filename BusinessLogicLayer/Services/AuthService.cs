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
    public class AuthService
    {

        public static TokenModel Authenticate(LoginModel login)
        {
            var tokenModel = new TokenModel();
            var config = new MapperConfiguration(c => c.CreateMap<LoginModel, Login>());
            var mapper = new Mapper(config);
            var data = mapper.Map<LoginModel, Login>(login);
            var result = DataAccessFactory.AuthDataAccess().Authenticate(data);

            if (result != null)
            {
                tokenModel.TokenData = result.TokenData;
                tokenModel.LoginId = result.LoginId;
            }
            if (result == null)
            {
                throw new Exception("User not found");
            }
            return tokenModel;
        }

        public static LoginModel EmailCheck(string email)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Login, LoginModel>();
            });
            var mapper = new Mapper(config);
            var isFind = mapper.Map<Login, LoginModel>(DataAccessFactory.AuthDataAccess().GetByEmail(email));
            return isFind;
        }
        
        public static bool isAuthenticated(string token)
        {
            var result = DataAccessFactory.AuthDataAccess().isAuthenticated(token);
            return result;
        }
        
        public static bool Logout(string token)
        {
            var result = DataAccessFactory.AuthDataAccess().isAuthenticated(token);
            return result;
        }




    }
}
