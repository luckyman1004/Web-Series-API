using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
  public  class VideoModel
    {
        
        public int Id { get; set; }
        public string VideoTitle { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Nullable<int> UserId { get; set; }
        public string VideoPath { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string Name { get; set; }


        //public virtual ICollection<ArchiveModel> Archives { get; set; }
        public virtual CategoryModel Category { get; set; }
        
        //[JsonIgnore]
        //public virtual ICollection<FeaturedVideoModel> FeaturedVideos { get; set; }
        public virtual UserModel User { get; set; }
    }
}
    

