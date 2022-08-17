using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
   public class CategoryModel
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> VideoId { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<VideoModel> Videos { get; set; }
       
    }
}

