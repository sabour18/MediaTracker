using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Review
{
    public Guid ReviewId { get; set; }

    public Guid UserId { get; set; }

    public Guid MediaId { get; set; }

    public string? Review1 { get; set; }

    public DateTime? ReviewedAt { get; set; }

    public decimal? Rating { get; set; }

    public virtual Medium Media { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
