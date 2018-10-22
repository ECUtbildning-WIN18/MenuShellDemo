using System;

namespace MenuShellDemo.Domain.View
{
    class AdministratorView
    {
        public static void Display()
        {
            bool isOff = false;

            do
            {
                Console.Clear();
                Console.WriteLine("(1) Manage users");
                Console.WriteLine("(2) Exit");

                var keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.D1)
                {

                }
                else if (keyInfo.Key == ConsoleKey.D2)
                {
                    isOff = true;
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }


            } while (isOff);
        }
    }
}
