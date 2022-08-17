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
    public class CategoryService
    {
        public static List<CategoryModel> Get()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Category, CategoryModel>();
                //c.CreateMap<Video, VideoModel>();

                //c.CreateMap<User, UserModel>();
                //c.CreateMap<Login, LoginModel>();
                //c.CreateMap<Salary, SalaryModel>();
                //c.CreateMap<FeaturedVideo, FeaturedVideoModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.CategoryDataAccess();
            var data = mapper.Map<List<CategoryModel>>(da.Get());
            return data;
        }
        public static CategoryModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Category, CategoryModel>();
                c.CreateMap<Video, VideoModel>();
                c.CreateMap<User, UserModel>();
                c.CreateMap<Login, LoginModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.CategoryDataAccess();
            var data = mapper.Map<CategoryModel>(da.Get(id));
            return data;
        }

        public static void Create(CategoryModel cat)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Category, CategoryModel>();
                c.CreateMap<CategoryModel, Category>();
                //c.CreateMap<VideoModel, Video>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Category>(cat);
            var isCreated = DataAccessFactory.CategoryDataAccess().Create(data);
            if (!isCreated) throw new Exception("Category not inserted");
        }

        public static void Update(CategoryModel cat)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<CategoryModel, Category>();
                c.CreateMap<VideoModel, Video>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<CategoryModel, Category>(cat);
            var isUpdated = DataAccessFactory.CategoryDataAccess().Update(data);
            if (!isUpdated) throw new Exception("Category not updated");
        }

        public static void Delete(int id)
        {
            var isDeleted = DataAccessFactory.CategoryDataAccess().Delete(id);
            if (!isDeleted) throw new Exception("category not deleted");
        }
    }
}
