using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class MywatchlistModel
    {
        public int Id { get; set; }
        public Nullable<int> UserID { get; set; }
        
        //========
        public string Name { get; set; }

        public virtual UserModel User { get; set; }
    }
}
