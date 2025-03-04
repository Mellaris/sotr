using System;
using System.Collections.Generic;

namespace Sotrydniki.Models;

public partial class Firedemployee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Mobilephone { get; set; }

    public DateOnly? Birthdate { get; set; }

    public string Email { get; set; } = null!;

    public DateTime? Dismissdate { get; set; }

    public string? Additionalinfo { get; set; }
}
