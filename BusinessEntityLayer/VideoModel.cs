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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArchiveModel> Archives { get; set; }
        public virtual CategoryModel Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<FeaturedVideoModel> FeaturedVideos { get; set; }
        public virtual UserModel User { get; set; }
    }
}
    

