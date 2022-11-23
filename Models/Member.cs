using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RestaurantAPI.Models;

public partial class Member
{
    public int Memberid { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Handphone { get; set; } = null!;

    public DateTime Joindate { get; set; }

    public virtual ICollection<Headorder> Headorders { get; } = new List<Headorder>();
}
