using System;
using System.Collections.Generic;

namespace Banken2023_V2.Models;

public partial class SavingAccount
{
    public int UserId { get; set; }

    public decimal BalanceSavings { get; set; }

    public virtual User User { get; set; } = null!;
}
