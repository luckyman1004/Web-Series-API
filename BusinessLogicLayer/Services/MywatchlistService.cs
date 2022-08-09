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
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Mywatchlist, MywatchlistModel>();
                c.CreateMap<User, UserModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.MywatchlistDataAccess();
            var data = mapper.Map<List<MywatchlistModel>>(da.Get());
            return data;
        }
    }
}
