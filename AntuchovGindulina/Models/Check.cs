using System;
using System.Collections.Generic;

namespace AntuchovGindulina.Models;

public partial class Check
{
    public int Id { get; set; }

    public string TotalCost { get; set; } = null!;

    public string DateAndTime { get; set; } = null!;

    public int CashDeskId { get; set; }

    public int RecordId { get; set; }

    public int EmployeesId { get; set; }

    public virtual CashDesk CashDesk { get; set; } = null!;

    public virtual Employee Employees { get; set; } = null!;

    public virtual Record Record { get; set; } = null!;

    public virtual ICollection<ServicesCheck> ServicesChecks { get; set; } = new List<ServicesCheck>();
}
