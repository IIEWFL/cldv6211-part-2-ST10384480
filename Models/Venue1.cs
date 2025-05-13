using System;
using System.Collections.Generic;

namespace EventVenueBookingSystem.Models;

public partial class Venue1
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Location { get; set; }

    public int? Capacity { get; set; }
}
