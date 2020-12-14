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
        List<string> FirstName = new List<string>();
        List<string> surName = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListBoxEmployeeBOX_Loaded(object sender, RoutedEventArgs e)
        {
            //string[] names = { "Jane Jones PT", "Joe Murphy FT", "John Smith PT", "Jess Walsh FT" };
            FirstName.Add("Jane");
            FirstName.Add("Joe");
            FirstName.Add("John");
            FirstName.Add("Jess");
            surName.Add("Jones");
            surName.Add("Murphy");
            surName.Add("Smith");
            surName.Add("Walsh");
            ListBoxEmployeeBOX.ItemsSource = FirstName;
            ListBoxEmployeeBOX.ItemsSource = surName;
        }

        private void FirstNameTBX_GotFocus(object sender, RoutedEventArgs e)
        {
            FirstNameTBX.Clear();
        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            string newFirst = FirstNameTBX.Text;
            string newSur = SurnameTBX.Text;
            FirstName.Add(newFirst);
            surName.Add(newSur);
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
