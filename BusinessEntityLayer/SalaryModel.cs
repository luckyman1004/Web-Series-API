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
        public Nullable<double> Salary1 { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> UserId { get; set; }

        public virtual UserModel User { get; set; }
    }
}
