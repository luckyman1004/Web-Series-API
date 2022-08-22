using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class TokenModel
    {
        public int Id { get; set; }
        public string TokenData { get; set; }
        public string Device { get; set; }
        public string Platfrom { get; set; }
        public string Browser { get; set; }
        public Nullable<System.DateTime> LoginTime { get; set; }
        public Nullable<System.DateTime> ExpiredAt { get; set; }
        public string GMT { get; set; }
        public string OS { get; set; }
        public string Role { get; set; }
        public Nullable<int> LoginId { get; set; }
        public Nullable<int> UserId { get; set; }

        public virtual LoginModel Login { get; set; }
    }
}
