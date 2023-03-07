using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Banken2023_V2.Models;

namespace Banken2023_V2.Repo
{
    public class DataAccess
    {
        private BankDbContext _connection;

        public User Login(string username, string password)
        {
            User userAttempt = _connection.Users.Where(x => x.Username == username && x.Password == password).SingleOrDefault();
            return userAttempt;
        }

        public List<CheckingAccount> GetChecking (int id) 
        {
            return _connection.CheckingAccounts.Where(x => x.UserId == id).ToList();
        }

        public List<SavingAccount> GetSaving (int id)
        {
            return _connection.SavingAccounts.Where(x => x.UserId == id).ToList();
        }

        public decimal [] TransfertoSavings (int id, decimal amount)
        {
            CheckingAccount fromAccount = _connection.CheckingAccounts.SingleOrDefault(c => c.UserId == id);

            decimal newCheckingBalance = fromAccount.BalanceChecking - amount;

            _connection.Entry(fromAccount.BalanceChecking).CurrentValues.SetValues(newCheckingBalance);

            SavingAccount toAccount = _connection.SavingAccounts.SingleOrDefault(c => c.UserId == id);

            decimal newSavingsBalance = toAccount.BalanceSavings - amount;

            _connection.Entry(toAccount.BalanceSavings).CurrentValues.SetValues(newSavingsBalance);

            decimal[] newbalances = { newCheckingBalance, newSavingsBalance };

            return newbalances;

        }

        public decimal [] TransfertoCheckings(int id, decimal amount)
        {
            SavingAccount fromAccount = _connection.SavingAccounts.SingleOrDefault(c => c.UserId == id);

            decimal newCheckingBalance = fromAccount.BalanceSavings - amount;

            _connection.Entry(fromAccount.BalanceSavings).CurrentValues.SetValues(newCheckingBalance);

            CheckingAccount toAccount = _connection.CheckingAccounts.SingleOrDefault(c => c.UserId == id);

            decimal newSavingsBalance = fromAccount.BalanceSavings - amount;

            _connection.Entry(fromAccount.BalanceSavings).CurrentValues.SetValues(newSavingsBalance);

            decimal[] newbalances = { newCheckingBalance, newSavingsBalance };

            return newbalances;

        }

        public decimal withdraw(int id, decimal amount)
        {
            CheckingAccount account = _connection.CheckingAccounts.SingleOrDefault(c => c.UserId == id);

            //lägg till logik som stoppar overdraft

            decimal newCheckingBalance = account.BalanceChecking - amount;

            _connection.Entry(account.BalanceChecking).CurrentValues.SetValues(newCheckingBalance);

            return newCheckingBalance;
        }

        public decimal deposit(int id, decimal amount)
        {
            CheckingAccount account = _connection.CheckingAccounts.SingleOrDefault(c => c.UserId == id);

            decimal newCheckingBalance = account.BalanceChecking - amount;

            _connection.Entry(account.BalanceChecking).CurrentValues.SetValues(newCheckingBalance);

            return newCheckingBalance;
        }
    }
}
