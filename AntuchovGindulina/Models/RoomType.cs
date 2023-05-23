using System;
using System.Collections.Generic;

namespace AntuchovGindulina.Models;

public partial class RoomType
{
    public int Id { get; set; }

    public string RoomType1 { get; set; } = null!;

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
