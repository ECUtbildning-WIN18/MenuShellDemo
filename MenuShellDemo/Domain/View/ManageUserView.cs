using System;

namespace MenuShellDemo.Domain.View
{
    class ManageUserView
    {
        public void Display()
        {
            bool isRunning = true;
            
            do
            {
                Console.Clear();
                Console.WriteLine("(1) Add user");
                Console.WriteLine("(2) Search user");
                Console.WriteLine("(3) Exit");

                var keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.D1)
                {
                    AddUserView.Display();
                }
                else if (keyInfo.Key == ConsoleKey.D2)
                {
                    SearchUserView.Display();
                }
                else if (keyInfo.Key == ConsoleKey.D3)
                {
                    isRunning = false;
                    AdministratorView.Display();
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

            } while (isRunning);
        }
    }
}
