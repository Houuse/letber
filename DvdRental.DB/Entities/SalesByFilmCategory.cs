using System;
using System.Collections.Generic;

namespace DvdRental.DB.Entities;

public partial class SalesByFilmCategory
{
    public string? Category { get; set; }

    public decimal? TotalSales { get; set; }
}
