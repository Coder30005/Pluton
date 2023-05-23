using System;
using System.Collections.Generic;

namespace AntuchovGindulina.Models;

public partial class Guest
{
    public int Id { get; set; }

    /// <summary>
    /// Рузана
    /// </summary>
    public string Fullname { get; set; } = null!;

    public string Passport { get; set; } = null!;

    public string PhoneNumer { get; set; } = null!;

    public virtual ICollection<Record> Records { get; set; } = new List<Record>();
}
