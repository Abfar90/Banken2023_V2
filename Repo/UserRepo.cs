using Banken2023_V2.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banken2023_V2.Models;

namespace Banken2023_V2.Repo
{
    public class UserRepo
    {
        private BankDbContext _connection;

        public UserRepo(BankDbContext connection)
        {
            _connection = connection;
        }

        public int ValidateLogin(User attemptLogin)
        {

        }
    }
}
