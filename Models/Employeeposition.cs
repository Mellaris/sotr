using System;
using System.Collections.Generic;

namespace Sotrydniki.Models;

public partial class Employeeposition
{
    public int Employeeid { get; set; }

    public int Positionid { get; set; }

    public int? Departmentid { get; set; }

    public int? Supervisorid { get; set; }

    public int? Assistantid { get; set; }

    public virtual Employee? Assistant { get; set; }

    public virtual Department? Department { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Position Position { get; set; } = null!;

    public virtual Employee? Supervisor { get; set; }
}
