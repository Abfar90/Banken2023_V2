using Banken2023_V2.Models;

namespace Banken2023_V2.Repo
{
    public class AccountRepo
    {
        DataAccess access = new DataAccess();

        public Dictionary<CheckingAccount, SavingAccount> checkBalance(int id)
        {
            CheckingAccount checking = access.GetChecking(id);
            SavingAccount saving = access.GetSaving(id);

            var listaccounts = new Dictionary<CheckingAccount, SavingAccount>()
            {
                { checking, saving },
            };

            return listaccounts;
        }

        public void transfer (string type, int id, decimal amount)
        {
            CheckingAccount newChecking = new CheckingAccount(id, amount);
            SavingAccount newSaving = new SavingAccount(id, amount);
            if (type.ToLower() == "s")
            {
                access.TransfertoCheckings(newSaving, newChecking);
            }

            else if (type.ToLower() == "c")
            {
                access.TransfertoSavings(newChecking, newSaving);
            }

        }

        public void withdraw (CheckingAccount account)
        {
            access.withdraw(account);
        }

        public void deposit (CheckingAccount account)
        {
            access.deposit(account);
        }

    }
}
