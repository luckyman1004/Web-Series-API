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
                var data = DataAccessFactory.UserDataAccess().Get();
                var users = new List<UserModel>();

                foreach (var item in data)
                {
                    var usr = new UserModel()
                    {
                        Id = item.Id,
                        LoginId = item.LoginId,
                        Name = item.Login.Name,
                        Email = item.Login.Email,
                        Role = item.Login.Role,  
                        Phone = item.Phone,
                        DOB = item.DOB,
                        Address1 = item.Address1,
                        Address2 = item.Address2,
                        Status = item.Status,
                        AccountCreateTime = item.AccountCreateTime,
                        LoginTime = item.LoginTime
                    };
                    users.Add(usr);
                }
    return users;
            }

            public static UserModel Get(int id)
            {
                var item = DataAccessFactory.UserDataAccess().Get(id);
                var user = new UserModel()
                {
                    Id = item.Id,
                    LoginId = item.LoginId,
                    Name = item.Login.Name,
                    Email = item.Login.Email,
                    Role = item.Login.Role,
                    Phone = item.Phone,
                    DOB = item.DOB,
                    Address1 = item.Address1,
                    Address2 = item.Address2,
                    Status = item.Status,
                    AccountCreateTime = item.AccountCreateTime,
                    LoginTime = item.LoginTime
                };
                return user;
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
