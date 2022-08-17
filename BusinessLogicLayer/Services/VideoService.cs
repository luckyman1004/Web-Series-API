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
    public class VideoService
    {
        public static List<VideoModel> Get()
        {
            //var data = DataAccessFactory.VideoDataAccess().Get();
            //var videos = new List<VideoModel>();

            //foreach (var item in data)
            //{
            //    var vdo = new VideoModel()
            //    {
            //        Id = item.Id,
            //        VideoTitle = item.VideoTitle,
            //        Description = item.Description,
            //        Status = item.Status,
            //        UserId = item.UserId,
            //        VideoPath = item.VideoPath,
            //        UploadDate = item.UploadDate,
            //        Phone = item.User.Phone,
            //        Address = item.User.Address1

            //    };
            //    videos.Add(vdo);
            //}
            //return videos;

            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Video, VideoModel>();
                c.CreateMap<User, UserModel>();
                c.CreateMap<Login, LoginModel>();
                c.CreateMap<Salary, SalaryModel>(); 
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.VideoDataAccess();
            var data = mapper.Map<List<VideoModel>>(da.Get());
            return data;
        }

        public static VideoModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Video, VideoModel>();
                c.CreateMap<User, UserModel>();
                c.CreateMap<Login, LoginModel>();
                c.CreateMap<Salary, SalaryModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.VideoDataAccess();
            var data = mapper.Map<VideoModel>(da.Get(id));
            return data;
        }

        public static void Create(VideoModel video)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<VideoModel, Video>();
                c.CreateMap<UserModel, User>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Video>(video);
            var isCreated = DataAccessFactory.VideoDataAccess().Create(data);
            if (!isCreated) throw new Exception("Video not uploaded");
        }

        public static void Update(VideoModel video)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<VideoModel, Video>();
                c.CreateMap<UserModel, User>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<VideoModel, Video>(video);
            var isUpdated = DataAccessFactory.VideoDataAccess().Update(data);
            if (!isUpdated) throw new Exception("Vidoe not updated");
        }

        public static void Delete(int id)
        {
            var isDeleted = DataAccessFactory.VideoDataAccess().Delete(id);
            if (!isDeleted) throw new Exception("Video not deleted");
        }
    }
}
