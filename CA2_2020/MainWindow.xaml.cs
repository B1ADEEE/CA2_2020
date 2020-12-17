using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CA2_2020
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Employee> employee= new ObservableCollection<Employee>();                                      //
        ObservableCollection<FullTimeEmployee> FullTimePeople= new ObservableCollection<FullTimeEmployee>();
        ObservableCollection<PartTimeEmployee> PartTimePeople = new ObservableCollection<PartTimeEmployee>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListBoxEmployeeBOX_Loaded(object sender, RoutedEventArgs e)
        {
            Employee e1= new PartTimeEmployee("Jane","Jones","PartTime",72,1);                                              //making the people in the employee class
            PartTimeEmployee e1v2 = new PartTimeEmployee("John", "Smith", "PartTime", 4, 21);                               //making the people for that group
            Employee e2 = new FullTimeEmployee("Joe","Murphy","FullTime",54);                                               
            FullTimeEmployee e2v2 = new FullTimeEmployee("Joe", "Murphy", "FullTime", 54);
            Employee e3 = new PartTimeEmployee("John", "Smith","PartTime",4,21);
            PartTimeEmployee e3v2 = new PartTimeEmployee("John", "Smith", "PartTime", 4, 21);
            Employee e4 = new FullTimeEmployee("Jess", "Walsh","FullTime",83);
            FullTimeEmployee e4v2 = new FullTimeEmployee("Jess", "Walsh", "FullTime", 83);
            employee.Add(e1);                                                                                               //adding people to the list for the employee class
            PartTimePeople.Add(e1v2);                                                                                       //indivisually adding each perosn to ther erespective group at first to help filtering later on
            employee.Add(e2);
            FullTimePeople.Add(e2v2);
            employee.Add(e3);
            PartTimePeople.Add(e3v2);
            employee.Add(e4);
            FullTimePeople.Add(e4v2);
            ListBoxEmployeeBOX.ItemsSource = employee;                                                                      //filling the empty table with just emplyee at first
            employee.OrderBy(x => x.SurName).ToList();                                                                      //Sorts them alphabetically 
            FullTimePeople.OrderBy(x => x.SurName).ToList();
            PartTimePeople.OrderBy(x => x.SurName).ToList();
        }

        private void FirstNameTBX_GotFocus(object sender, RoutedEventArgs e)
        {
            FirstNameTBX.Clear();                                                                                           //Clears when you click into it
        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            string firstname = FirstNameTBX.Text;                                                                           //setting the different boxs as a string
            string surname = SurnameTBX.Text;
            string salery = SalaryTBX.Text;
            string hoursworked = HoursWorkedTBX.Text;
            string hourlyrate = HourlyRateTBX.Text;
            if (FullTimeRAD.IsChecked == true)                                                                              //if the Full Time Radio button is checked i give the person fulltime 
            {
                string joblevel = "FullTime";
                decimal salaryv1 = Convert.ToDecimal(salery);
                FullTimeEmployee employees = new FullTimeEmployee(firstname, surname, joblevel,salaryv1);                   //creating the new employee and also setting it its indivisual class and employee as backup
                Employee employeesv2 = new FullTimeEmployee(firstname, surname, joblevel, salaryv1);
                FullTimePeople.Add(employees);
                employee.Add(employeesv2);
            }
            else
            {
                string joblevel = "PartTime";                                                                               //if the button is Full Time is not checked it must mean its part time
                decimal hoursworkedv1 = Convert.ToDecimal(hoursworked);
                double hourlyratev1 = Convert.ToDouble(hourlyrate);
                PartTimeEmployee employees = new PartTimeEmployee(firstname, surname, joblevel,hoursworkedv1,hourlyratev1); //creating the new employee and also setting it its indivisual class and employee as backup
                Employee employeesv2 = new PartTimeEmployee(firstname, surname, joblevel, hoursworkedv1, hourlyratev1);
                PartTimePeople.Add(employees);
                employee.Add(employees);
            }
        }

        private void ClearBTN_Click(object sender, RoutedEventArgs e)                                                       //all this clears each sector when the clear button is pressed
        {
            FirstNameTBX.Clear();
            SurnameTBX.Clear();
            FullTimeRAD.IsChecked = false;
            PartTimeRAD.IsChecked = false;
            SalaryTBX.Clear();
            HourlyRateTBX.Clear();
            HoursWorkedTBX.Clear();
            MonthlyPayTBK.Text = "";
        }

        private void UpdateBTN_Click(object sender, RoutedEventArgs e)
        {
            Employee TheEmployee = ListBoxEmployeeBOX.SelectedItem as Employee;                                             //getting the selected item
            FullTimeEmployee TheFull = ListBoxEmployeeBOX.SelectedItem as FullTimeEmployee;
            PartTimeEmployee ThePart = ListBoxEmployeeBOX.SelectedItem as PartTimeEmployee;
            string newFirst = FirstNameTBX.Text;                                                                            //setting the text in the different boxs as a string
            string newSur = SurnameTBX.Text;
            string newSalary = SalaryTBX.Text;
            string newPosition;
            if (FullTimeRAD.IsChecked == true)      
            {
                newPosition = "FullTime";
            }
            else
            {
                newPosition = "PartTime";
            }
            string newHours = HoursWorkedTBX.Text;
            string newRate = HourlyRateTBX.Text;
            for (int i = 0; i < FullTimePeople.Count; i++)                                                                  //for the amount of people in full time people do the following
            {
                if (TheFull == FullTimePeople[i])                                                                           //if the selected person is equal to that of in full time person class
                {
                    FullTimePeople[i].FirstName = newFirst;                                                                 //setting that employee with the new and updated info 
                    FullTimePeople[i].SurName = newSur;
                    FullTimePeople[i].Salary = Convert.ToDecimal(newSalary);
                    FullTimePeople[i].JobLevel = newPosition;
                    if (TheEmployee == FullTimePeople[i])                                                                   //backup name for employee
                    {
                        employee[i].FirstName = newFirst;
                        employee[i].SurName = newSur;
                        employee[i].JobLevel = newPosition;
                    }
                }
            }
            for (int i = 0; i < PartTimePeople.Count; i++)                                                                  //for the amount of people in part time people do the following
            {
                if (ThePart == PartTimePeople[i])                                                                           //if the selected person is equal to that of in part time person class
                {
                    PartTimePeople[i].FirstName = newFirst;                                                                 //setting that employee with the new and updated info 
                    PartTimePeople[i].SurName = newSur;
                    PartTimePeople[i].HourlyRate = Convert.ToDecimal(newRate);
                    PartTimePeople[i].HoursWorked = Convert.ToDouble(newHours);
                    PartTimePeople[i].JobLevel = newPosition;
                    if (TheEmployee == PartTimePeople[i])                                                                   //backup name for employee
                    {
                        employee[i].FirstName = newFirst;
                        employee[i].SurName = newSur;
                        employee[i].JobLevel = newPosition;
                    }
                }
            }
        }

        private void DeleteBTN_Click(object sender, RoutedEventArgs e)
        {
            Employee SelectedEmployee = ListBoxEmployeeBOX.SelectedItem as Employee;                                        //getting the selected employee ready to delete
            FullTimeEmployee FullSelectedEmployee = ListBoxEmployeeBOX.SelectedItem as FullTimeEmployee;
            PartTimeEmployee PartSelectedEmployee = ListBoxEmployeeBOX.SelectedItem as PartTimeEmployee;
            employee.Remove(SelectedEmployee);                                                                              //that employee gets removed from the class
            FullTimePeople.Remove(FullSelectedEmployee);
            PartTimePeople.Remove(PartSelectedEmployee);

        }

        private void SurnameTBX_GotFocus(object sender, RoutedEventArgs e)              
        {
            SurnameTBX.Clear();                                                                                             //Clears when you click into it
        }

        private void SalaryTBX_GotFocus(object sender, RoutedEventArgs e)
        {
            SalaryTBX.Clear();                                                                                              //Clears when you click into it
        }

        private void HoursWorkedTBX_GotFocus(object sender, RoutedEventArgs e)
        {
            HoursWorkedTBX.Clear();                                                                                         //Clears when you click into it
        }

        private void HourlyRateTBX_GotFocus(object sender, RoutedEventArgs e)
        {
            HourlyRateTBX.Clear();                                                                                          //Clears when you click into it
        }

        private void ListBoxEmployeeBOX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee SelectedEmployee = ListBoxEmployeeBOX.SelectedItem as Employee;                                        //getting the selected employee
            FullTimeEmployee FullSelectedEmployee = ListBoxEmployeeBOX.SelectedItem as FullTimeEmployee;
            PartTimeEmployee PartSelectedEmployee = ListBoxEmployeeBOX.SelectedItem as PartTimeEmployee;
            if (SelectedEmployee != null)                                                                                   // as long as there is an emplyee that is selected
            {
                FirstNameTBX.Text = SelectedEmployee.FirstName;                                                             //prints the data of that employee in the corilated boxs
                SurnameTBX.Text = SelectedEmployee.SurName;
                if (SelectedEmployee.JobLevel == "FullTime")                                                                //if the job level is FullTime do the following
                {
                    FullTimeRAD.IsChecked = true;
                    SalaryTBX.Text = FullSelectedEmployee.Salary.ToString();
                    MonthlyPayTBK.Text = FullSelectedEmployee.CalculateMonthlyPay().ToString();
                    HoursWorkedTBX.Clear();
                    HourlyRateTBX.Clear();
                }
                else
                {
                    PartTimeRAD.IsChecked = true;
                    HourlyRateTBX.Text = PartSelectedEmployee.HourlyRate.ToString();
                    HoursWorkedTBX.Text = PartSelectedEmployee.HoursWorked.ToString();
                    MonthlyPayTBK.Text = PartSelectedEmployee.CalculateMonthlyPay().ToString();
                    SalaryTBX.Clear();
                }
            }
        }

        private void FullTimeCHECK_Checked(object sender, RoutedEventArgs e)
        {
            if (FullTimeCHECK.IsChecked == true)                                                                            //if the fulltime check boc is checked list only full time ppl
            {   
                ListBoxEmployeeBOX.ItemsSource = FullTimePeople;
            }
        }

        private void PartTimeCHECK_Checked(object sender, RoutedEventArgs e)
        {
            if (PartTimeCHECK.IsChecked == true)                                                                            //if the fulltime check boc is checked list only part time ppl
            {
                ListBoxEmployeeBOX.ItemsSource = PartTimePeople;
            }
        }

        private void FullTimeCHECK_Unchecked(object sender, RoutedEventArgs e)
        {
            if (FullTimeCHECK.IsChecked == false)                                                                           //if the fulltime check boc is checked list only Full time ppl
            {
                ListBoxEmployeeBOX.ItemsSource = employee;
            }
        }

        private void PartTimeCHECK_Unchecked(object sender, RoutedEventArgs e)
        {
            if(PartTimeCHECK.IsChecked == false)
            {
                ListBoxEmployeeBOX.ItemsSource = employee;
            }
        }
    }
}
