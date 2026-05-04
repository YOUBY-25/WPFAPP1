using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace EmployeeApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // ===== CLASS MODEL =====
        public class Employee
        {
            public string LastName { get; set; }
            public double Salary { get; set; }
            public int YearOfEmployment { get; set; }

            public int GetExperience()
            {
                return DateTime.Now.Year - YearOfEmployment;
            }

            public int GetDaysWorked()
            {
                DateTime startDate = new DateTime(YearOfEmployment, 1, 1);
                return (DateTime.Now - startDate).Days;
            }
        }

        // ===== CREATE OBJECT FROM INPUT =====
        private Employee GetEmployeeFromInput()
        {
            return new Employee
            {
                LastName = LastNameBox.Text,
                Salary = double.TryParse(SalaryBox.Text, out double s) ? s : 0,
                YearOfEmployment = int.TryParse(YearBox.Text, out int y) ? y : 0
            };
        }

        // ===== EVENT 1 =====
        private void CalcExperience_Click(object sender, RoutedEventArgs e)
        {
            var emp = GetEmployeeFromInput();
            ResultText.Text = $"Employee {emp.LastName}\nExperience: {emp.GetExperience()} years";
        }

        // ===== EVENT 2 =====
        private void CalcDays_Click(object sender, RoutedEventArgs e)
        {
            var emp = GetEmployeeFromInput();
            ResultText.Text = $"Employee {emp.LastName}\nDays worked: {emp.GetDaysWorked()} days";
        }

        // ===== VALIDATION: ONLY NUMBERS =====
        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        // ===== BLOCK SPACE =====
        private void BlockSpace(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}