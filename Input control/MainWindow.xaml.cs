using System;
using System.Collections.Generic;
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
using FluentValidation;

namespace Input_control
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<Person> people = new List<Person>();

        private void register_click(object sender, RoutedEventArgs e)
        {
            string newFirstName = firstNameInput.Text;
            string newLastName = lastNameInput.Text;
            DateTime newDate = dateInput.SelectedDate.Value.Date;

            Person newPerson = new Person(newFirstName, newLastName, newDate);
        }
    }
}
