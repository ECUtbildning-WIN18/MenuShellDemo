using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MenuShellDemo.Domain.View
{
    class LoginView
    {
        public void Display()
        {
            var notLoggedIn = true;

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

            switch (user.Role)
            {
                case "Administrator":
                    AdministratorView.Display();
                    break;
                case "Receptionist":
                    ReceptionistView.Display();
                    break;
                case "Veterinarian":
                    VeterinarianView.Display();
                    break;
            }
        }
    }
}
