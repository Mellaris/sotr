using System;
using System.Collections.Generic;

namespace Sotrydniki.Models;

public partial class Abscenetype
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Employeeabsence> Employeeabsences { get; set; } = new List<Employeeabsence>();
}
