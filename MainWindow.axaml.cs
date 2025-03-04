using Avalonia.Controls;
using Microsoft.EntityFrameworkCore;
using Sotrydniki.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sotrydniki
{
    public partial class MainWindow : Window
    {
        public List<Department> spisokDepartment = new List<Department>();
        public List<Employee> sotrydnik = new List<Employee>();
        public MainWindow()
        {
            InitializeComponent();
            CallBaza();
        }
        private void CallBaza()
        {
            spisokDepartment.Clear();
            spisokDepartment = Helper.DbContext.Departments.Select(user => new Department
            {
                Id = user.Id,
                Name = user.Name,
            }).ToList();
            ListBoxdDol.ItemsSource = spisokDepartment;
            sotrydnik.Clear();
            sotrydnik = Helper.DbContext.Employees.Include(s => s.EmployeepositionEmployees).ThenInclude(s=>s.Position).Include(s => s.).Select(user => new Employee
            {
                Id = user.Id,
                Name = user.Name,
                Office = user.Office,
                Workphone = user.Workphone,
                Email = user.Email,
                EmployeepositionEmployees = user.EmployeepositionEmployees,


            }).ToList();
            ListBoxSort.ItemsSource = sotrydnik;
        }

        private void ListBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
        {
            int index = ListBoxdDol.SelectedIndex;
        }
    }
}