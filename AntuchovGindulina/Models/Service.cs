using System;
using System.Collections.Generic;

namespace AntuchovGindulina.Models;

public partial class Service
{
    public int Id { get; set; }

    public string Cost { get; set; } = null!;

    public virtual ICollection<ServicesCheck> ServicesChecks { get; set; } = new List<ServicesCheck>();
}
