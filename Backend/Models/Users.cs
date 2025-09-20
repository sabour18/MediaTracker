using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Users
{
    public Guid UserId { get; set; }

    public string Username { get; set; } = null!;

    public string? Password { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<FavouriteList> FavouriteList { get; set; } = new List<FavouriteList>();
}
