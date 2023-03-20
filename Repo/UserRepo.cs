using Banken2023_V2.Models;
using Banken2023_V2.UI;

namespace Banken2023_V2.Repo
{
    public class UserRepo
    {
        //private BankDbContext _connection;

        //public UserRepo(BankDbContext connection)
        //{
        //    _connection = connection;
        //}

        DataAccess access = new DataAccess();

        public void ValidateLogin(User attemptLogin)
        {
            //bool valid = false;
            Menu menu = new Menu();
            var login = access.Login(attemptLogin);

            while (login == null)
            {
                Console.WriteLine("Kindly enter correct login info");
            }

            menu.AppMenu(attemptLogin);
            
        }
    }
}
