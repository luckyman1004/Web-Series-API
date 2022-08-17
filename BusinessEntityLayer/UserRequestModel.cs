using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class UserRequestModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string RequestTitle { get; set; }
        public string RequestCategorie { get; set; }
        public string ImdbLink { get; set; }

        public virtual UserModel User { get; set; }
    }
}
