using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Sotrydniki.Models;
using System;
using System.Linq;

namespace Sotrydniki;

public partial class Edit : Window
{
    int Id = -1;
    public Edit()
    {
        InitializeComponent();
        DepartamentCB.ItemsSource = StaticClass.spisokDepartment.ToList();
        PositionCB.ItemsSource = Helper.DbContext.Positions.ToList();
        CaninetCB.ItemsSource = Helper.DbContext.Employees.ToList();
        StaffGrid.IsEnabled = true;
        RedactB.IsEnabled = false;
        ReadyB.IsEnabled = true;
    }
    public Edit(int Id)
    {
        this.Id = Id;
        InitializeComponent();
        DepartamentCB.ItemsSource = StaticClass.spisokDepartment.ToList();
        PositionCB.ItemsSource = Helper.DbContext.Positions.ToList();
        CaninetCB.ItemsSource = Helper.DbContext.Employees.ToList();

        Employee employee = StaticClass.sotrydnik.FirstOrDefault(s => s.Id == Id);
        Name.Text = employee.Name;
        BDay.SelectedDate = new DateTimeOffset(employee.Birthdate.ToDateTime(new TimeOnly()));
        Phone.Text = employee.Workphone;
        Email.Text = employee.Email;
        DepartamentCB.SelectedItem = employee.Departments;
        PositionCB.SelectedItem = employee.Positions;
        //CaninetCB.SelectedItem = employee.Cabinets;
    }
    private void Redact(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        StaffGrid.IsEnabled = true;
        RedactB.IsEnabled = false;
        ReadyB.IsEnabled = true;
    }
}