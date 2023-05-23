using System;
using System.Collections.Generic;

namespace AntuchovGindulina.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Fullmame { get; set; } = null!;

    public string Post { get; set; } = null!;

    public string Data { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Check> Checks { get; set; } = new List<Check>();
}
