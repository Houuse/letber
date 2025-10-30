using System;
using System.Collections.Generic;

namespace DvdRental.DB.Entities;

public partial class FilmList
{
    public int? Fid { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Category { get; set; }

    public decimal? Price { get; set; }

    public int? Length { get; set; }

    public string? Actors { get; set; }
}
