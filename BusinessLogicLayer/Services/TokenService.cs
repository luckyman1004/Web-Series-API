using AutoMapper;
using BusinessEntityLayer;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services
{
    public class TokenService
    {
        public static List<TokenModel> Get()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Token, TokenModel>();
                c.CreateMap<Login, LoginModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.TokenDataAccess();
            var data = mapper.Map<List<TokenModel>>(da.Get());
            return data;
        }

        public static string GetLoginByToken(string token)
        {
            var result = DataAccessFactory.TokenDataAccessForFilter().GetLoginByToken(token);
            return result.Role;
        }
        
        public static AuthPayloadModel GetRoleEmailByToken(string token)
        {
            var result = DataAccessFactory.TokenDataAccessForFilter().GetLoginByToken(token);
            var authPayload = new AuthPayloadModel()
            {
                Id = result.Id,
                Email = result.Email,
                Role = result.Role
            };
            return authPayload;
        }
        
    }
}
