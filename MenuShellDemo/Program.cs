using System;
using System.Data.SqlClient;
using MenuShellDemo.Domain;
using MenuShellDemo.Domain.View;

namespace MenuShellDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.Users.Add("admin", new User("admin", "secret", "Administrator"));

            var loginView = new LoginView();

            loginView.Display();
        }
    }
}
