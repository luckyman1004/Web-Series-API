using AutoMapper;
using BusinessEntityLayer;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class MywatchlistService
    {
        public static List<MywatchlistModel> Get()
        {
            var data = DataAccessFactory.MywatchlistDataAccess().Get();
            var withList = new List<MywatchlistModel>();
            foreach (var item in data)
            {
                var wl = new MywatchlistModel()
                {
                    Id = item.Id,
                    UserID = item.UserID,
                    Name = item.User.Login.Name
                };
                withList.Add(wl);
            }
            return withList;
        }

        public static void Create(MywatchlistModel p)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<MywatchlistModel, Mywatchlist>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Mywatchlist>(p);
            var da = DataAccessFactory.MywatchlistDataAccess();
            da.Create(data);
        }

        public static void Update(MywatchlistModel p)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<MywatchlistModel, Mywatchlist>();

            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Mywatchlist>(p);
            DataAccessFactory.MywatchlistDataAccess().Update(data);
        }

        public static void Delete(MywatchlistModel p)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<MywatchlistModel, Mywatchlist>();

            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Mywatchlist>(p);
            DataAccessFactory.MywatchlistDataAccess().Delete(data);
        }
    }
}
