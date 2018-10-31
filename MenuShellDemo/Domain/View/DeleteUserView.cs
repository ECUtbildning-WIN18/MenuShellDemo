using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MenuShellDemo.Domain.View
{
    class DeleteUserView
    {
        public Dictionary<string, User> UserList { get; }
        public Dictionary<string, User> SearchResult { get; }

        public DeleteUserView(Dictionary<string, User> users, Dictionary<string, User> searchResult)
        {
            UserList = users;
            SearchResult = searchResult;
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("  Search result\n");
            Database.PrintUserList(UserList);
            Console.Write("\nDelete> ");
            var username = Console.ReadLine();
            Console.WriteLine($"\nDelete user {username}?  (Y)es (N)o (C)ancel");
            var input = Console.ReadKey(true);

            switch (input.Key)
            {
                case ConsoleKey.Y:
                    if (SearchResult.Keys.Any(key => key.Equals(username)))
                    {
                        Database.DeleteUserFromList(UserList, username);
                        Console.WriteLine($"User { username} successfully deleted.");
                        Thread.Sleep(1500);
                        AdministratorView.Display();
                    }
                    else
                    {
                        Console.WriteLine($"The username: {username} didn't match any in the list. Try again.");
                        Console.ReadKey();
                        Display();
                    }
                    break;
                case ConsoleKey.N:
                    Display();
                    break;
                case ConsoleKey.C:
                    var manageUsersView = new ManageUserView();
                    manageUsersView.Display();
                    break;
            }
        }
    }
}
