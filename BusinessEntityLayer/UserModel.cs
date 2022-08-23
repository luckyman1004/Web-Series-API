using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> AccountCreateTime { get; set; }
        public Nullable<System.DateTime> LoginTime { get; set; }
        public Nullable<int> LoginId { get; set; }

        //public Nullable<int> SalaryId { get; set; }
        
        //======================
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        //======================

       
        //[JsonIgnore]
        //public virtual ICollection<ExpansModel> Expanses { get; set; }
        public virtual LoginModel Login { get; set; }
        
        //[JsonIgnore]
        //public virtual ICollection<MywatchlistModel> Mywatchlists { get; set; }
        // public virtual SalaryModel Salary { get; set; }
       
        //[JsonIgnore]
        //public virtual ICollection<SubscriptionModel> Subscriptions { get; set; }
        
       
        //[JsonIgnore]
        //public virtual ICollection<VideoModel> Videos { get; set; }
    }
}
