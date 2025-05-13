using System;
using System.Collections.Generic;

namespace EventVenueBookingSystem.Models;

public partial class Event1
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly Date { get; set; }
}
