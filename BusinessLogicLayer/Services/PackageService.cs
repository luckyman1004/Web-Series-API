using BusinessEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.EntityFramework;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class PackageService
    {
        public static List<PackageModel> Get()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Package, PackageModel>();
                c.CreateMap<User, UserModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<PackageModel>>(PackageRepo.Get());
            return data;
        }

        public static List<string> GetPackageNames()
        {
            var data = PackageRepo.Get().Select(n => n.Name).ToList();
            return data;
        }

        public static void Create(PackageModel p)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<PackageModel, Package>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Package>(p);
            PackageRepo.Create(data);
        }
    }
}
