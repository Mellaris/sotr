using System;
using System.Collections.Generic;

namespace Sotrydniki.Models;

public partial class Position
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Employeeposition> Employeepositions { get; set; } = new List<Employeeposition>();
}
