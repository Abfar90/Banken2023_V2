using Banken2023_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banken2023_V2.Repo;

namespace Banken2023_V2.Repo
{
    internal class AccountRepo
    {
        DataAccess access = new DataAccess();
        public void transfer (string type, int id, int amount)
        {
            if (type == "Savings")
            {
                access.TransfertoCheckings(id, amount);
            }

            else if (type == "Checking")
            {
                access.TransfertoSavings(id, amount);
            }

        }

        //deposit och withdraw nedan kan bli samma funktion
        public void withdraw (int id, int amount)
        {
            access.withdraw(id, amount);
        }

        public void deposit (int id, int amount)
        {
            access.deposit(id, amount);
        }

    }
}
