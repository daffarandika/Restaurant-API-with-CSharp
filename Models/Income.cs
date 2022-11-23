using System;
using System.Collections.Generic;

namespace RestaurantAPI.Models;

public partial class Income
{
    public string Month { get; set; } = null!;

    public string Year { get; set; } = null!;

    public int Income1 { get; set; }
}
