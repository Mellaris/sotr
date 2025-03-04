using System;
using System.Collections.Generic;

namespace Sotrydniki.Models;

public partial class Candidate
{
    public int Id { get; set; }

    public string Fullname { get; set; } = null!;

    public DateOnly Applicationdate { get; set; }

    public string Activitydirection { get; set; } = null!;

    public string Resume { get; set; } = null!;
}
