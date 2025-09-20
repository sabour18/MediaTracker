using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class FavouriteList
{
    public Guid FavouritesId { get; set; }

    public Guid UserId { get; set; }

    public Guid? TypeId { get; set; }

    public long MediaId { get; set; }

    public virtual Media Media { get; set; } = null!;

    public virtual MediaType? Type { get; set; }

    public virtual Users User { get; set; } = null!;
}
