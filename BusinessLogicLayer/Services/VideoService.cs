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


            var data = DataAccessFactory.VideoDataAccess().Get();
            var videos = new List<VideoModel>();

            foreach (var item in data)
            {
                var vdo = new VideoModel()
                {
                    Id = item.Id,
                    VideoTitle = item.VideoTitle,
                    Description = item.Description,
                    Status = item.Status,
                    UserId = item.UserId,
                    UserName= item.User.Login.Name,
                    VideoPath = item.VideoPath,
                    UploadDate = item.UploadDate,
                    CategoryId = item.CategoryId,
                    CategoryName = item.Category.Name,

                };
                videos.Add(vdo);
            }
            return videos;
        }

        public static VideoModel Get(int id)
        {
            var item = DataAccessFactory.VideoDataAccess().Get(id);
            var vdo = new VideoModel()
            {
                Id = item.Id,
                VideoTitle = item.VideoTitle,
                Description = item.Description,
                Status = item.Status,
                UserId = item.UserId,
                UserName = item.User.Login.Name,
                VideoPath = item.VideoPath,
                UploadDate = item.UploadDate,
                CategoryId = item.CategoryId,
                CategoryName = item.Category.Name,

            };
            return vdo;
        }

        public static void Create(VideoModel video)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<VideoModel, Video>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Video>(video);
            var isCreated = DataAccessFactory.VideoDataAccess().Create(data);
            if (!isCreated) throw new Exception("Video not uploaded");
        }

        public static void Update(VideoModel video)

        {
            Video vid = new Video();
            Category cat = new Category();

            int loginId = Convert.ToInt32(video.UserId);
            int catId = Convert.ToInt32(video.CategoryId);

            vid.Id = video.Id;
            vid.VideoTitle = video.VideoTitle;
            vid.Description = video.Description;
            vid.Status = video.Status;
            vid.UserId = loginId;
            vid.VideoPath = video.VideoPath;
            vid.UploadDate = video.UploadDate;
            vid.CategoryId = catId;

            var isUpdatedForVideo = DataAccessFactory.VideoDataAccess().Update(vid);
            var isUpdatedForCategory = DataAccessFactory.CategoryDataAccess().Update(cat);

            if (!isUpdatedForVideo) throw new Exception("Video : Video Model not updated");
        }

        public static void Delete(int id)
        {
            var isDeleted = DataAccessFactory.VideoDataAccess().Delete(id);
            if (!isDeleted) throw new Exception("Video not deleted");
        }
    }
}
