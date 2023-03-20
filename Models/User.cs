namespace Banken2023_V2.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual CheckingAccount? CheckingAccount { get; set; }

    public virtual SavingAccount? SavingAccount { get; set; }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public User()
    {
    }
}
