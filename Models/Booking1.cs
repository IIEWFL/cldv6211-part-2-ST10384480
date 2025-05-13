using System;
using System.Collections.Generic;

namespace EventVenueBookingSystem.Models;

public partial class Booking1
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public DateOnly BookingDate { get; set; }

    public int EventId { get; set; }

    public int VenueId { get; set; }
}
