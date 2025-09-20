using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Media
{
    public long MediaId { get; set; }

    public string Title { get; set; } = null!;

    public string? OriginalTitle { get; set; }

    public string? Overview { get; set; }

    public string PosterPath { get; set; } = null!;

    public string? BackdropPath { get; set; }

    public string? MediaType { get; set; }

    public string? OriginalLanguage { get; set; }

    public double Popularity { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public bool Video { get; set; }

    public double VoteAverage { get; set; }

    public int VoteCount { get; set; }

    public string? GenreIds { get; set; }

    public Guid? TypeId { get; set; }

    public virtual ICollection<FavouriteList> FavouriteList { get; set; } = new List<FavouriteList>();

    public virtual MediaType? Type { get; set; }
}
