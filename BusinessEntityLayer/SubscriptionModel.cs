using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class SubscriptionModel
    {

            public int Id { get; set; }
            public Nullable<int> PackageId { get; set; }
            public Nullable<int> UserId { get; set; }

            public virtual PackageModel Package { get; set; }
            public virtual UserModel User { get; set; }

    }
}
