using System;
using System.Collections.Generic;

namespace Banken2023_V2.Models;

public partial class Transaction
{
    public int UserId { get; set; }

    public DateTime TransactionDate { get; set; }

    public string? Info { get; set; }

    public string? FromAccount { get; set; }

    public decimal Amount { get; set; }

    public decimal Balance { get; set; }
}
