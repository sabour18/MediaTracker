using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class WatchedList
{
    public Guid WatchedId { get; set; }

    public Guid UserId { get; set; }

    public Guid MediaId { get; set; }

    public virtual Medium Media { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
