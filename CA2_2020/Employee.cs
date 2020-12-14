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
        public decimal Salary { get; set; }
        public override decimal CalculateMonthlyPay()
        {
            decimal MonthlyPay = Salary / 12;
            return MonthlyPay;
        }
    }
    public class PartTimeEmplyee : Employee
    {
        public decimal HourlyRate { get; set; }
        public double HoursWorked { get; set; }
        public override decimal CalculateMonthlyPay()
        {
            decimal MonthlyPay = HourlyRate * (decimal)HoursWorked;
            return MonthlyPay;
        }
    }
}
