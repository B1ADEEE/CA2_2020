using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_2020
{
    public abstract class Employee
    {
        //PROPERTIES
        public string FirstName { get; set; }
        public string SurName { get; set; }

        //METHODS
        public abstract decimal CalculateMonthlyPay();
    }
    public class FullTimeEmplyee : Employee
    {
        public override decimal CalculateMonthlyPay()
        {
            throw new NotImplementedException();
        }
    }
    public class PartTimeEmplyee : Employee
    {
        public override decimal CalculateMonthlyPay()
        {
            throw new NotImplementedException();
        }
    }
}
