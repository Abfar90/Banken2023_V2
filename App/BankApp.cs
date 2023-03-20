using Banken2023_V2.Repo;
using Banken2023_V2.UI;

namespace Banken2023_V2.App
{
    public class BankApp
    {
        //Härifrån startas applikationen.
        static void Main(string[] args)
        {
            UserRepo userRepo = new UserRepo();
            DataAccess access = new DataAccess();
            Menu menu = new Menu();


            userRepo.ValidateLogin(access.Login(menu.HomeScreen()));

        }
    }
}