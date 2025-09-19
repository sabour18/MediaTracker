using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Medium
{
    public Guid MediaId { get; set; }

    public string Title { get; set; } = null!;

    public Guid TypeId { get; set; }

    public virtual Movie? Movie { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual Show? Show { get; set; }

    public virtual MediaType Type { get; set; } = null!;

    public virtual ICollection<WatchedList> WatchedLists { get; set; } = new List<WatchedList>();
}
