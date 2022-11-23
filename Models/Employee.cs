using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RestaurantAPI.Models;

public partial class Employee
{
    public int Employeeid { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Handphone { get; set; } = null!;

    public string Position { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Headorder> Headorders { get; } = new List<Headorder>();
}
