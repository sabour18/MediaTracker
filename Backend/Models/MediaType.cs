using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class MediaType
{
    public Guid TypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Medium> Media { get; set; } = new List<Medium>();
}
