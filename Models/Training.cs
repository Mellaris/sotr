using System;
using System.Collections.Generic;

namespace Sotrydniki.Models;

public partial class Training
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Classification { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
