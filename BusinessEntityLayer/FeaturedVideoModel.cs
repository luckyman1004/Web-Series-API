using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class FeaturedVideoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public Nullable<int> VideoId { get; set; }

        public virtual VideoModel Video { get; set; }
    }
}
