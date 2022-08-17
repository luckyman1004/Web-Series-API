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
    public class FeaturedVideoService
    {
        public static List<FeaturedVideoModel> Get()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<FeaturedVideo, FeaturedVideoModel>();
                c.CreateMap<Video, VideoModel>();
                c.CreateMap<User, UserModel>();
                c.CreateMap<Login, LoginModel>();
                c.CreateMap<Salary, SalaryModel>();
                c.CreateMap<Category, CategoryModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.FeaturedVideoDataAccess();
            var data = mapper.Map<List<FeaturedVideoModel>>(da.Get());
            return data;
        }
        public static FeaturedVideoModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<FeaturedVideo, FeaturedVideoModel>();
                c.CreateMap<Video, VideoModel>();
                c.CreateMap<User, UserModel>();
                c.CreateMap<Login, LoginModel>();
                c.CreateMap<Salary, SalaryModel>();
                c.CreateMap<Category, CategoryModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.FeaturedVideoDataAccess();
            var data = mapper.Map<FeaturedVideoModel>(da.Get(id));
            return data;
        }

        public static void Create(FeaturedVideoModel fvid)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<FeaturedVideoModel, FeaturedVideo>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<FeaturedVideo>(fvid);
            var isCreated = DataAccessFactory.FeaturedVideoDataAccess().Create(data);
            if (!isCreated) throw new Exception("Featured Video not inserted");
        }

        public static void Update(FeaturedVideoModel fvid)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<FeaturedVideoModel, FeaturedVideo>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<FeaturedVideoModel, FeaturedVideo>(fvid);
            var isUpdated = DataAccessFactory.FeaturedVideoDataAccess().Update(data);
            if (!isUpdated) throw new Exception("Featured Video is not updated");
        }

        public static void Delete(int id)
        {
            var isDeleted = DataAccessFactory.FeaturedVideoDataAccess().Delete(id);
            if (!isDeleted) throw new Exception("Featured Video not deleted");
        }
    }
}
