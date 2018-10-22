using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MenuShellDemo.Domain;
using MenuShellDemo.Domain.View;

namespace MenuShellDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var notLoggedIn = true;

            const string administrator = "Administrator";
            const string receptionist = "Receptionist";
            const string veterinarian = "Veterinarian";

            
            Database.Users.Add("admin", new User("admin", "secret", administrator));
            Database.Users.Add("johndoe", new User("johndoe", "secret", receptionist));
            Database.Users.Add("janedoe", new User("janedoe", "secret", veterinarian));
            Database.Users.Add("jimdoe", new User("jimdoe", "secret", administrator));

            User user = null;

            do
            {
                Console.Clear();

                Console.Write("Username: ");
                var username = Console.ReadLine();

                Console.Write("Password: ");
                var password = Console.ReadLine();

                Console.WriteLine("Is this correct? (Y)es (N)o");
                var answer = Console.ReadKey(true).Key;

                if (answer == ConsoleKey.Y)
                {
                    if (Database.Users.ContainsKey(username) && Database.Users[username].Password == password)
                    {
                        user = Database.Users[username];
                        notLoggedIn = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid username and/or password. Please try again.");
                        Thread.Sleep(2000);
                    }
                }
                else if (answer != ConsoleKey.N)
                {
                    Console.WriteLine("Invalid selection.");
                    Thread.Sleep(2000);
                }
            } while (notLoggedIn);

            
            Console.Clear();

            switch (user.Role)
            {
                case administrator:
                    AdministratorView.Display();
                    break;
                case receptionist:
                    ReceptionistView.Display();
                    break;
                case veterinarian:
                    VeterinarianView.Display();
                    break;
            }

            var menuSelection = Console.ReadKey(true).Key;

            if (menuSelection == ConsoleKey.D1)
            {

            }
        }
    }
}
