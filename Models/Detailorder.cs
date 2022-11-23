using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RestaurantAPI.Models;

public partial class Detailorder
{
    public int Detailid { get; set; }

    public int Orderid { get; set; }

    public int Menuid { get; set; }

    public int Qty { get; set; }

    public int Price { get; set; }

    public string Status { get; set; } = null!;
    [JsonIgnore]
    public virtual Menu Menu { get; set; } = null!;
    [JsonIgnore]
    public virtual Headorder Order { get; set; } = null!;
}
