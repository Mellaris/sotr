using System;
using System.Collections.Generic;

namespace Sotrydniki.Models;

public partial class Calendar
{
    public int Calendarid { get; set; }

    public string Name { get; set; } = null!;

    public string? Type { get; set; }

    public int? Ownerid { get; set; }

    public int? Departmentid { get; set; }
}
