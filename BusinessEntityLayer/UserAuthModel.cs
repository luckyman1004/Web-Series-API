using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class UserAuthModel : UserModel
    {
        public List<AuthModel> Auths { get; set; }
    }
}
