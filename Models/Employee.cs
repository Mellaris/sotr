using System;
using System.Collections.Generic;
using System.Linq;

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

    public virtual ICollection<Employeeposition> EmployeepositionAssistants { get; set; } = new List<Employeeposition>();

    public virtual ICollection<Employeeposition> EmployeepositionEmployees { get; set; } = new List<Employeeposition>();

    public string Positions
    {
        get
        {
            return string.Join(' ', EmployeepositionEmployees.Select(p => p.Position).Select(p => p.Name));
        }
    }

    public virtual ICollection<Employeeposition> EmployeepositionSupervisors { get; set; } = new List<Employeeposition>();

    public virtual ICollection<Trainingmaterial> Trainingmaterials { get; set; } = new List<Trainingmaterial>();

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Training> Training { get; set; } = new List<Training>();
}
