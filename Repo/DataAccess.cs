using Banken2023_V2.Models;
using System.Data;

namespace Banken2023_V2.Repo
{
    public class DataAccess
    {
        private BankDbContext _connection;

        public DataAccess()
        {
            _connection = new BankDbContext();
        }

        public User Login(User user)
        {
            return _connection.Users.SingleOrDefault(x => x.Username == user.Username && x.Password == user.Password);
        }

        public CheckingAccount GetChecking(int id)
        {
            return _connection.CheckingAccounts.SingleOrDefault(c => c.UserId == id);
        }

        public SavingAccount GetSaving (int id)
        {
            return _connection.SavingAccounts.SingleOrDefault(s => s.UserId == id);
        }

        public void TransfertoSavings (CheckingAccount fromAccount, SavingAccount updatedRecipient)
        {

            var oldChecking = _connection.CheckingAccounts.SingleOrDefault(c => c.UserId == fromAccount.UserId);

            fromAccount.BalanceChecking = oldChecking.BalanceChecking - fromAccount.BalanceChecking;

            _connection.Entry(oldChecking).CurrentValues.SetValues(fromAccount);

            SavingAccount oldRecipient = _connection.SavingAccounts.SingleOrDefault(s => s.UserId == updatedRecipient.UserId);

            updatedRecipient.BalanceSavings += oldRecipient.BalanceSavings;

            _connection.Entry(oldRecipient).CurrentValues.SetValues(updatedRecipient);

            _connection.SaveChanges();

        }

        public void TransfertoCheckings(SavingAccount fromAccount, CheckingAccount updatedRecipient)
        {
            SavingAccount oldBalance = _connection.SavingAccounts.SingleOrDefault(c => c.UserId == fromAccount.UserId);

            fromAccount.BalanceSavings = oldBalance.BalanceSavings - fromAccount.BalanceSavings;

            _connection.Entry(oldBalance).CurrentValues.SetValues(fromAccount);

            CheckingAccount toAccount = _connection.CheckingAccounts.SingleOrDefault(c => c.UserId == updatedRecipient.UserId);

            updatedRecipient.BalanceChecking += toAccount.BalanceChecking;

            _connection.Entry(toAccount).CurrentValues.SetValues(updatedRecipient);

            _connection.SaveChanges();
        }

        public void withdraw(CheckingAccount withdraw)
        {
            CheckingAccount account = _connection.CheckingAccounts.SingleOrDefault(c => c.UserId == withdraw.UserId);

            withdraw.BalanceChecking -= account.BalanceChecking;

            _connection.Entry(account).CurrentValues.SetValues(withdraw);

            _connection.SaveChanges();
        }

        public void deposit(CheckingAccount deposit)
        {
            CheckingAccount account = _connection.CheckingAccounts.SingleOrDefault(c => c.UserId == deposit.UserId);

            deposit.BalanceChecking += account.BalanceChecking;

            _connection.Entry(account).CurrentValues.SetValues(deposit);

            _connection.SaveChanges();
        }
    }
}
