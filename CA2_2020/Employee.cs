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
        protected string FirstName { get; set; }
        protected string SurName { get; set; }
        public Employee(string firstname, string surname)
        {
            FirstName = firstname;
            SurName = surname;
        }
       public override string ToString()
        {
           return string.Format($"{SurName}, {FirstName}");
        }

        //METHODS
        public abstract decimal CalculateMonthlyPay();
    }
     public class FullTimeEmployee : Employee
    {

        public decimal Salary { get; set; }
        public FullTimeEmployee(string firstname, string surname):base(firstname, surname)
        {
        }
        public override decimal CalculateMonthlyPay()
        {
            decimal MonthlyPay = Salary / 12;
            return MonthlyPay;
        }
    }
    public class PartTimeEmployee : Employee
    {
        public decimal HourlyRate { get; set; }
        public double HoursWorked { get; set; }
        public PartTimeEmployee(string firstname,string surname):base(firstname,surname)
        {
        }
        public override decimal CalculateMonthlyPay()
        {
            decimal MonthlyPay = HourlyRate * (decimal)HoursWorked;
            return MonthlyPay;
        }
    }
}
