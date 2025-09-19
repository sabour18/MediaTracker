using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Show
{
    public Guid MediaId { get; set; }

    public string? ImdbId { get; set; }

    public virtual Medium Media { get; set; } = null!;
}
