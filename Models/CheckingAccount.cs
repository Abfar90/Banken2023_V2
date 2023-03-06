using System;
using System.Collections.Generic;

namespace Banken2023_V2.Models;

public partial class CheckingAccount
{
    public int UserId { get; set; }

    public decimal BalanceChecking { get; set; }

    public virtual User User { get; set; } = null!;
}
