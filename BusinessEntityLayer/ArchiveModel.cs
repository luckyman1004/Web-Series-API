using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class ArchiveModel
    {
        public int Id { get; set; }
        public Nullable<int> VideoId { get; set; }
        public string Status { get; set; }

        public virtual VideoModel Video { get; set; }
    }
}
