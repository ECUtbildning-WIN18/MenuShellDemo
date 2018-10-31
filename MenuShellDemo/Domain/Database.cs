using System;
using System.Collections.Generic;
using System.Linq;

namespace MenuShellDemo.Domain
{
    class Database
    {
        public static Dictionary<string, User> Users { get; set; } = new Dictionary<string, User>();

        public static Dictionary<string, User> GetUsersStartingWithString(string searchString)
        {
            var resultList = Users.Where(x => x.Key.StartsWith(searchString)).ToDictionary(x => x.Key, x => x.Value);

            return resultList;
        }

        public static int PrintUserList(Dictionary<string, User> userList)
        {
            var x = 0;
            foreach (var user in userList)
            {
                x++;
                Console.WriteLine($"{x}. {user.Value.Username,-15}");
            }
            return x;
        }

        public static void DeleteUserFromList(Dictionary<string, User> userList, string username)
        {
            userList.Remove(username);
        }
    }
}
