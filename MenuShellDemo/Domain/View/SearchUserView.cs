using System;
using System.Linq;
using System.Threading;

namespace MenuShellDemo.Domain.View
{
    class SearchUserView
    {
        public static void Display()
        {
            bool isRunning = true;

            do
            {
                Console.Clear();

                Console.WriteLine("# Search by username:\n");

                var userNameSearch = Console.ReadLine();
                var searchResult = Database.GetUsersStartingWithString(userNameSearch);
                var userList = Database.Users;

                if (searchResult.Any())
                {
                    Console.Clear();
                    Console.WriteLine("  Search result\n");
                    Database.PrintUserList(searchResult);
                    Console.WriteLine("\n(D)elete  (C)ancel");
                    var input = Console.ReadKey(true);
                    switch (input.Key)
                    {
                        case ConsoleKey.D:
                            var deleteUserView = new DeleteUserView(userList, searchResult);
                            deleteUserView.Display();
                            break;
                        case ConsoleKey.C:
                            var manageUserView = new ManageUserView();
                            manageUserView.Display();
                            break;
                        default:
                            Console.WriteLine("Invalid option. Try Again.");
                            Thread.Sleep(1500);
                            Display();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"No users found matching the search term: {userNameSearch}. Try again?");
                    Console.WriteLine("(Y)es (N)o");

                    var input = Console.ReadKey(true);

                    switch (input.Key)
                    {
                        case ConsoleKey.Y:
                            Display();
                            break;
                        case ConsoleKey.N:
                            var manageUserView = new ManageUserView();
                            manageUserView.Display();
                            break;
                        default:
                            Console.WriteLine("Invalid option. Try again.");
                            Thread.Sleep(1500);
                            Display();
                            break;
                    }
                }
            } while (isRunning);
        }
    }
}
