using System;
using System.Collections.Generic;

namespace AntuchovGindulina.Models;

public partial class ServicesCheck
{
    public int Id { get; set; }

    public string ServiceCost { get; set; } = null!;

    public int ServiceId { get; set; }

    public int ChecksId { get; set; }

    public virtual Check Checks { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
