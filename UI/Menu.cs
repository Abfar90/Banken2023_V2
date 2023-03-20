using Banken2023_V2.Models;
using Banken2023_V2.Repo;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banken2023_V2.UI
{
    public class Menu
    {
        //Välkomstmenu, tar in användarnamn och lösenord
        public User HomeScreen()
        {
            Console.WriteLine("Welcome to Trustly Bank!");
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            User attemptedLogin = new User(username, password);
            return attemptedLogin;
        }

        //Blir inloggningen godkänd så kommer man vidare till menyn nedan, härifrån styrs hela applikationen. Styrs med upp och ned pil. Klamrar visar vilket
        //Alternativ man är på.
        public void AppMenu(User user)
        {
            AccountRepo repo = new AccountRepo();
            Console.Clear();

            List<string> main_Menu = new List<string>()
            {
                    "Your accounts and balance",
                    "Transfer",
                    "Deposit",
                    "Withdraw",
                    "Exit"
            };

            bool[] choices = { true, false, false, false, false };

            int x = 0;

            bool showMenu = true;

            while (showMenu)
            {
                Console.Clear();
                if (choices[0] == true)
                {
                    Console.WriteLine("[ " + main_Menu[0] + " ]");
                }
                else if (choices[0] == false)
                {
                    Console.WriteLine(" " + " " + main_Menu[0]);
                }
                if (choices[1] == true)
                {
                    Console.WriteLine("[ " + main_Menu[1] + " ]");
                }
                else if (choices[1] == false)
                {
                    Console.WriteLine(" " + " " + main_Menu[1]);
                }
                if (choices[2] == true)
                {
                    Console.WriteLine("[ " + main_Menu[2] + " ]");
                }
                else if (choices[2] == false)
                {
                    Console.WriteLine(" " + " " + main_Menu[2]);
                }
                if (choices[3] == true)
                {
                    Console.WriteLine("[ " + main_Menu[3] + " ]");
                }
                else if (choices[3] == false)
                {
                    Console.WriteLine(" " + " " + main_Menu[3]);
                }
                if (choices[4] == true)
                {
                    Console.WriteLine("[ " + main_Menu[4] + " ]");
                }
                else if (choices[4] == false)
                {
                    Console.WriteLine(" " + " " + main_Menu[4]);
                }

                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (x == 5)
                    {
                        choices[0] = true;
                        choices[x] = false;
                        x = 0;
                    }
                    else
                    {
                        choices[x + 1] = true;
                        choices[x] = false;
                        x++;
                    }

                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    if (x == 0)
                    {
                        choices[5] = true;
                        choices[x] = false;
                        x = 5;
                    }
                    else
                    {
                        choices[x - 1] = true;
                        choices[x] = false;
                        x--;
                    }
                }

                else if (key.Key == ConsoleKey.Enter)
                {
                    var bankAccountsbalance = repo.checkBalance(user.UserId);
                    var showTable = new Table();
                    showTable.Border = TableBorder.HeavyHead;
                    showTable.AddColumn("[navajowhite3]Checking[/]");
                    showTable.AddColumn(new TableColumn("[navajowhite3]Saving[/]").Centered());
                    switch (x)
                    {
                        //Visa kontosaldo
                        case 0:
                            Console.WriteLine();
                            foreach (var account in bankAccountsbalance)
                            {
                                    showTable.AddRow($"{account.Key.BalanceChecking}", $"{account.Value.BalanceSavings}");
                            }
                            AnsiConsole.Write(showTable);
                            Console.ReadKey();
                            break;
                        
                        //Överföring till antingen sparkonto eller debit.
                        case 1:
                            Console.WriteLine("From which account would you like to transfer? enter C for Checking, and (S) for Saving");
                            string choice = (Console.ReadLine()).ToLower();

                            Console.WriteLine("See current balances below");

                            var bankAccounts = repo.checkBalance(user.UserId);

                            foreach (var account in bankAccounts)
                            {
                                showTable.AddRow($"{account.Key.BalanceChecking}", $"{account.Value.BalanceSavings}");
                            }
                            AnsiConsole.Write(showTable);
                            Console.ReadKey();

                            Console.WriteLine("Enter amount in SEK that you would like to transfer:");
                            decimal amount = decimal.Parse(Console.ReadLine());
                            
                            repo.transfer(choice, user.UserId, amount);
                            

                            Console.WriteLine("Transfer succesful! See new balances below:");

                            var showNewBalanceTable = new Table();
                            showNewBalanceTable.Border = TableBorder.HeavyHead;
                            showNewBalanceTable.AddColumn("[navajowhite3]Checking[/]");
                            showNewBalanceTable.AddColumn(new TableColumn("[navajowhite3]Saving[/]").Centered());

                            foreach (var account in bankAccounts)
                            {
                                showNewBalanceTable.AddRow($"[maroon]{account.Key.BalanceChecking}[/]", $"[green]{account.Value.BalanceSavings}[/]");
                            }
                            AnsiConsole.Write(showNewBalanceTable);
                            Console.ReadKey();

                            break;

                        //Insättning. Endast möjligt till checking kontot.
                        case 2:
                            Console.WriteLine("How much SEK would you like to deposit");
                            int deposit = int.Parse(Console.ReadLine());
                            CheckingAccount check = new CheckingAccount(user.UserId, deposit);
                            repo.deposit(check);
                            var deposits = repo.checkBalance(user.UserId);

                            Console.Clear();
                            
                            Console.WriteLine("Deposit succesful! See new balances below:");

                            var showDeposit = new Table();
                            showDeposit.Border = TableBorder.HeavyHead;
                            showDeposit.AddColumn("[navajowhite3]Checking[/]");
                            showDeposit.AddColumn(new TableColumn("[navajowhite3]Saving[/]").Centered());

                            foreach (var account in deposits)
                            {
                                showDeposit.AddRow($"[green]{account.Key.BalanceChecking}[/]", $"{account.Value.BalanceSavings}");
                            }
                            AnsiConsole.Write(showDeposit);
                            Console.ReadKey();

                            break;

                        //ta ut pengar, endast möjlig från checking.
                        case 3:
                            Console.WriteLine("How much would you like to withdraw?");
                            int withdrawAmount = int.Parse(Console.ReadLine());

                            CheckingAccount with = new CheckingAccount(user.UserId, withdrawAmount);

                            repo.withdraw(with);

                            var withdraw = repo.checkBalance(user.UserId);

                            Console.Clear();

                            Console.WriteLine("Withdraw succesful! See new balances below:");

                            var showWithdraw = new Table();
                            showWithdraw.Border = TableBorder.HeavyHead;
                            showWithdraw.AddColumn("[navajowhite3]Checking[/]");
                            showWithdraw.AddColumn(new TableColumn("[navajowhite3]Saving[/]").Centered());

                            foreach (var account in withdraw)
                            {
                                showWithdraw.AddRow($"[green]{account.Key.BalanceChecking}[/]", $"{account.Value.BalanceSavings}");
                            }
                            AnsiConsole.Write(showWithdraw);
                            Console.ReadKey();

                            break;

                        //Stänga av appen.
                        case 4:
                            Environment.Exit(0);
                            break;

                    }

                }
            }
        }
    }
}
