using System;
using System.Collections.Generic;

namespace Sotrydniki.Models;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Department> Childdepts { get; set; } = new List<Department>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Department> Parentdepts { get; set; } = new List<Department>();
}
