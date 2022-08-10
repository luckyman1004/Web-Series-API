using System;
using System.Collections.Generic;
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

       
        public virtual UserModel User { get; set; }
        public virtual CategoryModel Category { get; set; }
        public virtual FeaturedVideoModel FeaturedVideo { get; set; }
    }
}
    

