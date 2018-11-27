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
        List<School> schools = new List<School>();

        private void dellAllErr()
        {
            nameErr.Content = "";
            lastNameErr.Content = "";
            dateErr.Content = "";
        }

        private void register_click(object sender, RoutedEventArgs e)
        {
            string newFirstName = firstNameInput.Text;
            string newLastName = lastNameInput.Text;
            DateTime newDate = dateInput.SelectedDate.Value.Date;

            Person newPerson = new Person(newFirstName, newLastName, newDate);

            PersonValidator personValidator = new PersonValidator();

            FluentValidation.Results.ValidationResult results = personValidator.Validate(newPerson);

            dellAllErr();

            if (results.IsValid)
            {
                people.Add(newPerson);
            }
            else
            {
                foreach (FluentValidation.Results.ValidationFailure failure in results.Errors)
                {
                    if (failure.PropertyName == "FirstName")
                    {
                        nameErr.Content = failure.ErrorMessage;
                    }
                    else if (failure.PropertyName == "LastName")
                    {
                        lastNameErr.Content = failure.ErrorMessage;
                    }
                    else if (failure.PropertyName == "Date")
                    {
                        dateErr.Content = failure.ErrorMessage;
                    }
                }
            }

            string schoolName = schoolInput.Text;
            string schoolClassName = classInput.Text;

            bool schoolExist = false;
            bool classExist = false;

            if (schools.Any())
            {
                foreach (School school in schools)
                {
                    if (school.Name == schoolName)
                    {
                        schoolExist = true;
                        foreach (Class schoolClass in school.Classes)
                        {
                            if (schoolClass.Name == schoolClassName)
                            {
                                classExist = true;
                                schoolClass.People.Add(newPerson);
                            }
                            else
                            {
                                school.Classes.Add(new Class(schoolClassName, new List<Person> { newPerson }));
                            }
                        }
                    }
                    else
                    {
                        schools.Add(new School(schoolName, new List<Class> { new Class(schoolClassName, new List<Person> { newPerson }) }));
                    }
                }
            }
            else
            {
                schools.Add(new School(schoolName, new List<Class> { new Class(schoolClassName, new List<Person> { newPerson }) }));
            }
        }
    }
}
