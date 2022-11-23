using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RestaurantAPI.Models;

public partial class Menu
{
    public int Menuid { get; set; }

    public string Name { get; set; } = null!;

    public string Price { get; set; } = null!;

    public string Photo { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Detailorder> Detailorders { get; } = new List<Detailorder>();
}
