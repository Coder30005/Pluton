using System;
using System.Collections.Generic;

namespace AntuchovGindulina.Models;

public partial class CashDesk
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Check> Checks { get; set; } = new List<Check>();
}
