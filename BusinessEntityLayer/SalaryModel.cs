using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class SalaryModel
    {
        public int Id { get; set; }
        public double Salary1 { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<UserModel> Users { get; set; }
    }
}
