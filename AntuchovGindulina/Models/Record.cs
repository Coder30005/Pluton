using System;
using System.Collections.Generic;

namespace AntuchovGindulina.Models;

public partial class Record
{
    public int Id { get; set; }

    public DateTime ArrivalDate { get; set; }

    public string DateOfDeparture { get; set; } = null!;

    public int GuestsId { get; set; }

    public int RoomsId { get; set; }

    public virtual ICollection<Check> Checks { get; set; } = new List<Check>();

    public virtual Guest Guests { get; set; } = null!;

    public virtual Room Rooms { get; set; } = null!;
}
