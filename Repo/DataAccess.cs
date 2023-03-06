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
    internal class DataAccess
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
    }
}
