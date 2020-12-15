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
        public string JobLevel { get; set; }
        public Employee(string firstname, string surname,string joblevel)
        {
            FirstName = firstname;
            SurName = surname;
            JobLevel = joblevel; 
        }
       public override string ToString()
        {
           return string.Format($"{SurName.ToUpper()}, {FirstName} -- {JobLevel}");
        }

        //METHODS
        public abstract decimal CalculateMonthlyPay();
    }
     public class FullTimeEmployee : Employee
    {

        public decimal Salary { get; set; }
        public FullTimeEmployee(string firstname, string surname,string joblevel,decimal salary):base(firstname, surname,joblevel)
        {
            Salary = salary;
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
        public PartTimeEmployee(string firstname,string surname,string joblevel,decimal hourlyrate,double hoursworked):base(firstname,surname,joblevel)
        {
            HourlyRate = hourlyrate;
            HoursWorked = hoursworked;
        }
        public override decimal CalculateMonthlyPay()
        {
            decimal MonthlyPay = HourlyRate * (decimal)HoursWorked;
            return MonthlyPay;
        }
    }
}
