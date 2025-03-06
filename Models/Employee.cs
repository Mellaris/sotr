using System;
using System.Collections.Generic;

namespace Sotrydniki.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Mobilephone { get; set; }

    public DateOnly? Birthdate { get; set; }

    public string Workphone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Office { get; set; } = null!;

    public string? Additionalinfo { get; set; }

    public virtual ICollection<Employeeabsence> EmployeeabsenceEmployees { get; set; } = new List<Employeeabsence>();

    public virtual ICollection<Employeeabsence> EmployeeabsenceReplacements { get; set; } = new List<Employeeabsence>();

    public virtual ICollection<Trainingmaterial> Trainingmaterials { get; set; } = new List<Trainingmaterial>();

    public virtual ICollection<Employee> Assistants { get; set; } = new List<Employee>();

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Employee> EmployeesNavigation { get; set; } = new List<Employee>();

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Position> Positions { get; set; } = new List<Position>();

    public virtual ICollection<Employee> Supervisors { get; set; } = new List<Employee>();

    public virtual ICollection<Training> Training { get; set; } = new List<Training>();
}
