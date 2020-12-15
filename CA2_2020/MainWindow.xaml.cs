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
        ObservableCollection<Employee> employee= new ObservableCollection<Employee>();
        ObservableCollection<Employee> filteremployee= new ObservableCollection<Employee>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListBoxEmployeeBOX_Loaded(object sender, RoutedEventArgs e)
        {
            Employee e1= new PartTimeEmployee("Jane","Jones","PartTime",72,1);
            Employee e2 = new FullTimeEmployee("Joe","Murphy","FullTime",54);
            Employee e3 = new PartTimeEmployee("John", "Smith","PartTime",4,21);
            Employee e4 = new FullTimeEmployee("Jess", "Walsh","FullTime",83);
            employee.Add(e1);
            employee.Add(e2);
            employee.Add(e3);
            employee.Add(e4);
            ListBoxEmployeeBOX.ItemsSource = employee;
        }

        private void FirstNameTBX_GotFocus(object sender, RoutedEventArgs e)
        {
            FirstNameTBX.Clear();
        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            string firstname = FirstNameTBX.Text;
            string surname = SurnameTBX.Text;
            string salery = SalaryTBX.Text;
            string hoursworked = HoursWorkedTBX.Text;
            string hourlyrate = HourlyRateTBX.Text;
            if (FullTimeRAD.IsChecked == true)
            {
                string joblevel = "FullTime";
                decimal salaryv1 = Convert.ToDecimal(salery);
                Employee employees = new FullTimeEmployee(firstname, surname, joblevel,salaryv1);
                employee.Add(employees);
            }
            else
            {
                string joblevel = "PartTime";
                decimal hoursworkedv1 = Convert.ToDecimal(hoursworked);
                double hourlyratev1 = Convert.ToDouble(hourlyrate);
                Employee employees = new PartTimeEmployee(firstname, surname, joblevel,hoursworkedv1,hourlyratev1);
                employee.Add(employees);
            }
        }

        private void ClearBTN_Click(object sender, RoutedEventArgs e)
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

        }

        private void DeleteBTN_Click(object sender, RoutedEventArgs e)
        {
            Employee SelectedEmployee = ListBoxEmployeeBOX.SelectedItem as Employee;
            employee.Remove(SelectedEmployee);
        }

        private void SurnameTBX_GotFocus(object sender, RoutedEventArgs e)
        {
            SurnameTBX.Clear();
        }

        private void SalaryTBX_GotFocus(object sender, RoutedEventArgs e)
        {
            SurnameTBX.Clear();
        }

        private void HoursWorkedTBX_GotFocus(object sender, RoutedEventArgs e)
        {
            HoursWorkedTBX.Clear();
        }

        private void HourlyRateTBX_GotFocus(object sender, RoutedEventArgs e)
        {
            HourlyRateTBX.Clear();
        }

        private void ListBoxEmployeeBOX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee SelectedEmployee = ListBoxEmployeeBOX.SelectedItem as Employee;
            if(SelectedEmployee != null)
            {
                FirstNameTBX.Text = SelectedEmployee.FirstName;
                SurnameTBX.Text = SelectedEmployee.SurName;
                if (SelectedEmployee.JobLevel == "FullTime")
                {
                    FullTimeRAD.IsChecked = true;
                    //SalaryTBX.Text = SelectedEmployee.
                    
                }
                else
                {
                    PartTimeRAD.IsChecked = true;
                    
                }
            }
        }

        private void FullTimeCHECK_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void PartTimeCHECK_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
