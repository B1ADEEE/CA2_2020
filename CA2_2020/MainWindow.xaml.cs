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
            Employee e1= new PartTimeEmployee("Jane","Jones");
            Employee e2 = new FullTimeEmployee("Joe","Murphy");
            Employee e3 = new PartTimeEmployee("John", "Smith");
            Employee e4 = new FullTimeEmployee("Jess", "Walsh");
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
            //employee.Add(firstname);
            //surName.Add(newSur);
        }

        private void ClearBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
