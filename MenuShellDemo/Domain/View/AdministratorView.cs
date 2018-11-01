using System;

namespace MenuShellDemo.Domain.View
{
    class AdministratorView
    {
        public static void Display()
        {
            bool isRunning = true;

            do
            {
                Console.Clear();
                Console.WriteLine("(1) Manage users");
                Console.WriteLine("(2) Exit");

                var keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.D1)
                {
                    var manageUserView = new ManageUserView();
                    manageUserView.Display();
                }
                else if (keyInfo.Key == ConsoleKey.D2)
                {
                    isRunning = false;
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }


            } while (isRunning);
        }
    }
}
