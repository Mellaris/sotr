using System;
using System.Collections.Generic;

namespace Sotrydniki.Models;

public partial class Employeeabsence
{
    public int Absenceid { get; set; }

    public int? Employeeid { get; set; }

    public DateOnly Startdate { get; set; }

    public DateOnly Enddate { get; set; }

    public int AbsencetypeId { get; set; }

    public int? Replacementid { get; set; }

    public virtual Abscenetype Absencetype { get; set; } = null!;

    public virtual Employee? Employee { get; set; }

    public virtual Employee? Replacement { get; set; }
}
