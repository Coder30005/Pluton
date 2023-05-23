using System;
using System.Collections.Generic;

namespace AntuchovGindulina.Models;

public partial class Room
{
    public int Id { get; set; }

    public string Cost { get; set; } = null!;

    public int RoomTypesId { get; set; }

    public virtual ICollection<Record> Records { get; set; } = new List<Record>();

    public virtual RoomType RoomTypes { get; set; } = null!;
}
