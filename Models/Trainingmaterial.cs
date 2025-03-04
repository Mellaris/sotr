using System;
using System.Collections.Generic;

namespace Sotrydniki.Models;

public partial class Trainingmaterial
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly Approvaldate { get; set; }

    public DateOnly Lastmodifieddate { get; set; }

    public string? Status { get; set; }

    public string? Type { get; set; }

    public string? Area { get; set; }

    public int? Authorid { get; set; }

    public virtual Employee? Author { get; set; }
}
