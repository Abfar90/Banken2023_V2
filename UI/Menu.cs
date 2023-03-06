using Banken2023_V2.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banken2023_V2.UI
{
    internal class Menu
    {
        public static Customer HomeScreen()
        {
            Console.WriteLine("Welcome to Trustly Bank!");
            Console.Write("Enter social security number:");
            string social = Console.ReadLine();
            Console.Write("Enter password");
            string password = Console.ReadLine();

            Customer attemptedLogin = new Customer(social, password);
            return attemptedLogin;
        }

        public string AppMenu()
        {
            Console.WriteLine("1) View your accounts and balance");
            Console.WriteLine("2) Transfer between accounts");
            Console.WriteLine("3) Deposit ");
            Console.WriteLine("4) Logout");
            Console.Write("\r\nSelect an option: ");
            string choice = Console.ReadLine();

            return choice;
        }
    }
}
