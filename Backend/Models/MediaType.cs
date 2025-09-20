using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class MediaType
{
    public Guid TypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<FavouriteList> FavouriteList { get; set; } = new List<FavouriteList>();

    public virtual ICollection<Media> Media { get; set; } = new List<Media>();
}
