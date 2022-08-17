using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class ReviewModel
    {
        public int Id { get; set; }
        public int VideoId { get; set; }
        public string Comment { get; set; }
        public Nullable<double> Rating { get; set; }
    }
}
