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
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.PackageDataAccess();
            var data = mapper.Map<List<PackageModel>>(da.Get());
            return data;
        }

        public static List<string> GetPackageNames()
        {
            var da = DataAccessFactory.PackageDataAccess();
            var data = da.Get().Select(n => n.Name).ToList();
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
            var da = DataAccessFactory.PackageDataAccess();
            da.Create(data);
        }

        public static void Update(PackageModel p)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<PackageModel, Package>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Package>(p);
            DataAccessFactory.PackageDataAccess().Update(data);
        }

        public static void Delete(PackageModel p)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<PackageModel, Package>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Package>(p);
            DataAccessFactory.PackageDataAccess().Delete(data);
        }
    }
}
