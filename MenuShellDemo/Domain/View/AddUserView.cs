using System;

namespace MenuShellDemo.Domain.View
{
    class AddUserView
    {
        public static void Display()
        {
            bool addedNewUser = false;

            do
            {
                Console.Clear();

                Console.WriteLine("# Add user\n");

                Console.Write("Username: ");
                string username = Console.ReadLine();

                Console.Write("Password: ");
                string password = Console.ReadLine();

                Console.Write("Role: ");
                string role = Console.ReadLine();

                Console.WriteLine("\nIs this correct? (Y)es (N)o");

                var user = new User(username, password, role);

                var keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.Y)
                {
                    Database.Users.Add(user.Username, user);

                    var dataBase = new Database();
                    dataBase.AddUserToDB(user);

                    addedNewUser = true;
                    AdministratorView.Display();
                }
                else if (keyInfo.Key == ConsoleKey.N)
                {

                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            } while (addedNewUser);
        }
    }
}
