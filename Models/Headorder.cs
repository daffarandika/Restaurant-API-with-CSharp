using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RestaurantAPI.Models;

public partial class Headorder
{
    public int Orderid { get; set; }

    public int Employeeid { get; set; }

    public int Memberid { get; set; }

    public DateTime Date { get; set; }

    public string Payment { get; set; } = null!;

    public string Bank { get; set; } = null!;


    public virtual ICollection<Detailorder> Detailorders { get; } = new List<Detailorder>();
    [JsonIgnore]
    public virtual Employee Employee { get; set; } = null!;
    [JsonIgnore]
    public virtual Member Member { get; set; } = null!;
}
