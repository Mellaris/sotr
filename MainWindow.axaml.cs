using Avalonia.Controls;
using Microsoft.EntityFrameworkCore;
using Sotrydniki.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sotrydniki
{
    public partial class MainWindow : Window
    {
        
        
        public List<Employee> sotrydnikTwo = new List<Employee>();
        public MainWindow()
        {
            InitializeComponent();
            CallBaza();
        }
        private void CallBaza()
        {
            StaticClass.spisokDepartment.Clear();
            StaticClass.spisokDepartment = Helper.DbContext.Departments.Select(user => new Department
            {
                Id = user.Id,
                Name = user.Name,
            }).ToList();
            ListBoxdDol.ItemsSource = StaticClass.spisokDepartment;
            StaticClass.sotrydnik.Clear();
            StaticClass.sotrydnik = Helper.DbContext.Employees.Include(s => s.Positions).Include(a => a.Departments).Select(user => new Employee
            {
                Id = user.Id,
                Name = user.Name,
                Office = user.Office,
                Workphone = user.Workphone,
                Email = user.Email,
                Positions = user.Positions,
                Departments = user.Departments

            }).ToList();
            ListBoxSort.ItemsSource = StaticClass.sotrydnik;
            sotrydnikTwo = StaticClass.sotrydnik.ToList();
        }

        private void ListBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
        {
            var index = (ListBoxdDol.SelectedItem as Department);
            ListBoxSort.ItemsSource = Helper.DbContext.Employees.Include(s => s.Positions).Include(a => a.Departments).Where(x=>x.Departments.Contains(index)).Select(user => new Employee
            {
                Id = user.Id,
                Name = user.Name,
                Office = user.Office,
                Workphone = user.Workphone,
                Email = user.Email,
                Positions = user.Positions,
                Departments = user.Departments

            }).ToList();
        }

        private void Border_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
        {
            if ((ListBoxSort.SelectedItem as Employee) != null)
                new Edit((ListBoxSort.SelectedItem as Employee).Id).ShowDialog(this);
            StaticClass.sotrydnik = Helper.DbContext.Employees.Include(s => s.Positions).Include(s => s.Departments).ToList();

            
        }
    }
}