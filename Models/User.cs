using System;
using System.Collections.Generic;

namespace Banken2023_V2.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public User(int userId, string username, string password)
    {
        UserId = userId;
        Username = username;
        Password = password;
    }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }
}
